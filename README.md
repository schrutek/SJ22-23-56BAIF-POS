# Kauf-My-Stuff  <h1>

adsasddsa

## xy <h2>

asdasd

### 

...

###### <h6>

Lorem **ipsum** ***dolor*** sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.

Features:

1. asd
2. qwe
3. xcv

* asd
* qwe
* yxc

| a | b | c |
|---|---|---|
| 1 || 2    |

### Ein ID-Property

```C#
public int Id { get; set; }
```
xxx

```plantuml

@startuml

class Shop {
    Name: string
    Guid: Guid
    void Add(newShop: Shop)
}

class Category {

}

class CatPriceType {

}

class Customer {

}

class EntityBase {
    Id: int
}

class Price {

}

class Product {

}

class ShoppingCart {

}

class ShoppingCartItem {

}

class Address {

}

Shop <|-- EntityBase
Category <|-- EntityBase
CatPriceType  <|-- EntityBase
Price  <|-- EntityBase
ShoppingCart <|-- EntityBase
ShoppingCartItem <|-- EntityBase
Customer  <|-- EntityBase

Shop *-- Category
Category *-- Product
Product *-- Price
Product *-- ShoppingCartItem
ShoppingCart *-- ShoppingCartItem
Customer *-- ShoppingCart

Price -- CatPriceType
Customer -- Address
Shop -- Address

@enduml

```