# Ref Arg

## Overview

The main file containing the code is `Program.cs`.

This repository contains code demonstrating the difference between passing arguments by value and by reference in C#. The code includes examples of passing various types (e.g. int, struct, class) as arguments to methods, and modifying the values of the arguments within the methods.

## Output
The code will output the values of various variables before and after they are passed as arguments to methods. This will illustrate the difference between passing by value and by reference, as well as the impact of modifying the values of the arguments within the methods.

## Notes
Keep in mind that passing arguments by reference can lead to more difficult to predict code behavior and more difficult debugging. Therefore, caution should be taken and the appropriateness of using reference arguments should be considered.

## Driver
When writing highly performant applications, it is often beneficial to use value types such as structs instead of reference types like class. This is because structs are stored on the stack rather than the heap, which means the garbage collector has less work to do as it does not need to track and clean up unused structs.

Another technique to improve the performance of your program is to pass value types as reference arguments in methods. This avoids the overhead of copying the bytes of the value into the local scope of the method, especially when working with large value types or frequently calling the method.

## To dive deeper
See the continuation on `ref loclas` and `ref returns` that repo: [Ref-Lokals-Ref-Returns](https://github.com/ArturWincenciak/Ref-Locals-Ref-Returns)

## Output

```
Alright ref!

Passing an argument by reference.

#01: globalInt = 100

ArgIntMethod #1: argInt = 100
ArgIntMethod #2: argInt = 200
#02: globalInt = 100

ArgRefIntMethod #1: refArgInt = 100
ArgRefIntMethod #2: refArgInt = 200
#03: globalInt = 200

#04: globalStruct = [IntProp: 1000, StrProp: _str_in_struct_, ClassProp: [DoubleProp: 1000.1, StrProp: _str_in_class_, StructInClassProp: [FloatProp: 1000.2]], StructInStructProp: [FloatProp: 1000.3]]

ArgStructMethod: #1: argStruct = [IntProp: 1000, StrProp: _str_in_struct_, ClassProp: [DoubleProp: 1000.1, StrProp: _str_in_class_, StructInClassProp: [FloatProp: 1000.2]], StructInStructProp: [FloatProp: 1000.3]]
ArgStructMethod: #2: argStruct = [IntProp: 2000, StrProp: _str_in_struct_modified_, ClassProp: [DoubleProp: 2000.1, StrProp: _str_in_class_modified_, StructInClassProp: [FloatProp: 2000.2]], StructInStructProp: [FloatProp: 2000.3]]
#05: globalStruct = [IntProp: 1000, StrProp: _str_in_struct_, ClassProp: [DoubleProp: 2000.1, StrProp: _str_in_class_modified_, StructInClassProp: [FloatProp: 2000.2]], StructInStructProp: [FloatProp: 1000.3]]

ArgRefStructMethod: #1: refStruct = [IntProp: 1000, StrProp: _str_in_struct_, ClassProp: [DoubleProp: 2000.1, StrProp: _str_in_class_modified_, StructInClassProp: [FloatProp: 2000.2]], StructInStructProp: [FloatProp: 1000.3]]
ArgRefStructMethod: #2: refStruct = [IntProp: 2000, StrProp: _str_in_struct_modified_, ClassProp: [DoubleProp: 3000.1, StrProp: _str_in_class_modified_modified_, StructInClassProp: [FloatProp: 3000.2]], StructInStructProp: [FloatProp: 2000.3]]
#06: globalStruct = [IntProp: 2000, StrProp: _str_in_struct_modified_, ClassProp: [DoubleProp: 3000.1, StrProp: _str_in_class_modified_modified_, StructInClassProp: [FloatProp: 3000.2]], StructInStructProp: [FloatProp: 2000.3]]

#07: globalClass = [DoubleProp: 10.1, StrProp: _str_, StructInClassProp: [FloatProp: 10.2]]

EditPropsOfArgClassMethod: #1: argClass = [DoubleProp: 10.1, StrProp: _str_, StructInClassProp: [FloatProp: 10.2]]
EditPropsOfArgClassMethod: #2: argClass = [DoubleProp: 20.1, StrProp: modified_, StructInClassProp: [FloatProp: 20.2]]
#08: globalClass = [DoubleProp: 20.1, StrProp: modified_, StructInClassProp: [FloatProp: 20.2]]

EditPropsOfArgRefClassMethod: #1: refClass = [DoubleProp: 20.1, StrProp: modified_, StructInClassProp: [FloatProp: 20.2]]
EditPropsOfArgRefClassMethod: #2: refClass = [DoubleProp: 30.1, StrProp: modified_, StructInClassProp: [FloatProp: 30.2]]
#09: globalClass = [DoubleProp: 30.1, StrProp: modified_, StructInClassProp: [FloatProp: 30.2]]

CreateNewUsingArgClassMethod: #1: argClass = [DoubleProp: 30.1, StrProp: modified_, StructInClassProp: [FloatProp: 30.2]]
CreateNewUsingArgClassMethod: #2: argClass = [DoubleProp: 123456789, StrProp: _the_new_one_without_ref_, StructInClassProp: [FloatProp: 123456790]]
#10: globalClass = [DoubleProp: 30.1, StrProp: modified_, StructInClassProp: [FloatProp: 30.2]]

CreateNewUsingArgRefClassMethod: #1: refClass = [DoubleProp: 30.1, StrProp: modified_, StructInClassProp: [FloatProp: 30.2]]
CreateNewUsingArgRefClassMethod: #2: refClass = [DoubleProp: 987654321, StrProp: _the_new_one_by_ref_, StructInClassProp: [FloatProp: 987654340]]
#11: globalClass = [DoubleProp: 987654321, StrProp: _the_new_one_by_ref_, StructInClassProp: [FloatProp: 987654340]]
```
