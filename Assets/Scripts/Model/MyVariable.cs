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
