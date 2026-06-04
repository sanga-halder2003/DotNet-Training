Mahirl and Alphabets and Vowels
Problem Statement

Mahirl's uncle Sam has taught her about vowels and wants to test her understanding.

Given two words:

Remove all consonants from the first word that are also present in the second word.
Comparison should be case-insensitive (for example, 'A' and 'a' are considered the same).
Vowels (a, e, i, o, u) should not be removed.
After removing common consonants, if two or more consecutive characters in the first word are the same, keep only the first occurrence and remove the remaining consecutive duplicates.

Print the final processed string.

Input Format
First line: First word
Second line: Second word
Constraints
Maximum length of each string: 50
Strings contain only uppercase and lowercase English letters
Output Format
Print the final processed string after performing the required operations.
Sample Input 1
Amphiibian
Technologies
Sample Output 1
Ampibia
Explanation

Common consonants in both words are h and n.

After removing them:

Ampiibia

Removing consecutive duplicate i:

Ampibia
Sample Input 2
Aaaabcc
bcd
Sample Output 2
A
Explanation
b and c are common consonants and are removed.
Remaining string becomes:
Aaaa
Consecutive duplicate a characters are reduced to a single A.

Final output:

A
