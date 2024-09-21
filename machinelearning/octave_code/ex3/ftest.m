function [X, fX, i] = ftest(f, X, options, P1, P2, P3, P4, P5)

argstr = ['feval(f, X'];                      % compose string used to call function
for i = 1:(nargin - 3)
  argstr = [argstr, ',P', int2str(i)];
end
argstr = [argstr, ')'];
argstr
[f1 df1] = eval(argstr)