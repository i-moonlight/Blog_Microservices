import { User } from "src/app/core/models/user"

export class ContentCreateDto{
    title!: string
    text!: string
    categoryId!:string
    user!:User
    image!:File
}