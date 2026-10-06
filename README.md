# Unity Git 開発ルール

## 🌳 ブランチ構成

```text
main
 │
 └── develop
      │
      ├── feature/title
      ├── feature/player
      ├── feature/enemy
      └── feature/stage
```

### main

- 完成・提出用のブランチ
- **原則、直接pushしない**
- `develop` で十分に確認したものをPull Requestで統合する

### develop

- チーム開発の基本ブランチ
- 各featureブランチの統合先
- 動作確認が取れたものをここに入れる

### feature/*

- 機能ごとに作成する作業用ブランチ
- 1つの機能につき1ブランチを基本とする

例：

```text
feature/title
feature/player
feature/enemy
feature/stage
```

---

# 🔄 開発の流れ

```text
develop
   ↓
feature/xxx を作成
   ↓
開発・動作確認
   ↓
commit
   ↓
GitHubへpush
   ↓
Pull Request作成
   ↓
他のメンバーが確認・レビュー
   ↓
developへMerge
   ↓
完成したらmainへMerge
```

### Pull Requestについて

- **最低1人はレビューする**
- 自分だけで確認してそのままMergeしない
- 「何を変更したか」「動作確認したか」をPRに書く
- コンフリクトが発生した場合は、勝手に解決せずメンバーと確認する

---

# 🎮 Unity開発ルール

## 1. 同じSceneを同時に編集しない

UnityのSceneファイルは複数人で同時編集すると、変更内容が競合しやすい。

そのため、

```text
Aさん → Title Scene
Bさん → Game Scene
```

のように、できるだけ担当Sceneを分ける。

同じSceneを編集する必要がある場合は、事前にチーム内で共有する。

---

## 2. Prefabを積極的に使用する

複数のSceneで使用するオブジェクトは、できるだけPrefab化する。

例：

```text
Player
Enemy
Bullet
UI
Item
```

Prefabを利用することで、同じオブジェクトを複数のSceneで管理しやすくする。

---

## 3. Scriptは役割ごとに整理する

Scriptを1つに詰め込みすぎない。

例えば、

```text
Assets/
└── Scripts/
    ├── Player/
    ├── Enemy/
    ├── UI/
    ├── Game/
    └── Stage/
```

のように、役割ごとに整理する。

---

# 📝 Commitルール

Commitメッセージの先頭に、変更内容を表す種類を付ける。

```text
Add
Fix
Update
Remove
Refactor
```

### 例

```text
Add player controller
Add title scene
Fix player movement bug
Update enemy AI
Remove unused script
Refactor game manager
```

### Commitの基本

- 1つのCommitに多くの変更を詰め込みすぎない
- **1 Commit = 1つの目的**を基本とする
- 「何を変更したか」が分かるメッセージにする

---

# 📦 Gitで管理するもの

Unityプロジェクトでは、基本的に以下をGitHubで共有する。

```text
Assets/
Packages/
ProjectSettings/
```

一方、以下のようなUnityが自動生成するファイルはGitに入れない。

```text
Library/
Temp/
Logs/
Obj/
Build/
UserSettings/
```

`.gitignore`を使用して自動的に除外する。

---

# 💾 Git LFS

Unityでサイズの大きいファイルを扱う場合は、Git LFSの使用を検討する。

特に、

```text
.psd
.wav
.mp4
大型画像
大型3Dモデル
```

など、サイズの大きいバイナリファイルは通常のGitで大量に管理しない。

---

# ✅ Pull Requestを出す前の確認

PRを作成する前に、以下を確認する。

- [ ] Unityが正常に起動する
- [ ] Consoleにエラーがない
- [ ] 追加・変更した機能が正常に動作する
- [ ] 不要なファイルを追加していない
- [ ] Commitメッセージが分かりやすい
- [ ] 最新の`develop`を取り込んでいる
- [ ] 自分の変更によって他の機能が壊れていない

---

# ⚠️ 注意事項

### 同じSceneを複数人で同時に編集しない

Sceneの競合は解決が難しくなるため、可能な限り避ける。

### mainへ直接pushしない

```text
❌ feature → main
⭕ feature → develop → main
```

### 作業前に最新状態を確認する

作業を始める前に、現在のブランチが最新状態になっているか確認する。

### 大きな変更をするときは共有する

Scene構成の変更や、ゲーム全体に影響する変更を行う場合は、事前にチーム内で共有する。

---

# 🚀 基本的なGit操作

## 作業を始める

```bash
git switch develop
git pull
```

## featureブランチを作る

```bash
git switch -c feature/xxx
```

## 変更をCommit

```bash
git add .
git commit -m "Add xxx"
```

## GitHubへPush

```bash
git push -u origin feature/xxx
```

その後、GitHubでPull Requestを作成する。

---

# 🤝 チーム開発の基本

このプロジェクトでは、

```text
main
 ↓
完成・提出用

develop
 ↓
チーム開発用

feature/*
 ↓
個人の作業用
```

という役割分担で開発する。

**「自分のPCでは動いた」だけで終わらせず、チーム全体で動作確認できる状態を作ることを重視する。**
