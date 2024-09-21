function [result] = example_function(varargin)
    num_args = nargin;
    if num_args ==0
        result = "no args "
    elseif num_args == 1
        result ="one arg "
    else
        result = "more args"
        for i = 1:num_args
            result = [result num2str(varargin{i}) " "]
        end
    end