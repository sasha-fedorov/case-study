export class Book {
  constructor(
    public Id: String = '',
    public Title: String = '',
    public Author: String = '',
    public PublishYear: number = 0,
    public Genre: String = 'Other',
    public Collections: String[] = []
  ) {}
}
