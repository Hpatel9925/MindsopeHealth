import { DB } from './db.modele';

describe('DB', () => {
  it('should create an instance', () => {
    expect(new DB()).toBeTruthy();
  });
});

