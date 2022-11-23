import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Loan } from 'src/app/entities/loan';
import { Person } from 'src/app/entities/person';
import { Thing } from 'src/app/entities/thing';
import { LoanService } from 'src/app/services/loan.service';
import { PersonService } from 'src/app/services/person.service';
import { ThingService } from 'src/app/services/thing.service';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {
loans! : Loan[];
person! : Person;
things! : Thing[];

  
  constructor(
    private formBuilder : FormBuilder,
    private activatedRoute : ActivatedRoute,
    private route : Router,
    private service : LoanService,
    private servicePerson : PersonService,
    private serviceThing : ThingService) { }

    loanGroup = this.formBuilder.group({
      thingSelect : [0, Validators.required]
    })

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.paramMap.get('id');
    console.log("el id es", id)
    if (id !== null){
      this.service.getAllbyIdPerson(+id).subscribe(res => {
        this.loans = res;
        console.log(res);
      })
      this.servicePerson.getById(+id).subscribe(res => {
        this.person = res;
      })
      this.serviceThing.getAll().subscribe(res=> {
        this.things = res;
        console.log(this.things)
      })
    }
   
  }

  back(){
    this.route.navigate([`/person/`])
  }
  OnSubmit(){
    if(this.loanGroup.value.thingSelect != 0){
      let loan: Loan;
      loan = {
        thingId : this.loanGroup.value.thingSelect!, 
        personId : this.person.id!,
        status : "Prestado"  };
        this.service.addLoan(loan).subscribe(res => {
          this.loans.push(res);
        });
        this.route.navigate([`/loans/${this.person.id}`]);
    }
    
  }
}
