public class genlist<T>{

public T[] data;
public int size=0,capacity=2;
public genlist(){    size=0; capacity=2; data = new T[capacity]; }
public void clear(){ size=0; capacity=2; data = new T[capacity]; }
public T this[int i] => data[i];
public void push(T item){
	if(size==capacity){
		T[] newdata = new T[capacity*=2];
		for(int i=0;i<size;i++)newdata[i]=data[i];
		data = newdata;
		}
	data[size]=item;
	size++;
	}

}
