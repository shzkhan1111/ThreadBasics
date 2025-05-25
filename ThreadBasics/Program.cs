/*
 MUtex can be used within and accross processes 
Multiple process access the same resource race condition like thread 
cant use monitor

using mutex 

local mutex 
using (var m = new Mutex()){m.WaitOne(); try{//crit section}finally(m.releaseMutex);}
to use accross different processes 
param false, "Name"
using as this is a resource within operating system 

used case 
2 process of same application 
access a file resource and update its content 

usinng monitor and lock wouldnt work
implement mutex

using(var m = new Mutex(false //dont give calling initial ownership
, "Name"//make sure its unique as it will be used accross OS now it can protect shared resource accross processes  
){
m.WaitOne()//aquire mutex
try{
//open close file crical section 

}
finally{m.ReleaseMutex();}
}

uses more resources to create mutex than lock or monitor
 */
