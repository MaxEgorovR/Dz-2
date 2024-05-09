
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Xml.Linq;

bool flag = true, flag1 = false, flag2 = false;
string choise, choise1, cod, choise2, expression, sum, sum1, text;
int[] A1 = new int[5], A2 = new int[5];
int[,] B1 = new int[3, 4], B2 = new int[3,4];
int[,] arr = new int[5,5];
double[] result1;
double[,] result2;
Random random = new Random();
Matrix matrix = new Matrix();

while (flag)
{
    Console.WriteLine("1 - Continue\nElse - Exit");
    choise = Console.ReadLine();
    if(int.Parse(choise) == 1)
    {
        Console.WriteLine("1 - Task 1\n2 - Task 2\n3 - Task 3\n4 - Task 4\n5 - Task 5\n6 - Task 6\nElse - Task 7");
        choise1 = Console.ReadLine();
        if(int.Parse(choise1)== 1)
        {
            Console.WriteLine("Enter all numerators in A:");
            fillArr(A1);
            Console.WriteLine("Enter all denominators in A:");
            fillArr(A2);
            fillArrDoubleRandom34(B1);
            fillArrDoubleRandom34(B2);
            Console.WriteLine("Arr A:");
            printArr(A1,A2);
            Console.WriteLine("Arr B numerators:");
            printArrDouble34(B1);
            Console.WriteLine("Arr B denominators:");
            printArrDouble34(B2);
            result1 = getDoubleElemsArr(A1 ,A2);
            result2 = getDoubleElemsArrDouble(B1 ,B2);
            generalMinMax(result1, result2);
            sumMultiplyAllElems(result1, result2);
            sumOddEven(result1, result2);
        }
        else if (int.Parse(choise1) == 2)
        {
            fillArrDoubleRandom55(arr);
            printArrDouble55(arr);
            Console.WriteLine("Sum: "+sumElemsBetweenMinMax(arr));
        }
        else if (int.Parse(choise1) == 3)
        {
            Console.WriteLine("Enter the string:");
            cod = Console.ReadLine();
            cod = coder(cod);
            Console.WriteLine(cod);
            cod = decoder(cod);
            Console.WriteLine(cod);
        }
        else if (int.Parse(choise1) == 4)
        {
            matrix.fillMatrix();
            Console.WriteLine("1 - Multiply the matrix by 1 multiplier\n2 - Sum 2 matrixes\nElse - Multiply 2 matrixes");
            choise2 = Console.ReadLine();
            if(int.Parse(choise2) == 1)
            {
                matrix.multiplier = int.Parse(Console.ReadLine());
                matrix.printMatrix(matrix.multipleMatrix());
            }
            else if (int.Parse(choise2) == 2)
            {
                matrix.fillMatrixSum();
                matrix.printMatrix(matrix.sumMatrixWithMatrix());
            }
            else
            {
                matrix.fillMatrixMultiplier();
                matrix.printMatrix(matrix.multipleMatrixWithMatrix());
            }
        }
        else if (int.Parse(choise1) == 5)
        {
            sum = "";
            sum1 = "";
            Console.WriteLine("Enter the expression:");
            expression = Console.ReadLine();
            for (int i = 0; i < expression.Length; i++)
            {
                if(flag1 == false)
                {
                    if (expression[i] != '+'&& expression[i] != '-')
                    {
                        sum += expression[i];
                    }
                }
                else
                {
                    if (expression[i] != '+' && expression[i] != '-')
                    {
                        sum1 += expression[i];
                    }
                }
                if (expression[i] == '-')
                {
                    flag2 = true;
                }
            }
            if (flag2)
            {
                Console.WriteLine("Result: " + (int.Parse(sum) - int.Parse(sum1)).ToString());
            }
            else
            {
                Console.WriteLine("Result: " + (int.Parse(sum) + int.Parse(sum1)).ToString());
            }
        }
        else if (int.Parse(choise1) == 6)
        {
            Console.WriteLine("Enter the text:");
            text = Console.ReadLine();
            Console.WriteLine(Uppercase(text));
        }
        else
        {
            Console.WriteLine("Enter the text:");
            text = Console.ReadLine();
            Console.WriteLine(Check(text));
        }
    }
    else
    {
        flag = false;
    }
}

double[] getDoubleElemsArr(int[] arr1, int[] arr2)
{
    double[] tmp1 = new double[5];
    for (int i = 0; i < 5; i++)
    {
        tmp1[i] = Math.Round((double)(arr1[i] / arr2[i]), 2);
    }
    return tmp1;
}

double[,] getDoubleElemsArrDouble(int[,] arr3, int[,] arr4)
{
    double[,] tmp2 = new double[3, 4];
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            tmp2[i, j] = Math.Round((double)(arr3[i, j] / arr4[i, j]), 2);
        }
    }
    return tmp2;
}
void generalMinMax(double[] tmp1, double[,] tmp2)
{
    double[] tmp3 = new double[1];
    for (int k = 0; k < 3; k++)
    {
        for (int l = 0; l < 4; l++)
        {
            if (Array.IndexOf(tmp1, tmp2[k, l]) != -1 && Array.IndexOf(tmp3, tmp2[k, l]) == -1)
            {
                tmp3.Append(tmp2[k, l]);
            }
        }
    }
    if(tmp3.Length == 1)
    {
        Console.WriteLine("There are no general elements");
    }
    else
    {
        Console.WriteLine("Maximum general element: "+tmp3.Max());
        Console.WriteLine("Minimum general element: "+tmp3.Min());
    }
}

void sumMultiplyAllElems(double[] tmp1, double[,] tmp2)
{
    double sum1 = 0.00,sum2 = 0.00;
    double multiple1 = 1.00,multiple2 = 1.00;
    for(int i = 0;i < tmp1.Length;i++) {
        sum1 += tmp1[i];
        multiple1 *= tmp1[i];
    }
    for(int i=0;i<3;i++)
    {
        for(int j=0;j<4;j++)
        {
            sum2 += tmp2[i, j];
            multiple2 *= tmp2[i,j];
        }
    }
    Console.WriteLine("Sum all elems A: " + sum1 + " Multiply all elems A: " + multiple1);
    Console.WriteLine("Sum all elems B: " + sum2 + " Multiply all elems B: " + multiple2);
}

void sumOddEven(double[] tmp1, double[,] tmp2)
{
    double sum1 = 0.00, sum2 = 0.00;
    for(int i=1;i<tmp1.Length ;i+=2)
    {
        sum1 += tmp1[i];
    }
    for(int i = 0; i < 3; i++)
    {
        for(int j=0;j<4; j+=2)
        {
            sum2 += tmp2[i, j];
        }
    }
    Console.WriteLine("Sum even elems A: " + sum1);
    Console.WriteLine("Sum odd elems B: " + sum2);
}
void fillArr(int[] arr)
{
    for(int i = 0; i < arr.Length; i++)
    {
        arr[i] = int.Parse(Console.ReadLine());
    }
}
void printArr(int[] arr, int[] arr1)
{
    for(int i = 0;i < arr.Length; i++)
    {
        Console.Write(arr[i] + "/" + arr1[i]+" ");
    }
    Console.WriteLine();
}

void fillArrDoubleRandom34(int[,] arr)
{
    for (int i = 0; i<3; i++) { 
        for(int j = 0; j < 4; j++)
        {
            arr[i, j] = random.Next();
        }
    }
}

void fillArrDoubleRandom55(int[,] arr)
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            arr[i, j] = random.Next(-100, 100);
        }
    }
}

int sumElemsBetweenMinMax(int[,] arr)
{
    bool flag = false;
    int max = arr[0, 0], min=arr[0,0], sum=0;
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (arr[i, j] > max)
            {
                max = arr[i, j];
            }
            if (arr[i, j] < min)
            {
                min = arr[i, j];
            }
        }
    }
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (arr[i, j] == max)
            {
                flag = false;
            }
            if (flag)
            {
                sum += arr[i, j];
            }
            if (arr[i, j] == min) {
                flag = true;
            }
        }
    }
    return sum;
}
void printArrDouble34(int[,] arr)
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.Write(arr[i,j]+" ");
        }
        Console.WriteLine();
    }
}

void printArrDouble55(int[,] arr)
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            Console.Write(arr[i, j] + " ");
        }
        Console.WriteLine();
    }
}

string coder(string str)
{
    string tmp = "";
    for(int i = 0; i < str.LongCount(); i++)
    {
        tmp += (char)(str[i] - 3);
    }
    return tmp;
}

string decoder(string str)
{
    string tmp = "";
    for (int i = 0; i < str.LongCount(); i++)
    {
        tmp += (char)(str[i] + 3);
    }
    return tmp;
}

string Uppercase(string str)
{
    string temp1 = "";
    for(int i=0; i < str.LongCount();i++)
    {
        if (i > 2)
        {
            if (str[i - 2] == '.' && str[i - 1] == ' ')
            {
                temp1 += (char)(str[i] - 32);
            }
            else
            {
                temp1 += (char)str[i];
            }
        }
        else
        {
            temp1 += (char)str[i];
        }
    }
    return temp1;
}

string Check(string text)
{
    int counter=0;
    string tmp = "";
    for(int i = 0; i < text.Length; i++)
    {
        if (i < text.Length - 2)
        {
            if ((text[i] == 'd' || text[i] == 'D') && (text[i + 1] == 'i' || text[i + 1] == 'I') && (text[i + 2] == 'e' || text[i + 2] == 'E'))
            {
                tmp += "***";
                i += 2;
                counter++;
            }
            else
            {
                tmp += text[i];
            }
        }
        else
        {
            tmp += text[i];
        }
    }
    Console.WriteLine("Invalid words: "+counter);
    return tmp;
}
class Matrix
{
    public int multiplier { get; set; }
    public int length;
    public int width;
    public int[,] matrix;
    public int[,] matrixSum;
    public int[,] matrixMultiplier;
    public int[,] matrixResult;
    public int[,] matrixSumResult;
    public int[,] matrixMultiplierResult;

    public Matrix(){}
    public Matrix(int multiplier,int[,] matrix, int[,] matrixSum, int[,] matrixMultiplier)
    {
        this.multiplier = multiplier;
        this.matrix = matrix;
        this.matrixSum = matrixSum;
        this.matrixMultiplier = matrixMultiplier;
    }

    public int[,] multipleMatrix()
    {
        for (int i=0; i < this.length; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                matrixResult[i,j] = (int)((int)(matrix[i, j]) * (int)(multiplier));
            }
        }
        return matrixResult;
    }

    public int[,] sumMatrixWithMatrix()
    {
        for (int i = 0; i < this.length; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                this.matrixSumResult[i, j] = (int)((int)(this.matrix[i, j]) + (int)(this.matrixMultiplier[i, j]));
            }
        }
        return this.matrixSumResult;
    }

    public int[,] multipleMatrixWithMatrix()
    {
        for (int i = 0; i < this.length; i++)
        {
            for (int j = 0; j < this.width; j++)
            {
                this.matrixMultiplierResult[i, j] = (int)((int)(this.matrix[i, j]) * (int)(this.matrixMultiplier[i, j]));
            }
        }
        return this.matrixMultiplierResult;
    }

    public void fillMatrix()
    {
        Console.WriteLine("Enter the length:");
        this.length = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the width:");
        this.width = int.Parse(Console.ReadLine());
        this.matrix = new int[length, width];
        Console.WriteLine("Enter all elems:");
        for (int i = 0;i < length; i++)
        {
            for(int j = 0;j < width; j++)
            {
                this.matrix[i,j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void fillMatrixSum()
    {
        this.matrixSum = new int[length, width];
        Console.WriteLine("Enter all elems:");
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                this.matrixSum[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void fillMatrixMultiplier()
    {
        this.matrixMultiplier = new int[length, width];
        Console.WriteLine("Enter all elems:");
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                this.matrixMultiplier[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void printMatrix(int[,] arr) {
        Console.WriteLine("All elems:");
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(arr[i,j]+" ");
            }
            Console.WriteLine();
        }
    }
}

