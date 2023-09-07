/*using System;

abstract class Expr { 
  abstract public int Eval(Dictionary<String,int> env);
  abstract public String Fmt();
  abstract public String Fmt2(Dictionary<String,int> env);
}


class CstI : Expr { 
  protected int i;

  public CstI(int i) { 
    this.i = i; 
  }

  public override int Eval(Dictionary<String,int> env) {
    return i;
  } 

  public override String Fmt() {
    return ""+i;
  }

  public override String Fmt2(Dictionary<String,int> env) {
    return ""+i;
  }
}

class Var : Expr { 
  protected String name;

  public Var(String name) { 
    this.name = name; 
  }

  public override int Eval(Dictionary<String,int> env) {
    return env[name];
  } 

  public override String Fmt() {
    return name;
  } 

  public override String Fmt2(Dictionary<String,int> env) {
    return ""+env[name];
  } 

}

class abstract Prim : Expr { 
  protected String oper;
  protected Expr e1, e2;

  public Prim(String oper, Expr e1, Expr e2) { 
    this.oper = oper; this.e1 = e1; this.e2 = e2;
  }

  public override int Eval(Dictionary<String,int> env) {
    if (oper == ("+"))
      return e1.Eval(env) + e2.Eval(env);
    else if (oper == ("*"))
      return e1.Eval(env) * e2.Eval(env);
    else if (oper == ("-"))
      return e1.Eval(env) - e2.Eval(env);
    else
      throw new RuntimeException("unknown primitive");
  } 

  public override String Fmt() {
    return "(" + e1.Fmt() + oper + e2.Fmt() + ")";
  } 

  public override String Fmt2(Dictionary<String,int> env) {
    return "(" + e1.Fmt2(env) + oper + e2.Fmt2(env) + ")";
  } 

}


public class SimpleExpr {
  public static void main(String[] args) {
    Expr e1 = new CstI(17);
    Expr e2 = new Prim("+", new CstI(3), new Var("a"));
    Expr e3 = new Prim("+", new Prim("*", new Var("b"), new CstI(9)), 
		            new Var("a"));
    Dictionary<String,int> env0 = new Dictionary<String,int>();
    env0.Add("a", 3);
    env0.Add("c", 78);
    env0.Add("baf", 666);
    env0.Add("b", 111);

    Console.WriteLine("Env: " + env0.ToString());

    Console.WriteLine(e1.Fmt() + " = " + e1.Fmt2(env0) + " = " + e1.Eval(env0));
    Console.WriteLine(e2.Fmt() + " = " + e2.Fmt2(env0) + " = " + e2.Eval(env0));
    Console.WriteLine(e3.Fmt() + " = " + e3.Fmt2(env0) + " = " + e3.Eval(env0));
  }
}*/

abstract class Expr {
    abstract public int Eval(Dictionary<String,int> env);
    abstract public String Fmt();
}

class CstI : Expr {
    protected int i;

    public CstI(int i) { 
    this.i = i; 
    }
    
    public override int Eval(Dictionary<string, int> env)
    {
        throw new NotImplementedException();
    }

    public override string Fmt()
    {
        throw new NotImplementedException();
    }
}

class Var : Expr
{
    public override int Eval(Dictionary<string, int> env)
    {
        throw new NotImplementedException();
    }

    public override string Fmt()
    {
        throw new NotImplementedException();
    }
}









public abstract class Binop : Expr{

}

public class Add : Binop{

  
}

public class Sub : Binop{

  
}

public class Mul : Binop{

  
}