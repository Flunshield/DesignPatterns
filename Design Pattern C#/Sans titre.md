# Introduction

Un design pattern consiste à un schéma à objet qui forme une solution à un problème connu et fréquent. Le schéma à objet est constitué par un ensemble d'objets décrits par des classes et des relations liant les objets.

Ils répondent à un ou plusieurs problèmes de conceptions logiciel dans le cadre de la programmation objet.  Ce sont des solutions connues et reconnu dont la conception provient de l'expérience des développeurs.

Il n'y a pas de théorie derrière les patterns, mais plutôt une pratique.

Introduit en 1995 dans le GoF (Gang Of Four)

# La description des patterns

Les patterns vont être décrit de la manière suivante :

- le langage UML
- le langage C#

## Liste des patterns de conception
- [Abstract Factory](): A pour objectif la création d'une famille d'objet sans devoir préciser leur classes concrète.
- [Builder]: A pour objectif de séparer la construction d'objets complexes de leur implémentation de manière à ce qu'un **client** puisse créer des objets complexes sans avoir à se soucier de leur implémentation.
- [Factory Method]
- [Prototype]
- [Singleton]
- [Decorator]
- [Facade]
- [Flyweight]
- [Proxy]


## Comment choisir et utiliser un pattern correctement

# Organisation du cours :

Les patterns de conceptions sont organisées en 3 catégorie:
- **Pattern de création** : Ces patterns fournissent des mécanismes de création d'objet qui augmentent la flexibilité et al réutilisation du code existant.
- **Pattern de structure**: Ces patterns expliquent comment créer des structures de classe et d'objet plus complexe à partir de structures simples.
- **Patterns de comportement**: Ces patterns s'occupent de l'interaction flexible et de la distribution des responsabilités entre els objets.

# Contexte du cours
Nous allons nous placer dans le contexte d'un site web de ventes/locations de véhicules en ligne (voiture, motos, vélos, etc...)

## Patterns de création/construction
Les patterns de construction sont des patterns qui fournissent des mécanisme de création d'objet qui augmentent la flexibilité et la réutilisation du code existant : On utilise l'abstraction du mécanisme de création d'objet.

Les classes concrètes sont encapsulées lors de l'utilisation de tels patterns, on favorise l'utilisation d'interfaces et de classes abstraites.

Le pattern Singleton est un pattern de création. Il permet de construire une classe possédant au maximum une seule instance. Le mécanisme qui gère l'accès à la classe est encapsule dans la classe elle-même. Le client de la classe n'est pas au courant de l'existante du mécanisme.

## Les problèmes liés à la création d'objets

En C#, la création d'objet se fait de la façon suivante :

```C#
objet = new Classe();
```

On peut paramétrer la création d'objet en utilisant des constructeurs, ou des méthodes de création :

```C#
public Document construitDocument(string typeDocument)
{
	Document document = null;
	
	if(typeDocument == "PDF") {
		document = new DocumentPDF();
	}
	else if (typeDocument == "HTML") {
		document = new DocumentHTMML();
	}
	return document;
}
```

Cet exemple témoigne de la complexité du paramétrage du mécanisme de création d'objet. Il est difficile de modifier le code pour ajouter un nouveau type de document.

# Les patterns de création

## Abstract Factory

### Définition
Fournit une interface pour al création de familles d'objets liés ou dépendants sans préciser leur classe concrète.

### Contexte
Le système de vente de véhicules gère des véhicules qui fonctionnent soit de manière électrique soit avec de l'essence. La gestion de ce mécanisme sera géré par l'objet `Catalogue`. L'objet `catalogue` se charge alors de créer de tels objets (véhicules).

Pour chacun des produits, nous disposons d'une **classe abstraite** et sous-classe qui décrit la version essence et électrique.

Si l'objet `Catalogue` utilisent les sous classes pour instancier les produits, on devra apporter des modifications à la classe catalogue lors de l'ajout de chaque nouveau produit.

Le pattern **Abstract Factory** résout cette problématique en introduisant une interface `FabriqueVehicule` qui contient la signature des méthodes pour définir chaque produit. Le type de retour de ces méthodes est constitué par l'une des classes abstraites de produit. L'objet `Catalogue`
n'a alors pas besoin de connaitre les classes concrètes des produits.

L'objet prend alors pour paramètre une instance répondant à l'interface, cest-à-dire soit une instance de `fabriqueVehiculeElectric`, soit une instance de `FabriqueVehiculeEssence`. 