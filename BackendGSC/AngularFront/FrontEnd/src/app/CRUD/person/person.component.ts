import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication.service';
import { Address } from 'src/app/entities/address';
import { Person } from 'src/app/entities/person';
import { User } from 'src/app/entities/user';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  constructor(
    private formBuilder : FormBuilder,
    private service : PersonService,
    private route : Router,
    private authenticationService: AuthenticationService) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
     }
  title = "Persona ABM"
  persons! : Person[];
  currentUser!: User;

  personGroup = this.formBuilder.group({
    FirstName : ['', Validators.required],
    LastName : ['', Validators.required],
    Email : ['', Validators.required],
    Address : this.formBuilder.group({
      Street : ['', Validators.required],
      City : ['', Validators.required],
      Number : ['', Validators.required]
    })
  });
  ngOnInit(): void {
    this.getAllPersons();
  }
  onSubmit(){
    if(this.personGroup.valid){
      console.log("persona creada");
       let actualPerson : Person = new Person(this.personGroup.value.FirstName!,
        this.personGroup.value.LastName!,
        this.personGroup.value.Email!,
        new Address(this.personGroup.value.Address?.Street!,
          this.personGroup.value.Address?.Number!,
          this.personGroup.value.Address?.City!
          )
        );
       
      this.addPerson(actualPerson);
    }
  }
  addPerson(person : Person): void{
    this.service.addPerson(person).subscribe(p => {
    })
  }
  getAllPersons(){
    this.service.getAll().subscribe(ps => {
      this.persons = [];
      Array.prototype.push.apply(this.persons, ps)
    })
  }
  deleteById(id : number){
    if (id !== undefined)
    {
      this.service.deletePerson(id).subscribe(resp =>{
        console.log(resp);
      })
      this.persons = this.persons.filter(p => p.id != id);
    }
    else console.log("sin id")
  }
  getDetails(id : number){
    this.route.navigate([`/person/${id}`]);
  }
}