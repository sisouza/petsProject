

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


[ApiController]
//mapping for controller token
[Route("[controller")]
public class PetController: ControllerBase {

    public PetController(){

    }
    //List all Pets
    [HttpGet]
    public ActionResult<List<Pet>> GetAll() =>
    
           //return  result data in json
        PetService.GetAll();
  
   

    //get a single pet
    [HttpGet("{id")]
    public ActionResult<Pet> Get(int id)
    {
        var pet = PetService.Get(id);

        if(pet == null)
         return NotFound();

         return pet;
    }    


    //create a pet object
    [HttpPost]
    public IActionResult Create(Pet pet)
    {
        PetService.Add(pet);
        //action name, used for create a hhtp response header with a url to the new pet
        return CreatedAtAction(nameof(Create), new {id = pet.Id }, pet);

    }

    //updates an existing pet
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pet pet)
    {
        if (id != pet.Id)
        return BadRequest();

        //validates if pet exists
        var petExists = PetService.Get(id);
        if(petExists is null)
            return NotFound();

        PetService.Update(pet);           

        return NoContent();
    }

     //delete a pet

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pet = PetService.Get(id);

        if (pet is null)
            return NotFound();

        PetService.Delete(id);

        return NoContent();
    }

   

   

}