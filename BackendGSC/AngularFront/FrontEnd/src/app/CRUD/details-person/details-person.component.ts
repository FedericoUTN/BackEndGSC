import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/entities/person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-details-person',
  templateUrl: './details-person.component.html',
  styleUrls: ['./details-person.component.css']
})
export class DetailsPersonComponent implements OnInit {
  title = "Editar Persona"
  person! : Person ;

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
  constructor(
    private formBuilder : FormBuilder,
    private service : PersonService,
    private activatedRoute : ActivatedRoute,
    private route : Router) { }

  ngOnInit(): void {
    let id  = this.activatedRoute.snapshot.paramMap.get('id');
    if (id !== null){
      this.service.getById(+id).subscribe(p =>{
        this.person = p;
        this.mapDataToForm();
      });
    }
  }
  
    onSubmit(){
    if(this.personGroup.valid){
      this.mapFormToData();
      this.service.updatePerson(this.person).subscribe(res =>{
        console.log(res)
      });
      this.route.navigate([`/person`])
    }
  }
  mapDataToForm(){
    this.personGroup.setValue({
      FirstName : this.person.firstName,
      LastName : this.person.lastName,
      Email : this.person.email,
      Address : {
        Street : this.person.address.street,
        City : this.person.address.city,
        Number : this.person.address.number
      } 
    });
  }

  mapFormToData(){
    this.person.firstName = this.personGroup.value.FirstName!;
    this.person.lastName = this.personGroup.value.LastName!;
    this.person.email = this.personGroup.value.Email!;
    this.person.address.city = this.personGroup.value.Address?.City!;
    this.person.address.street = this.personGroup.value.Address?.Street!;
    this.person.address.number = this.personGroup.value.Address?.Number!;
  }

  back(){
    this.route.navigate([`/person/`])
  }


}
