using System;

namespace TMP_1Lab
{
  class Program
  {
    // Метод заключается в том, чтобы разделить стек на маленькие стеки по одному элементу и потом выполнять их слияние, параллельно сортируя
    static void Sort(ref Stack _stackToSort)
		{       
      // Создаём два стека
      Stack left = new Stack();
      Stack right = new Stack();

      // Заполняем эти два стека
      int size = _stackToSort.StackSize;
      for (int i = 0; i < size / 2; ++i)
			{
        left.Push(_stackToSort.Pop);        
			}    

      size = _stackToSort.StackSize;
      for (int i = 0; i < size; ++i)
			{
        right.Push(_stackToSort.Pop);
			}

      // Если количество элементов в стеке больше одного, разделяем стек дальше (для того, чтобы разбить на стеки по 1 элементу)
      if (left.StackSize > 1)
			{        
        Sort(ref left);
			}
      if (right.StackSize > 1)
			{        
        Sort(ref right);
      }

      // Создаём перевёрнутый изначальному стек
      Stack ltemp = new Stack();
      size = left.StackSize;
      for (int i = 0; i < size; ++i)
			{
        ltemp.Push(left.Pop);
			}      

      Stack rtemp = new Stack();
      size = right.StackSize;
      for (int i = 0; i < size; ++i)
			{
        rtemp.Push(right.Pop);
			}      

      // Сортируем перевёрнутые стеки
      while (ltemp.StackSize > 0 && rtemp.StackSize > 0)
			{
        if (ltemp.Back > rtemp.Back)
        {
          _stackToSort.Push(ltemp.Pop);          
        }
        else
				{          
          _stackToSort.Push(rtemp.Pop);          
        }
			}

      while (ltemp.StackSize > 0)
			{
        _stackToSort.Push(ltemp.Pop);
			}

      while (rtemp.StackSize > 0)
			{
        _stackToSort.Push(rtemp.Pop);
			}
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Write count of numbers:");
      int countOfNumbers = Convert.ToInt32(Console.ReadLine());
      Random rand = new Random();

      Stack stackToSort = new Stack();

      for (int i = 0; i < countOfNumbers; ++i)
			{
        stackToSort.Push(rand.Next(-50, 100));
			}
      //stackToSort.Push(6); stackToSort.Push(5); stackToSort.Push(3); stackToSort.Push(4);

      Console.WriteLine("Original stack:");

      Stack output = new Stack(stackToSort);
      int size = output.StackSize;      
      for (int i = 0; i < size; ++i)
			{
        Console.Write($"{output.Pop}\t");
			}

      Sort(ref stackToSort);

      Console.WriteLine("Sorted stack:");

      size = stackToSort.StackSize;
      for (int i = 0; i < size; ++i)
      {
        Console.Write($"{stackToSort.Pop}\t");
      }
    }      
  }
}
