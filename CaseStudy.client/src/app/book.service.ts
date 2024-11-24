import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../shared/models/Book';
import { BASE_API_URL } from '../shared/constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  url = BASE_API_URL + 'books';

  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url);
  }

  getBookGenres(): Observable<String[]> {
    return this.http.get<String[]>(this.url + '/genres');
  }

  addBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.url, book);
  }

  updateBook(book: Book): Observable<Book> {
    return this.http.put<Book>(this.url, book);
  }

  deleteBook(book: Book) {
    return this.http.delete(this.url + '/' + book.Id);
  }

  addBookToCollection(bookId: String, collectionId: String) {
    return this.http.get(this.url + '/' + bookId + '/' + collectionId);
  }
}
