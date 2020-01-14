import { Course } from './course.model';
import { Lection } from './lection.model';
import { Test } from './test.model';

export class Student {
    StudentID : number;
    UserID : number;
    Name : string;
    LastName : string;
    Description : string;
    BirthDate : Date;
    Courses : Course[];
    Lections : Lection[];
    Tests : Test[];
}
