import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public installments: Installment[];
  private readonly baseUrl: string;
  private readonly loadnCalculatorCtrl: string;
  private interestRate: number;
  public loanInfo: Loan;
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
    this.loadnCalculatorCtrl = 'api/LoanCalculator'
    this.loanInfo = {
      amount: 500000,
      paymentYears: 30,
      PaymentStrategy: PaymentStrategy.DecreasingInstallments
    } as Loan;
    this.getInterestRate();
  }

  public calculateInstallments() {
    const requestUrl = `${this.baseUrl}${this.loadnCalculatorCtrl}/GenerateInstallments`;

    this.http.post<Installment[]>(requestUrl, this.loanInfo ).subscribe(result => {
      this.installments = result;
    }, error => console.error(error));
  }

  private getInterestRate() {
    const requestUrl = `${this.baseUrl}${this.loadnCalculatorCtrl}/GetInterestRate`;

    this.http.get(requestUrl ).subscribe(result => {
      this.interestRate = result as number;;
    }, error => console.error(error));
  }
}

interface Installment {
  month: number;
  principal: number;
  interest: number;
  installmentAmount: number;
}

interface Loan {
  amount: number;
  paymentYears: number;
  PaymentStrategy: PaymentStrategy;
}

export enum PaymentStrategy {
  DecreasingInstallments = 0
}