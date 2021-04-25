import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DataService } from '../core/services/data.service';
import { CalculatedTaxViewModel } from '../models/calculated-tax.model';
import { Formulas, Frequency } from '../models/enums';
import { TaxFormViewModel } from '../models/tax-form.model';
import { ZipCodeViewModel } from '../models/zip-code-response';

@Component({
  selector: 'app-tax-form',
  templateUrl: './tax-form.component.html',
  styleUrls: ['./tax-form.component.css'],
})
export class TaxFormComponent implements OnInit {
  private zipCodeViewModel: ZipCodeViewModel;
  private frequency = Frequency;
  public state: string;
  public calculatedTax: CalculatedTaxViewModel = undefined;
  public taxForm: FormGroup;
  public frequencyValues = Object.values(this.frequency).filter( e => typeof( e ) == "string" );
  public formulaValues = Object.values(Formulas).filter( e => typeof( e ) == "string" );
  get zip() { return this.taxForm.get('zipcode'); }
  get income() { return this.taxForm.get('income'); }
  get frequencyControl() { return this.taxForm.get('frequency'); }
  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.taxForm = new FormGroup({
      income: new FormControl('', [Validators.required]),
      frequency: new FormControl('', [Validators.required]),
      zipcode: new FormControl('', [Validators.required, Validators.max(5)]),
    });
    this.taxForm.valueChanges.subscribe(form => {
      this.calculatedTax = null;
    })
    this.zip.valueChanges.subscribe(zipCode => {
      if (zipCode?.length === 5) {
        this.dataService.getZipCode(zipCode).subscribe((res) => {
          console.log({res})
          if (res.places.length > 0) {
            this.zipCodeViewModel = res;
            this.state = this.zipCodeViewModel?.places[0]['state'];
          }
        });
      }
    })
    
}
  retrieveState() {
    let zipCode = this.zip.value;
    if (zipCode.length === 5) {
      this.dataService.getZipCode(zipCode).subscribe((res) => {
        if (res.places.length > 0) {
          this.zipCodeViewModel = res;
          this.state = this.zipCodeViewModel?.places[0]['state'];
        }
      });
    }
  }
  onCalculate() {
    this.calculatedTax = null;
    let response = new TaxFormViewModel();
    response.state = this.zipCodeViewModel?.places[0]['state abbreviation'];
    response.frequency = this.frequencyControl.value;
    response.income = this.income.value;
    this.dataService.getTax(response).subscribe(res => {
      this.taxForm.reset()
      console.log({res})
      const { formula } = res;
      res.formula = this.formulaValues[formula]
      this.calculatedTax = res;
    })
  }
}
