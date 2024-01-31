import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-main-index',
  templateUrl: './index.component.html'
})
export class IndexComponent {
  public accounts: Account[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Account[]>(baseUrl + 'account/get').subscribe(result => {
      this.accounts = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface Account {
  AccountName: string;
  Password: number;
}