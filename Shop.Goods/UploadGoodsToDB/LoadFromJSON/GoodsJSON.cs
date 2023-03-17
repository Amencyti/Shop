public class Model
    {
        public string label { get; set; } 
        public string labelUID { get; set; }
        public string type { get; set; }
        public string typeUID { get; set; }
        public string brand { get; set; }
        public string brandUID { get; set; }
    }

    public class Row
    {
        public string art { get; set; }
        public string name { get; set; }
        public string itemUID { get; set; }
        public string number { get; set; }
        public int quantity { get; set; }
        public string add { get; set; }
        public Model model { get; set; }
        public string addition { get; set; }
        public string label { get; set; }
        public string shop { get; set; }
        public string subtype { get; set; }
        public int condition { get; set; }
        public int kit { get; set; }
        public string ndmforparts { get; set; }
        public string price { get; set; }
        public string bonus { get; set; }
        public string income { get; set; }
        public string shopstart { get; set; }
        public string description { get; set; }
    }

    public class Root
    {
        public List<Row> rows { get; set; }
    }