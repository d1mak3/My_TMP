using System;
using System.Collections.Generic;
using System.Text;

namespace TMP_1Lab
{
  class Stack
  {
    private int[] stack = new int[0]; // Стек

    public Stack()
    {

    }       

    public Stack(Stack _oldStack) // Копируем стек в наш стек
    {
      int size = _oldStack.StackSize;
      Stack temp = new Stack();
      for (int i = 0; i < size; ++i)
			{
        int newNum = _oldStack.Pop;
        temp.Push(newNum);
			}

      size = temp.StackSize;
      for (int i = 0; i < size; ++i)
			{
        int newNum = temp.Pop;
        this.Push(newNum);
        _oldStack.Push(newNum);
			}
    }

    public int StackSize // Размер стека
    {
      get
      {
        int size = 0;

        foreach (int o in stack)
        {          
          ++size;
        }      
        
        return size;
      }
    }

    public void Push(int _newElement) // Добавление элемента в конец стека
    {
      int[] temp = new int[StackSize];
      for (int i = 0; i < StackSize; ++i)
        temp[i] = stack[i];

      stack = new int[StackSize + 1];
      stack[0] = _newElement;

      for (int i = 1; i < StackSize; ++i)
        stack[i] = temp[i - 1];
    }    

    public int Pop  // Вывод и удаление последнего элемента
    {
      get
      {
        int popped = stack[0];
        int[] temp = stack;
        stack = new int[StackSize - 1];       

        int tempsize = 0;
        foreach (int o in temp)
          ++tempsize;

        for (int i = 0; i < StackSize; ++i)
          stack[i] = temp[i + 1];

        return popped;
      }
    }

    public int Back // Вывод последнего элемента
    {
      get
      {
        return stack[0];
      }
    }

    public void Clear() // Очищаем стек
    {
      stack = new int[0];
    }   
  }
}
