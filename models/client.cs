class Client
{
    public Client() { }

    public string? Name { get; set; }
    public string? updated_at { get; set; }
    public string? Created_at { get; set; }
    public int? Id { get; set; }


    // to String
    public override string ToString()
    {
        return $"Name: {Name}, Id: {Id}, Created_at: {Created_at}, updated_at: {updated_at}";
    }
}