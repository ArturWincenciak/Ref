Console.WriteLine("Alright ref!");

/*
 * Note
 *
 * Don't confuse the concept of passing by reference with the concept of reference types.
 * The two concepts are not the same.A method parameter can be modified by ref regardless
 * of whether it is a value type or a reference type. There is no boxing of a value type
 * when it is passed by reference.
 */

Console.WriteLine("Passing an argument by reference.");

var globalInt = 100;

ArgIntMethod(globalInt);
Console.WriteLine($"#1: {nameof(globalInt)} = {globalInt}"); // 100

ArgRefIntMethod(ref globalInt);
Console.WriteLine($"#2: {nameof(globalInt)} = {globalInt}"); // 200

void ArgIntMethod(int argInt)
{
    Console.WriteLine($"{nameof(ArgIntMethod)} #1: {nameof(argInt)} = {argInt}"); // 100
    argInt += 100;
    Console.WriteLine($"{nameof(ArgIntMethod)} #2: {nameof(argInt)} = {argInt}"); // 200
}

void ArgRefIntMethod(ref int refArgInt)
{
    Console.WriteLine($"{nameof(ArgRefIntMethod)} #1: {nameof(refArgInt)} = {refArgInt}"); // 100
    refArgInt += 100;
    Console.WriteLine($"{nameof(ArgRefIntMethod)} #2: {nameof(refArgInt)} = {refArgInt}"); // 200
}