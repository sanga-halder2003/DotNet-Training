There are two types of questions in a Question Paper --- 1 type of question for which &#39;X&#39; marks are
awarded for the correct answer and the other type of question for which &#39;Y&#39; marks are awarded for
the correct answer. There are &#39;n1&#39; questions of type 1 and &#39;n2&#39; questions of type 2.
 
A question will be awarded full marks if the answer is completely correct. Otherwise 0 marks will be
awarded for that question.
 
Given a mark scored by a student (&#39;M&#39;) , find whether it is a valid mark as per this scoring system.
 
Input Format:
Input consists of 5 integers that correspond to X, Y, N1, N2 and M respectively.
 
Output Format:
The first line of the output consists of a string that is either “Valid” or “Invalid”.
 
If the first line of the output is valid, in the next line print the marks scored by the student in Type I
questions and the marks scored by the student it Type II questions.
 
In cases of multiple possible answers, print the case where the student must have answered the
maximum number of Type 1 questions.
 
Sample Input 1:
5
8
5
4
44
 
Sample Output 1:
Valid
4
3
[Explanation :  4*5 + 3*8  = 44   // 4 &quot;5 Marks&quot; Questions and 3 &quot;8 Marks&quot; Questions are correct]
 
Sample Input 2:
5
8
5
4
46
 
Sample Output 2:
