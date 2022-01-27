

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
   

}