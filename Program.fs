// Learn more about F# at http://fsharp.org

open System
open Newtonsoft.Json
open System.Xml
open System.IO
type Tommy  = 
    {
        mutable Name: string
        mutable Age: int
    }
type Step() =
    member val Name = "" with get,set
    member val Age = 0 with get,set

    // {
    //     mutable Name: string
    //     mutable Desc: string
    // }

[<EntryPoint>]
let main argv =
    let xml = "                        <Step>
                            <Name>Tommy</Name>
                            <Age>27</Age>
                        </Step>"
    let serializer = System.Xml.Serialization.XmlSerializer(typeof<Step>);
    use memory = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml))
    let rez = (serializer.Deserialize(memory) :?> Step)
    printf "my name is %s and I'm %i" rez.Name rez.Age
    let result = JsonConvert.DeserializeObject<Tommy>("{\"Name\": \"Tommy Parnell\", \"Age\": 27}")
    if isNull(box result)
    then 
        Console.WriteLine "its null"
    else
        printfn "my name is %s and my age is %i" result.Name result.Age
    0 // return an integer exit code
