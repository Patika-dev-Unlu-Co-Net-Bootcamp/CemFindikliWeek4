namespace UnluCo.Week1.Models
{
    //Girilmesi beklenen araç bilgileri ile ilgili sınıf.
    public class Cars
    {
        //ID değeri.
        public int Id { get; set; } 
        //Araç markası.
        public string Brand { get; set; }
        //Araç modeli.
        public string Model { get; set; }
        //Aracın üretim yılı.
        public int Year { get; set; }
        //Aracın km değeri.
        public int Km { get; set; }
        //Aracın satış fiyatı.
        public int Price { get; set; }
    }
}