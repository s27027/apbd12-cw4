using Microsoft.AspNetCore.Mvc;
using apbd12_cw4.Data;
using apbd12_cw4.Models;

namespace apbd12_cw4.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAll() =>
        Ok(AnimalRepository.Animals);

    [HttpGet("{id}")]
    public ActionResult<Animal> GetById(int id)
    {
        var animal = AnimalRepository.Animals.FirstOrDefault(a => a.Id == id);
        return animal is null ? NotFound() : Ok(animal);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Animal>> SearchByName([FromQuery] string name)
    {
        var results = AnimalRepository.Animals
            .Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(results);
    }

    [HttpPost]
    public ActionResult Add(Animal animal)
    {
        animal.Id = AnimalRepository.Animals.Count + 1;
        AnimalRepository.Animals.Add(animal);
        return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Animal updated)
    {
        var animal = AnimalRepository.Animals.FirstOrDefault(a => a.Id == id);
        if (animal is null) return NotFound();

        animal.Name = updated.Name;
        animal.Category = updated.Category;
        animal.Weight = updated.Weight;
        animal.FurColor = updated.FurColor;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var animal = AnimalRepository.Animals.FirstOrDefault(a => a.Id == id);
        if (animal is null) return NotFound();

        AnimalRepository.Animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("{id}/visits")]
    public ActionResult<IEnumerable<Visit>> GetVisits(int id)
    {
        var animal = AnimalRepository.Animals.FirstOrDefault(a => a.Id == id);
        return animal is null ? NotFound() : Ok(animal.Visits);
    }

    [HttpPost("{id}/visits")]
    public ActionResult AddVisit(int id, Visit visit)
    {
        var animal = AnimalRepository.Animals.FirstOrDefault(a => a.Id == id);
        if (animal is null) return NotFound();

        visit.Id = animal.Visits.Count + 1;
        animal.Visits.Add(visit);

        return CreatedAtAction(nameof(GetVisits), new { id = animal.Id }, visit);
    }
}