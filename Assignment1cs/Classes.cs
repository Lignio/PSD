
abstract class Expr {
    abstract public int Eval(Dictionary<String,int> env);
    abstract public String Fmt();

    abstract public Expr Simplify();
}

class CstI : Expr {
    protected int i;

    public CstI(int i) { 
    this.i = i; 
    }
    
    public override int Eval(Dictionary<string, int> env)
    {
        return i;
    }

    public override string Fmt()
    {
        return ""+i;
    }
    public override Expr Simplify()
    {
        return this;
    }
}

class Var : Expr {
    protected string name;

    public Var(string name) { 
    this.name = name; 
    }

    public override int Eval(Dictionary<string, int> env)
    {
        return env[name];
    }

    public override string Fmt()
    {
        return name;
    }

    public override Expr Simplify()
    {
        return this;
    }
}







abstract class Binop : Expr{
  protected Expr e1;
  protected Expr e2;
  public Binop(Expr e1, Expr e2){
    this.e1 = e1;
    this.e2 = e2;
  }
}

class Add : Binop{
    public Add(Expr e1, Expr e2) : base(e1, e2)
    {
      
    }

    public override int Eval(Dictionary<string, int> env){
        return e1.Eval(env) + e2.Eval(env);
    }
  public override string Fmt(){
    return e1.Fmt() + " + " + e2.Fmt();
  }

  public override Expr Simplify()
    {
        if (e1.Fmt() == "0"){
            return e2;
        } else if (e2.Fmt() == "0") {
            return e1;
        }
        return this;
        
    }
}

class Sub : Binop{
    public Sub(Expr e1, Expr e2) : base(e1, e2)
    {
    }

    public override int Eval(Dictionary<string, int> env)
    {
        return e1.Eval(env) - e2.Eval(env);
    }

    public override String Fmt()
    {
        return e1.Fmt() + " - " + e2.Fmt();
    }

    public override Expr Simplify()
    {
        if (e2.Fmt() == "0") {
            return e1;
        } else if (e2 == e1){
            return new CstI(0);
        }
        return this;
    }

}

class Mul : Binop{
    public Mul(Expr e1, Expr e2) : base(e1, e2)
    {
    }

    public override int Eval(Dictionary<string, int> env)
    {
        return e1.Eval(env) * e2.Eval(env);
    }

    public override string Fmt(){
        
    return e1.Fmt() + " * " + e2.Fmt();
    }

    public override Expr Simplify()
    {
        if (e1.Fmt() == "0"){
            return e1;
        } else if (e2.Fmt() == "0") {
            return e2;
        } else if (e1.Fmt() == "1") {
            return e2;
        } else if (e2.Fmt()== "1") {
            return e1;
        }
        return this;
    }

  
}