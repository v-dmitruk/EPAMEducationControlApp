import { Student } from './student.model';
import { Test } from './test.model';
import { Lection } from './lection.model';
import { Teacher } from './teacher.model';

export class Course {
    CourseID : number;
    Name : string;
    Description : string;
    StudentsMaxQuantity : number;
    MaxScore : number;
    MinRequiredScore : number;
    Creator : Teacher;
    StartDate : Date;
    CreationDate : Date;
    DurationInDays : number;
    Lections : Lection[];
    Tests : Test[];
    Students : Student[];
}
