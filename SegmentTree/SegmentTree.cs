using System;
public class SegmentTree<T>{
<<<<<<< HEAD
    public SegmentTree(int n){
    }
    public T Query(int l,int r){
        throw new NotImplementedException();
    }
    public T this[int i]{
        get{
            throw new NotImplementedException();
        }
        set{
            throw new NotImplementedException();
=======
    private int N;
    private T id;
    private Func<T,T,T>op;

    public T[]table{get;}

    private void OpAssign(ref T x, T y){x=op(x,y);}

    public SegmentTree(int n, T id, Func<T,T,T>op){
        this.id=id;
        this.op=op;
        this.N=1;
        while(N<n)N<<=1;
        table=new T[2*N];
        for(int i=0;i<2*N;i++)table[i]=id;
    }
    public T Query(int l,int r){
        T ans=id;
        for(l+=N,r+=N;l<r;l>>=1,r>>=1){
            if(l%2==1)OpAssign(ref ans,table[l++]);
            if(r%2==1)OpAssign(ref ans,table[--r]);
        }
        return ans;
    }
    public T this[int i]{
        get => table[i+N];
        set{
            i+=N;
            table[i]=value;
            for(i>>=1;i>=1;i>>=1){
                table[i]=op(table[i<<1],table[(i<<1)+1]);
            }
>>>>>>> 611d89a... add a stub and tests of SegmentTree
        }
    }
}
