wget http://tianchi-competition.oss-cn-hangzhou.aliyuncs.com/531795/mchar_train.zip
wget http://tianchi-competition.oss-cn-hangzhou.aliyuncs.com/531795/mchar_test_a.zip

unzip mchar_train.zip -d mchar_train
unzip mchar_val.zip -d mchar_val
unzip mchar_test_a.zip -d mchar_test_a
rm -r mchar_train/__MACOSX
rm -r mchar_val/__MACOSX
mv  mchar_train mchar_train1
mv  mchar_val mchar_val1
mv mchar_train1/mchar_train mchar_train
mv mchar_val1/mchar_val mchar_val
rm -r mchar_train1
rm -r mchar_val1

mkdir -p user_data/model_data
mkdir -p tcdata/街景识别

mkdir  input
mv  mchar_train input/mchar_train
mv  mchar_val input/mchar_val


#yolo
mkdir ./input/images
mkdir -p ./input/images/val/
mkdir -p ./input/images/train/
cp -r ./input/mchar_train/* ./input/images/train/
cp -r ./input/mchar_val/* ./input/images/val/
python yolo_labels.py --json_file input/mchar_train.json --output_dir ./input/labels/ --split train --image_root ./input/mchar_train/
python yolo_labels.py --json_file input/mchar_val.json --output_dir ./input/labels/ --split val --image_root ./input/mchar_val/

