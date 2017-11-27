/* *********************************************************
FileName: MyArray.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
         Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System;
using System.Collections.Generic;


public class MyArray : Instance{

    public Dictionary<int, object> content = new Dictionary<int, object>();
    private int mSize;
    
    public MyArray(String ID, int _s) {
        mSize = _s ;
        this.ID = ID;
        for (int i = 0; i < mSize; i++){
            content[i] = 0;
        }
    }

    public int getSize(){
        return mSize;
    }

    public object getValue(int position){
        object result = 0;
        if (position < mSize && position >= 0 && content.ContainsKey(position)){
            result = content[position];
        }
        else{
            // Debug.LogError("Indice fuera de rango.(g)");
            Console.WriteLine("Indice fuera de rango.(g)");
            // MyConsole.main.AppendText("Indice fuera de rango.(g)");	
        }
        return result;
    }
    
    public void setValue(int position, object value){
        if (position < mSize && position >= 0 ){
            content[position] = value; //TODO check tamaño del array            
        }
        else{
            // Debug.LogError("Indice fuera de rango.(s)");
            Console.WriteLine("Indice fuera de rango.(s)");
            // MyConsole.main.AppendText("Indice fuera de rango.(s)");	
        }
    }

    public bool exists(int key){
        return content.ContainsKey(key);
    }

    public override string ToString(){
        string result = "[ ";
        for (int i = 0; i < mSize; i++){
            result += content[i] +  (i==mSize-1 ?" ":", ");
        }
        result += "]";
        return result;
        
    }
}

