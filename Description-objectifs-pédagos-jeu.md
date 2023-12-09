# Document de travail T4

Projet : FOC21

Rédacteurs : 
- Ivan Ehles
- Ewan Chauvin
- Cloe Heyd
- Enzo Mazzarella

URL GIT : https://gitlab.unistra.fr/t4-foc21-prh/projet-t4

## Instructions :
1. Prendre des notes, identifier des questions et obtenir des réponses lors de la rencontre tuteur.trice.
2. Synthétiser les notes la section « Description des objectifs pédagogiques du jeu »
3. Réaliser un prototype d’un jeu sérieux à partir de ces notes.
4. Compléter les autres sections de ce document de travail
5. Copier https://gitlab.unistra.fr/gossa/t432/-/blob/master/Evaluation-T4.md sur votre dépôt GIT.
6. Accompagner les étudiants en T2 remplir cette évaluation puis à améliorer ce document en utilisant la fonction “commentaire”
7. Transformer ce document finalisé, sauf les notes de rencontre, en README.md de votre projet avec todo-list (“- [ ]”) pour chaque item.


## Description des objectifs pédagogiques du jeu

### Objectif pédagogique général

Nous avons choisi deux objectifs pédagogiques principaux :
- L'utilisateur doit pouvoir apprendre ce qu’est le processus de lecture.
- Il doit également pouvoir apprendre ce qu’est le modèle de lecture.

Dans une version plus aboutie du jeu, nous prendrions d'autres objectifs pédagogiques en plus des précédents :
- Mettre les objectifs précédents en parallèle avec la dyslexie pour comprendre la différence entre un dyslexique et un normo-lecteur
- Apprendre la dyslexie de surface et la phonologique


### Description des objectifs pédagogiques

Pour le processus de lecture, l'utilisateur doit apprendre qu'il y a deux étapes dans ce processus :
- l'identification d'un mot, qui est spécifique à la lecture, c'est-à-dire qu'il faut associer le mot à sa prononciation pour le reconnaître.
- comprendre le mot, qui n'est pas spécifique à la lecture, c'est-à-dire connaitre son sens.

Pour le modèle de lecture, il doit apprendre les notions suivantes :
- La voie lexicale : on connaît déjà le mot 
    - Sémantique : on voit ce qu'est l'objet, on se le représente (par exemple pour le mot "table", on imagine une table)
    - Non-sémantique : on ne voit pas ce qu'est l’objet mais on connaît le mot 
- La voie sublexicale : on ne le connaît pas, on doit donc identifier les lettres et les associer aux sons qu'elles produisent


### Description de l’Unité d’Enseignement

#### Membres du projet

- Ivan Ehles
- Ewan Chauvin
- Cloe Heyd
- Enzo Mazzarella

#### Objectifs du projet

L'objectif de ce projet est de créer un jeu sérieux permettant d'apprendre une des notions qui nous a été présentées au cour d'une intervention. La thèse de notre intervenante était "Impacts d’entraînements à la morphologie et à l’orthographe sur le développement de la littératie des individus dyslexiques et normo-lecteurs", nous devons donc apprendre à l'utilisateur une des notions sur ce thème.

#### Délais

Nous avons trois jours et demi pour réaliser ce projet : 
- Une demie journée pour l'intervention, le rappel des notions, le choix des notions pour chaque groupe et le choix du type de jeu,
- Deux jours de programmation, mais la programmation de notre jeu ne pourra évidemment pas être finie en deux jours,
- Une journée avec les S2 afin de discuter de notre projet et de son cahier des charges.



## Description du jeu
- **Type de jeu** : plateforme / aventure
- **Incarnation du joueur** : un personnage rouge lambda qui veut rentrer dans sa maison

### Déroulement d’une partie

Le joueur commence avec une seule action : aller à droite. Il devra donc se déplacer à droite pour trouver un coffre qui lui permettra de débloquer une nouvelle action. Petit à petit, le joueur débloquera de plus en plus d'actions qui lui permettront d'atteindre la fin du niveau.

Pour débloquer une action, le joueur devra donc trouver un coffre. En ouvrant ce coffre, il accédera à une nouvelle phase de jeu. Il devra écouter un mot et le réécrire correctement. S'il n'y arrive pas, des lettres s'afficheront à chaque erreur afin de l'aider à trouver le mot.

Une fois qu'il aura trouvé le mot, une icone contenant le mot qu'il viendra d'écrire s'affichera en bas de son écran. Tant qu'il n'aura pas compris à quoi lui sert cette technique, l'icone n'affichera que le mot qu'il a trouvé. Après avoir trouvé l'utilité de son mot, l'icone affichera à la fois le mot et une image décrivant son utilité.

Le joueur avancera de coffre en coffre jusqu'au moment où il pourra entrer dans sa maison.


### Paramétrage d’une partie

Nous n'avons pas de paramètres à entrer pour commencer une partie. 

Cependant, dans une version plus aboutie du jeu, nous envisagerions de créer un mode pour les deux dyslexies dont nous a parlé notre intervenante :

- Dyslexie de surface : il s'agit de l'incapacité à se souvenir des mots, donc nous pourrions faire en sorte que le personnage oublie ses actions et qu'il doive les réapprendre en utilisant un livre contenant tous les mots qu'il connait.

- Dyslexie phonologique : il s'agit du fait de ne pas être capable de découvrir de nouveaux mots. Le personnage pourrait donc utiliser les mauvaises techniques en les confondant avec d'autres, par exemple aller à gauche au lieu de la droite.



## Modèle conceptuel applicatif
Liste, MCD ou diagramme de classe décrivant le jeu, et en particulier les entités, en séparant ce qui est exposé au joueur de ce qui est interne au jeu.

*Exemple :*
- membre : un membre du projet*
    - *prénom : le prénom du membre*
    - *compétence : quantité de travail fournie par unité de temps*
    - *connaissance des objectifs : pour chaque objectif, une quantité de travail déjà fournie à le connaître*
- *objectif : un des objectifs du projet*
    - *nom : le nom de l’objectif*
    - *travail nécessaire : quantité de travail nécessaire à l’accomplissement de l’objectif *
    - *connaissances maximales : quantité de travail nécessaire à la connaissance de l’objectif*
- *tâche : une tâche réalisée par un membre sur un objectif durant une unité de temps*
    - *membre : le membre qui réalise la tâche*
    - *objectif : l’objectif sur lequel travaille le membre*
    - *nature : en quoi consiste la tâche*
        - *connaître : fait monter le niveau de connaissance sur la tâche*
        - *réaliser : fait descendre la quantité de travail restant sur l’objectif*



## Description des fonctionnalités 

### Entrée
##### Actions en jeu
- Aller à gauche

- Aller à droite 

- Sauter 

- Courir 

- S’accroupir

- Monter une échelle 

- Descendre une échelle 

- Ouvrir une porte 

##### Actions pour déverrouiller une technique

- Ouvrir un coffre

- Écrire un mot après l’avoir écouté


### Moteur interne

##### Actions en jeu
- Aller à gauche : ...

- Aller à droite : ...

- Sauter : ...

- Courir : ...

- S’accroupir : ...

- Monter une échelle : ...

- Descendre une échelle : ...

- Ouvrir une porte : ...


##### Actions pour déverrouiller une technique

- Ouvrir un coffre : ...

- Écrire un mot : ...



## Scénarios

### Scénario tutorial

#### Débloquer une technique

1. Le joueur se déplace dans le niveau grâce aux techniques qu'il possède déja
2. Il trouve un coffre et l'ouvre
3. Il entend un mot que nous avons crée et doit le recopier dans une zone de texte, il peut réécouter le mot
    - Soit il se trompe, une lettre aléatoire s'affiche dans sa zone de texte (comme dans un pendu)
    - Soit il trouve le mot, la fenêtre du coffre se ferme
4. Une fois qu'il a trouvé la technique, elle s'affiche en bas de son écran sous la forme d'un texte


#### Comprendre une technique
1. Le joueur vient de débloquer une technique
2. Il explore la carte pour trouver l'endroit où il peut utiliser la technique
3. Quand un endroit l'intrigue, il peut interagir avec
    - Soit ce n'est pas la bonne technique et un texte lui indique
    - Soit c'est la bonne technique
4. S'il s'agit de la bonne technique, le texte en bas de son écran devient une image décrivant l'utilité de la technique


### Scénarios complémentaires

### Fonctionnalités additionnelles

- Ajouter un menu 
    - Mettre en pause
    - Quitter le jeu
    - Sauvegarder une partie
    - Accès à des paramètres (changer le volume du son, langue etc...)

