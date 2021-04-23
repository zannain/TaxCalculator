import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-tax-form',
  templateUrl: './tax-form.component.html',
  styleUrls: ['./tax-form.component.css']
})
export class TaxFormComponent implements OnInit {
  public taxForm: FormGroup;
  public frequency: ["Monthly", "Yearly"]
  public state: string;
  get zipCodeControl () { return this.taxForm.controls.zipcode}
  get incomeControl () { return this.taxForm.controls.income}
  get frequencyControl () { return this.taxForm.controls.frequency}
  constructor(private dataService: DataService) { }

  ngOnInit(): void {

    this.taxForm = new FormGroup({
      income: new FormControl('', [Validators.required]),
      frequency: new FormControl('', [Validators.required]),
      zipcode: new FormControl('', [Validators.required, Validators.max(5)])
    });

    this.zipCodeControl.valueChanges.subscribe(value => {
      if (value.length === 5) {
        console.log(value)
        this.dataService.getZipCode(value).subscribe(res => {
          if (res?) {

          }
          console.log({res})
        })
      }
    });
    this.incomeControl.valueChanges.subscribe(value => console.log({incomeControl: value}))
    this.frequencyControl.valueChanges.subscribe(value => console.log({frequencyControl: value}))


  }

  onCalculate() {
    console.log('..calculating')
  }

}
