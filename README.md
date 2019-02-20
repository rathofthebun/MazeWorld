# Spatia Neuro VR Maze
TO DO: add position recording function
TO DO:

## Version Required:
Unity 2018 3.4f1 or above
(You can use Unity Hub to manage versions on your computer) -- [Go to page of Unity Hub](https://store.unity.com/download?ref=personal).

## Libraries Reference:
SteamVR 2.1

## Install Git (if you don't have it)
#### Windows: download and install
1. [Download Git for Windows](https://git-scm.com/downloads/win).
2. Install Git-2.xx-32/64.exe
3. done

#### Mac: Install homebrew and Command Line Tool (if you don't have), then install git using package manager
- Homebrew is a package manager that allows you to install different softwares in terminal
1. Open your terminal, copy paste:
```shell
/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"
```
2. If you have never used command line tool / XCode on Mac, you will be asked to install it from Apple, confirm install. Otherwise, skip this step
3. Use brew to install anything in terminal like this:
```shell
brew install git
```
4. done

#### IMPORTANT: Install Git LFS 
1. download GIT LFS at: https://git-lfs.github.com/
2. Install package
3. In your terminal (Mac) or powershell / Gitbash / cmd (Windows), type:
```shell
git lfs install
```
4. done

## git clone / pull / push
#### git clone
For first time or need a clean repo:
1. In terminal, use "cd your/folder/name" or cd .. to navigate into "transWorld" folder:
2. type:
```shell
git clone https://github.com/Translab/transWorld
```

#### git pull
Note: Everytime when you make changes to the project, please pull the latest version from the server
1. Mac OS: open your terminal / Windows: Powershell
2. cd your/path/transWorld or cd .. to navigate into "transWorld" folder
3. git pull 


#### git push (add, commit, push)
Push your contributions to the world every time you finishes:
In terminal:
```shell
cd your/path/transWorld
git add .  
```
this prepares and adds all changed files to be uploaded *notice the space and dot after “add”.
if you have only a few files to add:
```shell
git add filenameA
git add filenameB
```
when you finish adding, you should commit the changes you made and push to the master branch:
```shell
git commit -m “your_message”
git push origin master
```

#### conflict reports or errors when pull or push
The principle is that, you should make sure your local repo is exactly same as the server repo.

if you have issues
you can always use:
```shell
git stash
```
It removes all the local changes and makes the local repo exactly same as the previous pull. Then you can pull again from the server to get the latest version. 

*note: don't use this method if you have made significant changes already on the project, git stash will wipe out every changes you made.

