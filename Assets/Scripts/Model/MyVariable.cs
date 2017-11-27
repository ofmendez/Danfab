/* *********************************************************
FileName: MyVariable.cs
Authors: Fabian Mendez <ofmendez@gmail.com>, 
		 Daniel Rodriguez <dlsusp@gmail.com>
Create Date: 14.11.2017
Modify Date: 27.11.2017 
********************************************************* */
using System;
public class MyVariable : Instance{
    public int tipo;
    public object value;

    public MyVariable(string ID, int tipo, object value) {
        this.tipo = tipo;
        this.value = value;
        this.ID = ID;
    }
}
