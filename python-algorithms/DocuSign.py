#!/usr/bin/env python

"""
These are the interview questions, and my answers, given during a DocuSign interview.

The tests for these solutions can be run with:
python -m doctest -v DocuSign.py

"""


def _is_number(string):
    """Given a string, return True if number

    Example:
    >>> _is_number(None)
    False

    >>> _is_number(2)
    True

    >>> _is_number("")
    False

    >>> _is_number("-5")
    True

    >>> _is_number("(6*2)")
    False
    """
    try:
       float(string)
       return True
    except (ValueError, TypeError):
       return False


def _pending_addition(expression):
    """Private helper method to find in an addition or multiplication exists in the inmediate scope,
       that is, not inside a parenthesis. The index of the operation is also returned, -1 if not found.

       Example:
       >>> _pending_addition("5*(5-2)")
       (False, -1)

       >>> _pending_addition("5*4-7")
       (True, 3)
    """
    open_parenthesis_count = 0
    for i in range(0, len(expression)):
        if expression[i] == '(':
            open_parenthesis_count += 1

        if expression[i] == ')':
            open_parenthesis_count -= 1

        if i > 0 and expression[i] in ['+', '-'] and open_parenthesis_count == 0:
            return True, i

    return False, -1


def calculate(expression):
    """Given a mathematical expression in string form, calculate the result.
    For example: given "(5*2)+(7-3)", return 14

    :param expression:
    :return:

    Examples:
    >>> calculate("-2")
    -2

    >>> calculate("")
    0

    >>> calculate("()")
    0

    >>> calculate("((-1))")
    -1

    >>> calculate("(-5)")
    -5

    >>> calculate("-5+3")
    -2

    >>> calculate("6-(3+2)")
    1

    >>> calculate("(5-6)+7")
    6

    >>> calculate("5*3-2+(-3)")
    10

    >>> calculate("5*4/2")
    10

    """
    import operator

    if expression is None:
        raise ValueError("Empty expression given.")

    if type(expression) is not str:
        raise ValueError("No string was provided.")

    # Base cases
    if expression == "":
        return 0
    if _is_number(expression):
        return int(expression)

    # Break into parts
    addition_operands = ['+', '-']
    multiplication_operands = ['*', '/']
    operator = {"+": operator.add,
                "-": operator.sub,
                "*": operator.mul,
                "/": operator.div}

    first_open_parenthesis_index = -1
    open_parenthesis_count = 0
    for i in range (0, len(expression)):
        if not i and expression[i] in addition_operands:
            continue

        elif expression[i] == '(':
            open_parenthesis_count += 1

            if first_open_parenthesis_index == -1:
                first_open_parenthesis_index = i

        elif expression[i] == ')':
            open_parenthesis_count -=1

            if open_parenthesis_count:
                continue
            else:
                sub_expression = calculate(expression[first_open_parenthesis_index+1:i])
                return calculate(str(sub_expression) + expression[i+1:])

        elif open_parenthesis_count:
            continue

        elif expression[i] in addition_operands:
            operand = operator[expression[i]]
            pending_addition,index_next_addition = _pending_addition(expression[i+1:])
            if pending_addition:
                index_next_addition = i + index_next_addition + 1
                sub_expression = str(operand(calculate(expression[0:i]), calculate(expression[i+1:index_next_addition])))
                return calculate(sub_expression + expression[index_next_addition:])
            else:
                return operand(calculate(expression[0:i]), calculate(expression[i+1:]))

        elif _pending_addition(expression)[0]:
            continue

        elif expression[i] in multiplication_operands:
            operand = operator[expression[i]]

            return operand(calculate(expression[0:i]), calculate(expression[i+1:]))


def reverse(string):
    """ Reverse a given string

    :param string:
    :return:

    Examples:
    >>> reverse("angel")
    'legna'

    >>> reverse(1)
    Traceback (most recent call last):
    ...
    ValueError: No string was provided.

    >>> reverse(None)

    >>> reverse("")

    """
    if not string:
        return None

    if type(string) is not str:
        raise ValueError("No string was provided.")

    result = ""
    for i in range(len(string)-1, -1, -1):
        result += string[i]

    return result