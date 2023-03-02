class Client
{
    public Client() { }

    public string? Name { get; set; }
    public string? Updated_at { get; set; }
    public string? Created_at { get; set; }
    public int? Id { get; set; }


    // to String
    public override string ToString()
    {
        return $"Name: {Name}, Id: {Id}, Created_at: {Created_at}, Updated_at: {Updated_at}";
    }
}