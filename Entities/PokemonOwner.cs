namespace pokemon_review_api.Entities
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}