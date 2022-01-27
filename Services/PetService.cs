
using System.Collections.Generic;
using System.Linq;


public static class PetService {
    static List<Pet> Pets {get; }
    static int nextId = 2;
    static PetService() 
    {
        Pets = new List<Pet>
        {
            new Pet { Id = 1, Name = "Harry", status = true}
        };
    }

    public static List<Pet> GetAll() => Pets;
    public static Pet? Get(int id) => Pets.FirstOrDefault(pet => pet.Id == id);
    
    public static void Add(Pet pet)
    {
        pet.Id = nextId++;
        Pets.Add(pet);
    }

    public static void Delete(int id)
    {
        var pet = Get(id);
        if(pet is null)
            return;

            Pets.Remove(pet);
    }

    public static void Update(Pet pet)
    {
        var index = Pets.FindIndex(p => p.Id == pet.Id);
        if(index == -1)
            return;

        Pets[index] = pet;    
    }
   
}