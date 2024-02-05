import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { IAuthResponse } from "../interfaces/IAuthResponse";
import { IResponse } from "../interfaces/IResponse";

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private url: string) { }

    auth(request: any) {
        return this.http.post<IResponse<IAuthResponse>>(this.url + 'webAccount/Auth', request);
    }
}