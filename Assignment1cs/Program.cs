
    Expr e = new Add(new CstI(17), new Var("z"));
    Expr f = new Sub(new CstI(17), new Var("z"));
    Expr g = new Mul(new CstI(17), new Var("z"));
    Expr h = new Add(new Mul(new CstI(17), new Var("z")), new Sub(new CstI(17), new Var("z")));
    Dictionary<String, int> d = new Dictionary<String, int>();
    d.Add("z", 3);
    
    Console.WriteLine(e.Fmt());
    Console.WriteLine(f.Fmt());
    Console.WriteLine(g.Fmt());
    Console.WriteLine(h.Fmt());
    Console.WriteLine(h.Eval(d));





