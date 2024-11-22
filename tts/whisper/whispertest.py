import torch
from transformers import WhisperProcessor, WhisperForConditionalGeneration
from datasets import load_dataset, Audio
import librosa
from tqdm import tqdm
from opencc import OpenCC

def process_audio_segment(segment, processor, model, sampling_rate):
    input_features = processor(segment, sampling_rate=sampling_rate, return_tensors="pt").input_features
    with torch.no_grad():
        generated_ids = model.generate(input_features)
    transcription = processor.batch_decode(generated_ids, skip_special_tokens=True)
    return transcription[0]  # 提取列表中的第一个元素

def main():
    # 确保路径正确
    model_dir = "./models/whisper-base"

    # 从本地目录加载处理器和模型
    processor = WhisperProcessor.from_pretrained(model_dir)
    model = WhisperForConditionalGeneration.from_pretrained(model_dir)

    # 加载本地的音频文件
    dataset = load_dataset('audiofolder', data_files={'test': ['./1.mp3']}, split='test')
    
    # 处理音频数据
    dataset = dataset.cast_column('audio', Audio())
    audio_sample = dataset[0]

    # 重新采样音频文件到 16000 Hz
    resampled_audio = librosa.resample(audio_sample['audio']['array'], orig_sr=audio_sample['audio']['sampling_rate'], target_sr=16000)
    sampling_rate = 16000

    # 分割音频文件
    segment_length = 10 * sampling_rate  # 每段10秒
    segments = [resampled_audio[i:i+segment_length] for i in range(0, len(resampled_audio), segment_length)]

    # 处理每个音频片段
    transcriptions = []
    for segment in tqdm(segments, desc="处理音频片段"):
        transcription = process_audio_segment(segment, processor, model, sampling_rate)
        transcriptions.append(transcription)

    # 合并所有转录结果
    full_transcription = ' '.join(transcriptions)

    # 创建简繁转换器
    converter = OpenCC('tw2sp')  # 繁体中文转简体中文

    # 将转录结果转换为简体中文
    simplified_transcription = converter.convert(full_transcription)

    # 输出转录结果
    print(f"完整转录结果（简体中文）: {simplified_transcription}")

if __name__ == '__main__':
    main()