# Ref Arg

## Overview
This repository contains code demonstrating the difference between passing arguments by value and by reference in C#. The code includes examples of passing various types (e.g. int, struct, class) as arguments to methods, and modifying the values of the arguments within the methods.

The main file containing the code is `Program.cs`.

## Output
The code will output the values of various variables before and after they are passed as arguments to methods. This will illustrate the difference between passing by value and by reference, as well as the impact of modifying the values of the arguments within the methods.

## Notes
Keep in mind that passing arguments by reference can lead to more difficult to predict code behavior and more difficult debugging. Therefore, caution should be taken and the appropriateness of using reference arguments should be considered.

## Driver
When writing highly performant applications, it is often beneficial to use value types such as structs instead of reference types like class. This is because structs are stored on the stack rather than the heap, which means the garbage collector has less work to do as it does not need to track and clean up unused structs.

Another technique to improve the performance of your program is to pass value types as reference arguments in methods. This avoids the overhead of copying the bytes of the value into the local scope of the method, especially when working with large value types or frequently calling the method.

## To dive deeper
See the continuation on `ref loclas` and `ref returns` that repo: [Ref-Lokals-Ref-Returns](https://github.com/ArturWincenciak/Ref-Lokals-Ref-Returns)
