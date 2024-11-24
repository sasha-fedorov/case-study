import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Collection } from '../shared/models/Collection';
import { BASE_API_URL } from '../shared/constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CollectionService {
  url = BASE_API_URL + 'collections';

  constructor(private http: HttpClient) {}

  getCollections(): Observable<Collection[]> {
    return this.http.get<Collection[]>(this.url);
  }

  addCollection(collection: Collection): Observable<Collection> {
    return this.http.post<Collection>(this.url, collection);
  }

  updateCollection(collection: Collection): Observable<Collection> {
    return this.http.put<Collection>(this.url, collection);
  }

  deleteCollection(collection: Collection) {
    return this.http.delete(this.url + '/' + collection.Id);
  }
}
