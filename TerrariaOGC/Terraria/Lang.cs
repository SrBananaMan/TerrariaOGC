using System.Globalization;

namespace Terraria
{
	internal sealed class Lang
	{
		public enum ID
		{
			NONE,
			ENGLISH,
			GERMAN,
			ITALIAN,
			FRENCH,
			SPANISH
		}

		// I should note that I have not accounted for the differences in text between 'Xbox 360' & 'PlayStation 3' mode. The same goes with the controls.

		public enum CONTROLS
		{
			SELECT,
			BACK,
			CLOSE,
			CHANGE_STORAGE,
			SHOW_PARTY,
			TOGGLE_GRAPPLE_MODE,
			BLACKLIST,
			MOVE_MAP,
			ZOOM,
			TOGGLE_PVP,
			SELECT_TEAM,
			INVITE_PLAYER,
			INVITE_PARTY,
			SHOW_GAMERCARD,
			CREATE_WORLD,
			JOIN,
			X_SHOW_GAMERCARD,
			CHANGE_ITEM,
			CHANGE_MENU,
			GRAPPLE,
			GRAPPLE_ALT,
			INTERACT,
			TALK,
			JUMP,
			INVENTORY,
			DROP,
			TRASH,
			SELL,
			USE,
			DIG,
			CHOP,
			ATTACK,
			HIT,
			BUILD,
			SELECT_ONE,
			SELECT_ALL,
			PLACE,
			PLACE_EQUIPMENT,
			SWAP,
			EQUIP,
			OPEN,
			REFORGE,
			SHOW_RECIPES,
			CRAFT,
			SHOW_ALL,
			SHOW_AVAILABLE,
			INGREDIENTS,
			RECIPES,
			CRAFTING_CATEGORY,
			BUY_ONE,
			BUY_ALL,
			SELL_ITEM_IN_HAND,
			CANCEL_BUFF,
			ASSIGN_TO_ROOM,
			CHECK_HOUSING,
			SHOW_BANNERS,
			HIDE_BANNERS,
			GENDER,
			DIFFICULTY,
			HAIR_TYPE,
			HAIR_COLOR,
			VEST_COLOR,
			SHIRT_COLOR,
			UNDERSHIRT_COLOR,
			PANTS_COLOR,
			SHOE_COLOR,
			SKIN_COLOR,
			EYE_COLOR,
			RANDOMIZE,
			CREATE_CHARACTER,
			CHANGE_CATEGORY,
			SELECT_COLOR,
			SELECT_TYPE,
			SELECT_GENDER,
			SELECT_DIFFICULTY,
			CHANGE_SOUND_VOLUME,
			CHANGE_MUSIC_VOLUME,
			NEXT_PAGE,
			PREVIOUS_PAGE,
			SCROLL_TEXT,
			SWITCH_LEADERBOARD,
			SHOW_TOP,
			SHOW_MYSELF,
			SHOW_FRIENDS,
			EXIT,
			BACK_TO_GAME, // Idk why this is even an option, the text just says 'Back'... like the 2nd entry in the list.
			UNLOCK_FULL_GAME
		}

		public const char LeftTrigger = '\u0080';

		public const char RightTrigger = '\u0081';

		public const char LeftSButton = '\u0082';

		public const char RightSButton = '\u0083';

		public const char LeftStick = '\u0084';

		public const char RightStick = '\u0085';

		public const char DPad = '\u0086';

		public const char BackButton = '\u0087';

		public const char StartButton = '\u0088';

		public const char HomeButton = '\u0089'; // I guess this is just here for posterity.

		public const char XButton = '\u008a';

		public const char YButton = '\u008b';

		public const char AButton = '\u008c';

		public const char BButton = '\u008d';

		public const char LeftStickPress = '\u008e';

		public const char RightStickPress = '\u008f';

		public const string BothSButtons = "\u0082\u0083";

		public const string RightTriggerAButton = "\u0081\u008c"; // Wtf uses this?

		public const string BothTriggers = "\u0080\u0081";

		private const char UseAction = AButton;

		private const char InteractAction = BButton;

		private const char InvSelectAction = AButton;

		private const char MoveAction = LeftStick;

		private const char ControlModeAction = RightStick;

		private const char JumpAction = AButton;

		private const char InventoryAction = YButton;

		private const char LeaveInvAction = BButton;

		private const char MoveCursorAction = RightStick;

		private const char DropAction = XButton;

		private const string HotbarScrollAction = BothSButtons;

		public static int LangOption = 0;

		public static string LanguageId = "en";

		public static string[] MiscText = new string[37];

		public static string[] MenuText = new string[113];

		public static string[] WorldGenText = new string[59];

		public static string[] InterfaceText = new string[80];

		public static string[] TipText = new string[52];

		public static string[] DeathText = new string[4];

		public static readonly string[] ControlsEN = new string[87]
		{
			AButton + "Select",
			BButton + "Back",
			BButton + "Close",
			XButton + "Change Storage Device",
			YButton + "Xbox LIVE Party",
			AButton + "Toggle Grappling Mode",
			RightSButton + "Ban World",
			MoveCursorAction + "Map",
			BothTriggers + "Zoom",
			AButton + "Toggle PvP",
			AButton + "Select Team",
			XButton + "Invite",
			YButton + "Invite Xbox LIVE Party",
			AButton + "Gamer card",
			AButton + "Create World",
			AButton + "Join",
			XButton + "Show gamer card",
			HotbarScrollAction + "Switch Item",
			BothSButtons + "Switch Menu",
			LeftTrigger + "Grapple",
			LeftStickPress + "Grapple",
			InteractAction + "Use",
			InteractAction + "Talk",
			JumpAction + "Jump",
			InventoryAction + "Inventory",
			DropAction + "Drop",
			XButton + "Trash",
			XButton + "Sell",
			RightTrigger + "Action",
			RightTrigger + "Dig",
			RightTrigger + "Chop",
			RightTrigger + "Attack",
			RightTrigger + "Hit",
			RightTrigger + "Build",
			RightTrigger + "Take One",
			InvSelectAction + "Take",
			InvSelectAction + "Place",
			InvSelectAction + "Equip",
			InvSelectAction + "Swap",
			RightTrigger + "Equip",
			RightTrigger + "Open",
			InvSelectAction + "Reforge",
			UseAction + "Show Recipes",
			InvSelectAction + "Craft",
			XButton + "Show All",
			XButton + "Show Available",
			YButton + "Ingredients",
			YButton + "Recipes",
			BothTriggers + "Switch Category",
			RightTrigger + "Buy One",
			UseAction + "Buy",
			UseAction + "Sell",
			InvSelectAction + "Cancel Buff",
			InvSelectAction + "Assign to Room",
			XButton + "Check Housing",
			YButton + "Show Room Flags",
			YButton + "Hide Room Flags",
			"Gender",
			"Difficulty",
			"Hair Type",
			"Hair Color",
			"Vest Color",
			"Shirt Color",
			"Undershirt Color",
			"Pants Color",
			"Shoe Color",
			"Skin Color",
			"Eye Color",
			YButton + "Randomize All",
			StartButton + " Create Character",
			BothSButtons + "Switch Category",
			MoveAction + "Select Color",
			MoveAction + "Select Type",
			MoveAction + "Select Gender",
			MoveAction + "Select Difficulty",
			MoveAction + "Change Sound Volume",
			MoveAction + "Change Music Volume",
			AButton + "Next Page",
			XButton + "Previous Page",
			MoveAction + "Scroll Text",
			BothSButtons + "Switch Leaderboard",
			XButton + "Show Top",
			XButton + "Show Myself",
			XButton + "Show Friends Only",
			AButton + "Exit Game",
			BButton + "Back",
			XButton + "Unlock Full Game"
		};

		public static readonly string[] ControlsDE = new string[87]
		{
			AButton + "Auswählen",
			BButton + "Zurück",
			BButton + "Schließen",
			XButton + "Speichermedium wechseln",
			YButton + "Xbox LIVE Party",
			AButton + "Auf Greifhaken-Modus umstellen",
			RightSButton + "Verbanne Welt",
			MoveCursorAction + "Karte",
			BothTriggers + "Zoom",
			AButton + "Auf PvP schalten",
			AButton + "Team wählen",
			XButton + "Einladung",
			YButton + "Einladung - Xbox LIVE Party",
			AButton + "Spielerkarte",
			AButton + "Welt erstellen",
			AButton + "Teilnehmen",
			XButton + "Spielerkarte zeigen",
			HotbarScrollAction + "Item austauschen",
			BothSButtons + "Menü wechseln",
			LeftTrigger + "Entern",
			LeftStickPress + "Entern",
			InteractAction + "Nutzen",
			InteractAction + "Sprechen",
			JumpAction + "Springen",
			InventoryAction + "Inventar",
			DropAction + "Fallenlassen",
			XButton + "Müll",
			XButton + "Verkaufen",
			RightTrigger + "Action",
			RightTrigger + "Graben",
			RightTrigger + "Hacken",
			RightTrigger + "Attackieren",
			RightTrigger + "Schlagen",
			RightTrigger + "Bauen",
			RightTrigger + "Nimm eins",
			InvSelectAction + "Nehmen",
			InvSelectAction + "Platzieren",
			InvSelectAction + "Ausstatten",
			InvSelectAction + "Tauschen",
			RightTrigger + "Ausstatten",
			RightTrigger + "Öffnen",
			InvSelectAction + "Wieder schmieden",
			UseAction + "Rezepte anzeigen",
			InvSelectAction + "Herstellen",
			XButton + "Alle",
			XButton + "Erhältliche",
			YButton + "Bestandteile",
			YButton + "Rezepte",
			BothTriggers + "Kategorie",
			RightTrigger + "Kauf eins",
			UseAction + "Kaufen",
			UseAction + "Verkaufen",
			InvSelectAction + "Buff löschen",
			InvSelectAction + "Raum zuweisen",
			XButton + "Unterkünfte",
			YButton + "Flaggen anzeigen",
			YButton + "Flaggen verbergen",
			"Geschlecht",
			"Schwierigkeitsstufe",
			"Haartyp",
			"Haarfarbe",
			"Hemdfarbe",
			"Shirt-Farbe",
			"Unterhemdfarbe",
			"Hosenfarbe",
			"Schuhfarbe",
			"Hautfarbe",
			"Augenfarbe",
			YButton + "Alle nach Zufallsprinzip auswählen",
			StartButton + " Charakter erstellen",
			BothSButtons + "Kategorie wechseln",
			MoveAction + "Farbe auswählen",
			MoveAction + "Typ auswählen",
			MoveAction + "Geschlecht auswählen",
			MoveAction + "Schwierigkeitsstufe auswählen",
			MoveAction + "Tonlautstärke ändern",
			MoveAction + "Musiklautstärke ändern",
			AButton + "Nächste Seite",
			XButton + "Vorherige Seite",
			MoveAction + "Text scrollen",
			BothSButtons + "Bestenlisten wechseln",
			XButton + "Bestplatzierte",
			XButton + "Mich selbst anzeigen",
			XButton + "Nur Freunde anzeigen",
			AButton + "Spiel verlassen",
			BButton + "Zurück",
			XButton + "Vollständiges Spiel freischalten"
		};

		public static readonly string[] ControlsFR = new string[87]
		{
			AButton + "Sélectionner",
			BButton + "Retour",
			BButton + "Fermer",
			XButton + "Changer périphérique de stockage",
			YButton + "Groupe d'amis Xbox LIVE",
			AButton + "Basculer en mode grappin",
			RightSButton + "Bannir un monde",
			MoveCursorAction + "Carte",
			BothTriggers + "Agrandir",
			AButton + "PvP",
			AButton + "L'équipe",
			XButton + "Invitation",
			YButton + "Inviter groupe d'amis Xbox LIVE",
			AButton + "Carte joueur",
			AButton + "Créer un monde",
			AButton + "Rejoindre",
			XButton + "Afficher la carte du joueur",
			HotbarScrollAction + "Changer objet",
			BothSButtons + "Changer menu",
			LeftTrigger + "Grappin",
			LeftStickPress + "Grappin",
			InteractAction + "Utiliser",
			InteractAction + "Parler",
			JumpAction + "Sauter",
			InventoryAction + "Inventaire",
			DropAction + "Lâcher",
			XButton + "Poubelle",
			XButton + "Vendre",
			RightTrigger + "Action",
			RightTrigger + "Creuser",
			RightTrigger + "Couper",
			RightTrigger + "Attaquer",
			RightTrigger + "Frapper",
			RightTrigger + "Construire",
			RightTrigger + "En prendre un(e)",
			InvSelectAction + "Prendre",
			InvSelectAction + "Placer",
			InvSelectAction + "Équiper",
			InvSelectAction + "Échanger",
			RightTrigger + "Équiper",
			RightTrigger + "Ouvrir",
			InvSelectAction + "Reforger",
			UseAction + "Afficher recettes",
			InvSelectAction + "Fabriquer",
			XButton + "Tout",
			XButton + "Disponible",
			YButton + "Ingrédients",
			YButton + "Recettes",
			BothTriggers + "Catégories",
			RightTrigger + "En acheter un(e)",
			UseAction + "Acheter",
			UseAction + "Vendre",
			InvSelectAction + "Annuler buff",
			InvSelectAction + "Attribuer chambre",
			XButton + "Logement",
			YButton + "Afficher drapeaux",
			YButton + "Masquer drapeaux",
			"Sexe",
			"Difficulté",
			"Type de cheveux",
			"Couleur de cheveux",
			"Couleur de veste",
			"Couleur de chemise",
			"Couleur de t-shirt",
			"Couleur de pantalon",
			"Couleur des chaussures",
			"Couleur de peau",
			"Couleur des yeux",
			YButton + "Tout au hasard",
			StartButton + "Créer un personnage",
			BothSButtons + "Changer de catégorie",
			MoveAction + "Choisir une couleur",
			MoveAction + "Choisir un type",
			MoveAction + "Choisir le sexe",
			MoveAction + "Choisir la difficulté",
			MoveAction + "Changer le volume des sons",
			MoveAction + "Changer le volume de la musique",
			AButton + "Page suivante",
			XButton + "Page précédente",
			MoveAction + "Faire défiler le texte",
			BothSButtons + "Changer le classement",
			XButton + "Afficher les premiers",
			XButton + "Afficher mon rang",
			XButton + "Afficher amis uniquement",
			AButton + "Quitter le jeu",
			BButton + "Retour",
			XButton + "Déverrouiller le jeu complet"
		};

		public static readonly string[] ControlsIT = new string[87]
		{
			AButton + "Seleziona",
			BButton + "Indietro",
			BButton + "Chiudi",
			XButton + "Cambia portaoggetti",
			YButton + "Party Xbox LIVE",
			AButton + "Attiva modalità di lotta",
			RightSButton + "Blocca Mondo",
			MoveCursorAction + "Mappa",
			BothTriggers + "Ingrandisci",
			AButton + "Attiva PvP",
			AButton + "Seleziona squadra",
			XButton + "Invito",
			YButton + "Invita ad un Party Xbox LIVE",
			AButton + "Scheda giocatore",
			AButton + "Crea Mondo",
			AButton + "Entra",
			XButton + "Mostra scheda giocatore",
			HotbarScrollAction + "Cambia oggetto",
			BothSButtons + "Cambia menu",
			LeftTrigger + "Afferra",
			LeftStickPress + "Afferra",
			InteractAction + "Utilizza",
			InteractAction + "Parla",
			JumpAction + "Salta",
			InventoryAction + "Inventario",
			DropAction + "Lascia",
			XButton + "Cestino",
			XButton + "Vendi",
			RightTrigger + "Azione",
			RightTrigger + "Scava",
			RightTrigger + "Taglia",
			RightTrigger + "Attacca",
			RightTrigger + "Colpisci",
			RightTrigger + "Costruisci",
			RightTrigger + "Prendi uno",
			InvSelectAction + "Prendi",
			InvSelectAction + "Posiziona",
			InvSelectAction + "Equipaggiati",
			InvSelectAction + "Scambia",
			RightTrigger + "Equipaggiamento",
			RightTrigger + "Apri",
			InvSelectAction + "Riforgia",
			UseAction + "Mostra formule",
			InvSelectAction + "Crea",
			XButton + "Tutto",
			XButton + "Disponibile",
			YButton + "Ingredienti",
			YButton + "Formule",
			BothTriggers + "Categoria",
			RightTrigger + "Compra uno",
			UseAction + "Compra",
			UseAction + "Vendi",
			InvSelectAction + "Cancella bonus",
			InvSelectAction + "Assegna stanza",
			XButton + "Alloggio",
			YButton + "Mostra bandiere",
			YButton + "Nascondi bandiere",
			"Sesso",
			"Difficoltà",
			"Tipologia capelli",
			"Colore capelli",
			"Colore giubbotto",
			"Colore maglia",
			"Colore canottiera",
			"Colore pantaloni",
			"Colore scarpe",
			"Colore pelle",
			"Colore occhi",
			YButton + "Randomizza tutto",
			StartButton + " Crea personaggio",
			BothSButtons + "Cambia categoria",
			MoveAction + "Seleziona colore",
			MoveAction + "Seleziona tipologia",
			MoveAction + "Seleziona sesso",
			MoveAction + "Seleziona difficoltà",
			MoveAction + "Cambia volume suono",
			MoveAction + "Cambia volume musica",
			AButton + "Pagina successiva",
			XButton + "Pagina precedente",
			MoveAction + "Scorri testo",
			BothSButtons + "Cambia classifica",
			XButton + "Mostra il primo in classifica",
			XButton + "Mostra il mio personaggio",
			XButton + "Mostra solo i miei amici",
			AButton + "Esci dal gioco",
			BButton + "Indietro",
			XButton + "Sblocca gioco completo"
		};

		public static readonly string[] ControlsES = new string[87]
		{
			AButton + "Seleccionar",
			BButton + "Atrás",
			BButton + "Cerrar",
			XButton + "Cambiar de dispositivo de almacenaje",
			YButton + "Xbox LIVE Party",
			AButton + "Cambiar de modo de agarre",
			RightSButton + "Prohibir Mundo",
			MoveCursorAction + "Mapa",
			BothTriggers + "Aumentar",
			AButton + "Cambiar PvP",
			AButton + "Seleccionar equipo",
			XButton + "Invitación",
			YButton + "Invitar a Xbox LIVE Party",
			AButton + "Mostrar jugador",
			AButton + "Crear mundo",
			AButton + "Unirse",
			XButton + "Mostrar tarjeta de jugador",
			HotbarScrollAction + "Cambiar objeto",
			BothSButtons + "Cambiar de menú",
			LeftTrigger + "Agarrar",
			LeftStickPress + "Agarrar",
			InteractAction + "Usar",
			InteractAction + "Hablar",
			JumpAction + "Saltar",
			InventoryAction + "Inventario",
			DropAction + "Soltar",
			XButton + "Basura",
			XButton + "Vender",
			RightTrigger + "Acción",
			RightTrigger + "Excavar",
			RightTrigger + "Cortar",
			RightTrigger + "Atacar",
			RightTrigger + "Golpear",
			RightTrigger + "Construir",
			RightTrigger + "Tomar uno",
			InvSelectAction + "Tomar",
			InvSelectAction + "Poner",
			InvSelectAction + "Equipar",
			InvSelectAction + "Cambiar",
			RightTrigger + "Equipar",
			RightTrigger + "Abrir",
			InvSelectAction + "Volver a forjar",
			UseAction + "Mostrar recetas",
			InvSelectAction + "Crear",
			XButton + "Todo",
			XButton + "Disponible",
			YButton + "Ingredientes",
			YButton + "Recetas",
			BothTriggers + "Categoría",
			RightTrigger + "Comprar uno",
			UseAction + "Comprar",
			UseAction + "Vender",
			InvSelectAction + "Cancelar potenciador",
			InvSelectAction + "Asignar habitación",
			XButton + "Cobijo",
			YButton + "Mostrar banderas",
			YButton + "Ocultar banderas",
			"Sexo",
			"Dificultad",
			"Peinado",
			"Color de pelo",
			"Color de la ropa",
			"Color de la camisa",
			"Color de camiseta",
			"Color de los pantalones",
			"Color de los zapatos",
			"Color de la piel",
			"Color de los ojos",
			YButton + "Todo aleatorio",
			StartButton + "Crear personaje",
			BothSButtons + "Cambiar categoría",
			MoveAction + "Elegir color",
			MoveAction + "Elegir tipo",
			MoveAction + "Elegir sexo",
			MoveAction + "Elegir dificultad",
			MoveAction + "Cambiar volumen del sonido",
			MoveAction + "Cambiar volumen de la música",
			AButton + "Página siguiente",
			XButton + "Página anterior",
			MoveAction + "Avanzar texto",
			BothSButtons + "Cambiar marcador",
			XButton + "Mostrar inicio",
			XButton + "Mostrar mi posición",
			XButton + "Mostrar solo amigos",
			AButton + "Salir del juego",
			BButton + "Atrás",
			XButton + "Desbloquear juego completo"
		};

#if USE_ORIGINAL_CODE
		private static readonly ControlDesc[] MenuControlsEN = new ControlDesc[13] // This setup is messy and not very viable for setting up the HD positions.
		{
			new ControlDesc(0, 361, 144, "Grapple"),
			new ControlDesc(0, 592, 144, "Action"),
			new ControlDesc(3, 255, 198, "Previous Item"),
			new ControlDesc(2, 703, 198, "Next Item"),
			new ControlDesc(1, 174, 310, "Quick Shortcuts"),
			new ControlDesc(3, 255, 265, "Move/"), // This might actually be an inconsistency, since in PS3 1.0 and versions above, the sticks are present in the labels.
			new ControlDesc(3, 550, 420, "Aim/Switch Cursor Mode"),
			new ControlDesc(0, 437, 108, "Player List & World Map"),
			new ControlDesc(0, 520, 172, "Pause"),
			new ControlDesc(2, 703, 290, "Jump"),
			new ControlDesc(2, 703, 260, "Use"),
			new ControlDesc(2, 703, 320, "Drop"),
			new ControlDesc(2, 703, 230, "Inventory")
		};

		private static readonly ControlDesc[] MenuControlsDE = new ControlDesc[13]
		{
			new ControlDesc(0, 361, 140, "Entern"),
			new ControlDesc(0, 592, 140, "Action"),
			new ControlDesc(3, 255, 198, "Vorheriges Item"),
			new ControlDesc(2, 703, 198, "Nächstes Item"),
			new ControlDesc(1, 174, 310, "Schnelle Verknüpfungen"),
			new ControlDesc(3, 255, 265, "Bewegen/"),
			new ControlDesc(3, 550, 420, "Mit Cursor zielen/Cursor-Modus ändern"),
			new ControlDesc(0, 437, 106, "Spielerliste/Weltkarte"),
			new ControlDesc(0, 520, 168, "Pause"),
			new ControlDesc(2, 703, 290, "Springen"),
			new ControlDesc(2, 703, 260, "Nutzen"),
			new ControlDesc(2, 703, 320, "Fallenlassen"),
			new ControlDesc(2, 703, 230, "Inventar")
		};

		private static readonly ControlDesc[] MenuControlsFR = new ControlDesc[13]
		{
			new ControlDesc(0, 361, 140, "Grappin"),
			new ControlDesc(0, 592, 140, "Action"),
			new ControlDesc(3, 255, 198, "Objet précédent"),
			new ControlDesc(2, 703, 198, "Objet suivant"),
			new ControlDesc(1, 174, 310, "Raccourcis"),
			new ControlDesc(3, 255, 265, "Se déplacer/"),
			new ControlDesc(3, 550, 420, "Viser/Changer le mode curseur"),
			new ControlDesc(0, 437, 106, "Liste du joueur/carte du monde"),
			new ControlDesc(0, 520, 168, "Pause"),
			new ControlDesc(2, 703, 290, "Sauter"),
			new ControlDesc(2, 703, 260, "Utiliser"),
			new ControlDesc(2, 703, 320, "Lâcher"),
			new ControlDesc(2, 703, 230, "Inventaire")
		};
		
		private static readonly ControlDesc[] MenuControlsIT = new ControlDesc[13]
		{
			new ControlDesc(0, 361, 140, "Afferra"),
			new ControlDesc(0, 592, 140, "Azione"),
			new ControlDesc(3, 255, 198, "Oggetto precedente"),
			new ControlDesc(2, 703, 198, "Oggetto nuovo"),
			new ControlDesc(1, 174, 310, "Comandi rapidi"),
			new ControlDesc(3, 255, 265, "Sposta/"),
			new ControlDesc(3, 550, 420, "Apuntar/Cambiar modo de cursor"),
			new ControlDesc(0, 437, 106, "Lista giocatori/Mappa Mondo"),
			new ControlDesc(0, 520, 168, "Pausa"),
			new ControlDesc(2, 703, 290, "Salta"),
			new ControlDesc(2, 703, 260, "Utilizza"),
			new ControlDesc(2, 703, 320, "Lascia"),
			new ControlDesc(2, 703, 230, "Inventario")
		};

		private static readonly ControlDesc[] MenuControlsES = new ControlDesc[13]
		{
			new ControlDesc(0, 361, 140, "Agarrar"),
			new ControlDesc(0, 592, 140, "Acción"),
			new ControlDesc(3, 255, 198, "Objeto anterior"),
			new ControlDesc(2, 703, 198, "Objeto siguiente"),
			new ControlDesc(1, 174, 310, "Accesos directos"),
			new ControlDesc(3, 255, 265, "Mover/"),
			new ControlDesc(3, 550, 420, "Apuntar/Cambiar modo de cursor"),
			new ControlDesc(0, 437, 106, "Lista de jugadores/Mapa del mundo"),
			new ControlDesc(0, 520, 168, "Pausa"),
			new ControlDesc(2, 703, 290, "Saltar"),
			new ControlDesc(2, 703, 260, "Usar"),
			new ControlDesc(2, 703, 320, "Soltar"),
			new ControlDesc(2, 703, 230, "Inventario")
		};

		public static ControlDesc[] Controls()
		{
			switch (LangOption)
			{
			case 2:
				return MenuControlsDE;
			case 4:
				return MenuControlsFR;
			case 3:
				return MenuControlsIT;
			case 5:
				return MenuControlsES;
			default:
				return MenuControlsEN;
			}
		}
#else
		private static readonly string[] MenuControlsEN = new string[13]
		{
			"Grapple",
			"Action",
			"Previous Item",
			"Next Item",
			"Quick Shortcuts",
			"Move/" + LeftStickPress,
			"Aim/" + RightStickPress + "Switch Cursor Mode",
			"Player List & World Map",
			"Pause",
			"Jump",
			"Use",
			"Drop",
			"Inventory"
		};

		private static readonly string[] MenuControlsDE = new string[13]
		{
			"Entern",
			"Action",
			"Vorheriges Item",
			"Nächstes Item",
			"Schnelle Verknüpfungen",
			"Bewegen/" + LeftStickPress,
			"Mit Cursor zielen/" + RightStickPress + "Cursor-Modus ändern",
			"Spielerliste/Weltkarte",
			"Pause",
			"Springen",
			"Nutzen",
			"Fallenlassen",
			"Inventar"
		};

		private static readonly string[] MenuControlsFR = new string[13]
		{
			"Grappin",
			"Action",
			"Objet précédent",
			"Objet suivant",
			"Raccourcis",
			"Se déplacer/" + LeftStickPress,
			"Viser/" + RightStickPress + "Changer le mode curseur",
			"Liste du joueur/carte du monde",
			"Pause",
			"Sauter",
			"Utiliser",
			"Lâcher",
			"Inventaire"
		};

		private static readonly string[] MenuControlsIT = new string[13]
		{
			"Afferra",
			"Azione",
			"Oggetto precedente",
			"Oggetto nuovo",
			"Comandi rapidi",
			"Sposta/" + LeftStickPress,
			RightStickPress + "Modalità cursore Mira/Cambia",
			"Lista giocatori/Mappa Mondo",
			"Pausa",
			"Salta",
			"Utilizza",
			"Lascia",
			"Inventario"
		};

		private static readonly string[] MenuControlsES = new string[13]
		{
			"Agarrar",
			"Acción",
			"Objeto anterior",
			"Objeto siguiente",
			"Accesos directos",
			"Mover/" + LeftStickPress,
			"Apuntar/" + RightStickPress + "Cambiar modo de cursor",
			"Lista de jugadores/Mapa del mundo",
			"Pausa",
			"Saltar",
			"Usar",
			"Soltar",
			"Inventario"
		};

		public static ControlDesc[] Controls()
		{
			string[] MenuLabels = MenuControlsEN;
			switch (LangOption)
			{
				case (int)ID.GERMAN:
					MenuLabels = MenuControlsDE;
					break;
				case (int)ID.FRENCH:
					MenuLabels = MenuControlsFR;
					break;
				case (int)ID.ITALIAN:
					MenuLabels = MenuControlsIT;
					break;
				case (int)ID.SPANISH:
					MenuLabels = MenuControlsES;
					break;
			}

			if (Main.ScreenHeightPtr != ScreenHeights.FHD)
			{
				ControlDesc[] ControlLayout = new ControlDesc[13]
				{
					new ControlDesc(0, 361, 140, MenuLabels[0]),
					new ControlDesc(0, 592, 140, MenuLabels[1]),
					new ControlDesc(3, 255, 198, MenuLabels[2]),
					new ControlDesc(2, 703, 198, MenuLabels[3]),
					new ControlDesc(1, 174, 310, MenuLabels[4]),
					new ControlDesc(3, 255, 265, MenuLabels[5]),
					new ControlDesc(3, 550, 420, MenuLabels[6]),
					new ControlDesc(0, 437, 106, MenuLabels[7]),
					new ControlDesc(0, 520, 168, MenuLabels[8]),
					new ControlDesc(2, 703, 290, MenuLabels[9]),
					new ControlDesc(2, 703, 260, MenuLabels[10]),
					new ControlDesc(2, 703, 320, MenuLabels[11]),
					new ControlDesc(2, 703, 230, MenuLabels[12])
				};

				if (LangOption == (int)ID.ENGLISH)
				{
					ControlLayout[0].Y += 4;
					ControlLayout[1].Y += 4;
					ControlLayout[7].Y += 2;
					ControlLayout[8].Y += 4;
				}

				if (Main.ScreenHeightPtr == ScreenHeights.HD)
				{
					for (int Coordinate = 0; Coordinate < ControlLayout.Length; Coordinate++)
					{
						ControlLayout[Coordinate].X = (ushort)(ControlLayout[Coordinate].X * 1.15f);
						ControlLayout[Coordinate].Y = (ushort)(ControlLayout[Coordinate].Y * 1.15f);
					}
					ControlLayout[0].X += 105;	// Grapple or Jump
					ControlLayout[0].Y += 73;
					ControlLayout[1].X += 70;	// Action
					ControlLayout[1].Y += 75;
					ControlLayout[2].X += 120;	// Prev Item
					ControlLayout[2].Y += 60;
					ControlLayout[3].X += 58;	// Next Item
					ControlLayout[3].Y += 60;
					ControlLayout[4].X += 133;	// Quick Shortcuts
					ControlLayout[4].Y += 43;
					ControlLayout[5].X += 120;	// Move
					ControlLayout[5].Y += 50;
					ControlLayout[6].X += 175;	// Aim
					ControlLayout[6].Y += 30;
					ControlLayout[7].X += 95;	// World Map
					ControlLayout[7].Y += 80;
					ControlLayout[8].X += 83;	// Pause
					ControlLayout[8].Y += 68;
					ControlLayout[9].X += 58;	// Jump
					ControlLayout[9].Y += 48;
					ControlLayout[10].X += 58;	// Use
					ControlLayout[10].Y += 50;
					ControlLayout[11].X += 58;	// Drop
					ControlLayout[11].Y += 43;
					ControlLayout[12].X += 58;	// Inventory
					ControlLayout[12].Y += 55;

					if (Main.PSMode) // Touch-ups to account for sprite differences
					{
						ControlLayout[1].X -= 10;
						ControlLayout[4].X -= 3;
						ControlLayout[8].X -= 13;
					}
				}

				return ControlLayout;
			}
			else
			{
				// In 1080p mode, the controller sprite is upscaled by about 155%, which wouldn't be a hassle...
				// ..but since 1080p mode is only available on PS4/XBOne, the controller layout is different, and so are the labels.
				// Here is the arrangement extracted from the console versions. PS4 is modified as FNA/SDL3 cannot yet read touch data from the pad so XB1 zooming is used in its place; the label has been adjusted as a result.
				if (Main.PSMode)
				{
					ControlDesc[] ControlLayout = new ControlDesc[13]
					{
						new ControlDesc(0, 800, 395, MenuLabels[0]),	// Grapple
						new ControlDesc(0, 1130, 395, MenuLabels[1]),	// Action
						new ControlDesc(3, 614, 462, MenuLabels[2]),	// Prev Item
						new ControlDesc(2, 1323, 462, MenuLabels[3]),	// Next Item
						new ControlDesc(3, 597, 608, MenuLabels[4]),	// Move (was Quick Shortcuts)
						new ControlDesc(3, 614, 531, MenuLabels[5]),	// Quick Shortcuts (was Move)
						new ControlDesc(3, 1227, 793, MenuLabels[6]),	// Aim
						new ControlDesc(0, 1173, 318, MenuLabels[7]),	// World Map
						new ControlDesc(0, 971, 265, MenuLabels[8]),	// Pause
						new ControlDesc(2, 1323, 572, MenuLabels[9]),	// Jump
						new ControlDesc(2, 1323, 531, MenuLabels[10]),	// Use
						new ControlDesc(2, 1323, 619, MenuLabels[11]),	// Drop
						new ControlDesc(2, 1323, 491, MenuLabels[12])	// Inventory
					};
					return ControlLayout;
				}
				else
				{
					ControlDesc[] ControlLayout = new ControlDesc[13]
					{
						new ControlDesc(0, 783, 335, MenuLabels[0]),
						new ControlDesc(0, 1121, 335, MenuLabels[1]),
						new ControlDesc(3, 616, 434, MenuLabels[2]),
						new ControlDesc(2, 1319, 434, MenuLabels[3]),
						new ControlDesc(3, 613, 613, MenuLabels[4]),
						new ControlDesc(3, 615, 519, MenuLabels[5]),
						new ControlDesc(3, 1051, 766, MenuLabels[6]),
						new ControlDesc(0, 918, 283, MenuLabels[7]),
						new ControlDesc(0, 1001, 370, MenuLabels[8]),
						new ControlDesc(2, 1319, 557, MenuLabels[9]),
						new ControlDesc(2, 1319, 516, MenuLabels[10]),
						new ControlDesc(2, 1319, 606, MenuLabels[11]),
						new ControlDesc(2, 1319, 475, MenuLabels[12])
					};
					return ControlLayout;
				}
			}
		}
#endif


		public static readonly string[] ProjectileNames = new string[Projectile.MaxNumProjTypes]
		{
			null,
			"Wooden Arrow",
			"Fire Arrow",
			"Shuriken",
			"Unholy Arrow",
			"Jester's Arrow",
			"Enchanted Boomerang",
			"Vilethorn",
			"Vilethorn (end)",
			"Starfury",
			"Purification Powder",
			"Vile Powder",
			"Fallen Star",
			"Grappling Hook",
			"Musket Ball",
			"Ball of Fire",
			"Magic Missile",
			"Dirt Ball",
			"Orb of Light",
			"Flamarang",
			"Green Laser",
			"Bone",
			"Water Stream",
			"Harpoon",
			"Spiky Ball",
			"Ball 'O Hurt",
			"Blue Moon",
			"Water Bolt",
			"Bomb",
			"Dynamite",
			"Grenade",
			"Sand Ball",
			"Ivy Whip",
#if VERSION_FINAL
			"Thorn Chakram",
#else
			"Thorn Chakrum",
#endif
			"Flamelash",
			"Sunfury",
			"Meteor Shot",
			"Sticky Bomb",
			"Harpy Feather",
			"Mud Ball",
			"Ash Ball",
			"Hellfire Arrow",
			"Sand Ball",
			"Tombstone",
			"Demon Sickle",
			"Demon Scythe",
			"Dark Lance",
			"Trident",
			"Throwing Knife",
			"Spear",
			"Glowstick",
			"Seed",
			"Wooden Boomerang",
			"Sticky Glowstick",
			"Poisoned Knife",
			"Stinger",
			"Ebonsand Ball",
			"Cobalt Chainsaw",
			"Mythril Chainsaw",
			"Cobalt Drill",
			"Mythril Drill",
			"Adamantite Chainsaw",
			"Adamantite Drill",
			"The Dao of Pow",
			"Mythril Halberd",
			"Ebonsand Ball",
			"Adamantite Glaive",
			"Pearl Sand Ball",
			"Pearl Sand Ball",
			"Holy Water",
			"Unholy Water",
			"Silt Ball",
			"Blue Fairy",
			"Hook",
			"Hook",
			"Happy Bomb",
			"Note",
			"Note",
			"Note",
			"Rainbow",
			"Ice Block",
			"Wooden Arrow",
			"Flaming Arrow",
			"Eye Laser",
			"Pink Laser",
			"Flames",
			"Pink Fairy",
			"Green Fairy",
			"Purple Laser",
			"Crystal Bullet",
			"Crystal Shard",
			"Holy Arrow",
			"Hallow Star",
			"Magic Dagger",
			"Crystal Storm",
			"Cursed Flame",
			"Cursed Flame",
			"Cobalt Naginata",
			"Poison Dart",
			"Boulder",
			"Death laser",
			"Eye Fire",
			"Bomb",
			"Cursed Arrow",
			"Cursed Bullet",
			"Gungnir",
			"Light Disc",
			"Hamdrax",
			"Explosives",
			"Snow Ball",
			"Bullet",
			"Guinea Pig",
			"Tonbogiri",
			"Spectral Arrow",
			"Vulcan Bolt",
			"Slime",
			"Tiphia",
			"Bat",
			"Werewolf",
			"Zombie"
		};

		private static readonly string[] ItemPrefixEN = new string[84]
		{
			null,
			"Large",
			"Massive",
			"Dangerous",
			"Savage",
			"Sharp",
			"Pointy",
			"Tiny",
			"Terrible",
			"Small",
			"Dull",
			"Unhappy",
			"Bulky",
			"Shameful",
			"Heavy",
			"Light",
			"Sighted",
			"Rapid",
			"Hasty",
			"Intimidating",
			"Deadly",
			"Staunch",
			"Awful",
			"Lethargic",
			"Awkward",
			"Powerful",
			"Mystic",
			"Adept",
			"Masterful",
			"Inept",
			"Ignorant",
			"Deranged",
			"Intense",
			"Taboo",
			"Celestial",
			"Furious",
			"Keen",
			"Superior",
			"Forceful",
			"Broken",
			"Damaged",
			"Shoddy",
			"Quick",
			"Deadly",
			"Agile",
			"Nimble",
			"Murderous",
			"Slow",
			"Sluggish",
			"Lazy",
			"Annoying",
			"Nasty",
			"Manic",
			"Hurtful",
			"Strong",
			"Unpleasant",
			"Weak",
			"Ruthless",
			"Frenzying",
			"Godly",
			"Demonic",
			"Zealous",
			"Hard",
			"Guarding",
			"Armored",
			"Warding",
			"Arcane",
			"Precise",
			"Lucky",
			"Jagged",
			"Spiked",
			"Angry",
			"Menacing",
			"Brisk",
			"Fleeting",
			"Hasty",
			"Quick",
			"Wild",
			"Rash",
			"Intrepid",
			"Violent",
			"Legendary",
			"Unreal",
			"Mythical"
		};

		private static readonly string[] ItemPrefixDE = new string[84]
		{
			null,
			"Groß",
			"Riesig",
			"Gefährlich",
			"Barbarisch",
			"Scharf",
			"Spitz",
			"Winzig",
			"Schrecklich",
			"Klein",
			"Stumpf",
			"Unglücklich",
			"Sperrig",
			"Beschämend",
			"Schwer",
			"Leicht",
			"Gesichtet",
			"Schnell",
			"Hastig",
			"Einschüchternd",
			"Tödlich",
			"Unerschütterlich",
			"Schrecklich",
			"Lethargisch",
			"Unbeholfen",
			"Mächtig",
			"Mystisch",
			"Geschickt",
			"Meisterhaft",
			"Ungeschickt",
			"Unwissend",
			"Gestört",
			"Intensiv",
			"Tabu",
			"Himmlisch",
			"Wütend",
			"Scharf",
			"Überlegen",
			"Kraftvoll",
			"Gebrochen",
			"Beschädigt",
			"Schäbig",
			"Rasch",
			"Tödlich",
			"Agil",
			"Wendig",
			"Mörderisch",
			"Langsam",
			"Träge",
			"Faul",
			"Lästig",
			"Böse",
			"Manisch",
			"Verletzend",
			"Stark",
			"Unangenehm",
			"Schwach",
			"Rücksichtslos",
			"Rasend",
			"Fromm",
			"Dämonisch",
			"Eifrig",
			"Schwer",
			"Schützend",
			"Gepanzert",
			"Abwehrend",
			"Geheimnisvoll",
			"Präzise",
			"Glücklich",
			"Gezackt",
			"Spike",
			"Wütend",
			"Bedrohlich",
			"Rege",
			"Flüchtig",
			"Hastig",
			"Rasch",
			"Wild",
			"Voreilig",
			"Unerschrocken",
			"Gewalttätig",
			"Legendär",
			"Unwirklich",
			"Mythisch"
		};

		private static readonly string[] ItemPrefixIT = new string[84]
		{
			null,
			"Grande",
			"Massiccio",
			"Pericoloso",
			"Selvaggio",
			"Appuntito",
			"Tagliente",
			"Minuto",
			"Terribile",
			"Piccolo",
			"Opaco",
			"Infelice",
			"Ingombrante",
			"Vergognoso",
			"Pesante",
			"Luce",
			"Avvistato",
			"Rapido",
			"Frettoloso",
			"Intimidatorio",
			"Mortale",
			"Convinto",
			"Orribile",
			"Letargico",
			"Scomodo",
			"Potente",
			"Mistico",
			"Esperto",
			"Magistrale",
			"Inetto",
			"Ignorante",
			"Squilibrato",
			"Intenso",
			"Tabù",
			"Celeste",
			"Furioso",
			"Appassionato",
			"Superiore",
			"Forte",
			"Rotto",
			"Danneggiato",
			"Scadente",
			"Veloce",
			"Mortale",
			"Agile",
			"Lesto",
			"Omicida",
			"Lento",
			"Lento",
			"Pigro",
			"Fastidioso",
			"Cattivo",
			"Maniaco",
			"Offensivo",
			"Robusto",
			"Sgradevole",
			"Debole",
			"Spietato",
			"Frenetico",
			"Devoto",
			"Diabolico",
			"Zelante",
			"Duro",
			"Protettivo",
			"Corazzato",
			"Difensivo",
			"Arcano",
			"Preciso",
			"Fortunato",
			"Frastagliato",
			"Spillo",
			"Arrabbiato",
			"Minaccioso",
			"Vivace",
			"Fugace",
			"Frettoloso",
			"Veloce",
			"Selvaggio",
			"Temerario",
			"Intrepido",
			"Violento",
			"Leggendario",
			"Irreale",
			"Mitico"
		};

		private static readonly string[] ItemPrefixFR = new string[84]
		{
			null,
			"Grand",
			"Massif",
			"Dangereuses",
			"Sauvages",
			"Coupante",
			"Pointues",
			"Minuscules",
			"Terrible",
			"Petit",
			"Terne",
			"Malheureux",
			"Volumineux",
			"Honteux",
			"Lourds",
			"Léger",
			"Voyants",
			"Rapide",
			"Hâtif",
			"Intimidant",
			"Mortelle",
			"Dévoué",
			"Affreux",
			"Léthargique",
			"Scomodo",
			"Puissante",
			"Mystique",
			"Expert",
			"Magistrale",
			"Inepte",
			"Ignorants",
			"Dérangé",
			"Intenses",
			"Tabou",
			"Célestes",
			"Furieux",
			"Vif",
			"Supérieure",
			"Énergique",
			"Rompu",
			"Endommagés",
			"Mesquin",
			"Prompt",
			"Mortelle",
			"Agile",
			"Leste",
			"Meurtrier",
			"Lente",
			"Paresseux",
			"Fainéant",
			"Ennuyeux",
			"Méchant",
			"Maniaco",
			"Blessant",
			"Robuste",
			"Désagréables",
			"Faibles",
			"Impitoyable",
			"Frénétique",
			"Pieux",
			"Démoniaque",
			"Zélé",
			"Durs",
			"Protecteur",
			"Blindés",
			"Défensif",
			"Ésotérique",
			"Précise",
			"Chanceux",
			"Déchiqueté",
			"Pointes",
			"Fâché",
			"Menaçant",
			"Brusque",
			"Fugace",
			"Hâtif",
			"Prompt",
			"Sauvages",
			"Téméraire",
			"Intrépide",
			"Violent",
			"Légendaire",
			"Irréel",
			"Mythique"
		};

		private static readonly string[] ItemPrefixES = new string[84]
		{
			null,
			"Grande",
			"Enorme",
			"Peligroso",
			"Salvaje",
			"Afilado",
			"Puntiagudo",
			"Diminuto",
			"Mala ",
			"Pequeño",
			"Aburrido",
			"Infeliz",
			"Voluminoso",
			"Vergonzoso",
			"Pesado",
			"Ligero",
			"Perspicaz",
			"Rápido",
			"Precipitado",
			"Intimidante",
			"Mortal",
			"Firme",
			"Atroz",
			"Letárgico",
			"Torpe",
			"Poderoso",
			"Místico",
			"Experto",
			"Maestro",
			"Inepto",
			"Ignorante",
			"Trastornado",
			"Intenso",
			"Prohibido",
			"Celeste",
			"Furioso",
			"Incisivo",
			"Superior",
			"Fuerte",
			"Roto",
			"Estropeado",
			"Chapucero",
			"Veloz",
			"Mortal",
			"Ágil",
			"Listo",
			"Asesino",
			"Lento",
			"Perezoso",
			"Gandul",
			"Molesto",
			"Feo",
			"Maníaco",
			"Hiriente",
			"Vigoroso",
			"Desagradable",
			"Débil",
			"Despiadado",
			"Frenético",
			"Piadoso",
			"Demoníaco",
			"Fanático",
			"Duro",
			"Protector",
			"Blindado",
			"Defensivo",
			"Arcano",
			"Preciso",
			"Afortunado",
			"Dentado",
			"Claveteado",
			"Enojado",
			"Amenazante",
			"Enérgico",
			"Fugaz",
			"Precipitado",
			"Veloz",
			"Salvaje",
			"Temerario",
			"Intrépido",
			"Violento",
			"Legendario",
			"Irreal",
			"Mítico"
		};

		private static readonly string[] TutorialEN = new string[80]
		{
			"Terraria is a game about adventuring to the ends of the World and defeating villainous bosses along the way. This tutorial will teach you the basics.\n ",
			"<c>Press " + BButton + " to continue.",
			"Use " + MoveAction + " to move around.",
			"Press " + JumpAction + " to jump.",
			"You can fall through wood platforms by pressing down " + MoveAction + ". Try falling through the platform.",
			"Now jump out by pressing " + JumpAction + ".",
			"Press (or hold) " + RightTrigger + " to perform actions with the current item. Aim with " + ControlModeAction + ".",
			"At the top of your screen is the Inventory Bar. You can switch between items with " + LeftSButton + " & " + RightSButton + ". Now switch to your sword.",
			"An evil monster has appeared. Defeat it with your sword by pressing " + RightTrigger + ".",
			"Terraria is full of monsters, especially at night. Luckily there are many weapons you can find to help you.\n ",
			"<c>Press " + BButton + " to continue.",
			"If you get hurt, you will heal over time. You can also use food or healing potions.\n ",
			"<c>Press " + BButton + " to continue.",
			"Killing that slime gave you a gel. If you had wood to combine it with, you could craft a torch. Let's gather some wood.\n ",
			"<c>Press " + BButton + " to continue.",
			"To chop down a tree you must use an axe. Switch to your axe.",
			"Chop down a tree by aiming toward one and holding " + RightTrigger + ".",
			"All the items you pick up go into your Inventory. Press " + InventoryAction + " to open the Inventory Menu.",
			"The Inventory Menu is split into sections. This area is your main Inventory. The top row of item slots is your Inventory Bar. There are also slots for ammo (such as arrows) or coins.\n ",
			"<c>Press " + BButton + " to continue.",
			"Use " + MoveAction + " to move between slots. Use " + InvSelectAction + " to pick up and place stacks of items. Use " + RightTrigger + " to move one item at a time.\n ",
			"<c>Press " + BButton + " to continue.",
			"To permanently delete an item, move it to the Trash slot or press " + XButton + ".\n ",
			"<c>Press " + BButton + " to continue.",
			"Press " + RightSButton + " to switch to the Equip section.",
			"The Equip section is where you place armor and accessories. Items in Vanity slots appear on your character, but do not give armor bonuses.\n ",
			"<c>Press " + BButton + " to continue.",
			"If you activate a chest or vendor NPC, a separate section will appear for it.\n ",
			"<c>Press " + BButton + " to continue.",
			"Press " + LeftSButton + " or " + RightSButton + " until you switch to the Crafting section.",
			"The gel and wood you collected can be crafted into a torch. Select the torch icon and press " + InvSelectAction + " to create it.",
			"If you want to find out more about a recipe's ingredients, you can press " + YButton + " to enter or exit the Ingredients area.\n ",
			"<c>Press " + BButton + " to continue.",
			"There are several categories of crafting items. You can switch between them by pressing " + LeftTrigger + " and " + RightTrigger + ".",
			"Press " + LeaveInvAction + " to exit Crafting.",
			"To create better items and explore the vast underground, you will need to dig down and mine ore with a pickaxe. Switch to your pickaxe.",
			"Nearby there is a vein of ore. Mine it all by aiming toward it and holding " + RightTrigger + ".",
			"As you dig deeper underground, you will find better ores. Some may require a better pickaxe to mine.\n ",
			"<c>Press " + BButton + " to continue.",
			"If you get stuck in a hole, you can place wood platforms to get out. Craft 5 wood platforms.",
			"Press " + YButton + " to open the Inventory Menu. Switch to Crafting with " + LeftSButton + " and " + RightSButton + ".",
			"Now select the wood platforms in your Inventory Bar.",
			"Placing items and structures is easier in the Manual Cursor Mode. Press " + RightStickPress + " to switch your Cursor Mode.",
			"In Manual Cursor Mode " + MoveCursorAction + " acts like a mouse. Aim the cursor and press " + RightTrigger + " to place wood platforms.\n\n",
			"Build enough so you can jump out of the hole.",
			"Remember you can switch between Cursor Modes at any time by pressing " + RightStickPress + ".\n ",
			"<c>Press " + BButton + " to continue.",
			"It's dangerous to be outside at night. Build a shelter before it gets dark.\n ",
			"<c>Press " + BButton + " to continue.",
			"To start, build walls and a ceiling. Give yourself plenty of room inside. If you don't have enough wood (or stone), gather more.",
			"\n\nA shelter must be at least 6 blocks high and 10 blocks wide.",
			"You'll need a door to get in and out. Remove 3 blocks from the bottom of a wall to make room.",
			"\n\nUse an axe to remove wood blocks, or a pickaxe to remove stone blocks.",
			"To craft a door, you need a work bench. Craft a work bench and place it inside your house.",
			"\nIf you don't have enough wood, chop down more trees.",
			"When you are standing near a work bench or other crafting station (such as an anvil or furnace), more recipes will be available to build in your Crafting menu.\n ",
			"<c>Press " + BButton + " to continue.",
			"Stand near your crafting table and craft a door.",
			"\nIf you don't have enough wood, chop down more trees.",
			"Now place the door in the space in the wall. This can be tricky, and is easiest in the Manual Cursor Mode, " + RightStickPress + ".",
			"You can open or close your door. Aim at it and press " + InteractAction + ".",
			"You're almost done. To make your house safe, you will need to panel the background of your house with walls (such as wood walls).\n ",
			"<c>Press " + BButton + " to continue.",
			"Craft a bunch of wood walls at your work bench.",
			"\nIf you don't have enough wood, chop down more trees.",
			"Panel the background of your house with wood walls. This is easiest in the Auto Cursor Mode, " + RightStickPress + ".",
			"Make sure to cover the entire background.",
			"Your house is now safe. For a room to be livable for NPCs, it needs: a table (such as your work bench), a chair, and a light source (such as a torch).\n ",
			"<c>Press " + BButton + " to continue.",
			"Craft a chair and place it in your house.",
			"Now place a torch on the walls or floor of your house. This is easiest in Manual Cursor Mode, " + RightStickPress + ".",
			"This room is now livable for NPCs. As you progress, there are many NPCs who can move into your house if you have enough livable rooms for them.\n ",
			"<c>Press " + BButton + " to continue.",
			"The Guide is the first NPC who can move into your house. You can talk to him for tips or details about crafting ingredients.\n ",
			"<c>Press " + BButton + " to continue.",
			"If you ever want to destroy furniture or background walls, you can craft a hammer to do so.\n ",
			"<c>Press " + BButton + " to continue.",
			"Congratulations, you have completed the tutorial. There are only a few areas to explore on this floating island. When you are ready, exit the tutorial and create yourself a whole new World!\n ",
			"<c>Press " + BButton + " to continue.",
			null
		};

		private static readonly string[] TutorialDE = new string[80]
		{
			"Terraria ist ein Spiel, in dem du dich bis ans Ende der Welt wagst und unterwegs bösartige Endgegner besiegst. Dieses Tutorial bringt dir die Grundlagen dafür bei.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Bewege dich mit " + MoveAction + ".",
			"Springe mit " + JumpAction + ".",
			"Du kannst durch Holzplattformen fallen, indem du " + MoveAction + " nach unten drückst. Versuche, durch eine Plattform zu fallen.",
			"Springe heraus, indem du " + JumpAction + " drückst.",
			"Drücke (oder halte) " + RightTrigger + ", um Aktionen mit einem Gegenstand durchzuführen. Ziele mit " + ControlModeAction + ".",
			"Am oberen Ende des Bildschirms befindet sich deine Inventarleiste. Mit" + LeftSButton + " & " + RightSButton + " kannst du zwischen Gegenständen wechseln. Wechsle zu deinem Schwert.",
			"Ein böses Monster ist erschienen. Besiege es mit deinem Schwert, indem du " + RightTrigger + " drückst.",
			"Terraria ist voller Monster, besonders nachts. Zum Glück kannst du viele Waffen finden, die dir helfen.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Wenn du verletzt wirst, regenerierst du dich mit der Zeit wieder. Du kannst dazu auch Nahrung oder Heiltränke verwenden.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Die Zerstörung des Schleims hat dir ein Gel eingebracht. Wenn du Holz hättest, könntest du damit eine Fackel herstellen. Lass uns Holz sammeln.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Zum Fällen eines Baumes musst du eine Axt benutzen. Wechsle zu deiner Axt.",
			"Fälle einen Baum, indem du auf ihn zielst und " + RightTrigger + " hältst.",
			"Alle von dir gesammelten Gegenstände gehen in dein Inventar. Drücke " + InventoryAction + ", um das Inventarmenü zu öffnen.",
			"Das Inventar-Menü ist in Sektionen unterteilt. Diese Sektion ist dein Hauptinventar. Die obere Reihe Gegenstand-Slots ist deine Inventarleiste. Es gibt auch Slots für Munition (z.B. Pfeile) oder Münzen.\n ",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Wechsle mit " + MoveAction + " zwischen den Slots. Nimm mit " + InvSelectAction + " einen Stapel von Gegenständen auf und platziere ihn. Bewege jeweils einen Gegenstand mit " + RightTrigger + ".\n ",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Um einen Gegenstand für immer zu löschen, lege ihn auf den Müll-Slot oder drücke " + XButton + ". \n ",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Wechsle durch Drücken von " + RightSButton + " zur Ausrüstungssektion.",
			"In der Ausrüstungssektion legst du deine Rüstung und dein Zubehör ab. Gegenstände in den Verzierungs-Slots erscheinen an deinem Charakter und verleihen keine Rüstungsboni.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Wenn du eine Schatzkiste oder einen Verkäufer-NPC aktivierst, erscheint dafür eine separate Sektion.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Drücke " + LeftSButton + " oder " + RightSButton + ", bis du zu der Herstellungssektion wechselst.",
			"Die gesammelten Gegenstände Gel und Holz können zu einer Fackel verarbeitet werden. Wähle das Fackelsymbol und drücke " + InvSelectAction + ", um sie anzufertigen.",
			"Wenn du mehr über eine Anleitung herausfinden möchtest, kannst du mit " + YButton + " die Sparte für Bestandteile anwählen oder verlassen.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Es gibt verschiedene Kategorien von herstellbaren Gegenständen. Durch Drücken von " + LeftTrigger + " und " + RightTrigger + " kannst du zwischen ihnen wechseln.",
			"Verlasse die Herstellungssektion durch Drücken von " + LeaveInvAction + ".",
			"Du brauchst eine Spitzhacke zur Herstellung besserer Gegenstände und zur Erforschung der Unterwelt. Mit ihr kannst du graben und Erz abbauen. Wechsle zu deiner Spitzhacke.",
			"In der Nähe befindet sich eine Erzader. Baue sie ab, indem du auf sie zielst und " + RightTrigger + " hältst.",
			"Wenn du tiefer in den Untergrund gräbst, findest du bessere Erze. Für manche brauchst du eine bessere Spitzhacke, um sie abzubauen.\n ",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Wenn du in einem Loch steckst, kannst du Holzplattformen errichten, um herauszukommen. Errichte fünf Holzplattformen.",
			"Drücke " + YButton + ", um das Inventarmenü zu öffnen. Wechsle mit " + LeftSButton + " und " + RightSButton + " zur Herstellungssektion.",
			"Wähle nun die Holzplattformen in deiner Inventarleiste.",
			"Gegenstände und Bauwerke können im manuellen Cursor-Modus leichter platziert werden. Drücke " + RightStickPress + ", um deinen Cursor-Modus zu wechseln.",
			"Im manuellen Cursor-Modus verhält sich " + MoveCursorAction + " wie eine Maus. Ziele mit dem Cursor und drücke " + RightTrigger + ", um Holzplattformen zu platzieren.\n\n",
			"Baue hoch genug, um aus dem Loch herauszuspringen.",
			"Denk daran, dass du jederzeit mit " + RightStickPress + " zwischen den Cursor-Modi wechseln kannst.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Es ist gefährlich, nachts draußen zu sein. Baue eine Unterkunft, bevor es dunkel wird.\n ",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Errichte zuerst Wände und ein Dach. Gestalte den Innenraum weiträumig. Falls du nicht genug Holz (oder Steine) hast, sammle mehr davon.",
			"\n\nEine Unterkunft muss mindestens sechs Blöcke hoch und zehn Blöcke breit sein.",
			"Du benötigst eine Tür, um hinein-und hinauszukommen. Entferne drei Blöcke an der Unterseite einer Wand, um Platz zu schaffen.",
			"\n\nBenutze eine Axt, um Holzblöcke zu entfernen oder eine Spitzhacke, um Steinblöcke zu entfernen.",
			"Zur Herstellung einer Tür benötigst du eine Werkbank. Errichte eine Werkbank und platziere sie in deinem Haus.",
			"\nFälle mehr Bäume, wenn du nicht genug Holz hast.",
			"Wenn du in der Nähe einer Werkbank oder anderer Arbeitsgeräte (wie z.B. Amboss oder Schmelzofen) stehst, sind mehr Anleitungen in deinem Herstellungsmenü verfügbar.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Stelle dich neben deine Werkbank und stelle eine Tür her.",
			"\nFälle mehr Bäume, wenn du nicht genug Holz hast.",
			"Platziere nun die Tür in der Aussparung der Wand. Dies kann knifflig sein und lässt sich am einfachstem im manuellen Cursor-Modus erledigen, " + RightStickPress + ".",
			"Du kannst die Tür öffnen oder schließen. Ziele darauf und drücke " + InteractAction + ".",
			"Du bist fast fertig. Um dein Haus sicher zu machen, musst du die Rückseite deines Hauses mit Wänden (wie z.B. Holzwänden) vertäfeln.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Stelle Holzwände auf deiner Werkbank her.",
			"\nFälle mehr Bäume, wenn du nicht genug Holz hast.",
			"Vertäfle die Rückseite deines Hauses mit Holzwänden. Am einfachsten lässt sich das im manuellen Cursor-Modus erledigen " + RightStickPress + ".",
			"Achte darauf, die gesamte Rückseite abzudecken.",
			"Dein Haus ist jetzt sicher. Damit NPCs in einem Raum leben können, brauchst du: Tisch (wie z.B. eine Werkbank), Stuhl und Lichtquelle (wie z.B. eine Fackel).\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Stelle einen Stuhl her und platziere ihn in deinem Haus.",
			"Platziere nun eine Fackel an der Wand oder auf dem Boden des Hauses. Am einfachsten lässt sich das im manuellen Cursor-Modus erledigen " + RightStickPress + ".",
			"Dieser Raum kann jetzt von NPCs bewohnt werden. Je weiter du vorankommst, desto mehr NPCs können in dein Haus einziehen, sofern du genug bewohnbare Räume für sie hast.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Der Ratgeber ist der erste NPC, der in dein Haus einziehen kann. Du kannst mit ihm reden und Tipps oder Details zu Herstellungsbestandteilen erhalten.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Wenn du Möbel oder Rückwände zerstören willst, kannst du dafür einen Hammer herstellen.\n",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			"Herzlichen Glückwunsch, du hast das Tutorial abgeschlossen. Es gibt nur ein paar wenige Areale auf dieser schwimmenden Insel zu erkunden.Beende das Tutorial und erschaffe eine komplett neue Welt, sobald du bereit dazu bist!\n ",
			"<c>Drücke " + BButton + ", um fortzufahren.",
			null
		};

		private static readonly string[] TutorialFR = new string[80]
		{
			"Terraria est un jeu qui entraîne le joueur au bout du monde et lui fait affronter les boss infâmes se dressant sur son chemin. Ce didacticiel va vous enseigner les bases.\n",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Utilisez " + MoveAction + " pour vous déplacer.",
			"Appuyez sur " + JumpAction + " pour sauter.",
			"Vous pouvez passer au travers des plateformes en bois en appuyant sur " + MoveAction + ".  Essayez de passer au travers de la plateforme.",
			"Maintenant, sautez de la plateforme en appuyant sur " + JumpAction + ".",
			"Appuyez sur (ou maintenez) " + RightTrigger + " pour réaliser des actions avec l'objet tenu. Visez avec " + ControlModeAction + ".",
			"La barre d'inventaire figure en haut de votre écran. Vous pouvez changer d'objet avec " + LeftSButton + " et " + RightSButton + ". Maintenant, prenez votre épée.",
			"Un monstre diabolique est apparu. Vainquez-le à l'aide de votre épée en appuyant sur " + RightTrigger + ".",
			"Terraria grouille de monstres, surtout la nuit. Heureusement, vous pouvez trouver beaucoup d'armes qui vous seront d'une grande aide.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"En cas de blessure, vous guérirez au fil du temps. Vous pouvez également utiliser de la nourriture ou des potions de soin.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Tuer ce slime vous a rapporté un gel. En le combinant avec du bois, vous pourriez fabriquer une torche. Ramassons du bois.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Pour couper un arbre, il vous faut une hache. Prenez votre hache.",
			"Coupez un arbre en le visant tout en maintenant " + RightTrigger + ".",
			"Tous les objets que vous collectez vont dans votre inventaire. Appuyez sur " + InventoryAction + " pour ouvrir le menu Inventaire.",
			"Le menu Inventaire est divisé en sections. Cette zone représente votre inventaire principal. La ligne supérieure des emplacements pour objets est votre barre d'inventaire. Il y a également des emplacements pour les munitions (comme les flèches) ou pour les pièces.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Utilisez " + MoveAction + " pour vous déplacer dans les emplacements. Utilisez " + InvSelectAction + " pour prendre et placer des piles d'objets. Utilisez " + RightTrigger + " pour déplacer un seul objet à la fois.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Pour supprimer définitivement un objet, placez-le sur l'emplacement Poubelle ou appuyez sur " + XButton + ". \n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Appuyez sur " + RightSButton + " pour passer à la section Équiper.",
			"La section Équiper est celle dans laquelle vous placez vos armures et vos accessoires. Les objets des emplacements Vanité apparaissent sur votre personnage, mais ne confèrent aucun bonus d'armure.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Une section séparée apparaîtra si vous activez un coffre ou un PNJ vendeur.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Appuyez sur " + LeftSButton + " ou " + RightSButton + " jusqu'à la section Artisanat.",
			"Vous pouvez combiner le gel et le bois que vous avez collectés pour fabriquer une torche. Sélectionnez l'icône de la torche et appuyez sur " + InvSelectAction + " pour la créer.",
			"Si vous voulez en savoir plus sur les ingrédients d'une recette, vous pouvez appuyer sur " + YButton + " pour entrer dans la zone Ingrédients ou en sortir.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Il existe plusieurs catégories d'objets d'artisanat. Vous pouvez les consulter en appuyant sur " + LeftTrigger + " et " + RightTrigger + ".",
			"Appuyez sur " + LeaveInvAction + " pour quitter Artisanat.",
			"Pour créer de meilleurs objets et explorer les immenses souterrains, vous devrez creuser et extraire du minerai à l'aide d'une pioche. Prenez votre pioche.",
			"Il y a une veine de minerai dans les environs. Exploitez-la entièrement en la visant tout en maintenant " + RightTrigger + ".",
			"En creusant plus profondément, vous trouverez de meilleurs minerais. Vous aurez peut-être besoin d'une pioche plus solide pour en extraire certains.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Si vous êtes dans un trou, vous pouvez placer des plateformes en bois pour en sortir. Fabriquez 5 plateformes en bois.",
			"Appuyez sur " + YButton + " pour ouvrir le menu Inventaire. Accédez à Artisanat avec " + LeftSButton + " et " + RightSButton + ".",
			"Sélectionnez les plateformes en bois dans votre barre d'inventaire.",
			"Le mode Curseur manuel permet de placer des objets et structures plus facilement. Appuyez sur " + RightStickPress + " pour changer le mode Curseur.",
			"En mode Curseur manuel, " + MoveCursorAction + " a la même fonction qu'une souris. Visez avec le curseur et appuyez sur " + RightTrigger + " pour placer les plateformes en bois.\n\n",
			"Construisez-en assez pour pouvoir sortir du trou.",
			"N'oubliez pas que vous pouvez changer de mode Curseur à tout moment en appuyant sur " + RightStickPress + ".\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"C'est dangereux d'être dehors quand il fait nuit. Construisez un abri avant la tombée de la nuit.\n",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Pour commencer, construisez les murs et le plafond. Accordez-vous beaucoup d'espace intérieur. Si vous n'avez pas assez de bois (ou de pierres), collectez-en plus.",
			"\n\nUn abri doit avoir au moins 6 blocs de hauteur et 10 blocs de largeur.",
			"Vous aurez besoin d'une porte pour entrer et sortir. Supprimez 3 blocs du bas d'un des murs pour réserver cet espace.",
			"\n\nUtilisez une hache pour supprimer les blocs de bois ou une pioche pour supprimer les blocs de pierre.",
			"Vous aurez besoin d'un établi pour fabriquer une porte. Fabriquez un établi et placez-le dans votre maison.",
			"\nSi vous n'avez pas assez de bois, coupez plus d'arbres.",
			"Lorsque vous vous tenez près d'un établi ou d'une autre station d'artisanat (comme une enclume ou une fournaise), de nouvelles recettes apparaîtront dans votre menu Artisanat.\n '",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Placez-vous à côté de votre établi et fabriquez une porte.",
			"\nSi vous n'avez pas assez de bois, coupez plus d'arbres.",
			"Placez maintenant la porte dans l'espace réservé du mur. Ceci peut s'avérer délicat et le mode Curseur manuel vous facilitera la tâche, " + RightStickPress + ".",
			"Vous pouvez ouvrir ou fermer votre porte. Visez-la et appuyez sur " + InteractAction + ".",
			"C'est presque fini. Pour sécuriser votre maison, vous devrez en recouvrir le fond de murs (par exemple, des murs en bois).\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Fabriquez une réserve de murs en bois à votre établi.",
			"\nSi vous n'avez pas assez de bois, coupez plus d'arbres.",
			"Recouvrez le fond de votre maison de murs en bois. Le mode Curseur auto vous facilitera la tâche, " + RightStickPress + ".",
			"Veillez à bien recouvrir la totalité du mur du fond.",
			"Votre maison est maintenant sûre. Afin qu'un PNJ puisse vivre dans une chambre, il faut\u00a0: une table (par exemple, votre établi), une chaise et une source de lumière (par exemple, une torche).\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Fabriquez une chaise et placez-la dans votre maison.",
			"Placez maintenant une torche aux murs ou sur le sol de votre maison. Le mode Curseur manuel vous facilitera la tâche, " + RightStickPress + ".",
			"Cette pièce est désormais habitable pour les PNJ. Au fur et à mesure de votre progression, plusieurs PNJ pourront s'installer dans votre maison si vous avez suffisamment de chambres habitables.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Le guide est le premier PNJ à pouvoir s'installer dans votre maison. Vous pouvez lui parler pour obtenir des conseils et des détails sur les ingrédients d'artisanat.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Vous pouvez fabriquer un marteau si jamais vous souhaitez détruire un meuble ou les murs du fond.\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			"Félicitations, vous avez achevé le didacticiel. Il n'y a que quelques zones à explorer sur cette île flottante.Quand vous serez prêt(e), quittez le didacticiel et créez-vous un monde complètement nouveau\u00a0!\n ",
			"<c>Appuyez sur " + BButton + " pour continuer.",
			null
		};

		private static readonly string[] TutorialIT = new string[80]
		{
			"Terraria è un gioco d'avventura per spingersi ai confini del Mondo e sconfiggere i perfidi boss sul tuo cammino. Questo tutorial te ne insegnerà le basi.\n",
			"<c>Premi " + BButton + " per continuare.",
			"Utilizza " + MoveAction + " per spostarti.",
			"Premi " + JumpAction + " per saltare.",
			"Puoi passare attraverso le piattaforme di legno, premendo in giù " + MoveAction + ". Prova a passare attraverso una piattaforma di legno.",
			"Quindi salta fuori, premendo " + JumpAction + ".",
			"Premi (o tieni premuto) " + RightTrigger + " per eseguire un'azione con l'oggetto in uso. Punta con " + ControlModeAction + ".",
			"La barra dell'Inventario si trova nella parte superiore dello schermo. È possibile passare da un oggetto all'altro con " + LeftSButton + " & " + RightSButton + ". Adesso passa alla spada.",
			"È apparso un mostro malvagio. Sconfiggilo con la spada, premendo " + RightTrigger + ".",
			"Terraria è piena di mostri, specialmente di notte. Per fortuna, puoi trovare molte armi che ti saranno di grande aiuto.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Se ti fai male, guarirai col tempo. Puoi anche usare del cibo o pozioni di guarigione.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"L'uccisione dello Slime ti ha fornito della gelatina. Combinandola con la legna, otterrai una torcia. Raccogliamo un po' di legna!\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Per abbattere un albero userai un'ascia. Passa all'ascia.",
			"Per abbattere un albero, puntane uno e tieni premuto " + RightTrigger + ".",
			"Tutti gli oggetti raccolti vanno nell'Inventario. Premi " + InventoryAction + " per aprire il menu dell'Inventario.",
			"Il menu dell'Inventario è diviso in sezioni. Quest'area costituisce l'Inventario principale. La riga superiore degli slot degli oggetti è la tua barra dell'Inventario. Inoltre, sono presenti slot per le munizioni (es. frecce) o per le monete.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Utilizza " + MoveAction + " per spostarti da uno slot all'altro. Utilizza " + InvSelectAction + " per raccogliere e posizionare gli oggetti accumulati. Utilizza " + RightTrigger + " per spostare un oggetto alla volta.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Sposta l'oggetto nella sezione del Cestino o premi " + XButton + ", per eliminarlo definitivamente. \n ",
			"<c>Premi " + BButton + " per continuare.",
			"Premi " + RightSButton + " per passare alla sezione Equipaggiamento.",
			"Nella sezione Equipaggiamento si trovano armature e accessori. Gli oggetti negli slot di Estetica sappaiono sul personaggio, ma non forniscono bonus per le armature.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Se attivi una cassa o un venditore PNG, apparirà una sezione apposita.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Premi " + LeftSButton + " o " + RightSButton + " finché non passi alla sezione Creazione Oggetti.",
			"Con la gelatina e la legna raccolte puoi creare una torcia. Seleziona l'icona della torcia e premi " + InvSelectAction + " per crearla.",
			"Per ottenere maggiori informazioni sugli ingredienti delle formule, premi " + YButton + " per entrare o uscire dall'area Ingredienti.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Ci sono diverse categorie di oggetti da creare.Puoi scorrerli premendo " + LeftTrigger + " e " + RightTrigger + ".",
			"Premi " + LeaveInvAction + " per uscire dalla sezione Creazione Oggetti.",
			"È necessario scavare ed estrarre minerali con un piccone per creare oggetti migliori ed esplorare gli immensi sotterranei. Passa al piccone.",
			"C'è un filone di minerali nei paraggi. Estrailo completamente, puntando su di esso e tenendo premuto " + RightTrigger + ".",
			"Quanto più scavi in profondità, tanto migliori saranno i minerali. Alcuni di questi richiedono un piccone migliore per essere estratti.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Se resti bloccato in un buco, è possibile posizionare delle piattaforme di legno per uscire. Crea 5 piattaforme di legno.",
			"Premi " + YButton + " per aprire il menu dell'Inventario. Passa alla sezione Creazione Oggetti premendo " + LeftSButton + " e " + RightSButton + ".",
			"Ora seleziona le piattaforme di legno dalla barra dell'Inventario",
			"È più facile posizionare oggetti e strutture nella modalità Cursore Manuale. Premi " + RightStickPress + " per cambiare modalità Cursore.",
			"Nella modalità Cursore Manuale, " + MoveCursorAction + " funge da mouse. Punta il cursore e premi " + RightTrigger + " per posizionare le piattaforme di legno.\n\n",
			"Costruisci abbastanza piattaforme per saltare fuori dal buco.",
			"Ricorda che puoi passare da una modalità Cursore all'altra in qualunque momento, premendo " + RightStickPress + ".\n ",
			"<c>Premi " + BButton + " per continuare.",
			"È pericoloso trovarsi fuori di notte. Costruisci un rifugio prima che faccia buio!\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Inizia a costruire i muri e il soffitto. Crea un ambiente spazioso e raccogli altra legna (o pietre) se non ne possiedi abbastanza.",
			"\n\nIl rifugio deve essere alto almeno 6 blocchi e largo 10 blocchi.",
			"Ti serve una porta per entrare e uscire. Rimuovi 3 blocchi dalla parte inferiore di un muro per fare spazio.",
			"\n\nUtilizza un'ascia per rimuovere i blocchi di legno o un piccone per rimuovere i blocchi di pietra.",
			"Per fare una porta ti serve un banco da lavoro. Crea un banco da lavoro e posizionalo all'interno dell'abitazione.",
			"\nAbbatti altri alberi se non possiedi abbastanza legna.",
			"Quando sei vicino a un banco da lavoro o a un'altra unità per la creazione (es. un'incudine o una fornace), nel menu Creazione Oggetti saranno disponibili più formule.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Avvicinati al banco da lavoro e fai una porta.",
			"\nAbbatti altri alberi se non possiedi abbastanza legna.",
			"Adesso posiziona la porta nello spazio creato nel muro. È complicato, ma risulta più facile nella modalità Cursore Manuale " + RightStickPress + ".",
			"Puoi aprire e chiudere la porta. Punta su di essa e premi " + InteractAction + ".",
			"Ci sei quasi! Per rendere sicura l'abitazione, è necessario rivestire lo sfondo di quest'ultima con dei muri (es. muri di legno).\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Crea un set di muri di legno sul banco da lavoro.",
			"\nAbbatti altri alberi se non possiedi abbastanza legna.",
			"Rivesti lo sfondo dell'abitazione con muri di legno. Il compito risulta più facile nella modalità Cursore Automatico, " + RightStickPress + ".",
			"Assicurati di coprire l'intero sfondo.",
			"L'abitazione ora è sicura. Perché un PNG possa abitare una stanza sono necessari: un tavolo (es. banco da lavoro), una sedia e una fonte di illuminazione (es. torcia).\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Crea una sedia e posizionala all'interno dell'abitazione.",
			"Quindi posiziona una torcia sui muri o sul pavimento dell'abitazione. Il compito è più facile nella modalità Cursore Manuale " + RightStickPress + ".",
			"Questa stanza è a misura di PNG! Man mano che avanzi, molti PNG potranno trasferirsi nell'abitazione se vi sono abbastanza stanze abitabili a disposizione.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"La Guida è il primo PNG che può trasferirsi nell'abitazione. Puoi parlargli per chiedere consigli o informazioni sugli ingredienti per la creazione.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"È possibile creare un martello per distruggere mobili o muri sullo sfondo.\n ",
			"<c>Premi " + BButton + " per continuare.",
			"Congratulazioni, hai completato il tutorial! Ci sono solo poche aree da esplorare su quest'isola fluttuante. Quando sei pronto, esci dal tutorial e crea un mondo completamente nuovo!\n ",
			"<c>Premi " + BButton + " per continuare.",
			null
		};

		private static readonly string[] TutorialES = new string[80]
		{
			"Terraria es un juego que te permite vivir aventuras en los confines de la tierra y derrotar a los malvados jefes que se crucen en tu camino. Con este tutorial te familiarizarás con los principios básicos.\n",
			"<c>Pulsa " + BButton + " para continuar.",
			"Usa " + MoveAction + " para moverte.",
			"Pulsa " + JumpAction + " para saltar.",
			"Puedes dejarte caer por las plataformas de madera pulsando hacia abajo " + MoveAction + ". Intenta dejarte caer por la plataforma.",
			"Ahora, salta pulsando " + JumpAction + ".",
			"Pulsa (o mantén presionado) " + RightTrigger + " para realizar acciones con el objeto actual. Apunta con " + ControlModeAction + ".",
			"La barra de inventario está en la parte superior de la pantalla. Puedes desplazarte entre los objetos pulsando " + LeftSButton + " & " + RightSButton + ". Ahora, cambia a la espada.",
			"Ha aparecido un malvado monstruo. Derrótalo con la espada pulsando " + RightTrigger + ".",
			"Terraria está llena de monstruos, sobre todo por la noche. Por suerte, hay muchas armas que puedes encontrar para facilitarte la vida.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Si te hieren, te curarás con el tiempo. También puedes usar comida o pociones sanadoras.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Si eliminas a ese slime conseguirás un gel. Si tuvieses madera con la que combinarlo, podrías fabricar una antorcha. Vamos a por algo de madera.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Para talar un árbol debes usar un hacha. Cambia al hacha.",
			"Tala un árbol apuntando hacia uno y manteniendo presionado " + RightTrigger + ".",
			"Todos los objetos que consigas irán al inventario. Pulsa " + InventoryAction + " para abrir el menú Inventario.",
			"El menú Inventario se divide en secciones. Esta zona es tu inventario principal. La barra de inventario es la fila superior de ranuras de objetos. También hay ranuras para monedas y munición (por ejemplo, flechas).\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Usa " + MoveAction + " para pasar de una ranura a otra. Usa " + InvSelectAction + " para coger un objeto y apilarlo. Usa " + RightTrigger + " para mover los objetos de uno en uno.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Si quieres eliminar un objeto permanentemente, ponlo en la ranura de basura o pulsa " + XButton + ". \n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Pulsa " + RightSButton + " para cambiar a la sección Equipo.",
			"En la sección Equipo se colocan la armadura y los accesorios. Los objetos de las ranuras de adornos cambian el aspecto de tu personaje, pero no proporcionan bonificaciones de armadura.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Si interactúas con un cofre o un PNJ comerciante, aparecerá una sección para el mismo.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Pulsa " + LeftSButton + " o " + RightSButton + " para cambiar a la sección Creación.",
			"El gel y la madera que has conseguido pueden usarse para fabricar una antorcha. Selecciona el icono de antorcha y pulsa " + InvSelectAction + " para crearla.",
			"Si quieres obtener más información acerca de los ingredientes de una receta, pulsa " + YButton + " para entrar o salir de la zona de ingredientes.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Hay varias categorías de objetos que puedes crear. Puedes cambiar entre ellas pulsando " + LeftTrigger + " y " + RightTrigger + ".",
			"Pulsa " + LeaveInvAction + " para salir del modo Creación.",
			"Para crear objetos mejores y explorar el amplio mundo subterráneo, necesitarás excavar y conseguir minerales con un pico. Cambia al pico.",
			"Hay una veta de minerales cerca. Explótala a fondo apuntando hacia ella y manteniendo presionado " + RightTrigger + ".",
			"Cuanto más profundo excaves, mejores minerales encontrarás. Algunos minerales requerirán un pico de mejor calidad.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Si te quedas bloqueado en un agujero, puedes colocar plataformas de madera para salir. Fabrica 5 plataformas de madera.",
			"Pulsa " + YButton + " para abrir el menú Inventario. Cambia al modo Creación con " + LeftSButton + " y " + RightSButton + ".",
			"Ahora selecciona las plataformas de madera de la barra de inventario.",
			"Colocar objetos y estructuras es más fácil en el modo cursor manual. Pulsa " + RightStickPress + " para cambiar el modo de cursor.",
			"En el modo cursor manual, " + MoveCursorAction + " actúa como un ratón. Apunta con el cursor y pulsa " + RightTrigger + " para colocar plataformas de madera.\n\n",
			"Construye suficientes para poder salir del agujero.",
			"Recuerda que puedes cambiar entre los modos de cursor en cualquier momento pulsando " + RightStickPress + ".\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Es peligroso estar fuera por la noche. Construye un cobijo antes de que sea tarde.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Para empezar, construye muros y un techo. Debes dejar bastante espacio dentro. Si no tienes madera o piedras suficientes, consigue más.",
			"\n\nLa casa o cobijo debe tener como mínimo 6 bloques de alto y 10 de ancho.",
			"Necesitarás una puerta para entrar y salir. Quita 3 bloques de la parte inferior del muro para hacer espacio.",
			"\n\nUsa un hacha para eliminar los bloques de madera o un pico para eliminar los bloques de piedra.",
			"Para fabricar una puerta necesitarás un banco de trabajo. Crea un banco de trabajo y ponlo dentro de la casa.",
			"\nSi no tienes madera suficiente, tala más árboles.",
			"Cuando estás cerca de un banco de trabajo o de cualquier objeto de tu taller de creación (como un yunque o una forja), tendrás más recetas disponibles para construir en el menú Creación.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Ponte cerca de la mesa y construye una puerta.",
			"\nSi no tienes madera suficiente, tala más árboles.",
			"Ahora coloca la puerta en el espacio de la pared. Esto puede ser algo complicado. Será más fácil si usas el modo cursor manual, " + RightStickPress + ".",
			"Puedes abrir o cerrar la puerta. Apunta hacia ella y pulsa " + InteractAction + ".",
			"Ya casi has terminado. Para hacer que la casa sea segura, necesitarás cubrir con muros (por ejemplo, paneles de madera) el fondo de la casa.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Crea unos cuantos muros de madera en el banco de trabajo.",
			"\nSi no tienes madera suficiente, tala más árboles.",
			"Cubre el fondo de la casa con muros de madera. Esto es más fácil en el modo cursor automático, " + RightStickPress + ".",
			"Asegúrate de cubrir todo el fondo.",
			"La casa ya es segura. Para que una habitación sea habitable para los PNJ, necesita: una mesa (como el banco de trabajo), una fuente de luz (como una antorcha) y una silla.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Crea una silla y ponla dentro de casa.",
			"Ahora coloca una antorcha en los muros o en el suelo de la casa. Esto es más fácil en el modo cursor manual, " + RightStickPress + ".",
			"A partir de ahora, esta sala podrá ser habitada por los PNJ. Conforme vayas progresando, otros PNJ se mudarán a tu casa si tienes suficientes habitaciones disponibles para ellos.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"El guía es el primer PNJ que se puede mudar a la casa. Puedes hablar con él para recibir consejos o detalles sobre los ingredientes empleados en el proceso de creación.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"Si alguna vez quieres destruir muebles o muros de fondo, puedes crear un martillo para hacerlo.\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			"¡Enhorabuena, has completado el tutorial! Solo quedan algunas zonas por explorar en esta isla flotante.¡Cuando estés preparado, sal del tutorial y crea todo un mundo nuevo para ti!\n ",
			"<c>Pulsa " + BButton + " para continuar.",
			null
		};

		public static string Controls(CONTROLS Idx)
		{
			switch (LangOption)
			{
				case (int)ID.GERMAN:
					return ControlsDE[(int)Idx];
				case (int)ID.FRENCH:
					return ControlsFR[(int)Idx];
				case (int)ID.ITALIAN:
					return ControlsIT[(int)Idx];
				case (int)ID.SPANISH:
					return ControlsES[(int)Idx];
				default:
					return ControlsEN[(int)Idx];
			}
		}

		public static string ItemPrefix(int PrefixType)
		{
			switch (LangOption)
			{
				case (int)ID.GERMAN:
					return ItemPrefixDE[PrefixType];
				case (int)ID.FRENCH:
					return ItemPrefixFR[PrefixType];
				case (int)ID.ITALIAN:
					return ItemPrefixIT[PrefixType];
				case (int)ID.SPANISH:
					return ItemPrefixES[PrefixType];
				default:
					return ItemPrefixEN[PrefixType];
			}
		}

		public static string NPCDialog(Player CurrentPlayer, int QuoteID)
		{
			string MerchantName = NPC.TypeNames[(int)EntityID.NPCID.MERCHANT];
			string NurseName = NPC.TypeNames[(int)EntityID.NPCID.NURSE];
			string GuideName = NPC.TypeNames[(int)EntityID.NPCID.GUIDE];
			string DealerName = NPC.TypeNames[(int)EntityID.NPCID.ARMS_DEALER];
			string DryadName = NPC.TypeNames[(int)EntityID.NPCID.DRYAD];
			string DemoName = NPC.TypeNames[(int)EntityID.NPCID.DEMOLITIONIST];
			string GoblinName = NPC.TypeNames[(int)EntityID.NPCID.GOBLIN_TINKERER];
			string MechanicName = NPC.TypeNames[(int)EntityID.NPCID.MECHANIC];
			string PlayerName = CurrentPlayer.Name;

#if !VERSION_INITIAL
			PlayerName = CurrentPlayer.CharacterName;
#endif

			if (LangOption <= (int)ID.ENGLISH)
			{
				switch (QuoteID)
				{
					case 1:
						return "I hope a scrawny kid like you isn't all that is standing between us and Cthulu's Eye.";
					case 2:
						return "Look at that shoddy armor you're wearing. Better buy some more healing potions.";
					case 3:
						return "I feel like an evil presence is watching me.";
					case 4:
						return "Sword beats paper! Get one today.";
					case 5:
						return "You want apples? You want carrots? You want pineapples? We got torches.";
					case 6:
						return "Lovely morning, wouldn't you say? Was there something you needed?";
					case 7:
						return "Night will be upon us soon, friend. Make your choices while you can.";
					case 8:
						return "You have no idea how much dirt blocks sell for overseas.";
					case 9:
						return "Ah, they will tell tales of " + PlayerName + " some day... good ones I'm sure.";
					case 10:
						return "Check out my dirt blocks; they are extra dirty.";
					case 11:
						return "Boy, that sun is hot! I do have some perfectly ventilated armor.";
					case 12:
						return "The sun is high, but my prices are not.";
					case 13:
						return "Oh, great. I can hear " + MechanicName + " and " + NurseName + " arguing from here.";
					case 14:
						return "Have you seen Chith...Shith.. Chat... The big eye?";
					case 15:
						return "Hey, this house is secure, right? Right? " + PlayerName + "?";
					case 16:
						return "Not even a Blood Moon can stop capitalism. Let's do some business.";
					case 17:
						return "Keep your eye on the prize, buy a lense!";
					case 18:
						return "Kosh, kapleck Mog. Oh sorry, that's klingon for 'Buy something or die.'";
					case 19:
						return PlayerName + " is it? I've heard good things, friend!";
					case 20:
						return "I hear there's a secret treasure... oh never mind.";
					case 21:
						return "Angel Statue you say? I'm sorry, I'm not a junk dealer.";
					case 22:
						return "The last guy who was here left me some junk... er I mean... treasures!";
					case 23:
						return "I wonder if the moon is made of cheese...huh, what? Oh yes, buy something!";
					case 24:
						return "Did you say gold?  I'll take that off of ya.";
					case 25:
						return "You better not get blood on me.";
					case 26:
						return "Hurry up and stop bleeding.";
					case 27:
						return "If you're going to die, do it outside.";
					case 28:
						return "What is that supposed to mean?!";
					case 29:
						return "I don't think I like your tone.";
					case 30:
						return "Why are you even here? If you aren't bleeding, you don't need to be here. Get out.";
					case 31:
						return "WHAT?!";
					case 32:
						return "Have you seen that old man pacing around the dungeon? He looks troubled.";
					case 33:
						return "I wish " + DemoName + " would be more careful.  I'm getting tired of having to sew his limbs back on every day.";
					case 34:
						return "Hey, has " + DealerName + " mentioned needing to go to the doctor for any reason? Just wondering.";
					case 35:
						return "I need to have a serious talk with " + GuideName + ". How many times a week can you come in with severe lava burns?";
					case 36:
						return "I think you look better this way.";
					case 37:
						return "Eww... What happened to your face?";
					case 38:
						return "MY GOODNESS! I'm good, but I'm not THAT good.";
					case 39:
						return "Dear friends we are gathered here today to bid farewell... Oh, you'll be fine.";
					case 40:
						return "You left your arm over there. Let me get that for you...";
					case 41:
						return "Quit being such a baby! I've seen worse.";
					case 42:
						return "That's gonna need stitches!";
					case 43:
						return "Trouble with those bullies again?";
					case 44:
						return "Hold on, I've got some cartoon bandages around here somewhere.";
					case 45:
						return "Walk it off, " + PlayerName + ", you'll be fine. Sheesh.";
					case 46:
						return "Does it hurt when you do that? Don't do that.";
					case 47:
						return "You look half digested. Have you been chasing slimes again?";
					case 48:
						return "Turn your head and cough.";
					case 49:
						return "That's not the biggest I've ever seen... Yes, I've seen bigger wounds for sure.";
					case 50:
						return "Would you like a lollipop?";
					case 51:
						return "Show me where it hurts.";
					case 52:
						return "I'm sorry, but you can't afford me.";
					case 53:
						return "I'm gonna need more gold than that.";
					case 54:
						return "I don't work for free you know.";
					case 55:
						return "I don't give happy endings.";
					case 56:
						return "I can't do anymore for you without plastic surgery.";
					case 57:
						return "Quit wasting my time.";
					case 227:
						return "I managed to sew your face back on. Be more careful next time.";
					case 228:
						return "That's probably going to leave a scar.";
					case 229:
						return "All better. I don't want to see you jumping off anymore cliffs.";
					case 230:
						return "That didn't hurt too bad, now did it?";
					case 58:
						return "I heard there is a doll that looks very similar to " + GuideName + " somewhere in the underworld.  I'd like to put a few rounds in it.";
					case 59:
						return "Make it quick! I've got a date with " + NurseName + " in an hour.";
					case 60:
						return "I want what " + NurseName + " is sellin'. What do you mean, she doesn't sell anything?";
					case 61:
						return DryadName + " is a looker.  Too bad she's such a prude.";
					case 62:
						return "Don't bother with " + DemoName + ", I've got all you need right here.";
					case 63:
						return "What's " + DemoName + "'s problem? Does he even realize we sell completely different stuff?";
					case 64:
						return "Man, it's a good night not to talk to anybody, don't you think, " + PlayerName + "?";
					case 65:
						return "I love nights like tonight.  There is never a shortage of things to kill!";
					case 66:
						return "I see you're eyeballin' the Minishark.. You really don't want to know how it was made.";
					case 67:
						return "Hey, this ain't a movie, pal. Ammo is extra.";
					case 68:
						return "Keep your hands off my gun, buddy!";
					case 69:
						return "Have you tried using purification powder on the ebonstone of the corruption?";
					case 70:
						return "I wish " + DealerName + " would stop flirting with me. Doesn't he realize I'm 500 years old?";
					case 71:
						return "Why does " + MerchantName + " keep trying to sell me an angel statues? Everyone knows that they don't do anything.";
					case 72:
						return "Have you seen the old man walking around the dungeon? He doesn't look well at all...";
					case 73:
						return "I sell what I want! If you don't like it, too bad.";
					case 74:
						return "Why do you have to be so confrontational during a time like this?";
					case 75:
						return "I don't want you to buy my stuff. I want you to want to buy my stuff, ok?";
					case 76:
						return "Dude, is it just me or is there like a million zombies out tonight?";
					case 77:
						return "You must cleanse the world of this corruption.";
					case 78:
						return "Be safe; Terraria needs you!";
					case 79:
						return "The sands of time are flowing. And well, you are not aging very gracefully.";
					case 80:
						return "What's this about me having more 'bark' than bite?";
					case 81:
						return "So two goblins walk into a bar, and one says to the other, 'Want to get a Goblet of beer?!";
					case 82:
						return "I cannot let you enter until you free me of my curse.";
					case 83:
						return "Come back at night if you wish to enter.";
					case 84:
						return "My master cannot be summoned under the light of day.";
					case 85:
						return "You are far too weak to defeat my curse.  Come back when you aren't so worthless.";
					case 86:
						return "You pathetic fool.  You cannot hope to face my master as you are now.";
					case 87:
						return "I hope you have like six friends standing around behind you.";
					case 88:
						return "Please, no, stranger. You'll only get yourself killed.";
					case 89:
						return "You just might be strong enough to free me from my curse...";
					case 90:
						return "Stranger, do you possess the strength to defeat my master?";
					case 91:
						return "Please! Battle my captor and free me! I beg you!";
					case 92:
						return "Defeat my master, and I will grant you passage into the Dungeon.";
					case 93:
						return "Trying to get past that ebonrock, eh?  Why not introduce it to one of these explosives!";
					case 94:
						return "Hey, have you seen a clown around?";
					case 95:
						return "There was a bomb sitting right here, and now I can't seem to find it...";
					case 96:
						return "I've got something for them zombies alright!";
					case 97:
						return "Even " + DealerName + " wants what I'm selling!";
					case 98:
						return "Would you rather have a bullet hole or a grenade hole? That's what I thought.";
					case 99:
						return "I'm sure " + NurseName + " will help if you accidentally lose a limb to these.";
					case 100:
						return "Why purify the world when you can just blow it up?";
					case 101:
						return "If you throw this one in the bathtub and close all the windows, it'll clear your sinuses and pop your ears!";
					case 102:
						return "Wanna play Fuse Chicken?";
					case 103:
						return "Hey, could you sign this Griefing Waiver?";
					case 104:
						return "NO SMOKING IN HERE!!";
					case 105:
						return "Explosives are da' bomb these days.  Buy some now!";
					case 106:
						return "It's a good day to die!";
					case 107:
						return "I wonder what happens if I... (BOOM!)... Oh, sorry, did you need that leg?";
					case 108:
						return "Dynamite, my own special cure-all for what ails ya.";
					case 109:
						return "Check out my goods; they have explosive prices!";
					case 110:
						return "I keep having vague memories of tying up a woman and throwing her in a dungeon.";
					case 111:
						return "... we have a problem! It's a Blood Moon out there!";
					case 112:
						return "T'were I younger, I would ask " + NurseName + " out. I used to be quite the lady killer.";
					case 113:
						return "That Red Hat of yours looks familiar...";
					case 114:
						return "Thanks again for freeing me from my curse. Felt like something jumped up and bit me.";
					case 115:
						return "Mama always said I would make a great tailor.";
					case 116:
						return "Life's like a box of clothes; you never know what you are gonna wear!";
					case 117:
						return "Of course embroidery is hard! If it wasn't hard, no one would do it! That's what makes it great.";
					case 118:
						return "I know everything they is to know about the clothierin' business.";
					case 119:
						return "Being cursed was lonely, so I once made a friend out of leather. I named him Wilson.";
					case 120:
						return "Thank you for freeing me, human.  I was tied up and left here by the other goblins.  You could say that we didn't get along very well.";
					case 121:
						return "I can't believe they tied me up and left me here just for pointing out that they weren't going east!";
					case 122:
						return "Now that I'm an outcast, can I throw away the spiked balls? My pockets hurt.";
					case 123:
						return "Looking for a gadgets expert? I'm your goblin!";
					case 124:
						return "Thanks for your help. Now, I have to finish pacing around aimlessly here. I'm sure we'll meet again.";
					case 125:
						return "I thought you'd be taller.";
					case 126:
						return "Hey...what's " + MechanicName + " up to? Have you...have you talked to her, by chance?";
					case 127:
						return "Hey, does your hat need a motor? I think I have a motor that would fit exactly in that hat.";
					case 128:
						return "Yo, I heard you like rockets and running boots, so I put some rockets in your running boots.";
					case 129:
						return "Silence is golden. Duct tape is silver.";
					case 130:
						return "YES, gold is stronger than iron. What are they teaching these humans nowadays?";
					case 131:
						return "You know, that mining helmet-flipper combination was a much better idea on paper.";
					case 132:
						return "Goblins are surprisingly easy to anger. In fact, they could start a war over cloth!";
					case 133:
						return "To be honest, most goblins aren't exactly rocket scientists. Well, some are.";
					case 134:
						return "Do you know why we all carry around these spiked balls? Because I don't.";
					case 135:
						return "I just finished my newest creation! This version doesn't explode violently if you breathe on it too hard.";
					case 136:
						return "Goblin thieves aren't very good at their job. They can't even steal from an unlocked chest!";
					case 137:
						return "Thanks for saving me, friend! This bondage was starting to chafe.";
					case 138:
						return "Ohh, my hero!";
					case 139:
						return "Oh, how heroic! Thank you for saving me, young lady!";
					case 140:
						return "Oh, how heroic! Thank you for saving me, young man!";
					case 141:
						return "Now that we know each other, I can move in with you, right?";
					case 142:
						return "Well, hi there, " + GuideName + "! What can I do for you today?";
					case 143:
						return "Well, hi there, " + DemoName + "! What can I do for you today?";
					case 144:
						return "Well, hi there, " + GoblinName + "! What can I do for you today?";
					case 145:
						return "Well, hi there, " + NurseName + "! What can I do for you today?";
					case 146:
						return "Well, hi there, " + MechanicName + "! What can I do for you today?";
					case 147:
						return "Well, hi there, " + DryadName + "! What can I do for you today?";
					case 148:
						return "Want me to pull a coin from behind your ear? No? Ok.";
					case 149:
						return "Do you want some magic candy? No? Ok.";
					case 150:
						return "I make a rather enchanting hot chocolate if you'd be inter... No? Ok.";
					case 151:
						return "Are you here for a peek at my crystal ball?";
					case 152:
						return "Ever wanted an enchanted ring that turns rocks into slimes? Well neither did I.";
					case 153:
						return "Someone once told me friendship is magic. That's ridiculous. You can't turn people into frogs with friendship.";
					case 154:
						return "I can see your future now... You will buy a lot of items from me!";
					case 155:
						return "I once tried to bring an Angel Statue to life. It didn't do anything.";
					case 156:
						return "Thanks! It was just a matter of time before I ended up like the rest of the skeletons down here.";
					case 157:
						return "Hey, watch where you're going! I was over there a little while ago!";
					case 158:
						return "Hold on, I've almost got wifi going down here.";
					case 159:
						return "But I was almost done putting blinking lights up here!";
					case 160:
						return "DON'T MOVE. I DROPPED MY CONTACT.";
					case 161:
						return "All I want is for the switch to make the... What?!";
					case 162:
						return "Oh, let me guess. Didn't buy enough wire. Idiot.";
					case 163:
						return "Just-could you just... Please? Ok? Ok. Ugh.";
					case 164:
						return "I don't appreciate the way you're looking at me. I am WORKING right now.";
					case 165:
						return "Hey, " + PlayerName + ", did you just come from " + GoblinName + "'s? Did he say anything about me by chance?";
					case 166:
						return DealerName + " keeps talking about pressing my pressure plate. I told him it was for stepping on.";
					case 167:
						return "Always buy more wire than you need!";
					case 168:
						return "Did you make sure your device was plugged in?";
					case 169:
						return "Oh, you know what this house needs? More blinking lights.";
					case 170:
						return "You can tell a Blood Moon is out when the sky turns red. There is something about it that causes monsters to swarm.";
					case 171:
						return "Hey, buddy, do you know where any deathweed is? Oh, no reason; just wondering, is all.";
					case 172:
						return "If you were to look up, you'd see that the moon is red right now.";
					case 173:
						return "You should stay indoors at night. It is very dangerous to be wandering around in the dark.";
					case 174:
						return "Greetings, " + PlayerName + ". Is there something I can help you with?";
					case 175:
						return "I am here to give you advice on what to do next.  It is recommended that you talk with me anytime you get stuck.";
					case 176:
						return "They say there is a person who will tell you how to survive in this land... oh wait. That's me.";
					case 177:
						return "You can use your pickaxe to dig through dirt, and your axe to chop down trees. Just place your cursor over the tile and press " + RightTrigger + "!";
					case 178:
						return "If you want to survive, you will need to create weapons and shelter. Start by chopping down trees and gathering wood.";
					case 179:
						return "Press " + YButton + "to access your crafting menu. When you have enough wood, create a workbench. This will allow you to create more complicated things, as long as you are standing close to it.";
					case 180:
						return "You can build a shelter by placing wood or other blocks in the world. Don't forget to create and place walls.";
					case 181:
						return "Once you have a wooden sword, you might try to gather some gel from the slimes. Combine wood and gel to make a torch!";
					case 182:
						return "To interact with backgrounds and placed objects, use a hammer!";
					case 183:
						return "You should do some mining to find metal ore. You can craft very useful things with it.";
					case 184:
						return "Now that you have some ore, you will need to turn it into a bar in order to make items with it. This requires a furnace!";
					case 185:
						return "You can create a furnace out of torches, wood, and stone. Make sure you are standing near a work bench.";
					case 186:
						return "You will need an anvil to make most things out of metal bars.";
					case 187:
						return "Anvils can be crafted out of iron, or purchased from a merchant.";
					case 188:
						return "Underground are crystal hearts that can be used to increase your max life. You will need a hammer to obtain them.";
					case 189:
						return "If you gather 10 fallen stars, they can be combined to create an item that will increase your magic capacity.";
					case 190:
						return "Stars fall all over the world at night. They can be used for all sorts of usefull things. If you see one, be sure to grab it because they disappear after sunrise.";
					case 191:
						return "There are many different ways you can attract people to move in to our town. They will of course need a home to live in.";
					case 192:
						return "In order for a room to be considered a home, it needs to have a door, chair, table, and a light source.  Make sure the house has walls as well.";
					case 193:
						return "Two people will not live in the same home. Also, if their home is destroyed, they will look for a new place to live.";
					case 194:
						return "You can use the housing interface to assign and view housing.";
					case 195:
						return "If you want a merchant to move in, you will need to gather plenty of money. 50 silver coins should do the trick!";
					case 196:
						return "For a nurse to move in, you might want to increase your maximum life.";
					case 197:
						return "If you had a gun, I bet an arms dealer might show up to sell you some ammo!";
					case 198:
						return "You should prove yourself by defeating a strong monster. That will get the attention of a dryad.";
					case 199:
						return "Make sure to explore the dungeon thoroughly. There may be prisoners held deep within.";
					case 200:
						return "Perhaps the old man by the dungeon would like to join us now that his curse has been lifted.";
					case 201:
						return "Hang on to any bombs you might find. A demolitionist may want to have a look at them.";
					case 202:
						return "Are goblins really so different from us that we couldn't live together peacefully?";
					case 203:
						return "I heard there was a powerfully wizard who lives in these parts.  Make sure to keep an eye out for him next time you go underground.";
					case 204:
						return "If you combine lenses at a demon altar, you might be able to find a way to summon a powerful monster. You will want to wait until night before using it, though.";
					case 205:
						return "You can create worm bait with rotten chunks and vile powder. Make sure you are in a corrupt area before using it.";
					case 206:
						return "Demonic altars can usually be found in the corruption. You will need to be near them to craft some items.";
					case 207:
						return "You can make a grappling hook from a hook and 3 chains. Skeletons found deep underground usually carry hooks, and chains can be made from iron bars.";
					case 208:
						return "If you see a pot, be sure to smash it open. They contain all sorts of useful supplies.";
					case 209:
						return "There is treasure hidden all over the world. Some amazing things can be found deep underground!";
					case 210:
						return "Smashing a shadow orb will sometimes cause a meteor to fall out of the sky. Shadow orbs can usually be found in the chasms around corrupt areas.";
					case 211:
						return "You should focus on gathering more heart crystals to increase your maximum life.";
					case 212:
						return "Your current equipment simply won't do. You need to make better armor.";
					case 213:
						return "I think you are ready for your first major battle. Gather some lenses from the eyeballs at night and take them to a demon altar.";
					case 214:
						return "You will want to increase your life before facing your next challenge. Fifteen hearts should be enough.";
					case 215:
						return "The ebonstone in the corruption can be purified using some powder from a dryad, or it can be destroyed with explosives.";
					case 216:
						return "Your next step should be to explore the corrupt chasms.  Find and destroy any shadow orb you find.";
					case 217:
						return "There is a old dungeon not far from here. Now would be a good time to go check it out.";
					case 218:
						return "You should make an attempt to max out your available life. Try to gather twenty hearts.";
					case 219:
						return "There are many treasures to be discovered in the jungle, if you are willing to dig deep enough.";
					case 220:
						return "The underworld is made of a material called hellstone. It's perfect for making weapons and armor.";
					case 221:
						return "When you are ready to challenge the keeper of the underworld, you will have to make a living sacrifice. Everything you need for it can be found in the underworld.";
					case 222:
						return "Make sure to smash any demon altar you can find. Something good is bound to happen if you do!";
					case 223:
						return "Souls can sometimes be gathered from fallen creatures in places of extreme light or dark.";
					case 224:
						return "Ho ho ho, and a bottle of... Egg Nog!";
					case 225:
						return "Care to bake me some cookies?";
					case 226:
						return "What? You thought I wasn't real?";
				}
			}
			else if (LangOption == (int)ID.GERMAN)
			{
				switch (QuoteID)
				{
					case 1:
						return "Ich hoffe, du dünnes Hemd bist nicht das Einzige, was zwischen Chtulus Auge und uns steht.";
					case 2:
						return "Was für eine schäbige Rüstung du trägst. Kauf lieber ein paar Heiltränke.";
					case 3:
						return "Ich habe das Gefühl, dass mich eine böse Kraft beobachtet.";
					case 4:
						return "Schwert schlägt Papier! Hol dir noch heute eins.";
					case 5:
						return "Du möchtest Äpfel? Du willst Karotten? Ananas? Wir haben Fackeln.";
					case 6:
						return "Ein schöner Morgen, nicht wahr? War da noch was, was du brauchst?";
					case 7:
						return "Die Nacht wird bald hereinbrechen, mein Freund. Entscheide dich, solange du kannst.";
					case 8:
						return "Du hast keine Ahnung, wie gut sich Dreckblöcke nach Übersee verkaufen.";
					case 9:
						return "Ach, eines Tages werden sie Geschichten über" + PlayerName + " erzählen ... sicher gute.";
					case 10:
						return "Schau dir mal meine Dreckblöcke an; die sind wirklich super-dreckig.";
					case 11:
						return "Junge, Junge, wie die Sonne brennt! Ich hab da eine tolle klimatisierte Rüstung.";
					case 12:
						return "Die Sonne steht zwar hoch, meine Preise sind's aber nicht.";
					case 13:
						return "Toll. Ich kann " + MechanicName + " und " + NurseName + " von hier aus diskutieren hören.";
					case 14:
						return "Hast du Chith ... Shith.. Chat... das große Auge gesehen?";
					case 15:
						return "Heh, dieses Haus ist doch wohl sicher? Oder? " + PlayerName + "?";
					case 16:
						return "Nicht mal ein Blutmond kann den Kapitalismus stoppen. Lass uns also Geschäfte machen.";
					case 17:
						return "Achte auf den Preis, kaufe eine Linse!";
					case 18:
						return "Kosh, kapleck Mog. Oha, sorry. Das ist klingonisch für: Kauf oder stirb!";
					case 19:
						return PlayerName + " ist es? Ich habe nur Gutes über dich gehört!";
					case 20:
						return "Ich hörte, es gibt einen geheimen Schatz ... oh, vergiss es!";
					case 21:
						return "Engelsstatue, sagst du? Tut mir Leid, ich bin kein Nippesverkäufer.";
					case 22:
						return "Der letzte Typ, der hier war, hinterließ mir einigen Nippes, äh, ich meine ... Schätze!";
					case 23:
						return "Ich frage mich, ob der Mond aus Käse ist ... huch, was? Oh, ja, kauf etwas!";
					case 24:
						return "Hast du Gold gesagt? Ich nehm' dir das ab.";
					case 25:
						return "Blute mich bloß nicht voll!";
					case 26:
						return "Mach schon und hör mit dem Bluten auf!";
					case 27:
						return "Wenn du stirbst, dann bitte draußen.";
					case 28:
						return "Was soll das heißen?!";
					case 29:
						return "Irgendwie gefällt mir dein Ton nicht.";
					case 30:
						return "Warum bist du überhaupt hier? Wenn du nicht blutest, gehörst du nicht hierher. Raus jetzt!";
					case 31:
						return "WAS?!";
					case 32:
						return "Hast du den Greis um das Verlies schreiten sehen? Der scheint Probleme zu haben.";
					case 33:
						return "Ich wünschte, " + DemoName + " wäre vorsichtiger. Es nervt mich, täglich seine Glieder zusammennähen zu müssen.";
					case 34:
						return "Heh, hat " + DealerName + " den Grund für einen notwendigen Arztbesuch erwähnt? Ich wundere mich nur.";
					case 35:
						return "Ich muss mal ein ernsthaftes Wort mit  " + GuideName + " reden. Wie oft kann man in einer Woche mit schweren Lavaverbrennungen hereinkommen?";
					case 36:
						return "Ich finde, du siehst so besser aus.";
					case 37:
						return "Ähhh ... was ist denn mit deinem Gesicht passiert?";
					case 38:
						return "MEINE GÜTE! Ich bin gut, aber ich bin nicht SO gut.";
					case 39:
						return "Liebe Freunde, wir sind zusammengekommen, um Aufwiedersehen zu sagen ... Ach, es wird schon werden.";
					case 40:
						return "Du hast deinen Arm da drüben gelassen. Lass mich ihn holen ...";
					case 41:
						return "Hör schon auf, wie ein Baby zu plärren! Ich habe Schlimmeres gesehen.";
					case 42:
						return "Das geht nicht ohne ein paar Stiche!";
					case 43:
						return "Schon wieder Ärger mit diesen Rabauken?";
					case 44:
						return "Halt durch. Ich hab hier irgendwo ein paar hübsch bedruckte Pflaster.";
					case 45:
						return "Hör schon auf, " + PlayerName + ", du überstehst das schon. Mist.";
					case 46:
						return "Tut es weh, wenn du das machst? Tu das nicht.";
					case 47:
						return "Du siehst halb verdaut aus. Hast du schon wieder Schleime gejagt?";
					case 48:
						return "Dreh deinen Kopf und huste!";
					case 49:
						return "Ich habe schon Schlimmeres gesehen ... ja, ganz sicher habe ich schon größere Wunden gesehen.";
					case 50:
						return "Möchtest du einen Lollipop?";
					case 51:
						return "Zeig mir, wo es weh tut.";
					case 52:
						return "Tut mir leid, aber ich bin viel zu teuer für dich.";
					case 53:
						return "Dafür brauche ich mehr Gold.";
					case 54:
						return "Ich arbeite schließlich nicht umsonst, weißt du.";
					case 55:
						return "Ich verschenke keine Happy-Ends.";
					case 56:
						return "Ohne eine Schönheitsoperation kann ich nicht mehr für dich tun .";
					case 57:
						return "Hör auf, meine Zeit zu verschwenden!";
					case 227:
						return "Es gelang mir, dein Gesicht wieder anzunähen. Sei beim nächsten Mal vorsichtiger.";
					case 228:
						return "Das wird wahrscheinlich eine Narbe hinterlassen.";
					case 229:
						return "Alles okay. Ich will nicht, dass du nochmal von irgendwelchen Klippen springst.";
					case 230:
						return "Das hat nicht allzu weh getan, oder?";
					case 58:
						return "Ich habe gehört, es gibt eine Puppe in der Unterwelt, die " + GuideName + " sehr ähnlich sieht. Ich würde sie gerne mit ein paar Kugeln durchlöchern.";
					case 59:
						return "Mach schnell! Ich habe in einer Stunde ein Date mit " + NurseName + ".";
					case 60:
						return "Ich möchte das, was " + NurseName + "  verkauft. Was heißt, sie verkauft nichts?";
					case 61:
						return DryadName + " ist hübsch. Zu dumm, dass sie so prüde ist.";
					case 62:
						return "Halte dich nicht mit " + DemoName + " auf, ich habe alles, was du brauchst, hier.";
					case 63:
						return "Was ist eigentlich mit " + DemoName + " los? Kriegt der mal mit, dass wir ganz andere Sachen verkaufen?";
					case 64:
						return "Das ist eine gute Nacht, um mit niemandem zu sprechen, denkst du nicht, " + PlayerName + "?";
					case 65:
						return "Ich liebe Nächte wie diese. Es gibt immer genug zu töten!";
					case 66:
						return "Wie ich sehe, starrst du den Minihai an ... Du solltest lieber nicht fragen, wie der entstand.";
					case 67:
						return "Moment, das ist kein Film, Freundchen. Munition geht extra.";
					case 68:
						return "Hände weg von meinem Gewehr, Kumpel!";
					case 69:
						return "Hast du versucht, das Reinigungspulver auf dem Ebenstein des Verderbens auszuprobieren?";
					case 70:
						return "Ich wünschte, " + DealerName + " würde aufhören, mit mir zu flirten. Versteht er nicht, dass ich 500 Jahre alt bin?";
					case 71:
						return "Warum versucht " + MerchantName + " , mir Engelsstatuen zu verkaufen? Jeder weiß, dass sie nutzlos sind.";
					case 72:
						return "Hast du den Greis um das Verlies herumgehen sehen? Der sieht gar nicht gut aus ...";
					case 73:
						return "Ich verkaufe, was ich will! Dein Pech, wenn du es nicht magst.";
					case 74:
						return "Warum bist du in einer Zeit wie dieser so aggressiv?";
					case 75:
						return "Ich möchte nicht, dass du meine Sachen kaufst, sondern dass du dir wünschst, sie zu kaufen, okay?";
					case 76:
						return "Kommt es mir nur so vor oder sind heute Nacht eine Million Zombies draußen?";
					case 77:
						return "Du musst die Welt von diesem Verderben befreien.";
					case 78:
						return "Pass auf dich auf, Terraria braucht dich!";
					case 79:
						return "Der Zahn der Zeit nagt und du alterst nicht gerade würdevoll.";
					case 80:
						return "Was soll das heißen: Ich belle mehr als ich beiße?";
					case 81:
						return "Zwei Goblins kommen in einen Stoffladen. Sagt der eine zum anderen: Sitzt du gerne auf Gobelin?";
					case 82:
						return "Ich kann dich erst hineinlassen, wenn du mich von meinem Fluch befreit hast.";
					case 83:
						return "Komm in der Nacht wieder, wenn du hineinwillst.";
					case 84:
						return "Mein Meister kann nicht bei Tageslicht herbeigerufen werden.";
					case 85:
						return "Du bist viel zu schwach, um meinen Fluch zu brechen. Komm wieder, wenn du was aus dir gemacht hast.";
					case 86:
						return "Du armseliger Wicht. So kannst du meinem Meister nicht gegenübertreten.";
					case 87:
						return "Ich hoffe, du hast mindestens sechs Freunde, die hinter dir stehen.";
					case 88:
						return "Bitte nicht, Fremdling. Du bringst dich nur selbst um.";
					case 89:
						return "Du könntest tatsächlich stark genug sein, um mich von meinem Fluch zu befreien ...";
					case 90:
						return "Fremdling, hast du die Kraft, meinen Meister zu besiegen?";
					case 91:
						return "Bitte! Bezwinge meinen Kerkermeister und befreie mich! Ich flehe dich an!";
					case 92:
						return "Besiege meinen Meister und ich gewähre dir den Zutritt in das Verlies.";
					case 93:
						return "Du versuchst, hinter den Ebenstein zu kommen? Warum führst du ihn nicht mit diesen Explosiva zusammen?";
					case 94:
						return "Heh, hast du hier in der Gegend einen Clown gesehen?";
					case 95:
						return "Genau hier war doch eine Bombe und jetzt kann ich sie nicht finden ...";
					case 96:
						return "Ich habe etwas für diese Zombies!";
					case 97:
						return "Sogar " + DealerName + " ist scharf auf meine Waren!";
					case 98:
						return "Hättest du lieber das Einschussloch eines Gewehrs oder das einer Granate? Das dachte ich mir.";
					case 99:
						return "Ich bin sicher, dass " + NurseName + " dir helfen wird, wenn du versehentlich ein Glied verlierst.";
					case 100:
						return "Warum willst du die Welt reinigen, wenn du sie einfach in die Luft jagen kannst?";
					case 101:
						return "Wenn du das hier in die Badewanne schmeißt und alle Fenster schließt, durchpustet es deine Nasenhöhlen und  dir fliegen die Ohren weg!";
					case 102:
						return "Möchtest du mal Grillhähnchen spielen?";
					case 103:
						return "Könntest du hier unterschreiben, dass du nicht jammern wirst?";
					case 104:
						return "RAUCHEN IST HIER NICHT ERLAUBT!!";
					case 105:
						return "Sprengstoffe sind zur Zeit der Knaller. Kauf dir jetzt welche!";
					case 106:
						return "Ein schöner Tag, um zu sterben!";
					case 107:
						return "Ich frage mich, was passiert, wenn ich ... (BUMM!) ... Oha, sorry, brauchtest du dieses Bein noch?";
					case 108:
						return "Dynamit, mein ganz spezielles Heilmittelchen - für alles, was schmerzt.";
					case 109:
						return "Schau dir meine Waren an - sie haben hochexplosive Preise!";
					case 110:
						return "Ich erinnere mich vage an eine Frau, die ich fesselte und in das Verlies warf.";
					case 111:
						return "... wir haben ein Problem! Es ist Blutmond!";
					case 112:
						return "Wenn ich jünger wäre, würde ich mit " + NurseName + " ausgehen wollen. Ich war mal ein Womanizer.";
					case 113:
						return "Dein roter Hut kommt mir bekannt vor ...";
					case 114:
						return "Danke nochmals, dass du mich von meinem Fluch befreit hast. Es fühlte sich an, als hätte mich etwas angesprungen und gebissen.";
					case 115:
						return "Mama sagte immer, dass ich einen guten Schneider abgeben würde.";
					case 116:
						return "Das Leben ist wie ein Kleiderschrank; du weißt nie, was du tragen wirst!";
					case 117:
						return "Natürlich ist die Stickerei schwierig! Wenn es nicht schwierig wäre, würde es niemand machen! Das macht es so großartig.";
					case 118:
						return "Ich weiß alles, was man über das Kleidergeschäft wissen muss.";
					case 119:
						return "Das Leben mit dem Fluch war einsam, deshalb fertigte ich mir aus Leder einen Freund an. Ich nannte ihn Wilson.";
					case 120:
						return "Danke für die Befreiung, Mensch. Ich wurde gefesselt und von den anderen Goblins hier zurückgelassen. Man kann sagen, dass wir nicht besonders gut miteinander auskamen.";
					case 121:
						return "Ich kann nicht glauben, dass sie mich fesselten und hier ließen, nur um klarzumachen, dass sie nicht nach Osten gehen.";
					case 122:
						return "Darf ich nun, da ich zu den Verstoßenen gehöre, meine Stachelkugeln wegwerfen? Sie pieken durch die Taschen.";
					case 123:
						return "Suchst du einen Bastelexperten? Dann bin ich dein Goblin!";
					case 124:
						return "Danke für deine Hilfe. Jetzt muss ich erst mal aufhören, hier ziellos herumzuschreiten. Wir begegnen uns sicher wieder.";
					case 125:
						return "Ich hielt dich für größer.";
					case 126:
						return "Heh ... was macht " + MechanicName + " so? Hast du ... hast du vielleicht mit ihr gesprochen?";
					case 127:
						return "Wäre ein Motor für deinen Hut nicht schick? Ich glaube, ich habe einen Motor, der genau hineinpasst.";
					case 128:
						return "Ja, ich hab schon gehört, dass du Raketen und Laufstiefel magst. Deshalb habe ich ein paar Raketen in deine Laufstiefel montiert.";
					case 129:
						return "Schweigen ist Gold. Klebeband ist Silber.";
					case 130:
						return "Ja! Gold ist stärker als Eisen. Was bringt man den Menschen heutzutage eigentlich bei?";
					case 131:
						return "Diese Bergmanns-Helm-Flossen-Kombination sah auf dem Papier viel besser aus.";
					case 132:
						return "Goblins kann man erstaunlich leicht auf die Palme bringen. Die würden sogar wegen Kleidern einen Krieg anfangen.";
					case 133:
						return "Um ehrlich zu sein, Goblins sind nicht gerade Genies oder Astroforscher. Naja, bis auf ein paar Ausnahmen.";
					case 134:
						return "Weißt du eigentlich, warum wir alle diese Stachelkugeln mit uns herumtragen? Ich weiß es nämlich nicht.";
					case 135:
						return "Meine neuste Erfindung ist fertig! Diese Version explodiert nicht, wenn du sie heftig anhauchst.";
					case 136:
						return "Goblin-Diebe sind nicht besonders gut in ihrem Job. Sie können nicht mal was aus einer unverschlossenen Truhe klauen.";
					case 137:
						return "Danke für die Rettung, mein Freund! Die Fesseln fingen an, zu scheuern.";
					case 138:
						return "Oh, mein Held!";
					case 139:
						return "Oh, wie heroisch! Danke für die Rettung, Lady!";
					case 140:
						return "Oh, wie heroisch! Danke für die Rettung, mein Herr!";
					case 141:
						return "Nun da wir uns kennen, kann ich doch bei dir einziehen, oder?";
					case 142:
						return "Hallo, " + GuideName + "! Was kann ich heute für dich tun?";
					case 143:
						return "Hallo, " + DemoName + "! Was kann ich heute für dich tun?";
					case 144:
						return "Hallo, " + GoblinName + "! Was kann ich heute für dich tun?";
					case 145:
						return "Hallo, " + NurseName + "! Was kann ich heute für dich tun?";
					case 146:
						return "Hallo, " + MechanicName + "! Was kann ich heute für dich tun?";
					case 147:
						return "Hallo, " + DryadName + "! Was kann ich heute für dich tun?";
					case 148:
						return "Möchtest du, dass ich eine Münze hinter deinem Ohr hervorziehe? Nein? Gut.";
					case 149:
						return "Möchtest du vielleicht magische Süßigkeiten? Nein? Gut.";
					case 150:
						return "Ich braue eine heiße Zauber-Schokolade, wenn du inter ... Nein? Gut.";
					case 151:
						return "Bist du hier, um einen Blick in meine Kristallkugel zu werfen?";
					case 152:
						return "Hast du dir je einen verzauberten Ring gewünscht, der Steine in Schleime verwandelt? Ich auch nicht.";
					case 153:
						return "Jemand sagte mir mal, Freundschaft sei magisch. Das ist lächerlich. Du kannst mit Freundschaft keine Menschen in Frösche verwandeln.";
					case 154:
						return "Jetzt kann ich deine Zukunft sehen ... Du wirst mir eine Menge Items abkaufen!";
					case 155:
						return "Ich habe mal versucht, eine Engelsstatue zu beleben. Hat überhaupt nichts gebracht!";
					case 156:
						return "Danke! Es wäre nur eine Frage der Zeit gewesen, bis aus mir eines der Skelette hier geworden wäre.";
					case 157:
						return "Pass auf, wo du hingehst! Ich war vor einer Weile dort drüben.";
					case 158:
						return "Warte, ich habe es fast geschafft, hier unten WiFi zu installieren.";
					case 159:
						return "Aber ich hatte es fast geschafft, hier oben blinkende Lichter anzubringen.";
					case 160:
						return "BEWEG DICH NICHT. ICH HABE MEINE KONTAKTLINSE VERLOREN.";
					case 161:
						return "Ich möchte nur den Schalter ... Was?!";
					case 162:
						return "Oh, lass mich raten. Nicht genügend Kabel gekauft, Idiot.";
					case 163:
						return "Könntest du vielleicht ... bitte? Ja? Gut. Uff!";
					case 164:
						return "Mir gefällt nicht, wie du mich anschaust. Ich ARBEITE gerade.";
					case 165:
						return "Sag, " + PlayerName + ", kommst du gerade von " + GoblinName + "? Hat er vielleicht etwas über mich gesagt?";
					case 166:
						return DealerName + " spricht immer davon, auf meine Druckplatten zu drücken. Ich habe ihm gesagt, die ist zum Drauftreten.";
					case 167:
						return "Kaufe immer etwas mehr Kabel als nötig!";
					case 168:
						return "Hast du dich vergewissert, dass dein Gerät angeschlossen ist?";
					case 169:
						return "Oh, weißt du, was dieses Haus noch braucht? Mehr blinkende Lichter.";
					case 170:
						return "Du erkennst den Blutmond an der Rotfärbung des Himmels. Irgendetwas daran lässt Monster ausschwärmen.";
					case 171:
						return "Weißt du vielleicht, wo Todeskraut ist? Nein, es hat keinen Grund. Ich frag mich das bloß.";
					case 172:
						return "Wenn du mal hochschauen würdest, würdest du bemerken, dass der Mond rot ist.";
					case 173:
						return "Du solltest in der Nacht drinnen bleiben. Es ist sehr gefährlich, in der Dunkelheit umherzustreifen.";
					case 174:
						return "Sei gegrüßt, " + PlayerName + ". Gibt es etwas, das ich für dich tun kann?";
					case 175:
						return "Ich bin hier, um dir zu raten, was du als Nächstes tust. Du solltest immer zu mir kommen, wenn du feststeckst.";
					case 176:
						return "Man sagt, es gibt jemanden, der dir erklaert, wie man in diesem Land überlebt ... oh, Moment. Das bin ja ich.";
					case 177:
						return "Du kannst deine Spitzhacke zum Graben im Dreck verwenden und deine Axt zum Holzfällen. Bewege einfach deinen Zeiger über das Feld und klicke!";
					case 178:
						return "Wenn du überleben willst, musst du Waffen und Zufluchten bauen. Fälle dazu Bäume und sammle das Holz.";
					case 179:
						return "Drücke " + YButton + " zum Aufrufen des Handwerksmenüs. Wenn du genügend Holz hast, stelle eine Werkbank zusammen. Damit kannst du komplexere Sachen herstellen, solange du nahe genug bei ihr stehst.";
					case 180:
						return "Du kannst durch Platzieren von Holz oder anderen Blöcken in der Welt eine Zuflucht bauen. Vergiss dabei nicht, auch Wände zu bauen und aufzustellen.";
					case 181:
						return "Wenn du einmal ein Holzschwert hast, kannst du versuchen, etwas Glibber von den Schleimen zu sammeln. Kombiniere Holz und Glibber zur Herstellung einer Fackel.";
					case 182:
						return "Verwende einen Hammer zum Interagieren mit Hintergründen und platzierten Objekten!";
					case 183:
						return "Du solltest ein bisschen Bergbau betreiben, um Gold zu finden. Du kannst sehr nützliche Dinge damit herstellen.";
					case 184:
						return "Jetzt, da du etwas Gold hast, musst du es in einen Barren verwandeln, um damit Items zu erschaffen. Dazu brauchst du einen Schmelzofen!";
					case 185:
						return "Du kannst einen Schmelzofen aus Fackeln, Holz und Steinen herstellen. Achte dabei darauf, dass du neben einer Werkbank stehst.";
					case 186:
						return "Zum Herstellen der meisten Sachen aus einem Metallbarren wirst du einen Amboss brauchen.";
					case 187:
						return "Ambosse können aus Eisen hergestellt oder von einem Händler gekauft werden.";
					case 188:
						return "Unterirdisch finden sich Kristallherzen, die verwendet werden können, um deine maximale Lebensspanne zu erhöhen. Um sie zu erhalten, benötigst du einen Hammer.";
					case 189:
						return "Wenn du 10 Sternschnuppen gesammelt hast, können sie zur Herstellung eines Items kombiniert werden. Dieses Item erhöht deine magische Fähigkeit.";
					case 190:
						return "Sterne fallen nachts auf der ganzen Welt herunter. Sie können für alle möglichen nützlichen Dinge verwendet werden. Wenn du einen erspäht hast, dann greif ihn dir schnell - sie verschwinden nach Sonnenaufgang.";
					case 191:
						return "Es gibt viele Möglichkeiten, wie du Menschen dazu bewegen kannst, in unsere Stadt zu ziehen. Sie brauchen zuallererst ein Zuhause.";
					case 192:
						return "Damit ein Raum wie ein Heim wirkt, braucht es eine Tür, einen Stuhl, einen Tisch und eine Lichtquelle. Achte darauf, dass das Haus auch Wände hat.";
					case 193:
						return "Zwei Menschen werden nicht im selben Haus leben wollen. Außerdem brauchen sie ein neues Zuhause, wenn ihr Heim zerstört wurde.";
					case 194:
						return "Du kannst das Behausungsinterface verwenden, um ein Haus zuzuweisen und anzuschauen. Öffne dein Inventar und klicke auf das Haus-Symbol.";
					case 195:
						return "Wenn du willst, dass ein Händler einzieht, brauchst du eine Menge Geld. 50 Silbermünzen sollten aber reichen.";
					case 196:
						return "Damit eine Krankenschwester einzieht, solltest du deine maximale Lebensspanne erhöhen.";
					case 197:
						return "Wenn du ein Gewehr hast, taucht garantiert ein Waffenhändler auf, um dir Munition zu verkaufen!";
					case 198:
						return "Du solltest dich selbst testen, indem du ein starkes Monster besiegst. Das wird die Aufmerksamkeit eines Dryaden erregen.";
					case 199:
						return "Erforsche das Verlies wirklich sorgfältig. Tief unten könnte sich ein Gefangener befinden.";
					case 200:
						return "Vielleicht hat der Greis vom Verlies Lust, bei uns mitzumachen - jetzt da sein Fluch aufgehoben wurde.";
					case 201:
						return "Behalte alle Bomben, die du findest. Ein Sprengmeister möchte vielleicht einen Blick darauf werfen.";
					case 202:
						return "Sind Goblins wirklich so anders als wir, dass wir nicht in Frieden zusammenleben können?";
					case 203:
						return "Ich hörte, dass ein mächtiger Zauberer in diesen Gebieten lebt. Achte bei deiner nächsten unterirdischen Expedition auf ihn.";
					case 204:
						return "Wenn du Linsen an einem Dämonenaltar kombinierst, kannst du vielleicht ein mächtiges Monster herbeirufen. Du solltest jedoch bis zur Nacht warten, bevor du es verwendest.";
					case 205:
						return "Du kannst einen Wurmköder mit verfaulten Fleischbrocken und Ekelpulver erzeugen. Achte aber darauf, dass du dich vor der Verwendung in einem verderbten Gebiet befindest.";
					case 206:
						return "Dämonenaltäre sind gewöhnlich im Verderben zu finden. Du musst aber nahe bei ihnen stehen, um Items herstellen zu können.";
					case 207:
						return "Du kannst einen Greifhaken aus einem Haken und 3 Ketten herstellen. Die Skelette tief unter der Erde tragen gewöhnlich Haken bei sich. Die Ketten dazu können aus Eisenbarren gefertigt werden.";
					case 208:
						return "Wenn du einen Topf siehst, so schlage ihn auf. Töpfe enthalten alle möglichen nützlichen Zubehörteile.";
					case 209:
						return "Verborgene Schätze sind auf der ganzen Welt zu finden! Einige erstaunliche Dinge sind auch tief unter der Erde aufzuspüren!";
					case 210:
						return "Beim Zerschlagen einer Schattenkugel fällt mitunter ein Meteor vom Himmel. Schattenkugeln können normalerweise in den Schluchten bei verderbten Gebieten gefunden werden.";
					case 211:
						return "Du solltest dich darauf konzentrieren, mehr Kristallherzen zur Erhöhung deiner maximalen Lebensspanne zu sammeln.";
					case 212:
						return "Deine jetzige Ausrüstung wird einfach nicht ausreichen. Du musst eine bessere Rüstung fertigen.";
					case 213:
						return "Ich denke, du bist bereit für deinen ersten großen Kampf. Sammle in der Nacht ein paar Linsen von den Augäpfeln und bringe sie zum Dämonenaltar.";
					case 214:
						return "Du solltest dein Leben verlängern, bevor du die nächste Herausforderung annimmst. 15 Herzen sollten ausreichen.";
					case 215:
						return "Der Ebenstein im Verderben kann durch Verwendung von etwas Pulver eines Dryaden gereinigt werden oder er kann durch Sprengstoffe zerstört werden.";
					case 216:
						return "Dein nächster Schritt ist, die verderbten Schluchten zu untersuchen. Suche nach Schattenkugeln und zerstöre sie!";
					case 217:
						return "Nicht weit von hier gibt es ein altes Verlies. Dies wäre ein guter Zeitpunkt, es zu untersuchen.";
					case 218:
						return "Du solltest versuchen, deine Lebensspanne auf das Maximum anzuheben. Versuche, 20 Herzen zu finden.";
					case 219:
						return "Im Dschungel lassen sich viele Schätze finden, wenn du bereit bist, tief genug zu graben.";
					case 220:
						return "Die Unterwelt entstand aus einem Material, welches sich Höllenstein nennt. Es ist perfekt geeignet für die Produktion von Waffen und Rüstungen.";
					case 221:
						return "Wenn du bereit bist, den Wächter der Unterwelt herauszufordern, musst du ein Opfer bringen. Alles was du brauchst, findest du in der Unterwelt.";
					case 222:
						return "Zerschlage jeden Dämonenaltar, den du findest. Etwas Gutes wird sich ereignen!";
					case 223:
						return "Seelen können manchmal von gefallenen Kreaturen an Orten extremen Lichts oder extremer Finsternis aufgesammelt werden.";
					case 224:
						return "Ho ho ho, und eine Flasche ... Egg Nog!";
					case 225:
						return "Würdest du mir ein paar Plätzchen backen?";
					case 226:
						return "Was? Du dachtest, ich wäre nicht real?";
				}
			}
			else if (LangOption == (int)ID.ITALIAN)
			{
				switch (QuoteID)
				{
					case 1:
						return "Spero che tra noi e l'Occhio di Cthulhu non ci sia solo un bimbo scarno come te.";
					case 2:
						return "Guarda la pessima armatura che indossi. Faresti meglio a comprare più pozioni curative.";
					case 3:
						return "Ho la sensazione che una presenza malvagia mi stia guardando.";
					case 4:
						return "Spada batte carta! Prendine una oggi.";
					case 5:
						return "Desideri mele? Carote? Ananas? Abbiamo delle torce.";
					case 6:
						return "Bella mattina, no? C'era qualcosa di cui avevi bisogno?";
					case 7:
						return "Presto si farà notte, amico. Fai le tue scelte finché puoi.";
					case 8:
						return "Non immagini quanti blocchi di terra si vendono oltreoceano.";
					case 9:
						return "Ah, racconteranno storie di " + PlayerName + " un giorno... belle storie ovviamente.";
					case 10:
						return "Guarda i miei blocchi di terra: sono super terrosi.";
					case 11:
						return "Ragazzo, quel sole scotta! Ho un'armatura perfettamente ventilata.";
					case 12:
						return "Il sole è alto, ma i miei prezzi no.";
					case 13:
						return "Fantastico! Da qui sento " + MechanicName + " e " + NurseName + " discutere.";
					case 14:
						return "Hai visto Chith... Shith... Chat... Il grande occhio?";
					case 15:
						return "Ehi, questa casa è sicura, no? Giusto? " + PlayerName + "?";
					case 16:
						return "Nemmeno una Luna di Sangue può fermare il capitalismo. Facciamo un po' di affari.";
					case 17:
						return "Tieni d'occhio il premio, compra una lente!";
					case 18:
						return "Kosh, kapleck Mog. Oh scusa, in klingon significa 'Compra qualcosa o muori.'";
					case 19:
						return "Sei, " + PlayerName + ", vero? Ho sentito belle cose su di te!";
					case 20:
						return "Sento che c'è un tesoro segreto... non importa.";
					case 21:
						return "Una Statua D'Angelo, dici? Scusa, non tratto cianfrusaglie.";
					case 22:
						return "L'ultimo ragazzo venuto qui mi lasciò delle cianfrusaglie... o meglio... tesori!";
					case 23:
						return "Mi chiedo se la luna sia fatta di formaggio... Uhm, cosa? Oh sì, compra qualcosa!";
					case 24:
						return "Hai detto oro? Te lo tolgo io.";
					case 25:
						return "Niente sangue su di me.";
					case 26:
						return "Sbrigati e smettila di sanguinare.";
					case 27:
						return "Se stai per morire, fallo fuori.";
					case 28:
						return "Cosa vorresti insinuare?!";
					case 29:
						return "Quel tuo tono non mi piace.";
					case 30:
						return "Che ci fai qui? Se non sanguini, non devi stare qui. Via.";
					case 31:
						return "COSA?!";
					case 32:
						return "Hai visto il vecchio che gira intorno alla segreta? Sembra agitato.";
					case 33:
						return "Vorrei che " + DemoName + " fosse più attento.  Mi sto stancando di dovergli ricucire gli arti ogni giorno.";
					case 34:
						return "Ehi, " + DealerName + " ha detto di dover andare dal dottore per qualche ragione? Solo per chiedere.";
					case 35:
						return "Devo parlare seriamente con " + GuideName + ". Quante volte a settimana si può venire con gravi ustioni da lava?";
					case 36:
						return "Penso che tu stia meglio così.";
					case 37:
						return "Ehm... Che ti è successo alla faccia?";
					case 38:
						return "SANTO CIELO! Sono brava, ma non fino a questo punto.";
					case 39:
						return "Cari amici, siamo qui riuniti, oggi, per congedarci... Oh, ti riprenderai.";
					case 40:
						return "Hai lasciato il braccio laggiù. Te lo prendo io...";
					case 41:
						return "Smettila di fare il bambino! Ho visto di peggio.";
					case 42:
						return "Serviranno dei punti!";
					case 43:
						return "Di nuovo problemi con quei bulli?";
					case 44:
						return "Aspetta, ho i cerotti con i cartoni animati da qualche parte.";
					case 45:
						return "Cammina, " + PlayerName + " starai bene. Fiuu.";
					case 46:
						return "Ti fa male quando lo fai? Non farlo.";
					case 47:
						return "Sembri mezzo digerito. Hai di nuovo inseguito gli slime?";
					case 48:
						return "Gira la testa e tossisci.";
					case 49:
						return "Non è la ferita più grande che abbia mai visto... Ne ho viste certamente di più grandi.";
					case 50:
						return "Vuoi un lecca-lecca?";
					case 51:
						return "Dimmi dove ti fa male.";
					case 52:
						return "Scusa, ma non puoi permetterti di avermi.";
					case 53:
						return "Avrò bisogno di più soldi.";
					case 54:
						return "Sai che non lavoro gratis.";
					case 55:
						return "Non faccio lieti fini.";
					case 56:
						return "Non posso fare più nulla per te senza chirurgia plastica.";
					case 57:
						return "Smettila di sprecare il mio tempo.";
					case 227:
						return "Sono riuscita a cucire di nuovo la tua faccia. Stai più attento la prossima volta.";
					case 228:
						return "Probabilmente ti lascerà una cicatrice.";
					case 229:
						return "I miei migliori auguri. Non voglio vederti saltare da altre scogliere.";
					case 230:
						return "Non ti ha fatto male, vero?";
					case 58:
						return "Ho sentito che c'è una bambola molto simile a " + GuideName + " nel sotterraneo. Vorrei metterci dei proiettili.";
					case 59:
						return "Veloce! Ho un appuntamento con " + NurseName + " tra un'ora.";
					case 60:
						return "Voglio quello che vende " + NurseName + ". In che senso, non vende niente?";
					case 61:
						return DryadName + " è uno spettacolo. Peccato sia così bigotta.";
					case 62:
						return "Lascia stare " + DemoName + ", qui ho tutto ciò che ti serve.";
					case 63:
						return "Qual è il problema di " + DemoName + "? Almeno lo sa che vendiamo oggetti diversi?";
					case 64:
						return "Beh, è una bella notte per non parlare con nessuno, non credi, " + PlayerName + "?";
					case 65:
						return "Mi piacciono le notti come questa. Non mancano mai cose da uccidere!";
					case 66:
						return "Vedo che stai addocchiando il Minishark... Meglio che non ti dica di cosa è fatto.";
					case 67:
						return "Ehi, non è un film, amico. Le munizioni sono extra.";
					case 68:
						return "Giù le mani dalla mia pistola, amico!";
					case 69:
						return "Hai provato a utilizzare la polvere purificatrice sulla pietra d'ebano della corruzione?";
					case 70:
						return "Vorrei che " + DealerName + " la smettesse di flirtare con me. Non sa che ho 500 anni?";
					case 71:
						return "Perché " + MerchantName + " continua a vendermi statue d'angelo? Lo sanno tutti che non servono a nulla.";
					case 72:
						return "Hai visto il vecchio che gira intorno alla dungeon? Non ha per niente un bell'aspetto...";
					case 73:
						return "Vendo ciò che voglio! Se non ti piace, pazienza.";
					case 74:
						return "Perché devi essere così conflittuale in un momento come questo?";
					case 75:
						return "Non voglio che tu compri la mia roba. Voglio che tu desideri comprarla, ok?";
					case 76:
						return "Amico, sbaglio o ci sono tipo un milione di zombie in giro, stanotte?";
					case 77:
						return "Devi purificare il mondo da questa corruzione.";
					case 78:
						return "Sii cauto: Terraria ha bisogno di te!";
					case 79:
						return "Il tempo vola e tu, ahimé, non stai invecchiando molto bene.";
					case 80:
						return "Cos'è questa storia di me che abbaio, ma non mordo?";
					case 81:
						return "Due goblin entrano in un bar e uno dice all'altro: 'Vuoi un calice di birra?!' ";
					case 82:
						return "Non posso farti entrare finché non mi libererai dalla maledizione.";
					case 83:
						return "Torna di notte se vuoi entrare.";
					case 84:
						return "Il mio padrone non può essere evocato di giorno.";
					case 85:
						return "Sei decisamente troppo debole per sconfiggere la mia maledizione. Torna quando servirai a qualcosa.";
					case 86:
						return "Tu, pazzo patetico. Non puoi sperare di affrontare il mio padrone ora come ora.";
					case 87:
						return "Spero che tu abbia almeno sei amici che ti coprano le spalle.";
					case 88:
						return "No, ti prego, straniero. Finirai per essere ucciso.";
					case 89:
						return "Potresti essere abbastanza forte da liberarmi dalla mia maledizione...";
					case 90:
						return "Straniero, hai la forza per sconfiggere il mio padrone?";
					case 91:
						return "Ti prego! Sconfiggi chi mi ha catturato e liberami, ti supplico!";
					case 92:
						return "Sconfiggi il mio padrone e ti farò passare nella dungeon.";
					case 93:
						return "Stai provando a superare quella pietra d'ebano, eh? Perché non metterci uno di questi esplosivi!";
					case 94:
						return "Ehi, hai visto un clown in giro?";
					case 95:
						return "C'era una bomba qui e ora non riesco a trovarla...";
					case 96:
						return "Ho qualcosa per quegli zombie, altroché!";
					case 97:
						return "Persino " + DealerName + " vuole ciò che sto vendendo!";
					case 98:
						return "Preferisci avere un buco da proiettile o granata? Ecco ciò che pensavo.";
					case 99:
						return "Sono sicuro che " + NurseName + " ti aiuterà se per caso perderai un arto.";
					case 100:
						return "Perché purificare il mondo quando potresti farlo saltare in aria?";
					case 101:
						return "Se verserai questo nella vasca da bagno e chiuderai tutte le finestre, ti pulirà le cavità nasali e ti sturerà le orecchie.";
					case 102:
						return "Vuoi giocare a Esplodi-Pollo?";
					case 103:
						return "Ehi, potresti firmare questa rinuncia al dolore?";
					case 104:
						return "VIETATO FUMARE QUI DENTRO!!";
					case 105:
						return "Gli esplosivi vanno a ruba di questi tempi. Comprane un po'!";
					case 106:
						return "È un bel giorno per morire!";
					case 107:
						return "Mi chiedo cosa succederà se io... (BUM!) ... Oh, scusa, ti serviva quella gamba?";
					case 108:
						return "La dinamite, la mia cura speciale per tutto ciò che ti affligge.";
					case 109:
						return "Guarda i miei prodotti: hanno prezzi esplosivi!";
					case 110:
						return "Continuo ad avere vaghi ricordi di aver legato una donna e averla gettata nella dungeon.";
					case 111:
						return "... abbiamo un problema! C'è una Luna di Sangue là fuori!";
					case 112:
						return "Fossi più giovane, chiederei a " + NurseName + " di uscire. Avevo un successone con le ragazze.";
					case 113:
						return "Quel tuo Cappello rosso mi sembra familiare...";
					case 114:
						return "Grazie ancora per avermi liberato dalla mia maledizione. Sentivo come qualcosa che saltava e mi mordeva.";
					case 115:
						return "Mia mamma mi diceva sempre che sarei stato un grande sarto.";
					case 116:
						return "La vita è come una scatola di vestiti; non sai mai ciò che indosserai!";
					case 117:
						return "Ricamare è difficile! Se non fosse così, nessuno lo farebbe! È ciò che lo rende fantastico.";
					case 118:
						return "So tutto ciò che c'è da sapere riguardo alle attività di sartoria.";
					case 119:
						return "Nella maledizione ero solo, perciò una volta mi creai un amico di pelle. Lo chiamai Wilson.";
					case 120:
						return "Grazie per avermi liberato, umano. Sono stato legato e lasciato qui da altri goblin. Si potrebbe dire che non andavamo proprio d'accordo.";
					case 121:
						return "Non posso credere che mi hanno legato e lasciato qui soltanto per far notare che non andavano verso est!";
					case 122:
						return "Ora che sono un escluso, posso buttar via le palle chiodate? Mi fanno male le tasche.";
					case 123:
						return "Cerchi un esperto di gadget? Sono il tuo goblin!";
					case 124:
						return "Grazie per l'aiuto. Ora devo smetterla di gironzolare senza scopo qui attorno. Sono sicuro che ci incontreremo di nuovo.";
					case 125:
						return "Pensavo fossi più alto.";
					case 126:
						return "Ehi... cosa sta combinando " + MechanicName + "? Hai... hai parlato con lei, per caso?";
					case 127:
						return "Ehi, il tuo cappello ha bisogno di un motore? Credo di averne uno perfettamente adatto.";
					case 128:
						return "Ciao, ho sentito che ti piacciono i razzi e gli stivali da corsa, così ho messo dei missili nei tuoi stivali.";
					case 129:
						return "Il silenzio è d'oro. Il nastro adesivo è d'argento.";
					case 130:
						return "SÌ, l'oro è più forte del ferro. Cosa insegnano al giorno d'oggi a questi umani?";
					case 131:
						return "Sai, quella combinazione casco da minatore-pinne era un'idea molto migliore sulla carta.";
					case 132:
						return "I goblin si irritano molto facilmente. Potrebbero persino scatenare una guerra per i tessuti!";
					case 133:
						return "A dire il vero, la maggior parte dei goblin non sono ingegneri aerospaziali. Beh, alcuni sì.";
					case 134:
						return "Sai perché noi tutti ci portiamo dietro queste palle chiodate? Perché io non lo faccio.";
					case 135:
						return "Ho appena finito la mia ultima creazione! Questa versione non esplode violentemente se ci si respira troppo forte sopra.";
					case 136:
						return "I ladri goblin non sono molto furbi. Non sanno nemmeno rubare da una cassa aperta!";
					case 137:
						return "Grazie per avermi salvato, amico! Questi legacci iniziavano a irritarmi.";
					case 138:
						return "Ohh, mio eroe!";
					case 139:
						return "Oh, eroica! Grazie per avermi salvato, ragazza!";
					case 140:
						return "Oh, eroico!  Grazie per avermi salvato, ragazzo!";
					case 141:
						return "Ora che ci conosciamo, posso trasferirmi da te, vero?";
					case 142:
						return "Bene, ciao, " + GuideName + "! Cosa posso fare per te oggi?";
					case 143:
						return "Bene, ciao, " + DemoName + "! Cosa posso fare per te oggi?";
					case 144:
						return "Bene, ciao, " + GoblinName + "! Cosa posso fare per te oggi?";
					case 145:
						return "Bene, ciao, " + NurseName + "! Cosa posso fare per te oggi?";
					case 146:
						return "Bene, ciao, " + MechanicName + "! Cosa posso fare per te oggi?";
					case 147:
						return "Bene, ciao, " + DryadName + "! Cosa posso fare per te oggi?";
					case 148:
						return "Vuoi che tiri fuori una moneta da dietro il tuo orecchio? No? Ok.";
					case 149:
						return "Vuoi dei dolci magici? No? Ok.";
					case 150:
						return "Posso preparare una cioccalata calda proprio deliziosa se sei inter...No? Ok.";
					case 151:
						return "Sei qui per dare un'occhiata alla mia sfera di cristallo?";
					case 152:
						return "Mai desiderato un anello incantato che trasforma le rocce in slime? Neanch'io.";
					case 153:
						return "Una volta qualcuno mi disse che l'amicizia è magica. Sciocchezze. Non puoi trasformare le persone in rane con l'amicizia.";
					case 154:
						return "Ora vedo il tuo futuro... Comprerai molti prodotti da me!";
					case 155:
						return "Una volta ho provato a dare la vita a una Statua D'Angelo. Invano.";
					case 156:
						return "Grazie! Era solo questione di tempo prima che facessi la stessa fine degli scheletri laggiù.";
					case 157:
						return "Ehi, guarda dove stai andando! Ero laggiù un attimo fa!";
					case 158:
						return "Resisti, sono quasi riuscito a portare fin qui il Wi-Fi.";
					case 159:
						return "Ma ero quasi riuscito a mettere luci intermittenti quassù!";
					case 160:
						return "NON MUOVERTI. MI È CADUTA UNA LENTE A CONTATTO.";
					case 161:
						return "Tutto ciò che voglio è che l'interruttore faccia... Cosa?!";
					case 162:
						return "Oh, fammi indovinare. Non hai comprato abbastanza cavi. Idiota.";
					case 163:
						return "Soltanto-potresti soltanto... Per favore? Ok? Ok. Puah.";
					case 164:
						return "Non apprezzo il modo in cui mi guardi. Sto LAVORANDO ora.";
					case 165:
						return "Ehi, " + PlayerName + ", sei appena stato da " + GoblinName + "? Ha detto qualcosa di me, per caso?";
					case 166:
						return DealerName + " continua a dire di aver schiacciato la mia piastra a pressione. Gli ho spiegato che serve proprio a quello.";
					case 167:
						return "Compra sempre più cavi del necessario!";
					case 168:
						return "Ti sei assicurato che il tuo dispositivo fosse collegato?";
					case 169:
						return "Oh, sai di cosa ha bisogno questa casa? Di più luci intermittenti.";
					case 170:
						return "Si può dire che appare una luna di sangue quando il cielo si fa rosso.  C'è qualcosa in lei che ridesta i mostri.";
					case 171:
						return "Ehi, amico, sai dov'è un po' di erba della morte? Scusa, me lo stavo solo chiedendo, tutto qua.";
					case 172:
						return "Se dovessi alzare lo sguardo, vedresti che la luna è rossa ora.";
					case 173:
						return "Dovresti stare dentro di notte. È molto pericoloso girare al buio.";
					case 174:
						return "Saluti, " + PlayerName + ". Come posso esserti utile?";
					case 175:
						return "Sono qui per darti consigli su cosa fare dopo. Ti consiglio di parlare con me ogni volta che sarai nei guai.";
					case 176:
						return "Si dice ci sia una persona che ti dirà come sopravvivere in questa terra... Aspetta. Sono io.";
					case 177:
						return "Puoi utilizzare il piccone per scavare nell'immondizia e l'ascia per abbattere gli alberi. Posiziona il cursore sulla mattonella e clicca " + RightTrigger + "!";
					case 178:
						return "Se vuoi sopravvivere, dovrai creare armi e un riparo. Inizia abbattendo gli alberi e raccogliendo legna.";
					case 179:
						return "Clicca su " + YButton + "per accedere al menu Creazione Oggetti. Quando avrai abbastanza legna, crea un banco da lavoro. Così potrai creare oggetti più sofisticati, finché sarai vicino ad esso.";
					case 180:
						return "Puoi costruirti un riparo con legna o altri blocchi nel mondo. Non dimenticare di creare e sistemare i muri.";
					case 181:
						return "Una volta che possiederai una spada di legno, puoi provare a raccogliere la gelatina dagli slime. Unisci la legna e la gelatina per creare una torcia!";
					case 182:
						return "Per interagire con gli ambienti e gli oggetti posizionati, usa un martello!";
					case 183:
						return "Devi praticare un po' di estrazione per trovare minerali metallici. Puoi crearci oggetti molto utili.";
					case 184:
						return "Ora che hai un po' di minerale, dovrai trasformarlo in una barra per poterci fare degli oggetti. Per questo serve una fornace!";
					case 185:
						return "Puoi creare una fornace con torce, legna e pietra. Assicurati di essere vicino a un banco da lavoro.";
					case 186:
						return "Avrai bisogno di un'incudine per creare la maggior parte degli oggetti dalle barre metalliche.";
					case 187:
						return "Le incudini possono essere create con del ferro o acquistate da un mercante.";
					case 188:
						return "Nel Sottoterraneo vi sono cuori di cristallo che possono essere utilizzati per aumentare la tua vita massima. Dovrai avere un martello per ottenerli.";
					case 189:
						return "Se raccoglierai 10 stelle cadenti, potrai combinarle per creare un oggetto che aumenterà le tue abilità magiche.";
					case 190:
						return "Le stelle cadono sul mondo di notte. Possono essere utilizzate per ogni tipo di oggetto utile.  Se ne vedi una, cerca di afferrarla, poiché scomparirà dopo l'alba.";
					case 191:
						return "Ci sono diversi modi per convincere le persone a trasferirsi nella tua città. Di sicuro dovranno avere una casa in cui vivere.";
					case 192:
						return "Perché una stanza sia considerata una casa, ha bisogno di una porta, una sedia, un tavolo e una fonte di illuminazione. Assicurati che la casa abbia anche i muri.";
					case 193:
						return "Due persone non possono vivere nella stessa casa. Inoltre, se la loro casa verrà distrutta, cercheranno un nuovo posto in cui vivere.";
					case 194:
						return "Puoi utilizzare l'interfaccia Alloggio per visualizzare e assegnare gli alloggi. Apri l'inventario e clicca sull'icona della casa.";
					case 195:
						return "Se vuoi che un mercante si trasferisca, dovrai raccogliere molto denaro. Servono 50 monete d'argento!";
					case 196:
						return "Se vuoi che un'infermiera si trasferisca, dovrai aumentare la tua vita massima.";
					case 197:
						return "Se avessi una pistola, scommetto che potrebbe apparire un mercante d'armi per venderti munizioni!";
					case 198:
						return "Dovresti metterti alla prova sconfiggendo un mostro forte. Così attirerai l'attenzione di una driade.";
					case 199:
						return "Esplora attentamente tutta la dungeon. Potrebbero esserci prigionieri nelle zone più profonde.";
					case 200:
						return "Forse il vecchio della dungeon vorrebbe unirsi a noi, ora che la maledizione è terminata.";
					case 201:
						return "Arraffa tutte le bombe che potresti trovare. Un esperto di demolizioni potrebbe volerci dare un'occhiata.";
					case 202:
						return "I goblin sono così diversi da noi che non possiamo convivere in maniera pacifica?";
					case 203:
						return "Ho sentito che c'era un potente stregone da queste parti. Tienilo d'occhio la prossima volta che scenderai sottoterra.";
					case 204:
						return "Se unirai le lenti a un altare dei demoni, potresti trovare un modo per evocare un potente mostro. Ma aspetta che si faccia buio prima di utilizzarlo.";
					case 205:
						return "Puoi creare un'esca di vermi con pezzi marci e polvere disgustosa. Assicurati di essere in una zona corrotta prima di utilizzarla.";
					case 206:
						return "Gli altari dei demoni si trovano generalmente nella corruzione. Dovrai essere vicino ad essi per creare oggetti.";
					case 207:
						return "Puoi creare un rampino con un uncino e tre catene. Gli scheletri sottoterra di solito trasportano gli uncini, mentre le catene possono essere ricavate dalle barre di ferro.";
					case 208:
						return "Se vedi un vaso, demoliscilo e aprilo. Contiene una serie di utili provviste.";
					case 209:
						return "Vi sono tesori nascosti in tutto il mondo. Alcuni oggetti fantastici si possono trovare nelle zone sotterranee più profonde.";
					case 210:
						return "Demolire un'orbita d'ombra provocherà a volte la caduta di un meteorite dal cielo. Le orbite d'ombra si possono generalmente trovare negli abissi attorno alle zone distrutte.";
					case 211:
						return "Dovresti cercare di raccogliere più cuori di cristallo per aumentare la tua vita massima.";
					case 212:
						return "Il tuo equipaggiamento attuale non è sufficiente. Hai bisogno di un'armatura migliore.";
					case 213:
						return "Credo tu sia pronto per la tua prima grande battaglia. Raccogli lenti dai bulbi oculari di notte e portale a un altare dei demoni.";
					case 214:
						return "Aumenta la tua vita prima di affrontare la prossima sfida. Quindici cuori dovrebbero bastare.";
					case 215:
						return "La pietra d'ebano nella corruzione può essere purificata con polvere di driade o distrutta con esplosivi.";
					case 216:
						return "La prossima tappa consiste nell'esplorazione degli abissi corrotti. Trova e distruggi ogni orbita d'ombra che incontrerai.";
					case 217:
						return "C'è una vecchia dungeon non lontano da qui. Sarebbe il momento giusto per visitarla.";
					case 218:
						return "Dovresti tentare di massimizzare la vita disponibile. Prova a raccogliere venti cuori.";
					case 219:
						return "Ci sono molti tesori da scroprire nella giungla, se sei disposto a scavare abbastanza in profondità.";
					case 220:
						return "Il sotterraneo è composto da un materiale detto pietra infernale, perfetto per creare armi e armatura.";
					case 221:
						return "Quando sarai pronto a sfidare il custode del sotterraneo, dovrai fare un enorme sacrificio. Tutto ciò che ti serve si trova nel sotterraneo.";
					case 222:
						return "Assicurati di demolire ogni altare dei demoni che incontri. Se lo farai, ti succederà qualcosa di bello!";
					case 223:
						return "A volte è possibile riunire le anime delle creature morte in luoghi estremamente luminosi o bui.";
					case 224:
						return "Ho ho ho e una bottiglia di ... Egg Nog!";
					case 225:
						return "Ti sta a cuore prepararmi dei biscotti?";
					case 226:
						return "Che cosa? Credevi non fosse vero?";
				}
			}
			else if (LangOption == (int)ID.FRENCH)
			{
				switch (QuoteID)
				{
					case 1:
						return "Rassurez-moi, on ne doit pas compter que sur vous pour nous protéger de l'œil de Cthulhu.";
					case 2:
						return "Regardez-moi cette armure bas de gamme que vous avez sur le dos. Vous avez intérêt à acheter davantage de potions de soin.";
					case 3:
						return "Je sens une présence maléfique m'observer.";
					case 4:
						return "L'épée est plus forte que la plume. Achetez-en une dès aujourd'hui.";
					case 5:
						return "Vous voulez des pommes ? Vous voulez des poires ? Vous voulez des scoubidous ? Nous avons des torches.";
					case 6:
						return "Quelle belle matinée, n'est-ce pas\u00a0? Vous voulez quelque chose\u00a0?";
					case 7:
						return "La nuit va bientôt tomber, alors faites votre choix tant qu'il est encore temps.";
					case 8:
						return "Vous n'avez pas idée du prix des blocs de terre à l'étranger.";
					case 9:
						return "Un jour, des légendes étonnantes circuleront sur " + PlayerName + ".";
					case 10:
						return "Jetez un œil à mes blocs de terre, c'est de la terre de premier choix.";
					case 11:
						return "Voyez comme le soleil tape. J'ai des armures parfaitement ventilées.";
					case 12:
						return "Le soleil est haut dans le ciel, mais mes prix sont bas.";
					case 13:
						return "Super. J'entends " + MechanicName + " et " + NurseName + " se disputer d'ici.";
					case 14:
						return "Avez-vous vu Chult... Cthuch... Le truc avec le gros œil\u00a0?";
					case 15:
						return "Cette maison est sûre, n'est-ce pas ? Hein, " + PlayerName + "?";
					case 16:
						return "Même la lune sanglante ne peut arrêter le capitalisme. Alors, faisons affaires.";
					case 17:
						return "Pour garder un œil sur les prix, achetez une lentille.";
					case 18:
						return "Kosh, kapleck Mog. Oh désolé, ça veut dire « Achetez-moi quelque chose ou allez au diable » en klingon.";
					case 19:
						return "Vous êtes " + PlayerName + ", n'est-ce pas ? J'ai entendu de bonnes choses à votre sujet.";
					case 20:
						return "J'ai entendu dire qu'il y avait un trésor caché... Bon, laissez tomber.";
					case 21:
						return "Une statue d'ange, dites-vous ? Désolé, ce n'est pas une boutique de souvenirs ici.";
					case 22:
						return "Le dernier type qui est venu m'a vendu quelques sales... Je veux dire, de vrais trésors.";
					case 23:
						return "Je me demande si la lune est un gros fromage... Hein, quoi\u00a0? Oh, bien sûr, achetez ce que vous voulez\u00a0!";
					case 24:
						return "Vous avez dit or ? Je vais vous en débarrasser.";
					case 25:
						return "Faites attention de ne pas me mettre du sang partout.";
					case 26:
						return "Dépêchez-vous et arrêtez de saigner.";
					case 27:
						return "Si vous comptez mourir, faites-le dehors.";
					case 28:
						return "Qu'est-ce que ça veut dire\u00a0?";
					case 29:
						return "Je n'aime pas beaucoup votre ton.";
					case 30:
						return "Qu'est-ce que vous faites là\u00a0? Si vous ne saignez pas, sortez d'ici. Dehors\u00a0!";
					case 31:
						return "QUOI\u00a0?!";
					case 32:
						return "Vous avez vu ce vieil homme qui se pressait autour du donjon ? Il semblait avoir des ennuis.";
					case 33:
						return "J'aimerais bien que " + DemoName + " fasse plus attention. J'en ai assez de lui faire des points de suture chaque jour.";
					case 34:
						return "Je me demande si " + DealerName + " a dit qu'il avait besoin d'un docteur.";
					case 35:
						return "Il va falloir que je discute sérieusement avec " + GuideName + ". Combien de fois par semaine allez-vous revenir ici avec des brûlures au second degré ?";
					case 36:
						return "Vous avez meilleure mine comme ça.";
					case 37:
						return "Que vous est-il arrivé au visage ?";
					case 38:
						return "Bon sang, je suis une bonne infirmière, mais pas à ce point.";
					case 39:
						return "Mes chers amis, nous sommes rassemblés aujourd'hui pour faire nos adieux... Bon, tout se passera bien.";
					case 40:
						return "Vous avez laissé votre bras là-bas. Laissez-moi arranger ça.";
					case 41:
						return "Arrêtez de vous comporter comme une mauviette. J'ai déjà vu bien pire.";
					case 42:
						return "Cela va demander quelques points de suture.";
					case 43:
						return "Encore des soucis avec ces brutes ?";
					case 44:
						return "Attendez, je dois avoir quelques pansements pour enfants quelque part.";
					case 45:
						return "Allez faire quelques pas, " + PlayerName + ", ça devrait aller. Allez, ouste !";
					case 46:
						return "Ça vous fait mal quand vous faites ça ? Eh bien, ne le faites pas.";
					case 47:
						return "On dirait qu'on a commencé à vous digérer. Vous avez encore chassé des slimes ?";
					case 48:
						return "Tournez votre tête et toussez.";
					case 49:
						return "Ce n'est pas la plus grave blessure que j'ai vue... Oui, j'ai déjà vu des blessures bien plus graves que ça.";
					case 50:
						return "Vous voulez une sucette ?";
					case 51:
						return "Montrez-moi où vous avez mal.";
					case 52:
						return "Je suis désolée, mais vous n'avez pas les moyens.";
					case 53:
						return "Il va me falloir plus d'or que cela.";
					case 54:
						return "Je ne travaille pas gratuitement, vous savez.";
					case 55:
						return "Je ne vous garantis pas le résultat.";
					case 56:
						return "Je ne peux rien faire de plus pour vous sans chirurgie esthétique.";
					case 57:
						return "Arrêtez de me faire perdre mon temps.";
					case 227:
						return "J'ai réussi à recoudre votre visage. Faites plus attention la prochaine fois.";
					case 228:
						return "Cela va probablement laisser une cicatrice.";
					case 229:
						return "Ça va mieux. Je ne veux plus vous voir sauter du sommet des falaises.";
					case 230:
						return "Cela n'a pas fait trop mal, n'est-ce pas\u00a0?";
					case 58:
						return "J'ai entendu dire qu'il y aurait une poupée qui ressemblerait beaucoup à " + GuideName + " dans le monde inférieur. J'aimerais bien lui coller quelques pruneaux.";
					case 59:
						return "Dépêchez-vous, j'ai un rencard avec " + NurseName + " dans une heure.";
					case 60:
						return "Je veux ce que vend " + NurseName + ". Comment ça, elle ne vend rien !";
					case 61:
						return DryadName + " est vraiment canon. Dommage qu'elle soit aussi prude.";
					case 62:
						return "Ne vous embêtez pas avec " + DemoName + ", j'ai tout ce qu'il vous faut ici.";
					case 63:
						return "C'est quoi le problème de " + DemoName + " ? Est-ce qu'il réalise seulement que l'on vend du matériel complètement différent ?";
					case 64:
						return "Eh bien, c'est la nuit idéale pour ne parler à personne, n'est-ce pas, " + PlayerName + " ?";
					case 65:
						return "J'adore les nuits comme celle-ci, car il y a toujours des choses à tuer.";
					case 66:
						return "Je vois que vous êtes en train de zieuter le minishark... Mieux vaut ne pas savoir comment c'est fabriqué.";
					case 67:
						return "Eh, c'est pas du cinéma. Les munitions sont superflues.";
					case 68:
						return "Retirez les mains de mon flingue.";
					case 69:
						return "Avez-vous essayé d'utiliser de la poudre de purification sur la pierre d'ébène de corruption ?";
					case 70:
						return "Ce serait bien si " + DealerName + " cessait de me courtiser. Il n'a pas l'air de réaliser que j'ai 500\u00a0ans.";
					case 71:
						return "Pourquoi " + MerchantName + " essaie-t-il toujours de me vendre des statues d'ange ? Tout le monde sait qu'elles sont sans intérêt.";
					case 72:
						return "Avez-vous vu le vieil homme en train de marcher autour du donjon ? Il n'avait vraiment pas l'air bien.";
					case 73:
						return "Je vends ce que je veux, et si cela ne vous plaît pas, tant pis pour vous.";
					case 74:
						return "Pourquoi adopter un comportement aussi conflictuel en cette période ?";
					case 75:
						return "Je ne veux pas que vous achetiez mes marchandises, je veux que vous ayez envie de les acheter, vous saisissez la nuance\u00a0?";
					case 76:
						return "Dites, c'est moi ou il y a un million de zombies qui déambulent cette nuit ?";
					case 77:
						return "Je veux que vous purifiiez le monde de la corruption.";
					case 78:
						return "Faites attention, Terraria a besoin de vous.";
					case 79:
						return "Les sables du temps s'écoulent et il faut bien avouer que vous vieillissez plutôt mal.";
					case 80:
						return "Comment ça, j'aboie plus que je ne mords ?";
					case 81:
						return "C'est l'histoire de deux gobelins qui entrent dans une taverne et l'un dit à l'autre : « Tu veux un gobelet de bière ? »";
					case 82:
						return "Je ne peux pas vous laisser entrer tant que vous ne m'aurez pas débarrassé de ma malédiction.";
					case 83:
						return "Revenez à la nuit tombée si vous voulez entrer.";
					case 84:
						return "Mon maître ne peut pas être invoqué à la lumière du jour.";
					case 85:
						return "Vous êtes bien trop faible pour me débarrasser de ma malédiction. Revenez quand vous serez de taille.";
					case 86:
						return "C'est pathétique ! Vous n'espérez quand même pas affronter mon maître dans votre état.";
					case 87:
						return "J'espère que vous avez au moins six amis pour vous épauler.";
					case 88:
						return "Je vous en prie, ne faites pas ça. Vous allez vous faire tuer.";
					case 89:
						return "Votre puissance semble suffisante pour me débarrasser de ma malédiction.";
					case 90:
						return "Disposez-vous de la force nécessaire pour vaincre mon maître ?";
					case 91:
						return "S'il vous plaît, je vous en conjure, affrontez mon ravisseur et libérez-moi.";
					case 92:
						return "Terrassez mon maître et je vous ouvrirai la voie du donjon.";
					case 93:
						return "Vous essayez d'écouler cette pierre d'ébène, hein ? Pourquoi ne pas l'intégrer à l'un de ces explosifs ?";
					case 94:
						return "Dites donc, vous n'auriez pas vu un clown dans le coin ?";
					case 95:
						return "Il y avait une bombe juste là et je n'arrive plus à remettre la main dessus.";
					case 96:
						return "J'ai quelque chose dont les zombies raffolent.";
					case 97:
						return "Même " + DealerName + " raffole de mes marchandises.";
					case 98:
						return "Vous préférez un trou de balle ou un trou de grenade ? C'est bien ce que je pensais.";
					case 99:
						return NurseName + " vous aidera si jamais vous perdez un membre avec ça.";
					case 100:
						return "Pourquoi purifier le monde alors que vous pouvez tout faire sauter ?";
					case 101:
						return "Si vous lancez ça dans votre baignoire et que vous fermez les fenêtres, ça vous débouchera les sinus et les oreilles en moins de deux.";
					case 102:
						return "Vous voulez jouer au poulet-fusée ?";
					case 103:
						return "Pourriez-vous signer cette clause de non-responsabilité ?";
					case 104:
						return "INTERDICTION FORMELLE DE FUMER.";
					case 105:
						return "Les explosifs, c'est de la bombe en ce moment. Achetez-en dès maintenant.";
					case 106:
						return "C'est un bon jour pour mourir.";
					case 107:
						return "Je me demande ce qui va se passer si je... (BOUM !)... Désolé, vous aviez besoin de cette jambe ?";
					case 108:
						return "La dynamite, c'est mon remède spécial à tous vos petits problèmes.";
					case 109:
						return "Jetez un œil à mes marchandises, mes prix sont explosifs.";
					case 110:
						return "J'ai encore le vague souvenir d'avoir attaché une femme et de l'avoir balancée dans un donjon.";
					case 111:
						return "Il y a un problème, c'est la lune sanglante.";
					case 112:
						return "Si j'avais été plus jeune, j'aurais proposé un rencard à " + NurseName + ". J'étais un bourreau des cœurs dans le temps.";
					case 113:
						return "Ce chapeau rouge que vous portez me dit quelque chose.";
					case 114:
						return "Merci de m'avoir débarrassé de cette malédiction. J'avais l'impression que quelque chose m'avait mordu et ne me lâchait plus.";
					case 115:
						return "Ma mère m'a toujours dit que je ferais un bon tailleur.";
					case 116:
						return "La vie est comme le chapeau d'un magicien, on ne sait jamais ce qui va en sortir.";
					case 117:
						return "La broderie, c'est très difficile. Si ça ne l'était pas, personne n'en ferait. C'est ce qui la rend si intéressante.";
					case 118:
						return "Le commerce du prêt-à-porter n'a aucun secret pour moi.";
					case 119:
						return "Quand on est maudit, ça n'aide pas à se faire des amis. Alors un jour, je m'en suis fait un avec un morceau de cuir et je l'ai appelé Wilson.";
					case 120:
						return "Merci de m'avoir libéré, humain. J'ai été attaché et laissé ici par les autres gobelins. On peut dire qu'on ne s'entendait pas très bien, eux et moi.";
					case 121:
						return "Je n'arrive pas à croire qu'ils m'aient attaché et planté ici juste pour montrer qu'ils ne voulaient pas aller vers l'est.";
					case 122:
						return "Puisque je suis devenu un paria, puis-je jeter mes boules piquantes ? Mes poches me font mal.";
					case 123:
						return "Vous cherchez un expert en gadgets ? Je suis votre gobelin.";
					case 124:
						return "Merci de votre aide. À présent, je dois continuer à errer sans but dans les environs. Je suis sûr qu'on se reverra.";
					case 125:
						return "Je ne vous imaginais pas comme ça.";
					case 126:
						return "Et comment va " + MechanicName + "\u00a0? Lui auriez-vous parlé, par hasard\u00a0?";
					case 127:
						return "Est-ce que votre chapeau a besoin d'un moteur ? Je crois en avoir un en stock qui ferait parfaitement l'affaire.";
					case 128:
						return "J'ai entendu dire que vous aimiez les bottes de course et les fusées, du coup, j'ai installé des fusées dans vos bottes de course.";
					case 129:
						return "Le silence est d'or, mais le chatterton reste très efficace.";
					case 130:
						return "Oui, l'or est plus précieux que le fer. Mais qu'est-ce qu'ils vous apprennent chez les humains ?";
					case 131:
						return "C'est vrai que ce casque de mineur combiné à une palme rendait mieux sur le papier.";
					case 132:
						return "Les gobelins sont étonnamment soupe au lait. Ils pourraient déclencher une guerre pour un mot de travers.";
					case 133:
						return "Il faut bien avouer que les gobelins n'ont pas inventé la poudre, mais il y a des exceptions à la règle.";
					case 134:
						return "Savez-vous pourquoi on trimballe toujours ces boules piquantes ? Parce que moi, je n'en sais fichtre rien.";
					case 135:
						return "Je viens de mettre la touche finale à ma dernière invention. Et ce modèle n'explosera pas si vous soufflez trop fort dessus.";
					case 136:
						return "Les voleurs gobelins sont des vrais manchots. Ils ne sont même pas capables de dérober le contenu d'un coffre non verrouillé.";
					case 137:
						return "Merci de m'avoir secouru. Ces liens commençaient à m'irriter la peau.";
					case 138:
						return "Mon héros !";
					case 139:
						return "Quel héroïsme ! Merci de m'avoir sauvé, belle dame.";
					case 140:
						return "Quel héroïsme ! Merci de m'avoir sauvé, fringant jeune homme.";
					case 141:
						return "Maintenant que nous avons fait connaissance, je peux venir avec vous, n'est-ce pas ?";
					case 142:
						return "Bonjour, " + GuideName + "\u00a0! Que puis-je pour vous, aujourd'hui\u00a0?";
					case 143:
						return "Bonjour, " + DemoName + "\u00a0! Que puis-je pour vous, aujourd'hui\u00a0?";
					case 144:
						return "Bonjour, " + GoblinName + "\u00a0! Que puis-je pour vous, aujourd'hui\u00a0?";
					case 145:
						return "Bonjour, " + NurseName + "\u00a0! Que puis-je pour vous, aujourd'hui\u00a0?";
					case 146:
						return "Bonjour, " + MechanicName + "\u00a0! Que puis-je pour vous, aujourd'hui\u00a0?";
					case 147:
						return "Bonjour, " + DryadName + "\u00a0! Que puis-je pour vous, aujourd'hui\u00a0?";
					case 148:
						return "Voulez-vous que je fasse apparaître une pièce de monnaie de derrière votre oreille ? Non ? Bon.";
					case 149:
						return "Est-ce qu'un berlingot magique vous ferait plaisir ? Non ? Bon.";
					case 150:
						return "Je peux concocter un merveilleux chocolat chaud magique, si cela vous intéresse... Non\u00a0? Bon.";
					case 151:
						return "Souhaitez-vous jeter un œil à ma boule de cristal ?";
					case 152:
						return "N'avez-vous jamais rêvé de posséder un anneau magique qui transformerait les rochers en slimes\u00a0? Moi non plus, à vrai dire.";
					case 153:
						return "Un jour, quelqu'un m'a dit que l'amitié était quelque chose de magique. C'est n'importe quoi. On ne peut pas transformer quelqu'un en grenouille avec l'amitié.";
					case 154:
						return "À présent, votre avenir m'apparaît clairement... Vous allez m'acheter de nombreux objets.";
					case 155:
						return "Une fois, j'ai tenté de ramener une statue d'ange à la vie. Il ne s'est rien passé.";
					case 156:
						return "Merci. C'était moins une, j'ai failli terminer comme tous ces squelettes.";
					case 157:
						return "Attention où vous mettez les pieds. J'étais encore là-bas il y a peu.";
					case 158:
						return "Attendez, j'ai presque réussi à me connecter au Wi-Fi ici.";
					case 159:
						return "Mais j'avais presque terminé d'installer des stroboscopes là-haut.";
					case 160:
						return "QUE PERSONNE NE BOUGE ! J'AI PERDU UNE LENTILLE\u00a0!";
					case 161:
						return "Tout ce que je veux, c'est que l'interrupteur... Quoi ?";
					case 162:
						return "Je parie que vous n'avez pas acheté assez de câbles. Décidément, vous n'êtes vraiment pas une lumière.";
					case 163:
						return "Est-ce que vous pourriez juste... S'il vous plaît ? OK ? OK.";
					case 164:
						return "Je n'aime pas trop la façon dont vous me regardez. Je suis en train de travailler, moi.";
					case 165:
						return "Au fait, " + PlayerName + ", vous venez de voir  " + GoblinName + " ? Est-ce qu'il aurait parlé de moi, par hasard ?";
					case 166:
						return DealerName + " parle toujours de pressuriser mes plaques de pression. Je lui ai dit que c'était pour marcher dessus.";
					case 167:
						return "Il faut toujours acheter plus de câbles que prévu.";
					case 168:
						return "Vous avez bien vérifié que votre matériel était branché ?";
					case 169:
						return "Vous savez ce qu'il faudrait à cette maison ? Plus de stroboscopes.";
					case 170:
						return "La lune sanglante se remarque lorsque le ciel vire au rouge et quelque chose fait que les monstres pullulent.";
					case 171:
						return "Dites donc, vous savez où je peux trouver de la mauvaise herbe morte. Non, pour rien, je me demandais, c'est tout.";
					case 172:
						return "Si vous regardiez en l'air, vous verriez que là, la lune est toute rouge.";
					case 173:
						return "La nuit, vous devriez rester à l'intérieur. C'est très dangereux de se balader dans le noir.";
					case 174:
						return "Bienvenue, " + PlayerName + ". Je peux faire quelque chose pour vous\u00a0?";
					case 175:
						return "Je suis là pour vous conseiller et vous aider dans vos prochaines actions. Vous devriez venir me parler au moindre problème.";
					case 176:
						return "On dit qu'il y a une personne capable de vous aider à survivre sur ces terres... Oh, attendez, c'est moi.";
					case 177:
						return "Vous pouvez utiliser votre pioche pour creuser dans la terre, et votre hache pour abattre des arbres. Placez simplement le curseur à l'emplacement souhaité et cliquez.";
					case 178:
						return "Si vous voulez survivre, vous allez devoir fabriquer des armes et un abri. Commencez par abattre des arbres et récolter du bois.";
					case 179:
						return "Appuyez sur " + YButton + " pour accéder au menu d'artisanat. Lorsque vous avez assez de bois, créez un établi. Tant que vous vous tiendrez à proximité, il vous permettra de fabriquer des objets plus complexes.";
					case 180:
						return "Vous pouvez construire un abri en plaçant du bois ou d'autres blocs dans le monde. N'oubliez pas de créer des murs et de les placer.";
					case 181:
						return "Une fois que vous aurez une épée en bois, vous pourrez essayer de récupérer du gel grâce aux slimes. Combinez ensuite le bois et le gel pour faire une torche.";
					case 182:
						return "Pour interagir avec les arrière-plans et les objets placés, utilisez un marteau.";
					case 183:
						return "Vous devriez creuser pour trouver du minerai. Cela vous permet de fabriquer des objets très utiles.";
					case 184:
						return "Maintenant que vous avez du minerai, vous allez devoir le transformer en lingot pour pouvoir en faire des objets. Il vous faut une fournaise.";
					case 185:
						return "Vous pouvez fabriquer une fournaise avec des torches, du bois et de la pierre. Assurez-vous de vous tenir près d'un établi.";
					case 186:
						return "Vous aurez besoin d'une enclume pour pouvoir fabriquer la plupart des choses à partir des lingots de métal.";
					case 187:
						return "Une enclume peut être fabriquée avec du fer ou bien achetée chez les marchands.";
					case 188:
						return "Le souterrain contient des cœurs de cristal utilisés pour augmenter votre maximum de vie. Il vous faudra un marteau pour les extraire.";
					case 189:
						return "Si vous récupérez dix étoiles filantes, elles peuvent être combinées pour fabriquer un objet qui augmentera votre capacité de magie.";
					case 190:
						return "Les étoiles tombent sur le monde durant la nuit. Elles peuvent être utilisées pour toutes sortes de choses utiles. Si vous en voyez une, dépêchez-vous de la ramasser, car elles disparaissent l'aube venue.";
					case 191:
						return "Il existe de nombreux moyens pour attirer du monde dans notre ville. Bien sûr, une fois sur place, ces nouveaux arrivants auront besoin d'une maison pour s'abriter.";
					case 192:
						return "Pour qu'une pièce puisse être considérée comme un foyer, elle doit comporter une porte, une chaise, une table et une source de lumière. Assurez-vous que la maison dispose également de murs.";
					case 193:
						return "Deux personnes distinctes ne vivront pas dans le même foyer. De plus, si leur foyer est détruit, ils chercheront un nouveau lieu où habiter.";
					case 194:
						return "Vous pouvez utiliser l'interface de logement pour attribuer des logements et les visualiser. Ouvrez votre inventaire et cliquez sur l'icône de maison.";
					case 195:
						return "Si vous souhaitez qu'un marchand emménage, vous devrez avoir une quantité d'argent suffisante. 50 pièces d'argent devraient suffire.";
					case 196:
						return "Pour qu'une infirmière emménage, il vous faudra peut-être augmenter votre maximum de vie.";
					case 197:
						return "Si vous avez un pistolet, il se peut qu'un marchand d'armes fasse son apparition pour vous vendre des munitions.";
					case 198:
						return "Vous devriez montrer de quoi vous êtes capable en triomphant d'un monstre. Cela attirera l'attention d'une dryade.";
					case 199:
						return "Assurez-vous d'explorer minutieusement les donjons. Il pourrait y avoir des prisonniers retenus captifs dans les profondeurs.";
					case 200:
						return "Peut-être que le vieil homme du donjon voudra se joindre à nous maintenant que sa malédiction a été levée.";
					case 201:
						return "Récupérez toutes les bombes que vous pourrez trouver. Un démolisseur voudra sûrement y jeter un œil.";
					case 202:
						return "Les gobelins sont-ils si différents de nous pour que nous ne puissions pas vivre ensemble de manière paisible ?";
					case 203:
						return "J'ai entendu dire qu'un puissant magicien vivait dans les environs. Assurez-vous de le trouver la prochaine fois que vous irez dans le souterrain.";
					case 204:
						return "Si vous combinez des lentilles à un autel de démon, vous pourrez trouver un moyen d'invoquer un monstre très puissant. Cependant, il vous faudra attendre la tombée de la nuit avant de pouvoir l'utiliser.";
					case 205:
						return "Vous pouvez fabriquer de la nourriture pour ver avec des morceaux pourris et de la poudre infecte. Assurez-vous de vous trouver dans une zone corrompue avant de l'utiliser.";
					case 206:
						return "Les autels démoniaques peuvent généralement être trouvés dans la corruption. Il vous faudra vous tenir près d'eux pour fabriquer certains objets.";
					case 207:
						return "Vous pouvez fabriquer un grappin avec un crochet et trois chaînes. Les squelettes trouvés dans les profondeurs portent souvent des crochets sur eux. Les chaînes peuvent être fabriquées à l'aide de lingots de fer.";
					case 208:
						return "Si vous voyez des pots, détruisez-les pour les ouvrir, car ils contiennent souvent des objets très utiles.";
					case 209:
						return "Des trésors sont disséminés un peu partout dans le monde et vous pouvez trouver des objets fantastiques dans les profondeurs.";
					case 210:
						return "Lorsqu'on écrase un orbe d'ombre, il arrive qu'une météorite tombe du ciel. Les orbes d'ombre peuvent généralement être trouvés dans les gouffres des zones corrompues.";
					case 211:
						return "Vous devriez vous employer à récolter davantage de cristaux de cœur pour augmenter votre maximum de vie.";
					case 212:
						return "Votre équipement actuel ne suffira pas. Il vous faut une meilleure armure.";
					case 213:
						return "Je crois que vous pouvez maintenant prendre part à votre première grande bataille. De nuit, rassemblez des lentilles récupérées des globes oculaires et portez-les sur un autel du démon.";
					case 214:
						return "Vous devriez augmenter votre vie avant votre prochaine épreuve. Quinze cœurs devraient suffire.";
					case 215:
						return "La pierre d'ébène dans la corruption peut être purifiée en utilisant de la poudre fournie par une dryade, ou bien peut être détruite avec des explosifs.";
					case 216:
						return "Votre prochaine épreuve sera d'explorer les abîmes corrompus. Trouvez et détruisez tous les orbes d'ombre que vous trouverez.";
					case 217:
						return "Il existe un vieux donjon situé pas très loin d'ici. Vous devriez aller y faire un tour dès maintenant.";
					case 218:
						return "Vous devriez essayer d'augmenter votre vie au maximum. Essayez de rassembler vingt cœurs.";
					case 219:
						return "Si vous pouvez creuser assez profondément, il y a de nombreux trésors à découvrir dans la jungle.";
					case 220:
						return "Le monde des Enfers est fait d'un matériau appelé pierre de l'enfer. Ce matériau est parfait pour la fabrication d'armes et d'armures.";
					case 221:
						return "Lorsque vous voudrez affronter le gardien du monde des Enfers, vous devrez faire le sacrifice d'un être vivant. Tout ce dont vous avez besoin pour cela se trouve dans le monde des Enfers.";
					case 222:
						return "Assurez-vous d'écraser tous les autels de démon que vous trouverez. Vous pourrez en tirer quelque chose de bénéfique.";
					case 223:
						return "Des âmes peuvent être parfois récupérées des créatures déchues dans des lieux de lumière ou d'ombre extrême.";
					case 224:
						return "Ho ho ho et une bouteille de... lait de poule\u00a0!";
					case 225:
						return "Vous voulez bien me faire des biscuits\u00a0?";
					case 226:
						return "Quoi\u00a0? Vous pensiez que je n'existais pas\u00a0?";
				}
			}
			else if (LangOption == (int)ID.SPANISH)
			{
				switch (QuoteID)
				{
					case 1:
						return "Espero que un canijo como tú no sea lo único que se interpone entre nosotros y el Ojo de Cthulu.";
					case 2:
						return "Vaya una armadura más chapucera que llevas. Yo de ti compraría más pociones curativas.";
					case 3:
						return "Siento como si una presencia maligna me observara.";
					case 4:
						return "¡La espada siempre gana! Cómprate una ahora.";
					case 5:
						return "¿Quieres manzanas? ¿Zanahorias? ¿Unas piñas? Tenemos antorchas.";
					case 6:
						return "Una mañana estupenda, ¿verdad? ¿No necesitas nada?";
					case 7:
						return "La noche caerá pronto, amigo. Haz tus compras mientras puedas.";
					case 8:
						return "Ni te imaginas lo bien que se venden los bloques de tierra en el extranjero.";
					case 9:
						return "Oh, algún día narrarán las aventuras de " + PlayerName + "... y seguro que acaban bien.";
					case 10:
						return "Echa un vistazo a estos bloques de tierra... ¡Tienen extra de tierra!";
					case 11:
						return "¡Oye, cómo pega el sol! Por suerte, tengo armaduras totalmente transpirables.";
					case 12:
						return "El sol está alto, al contrario que mis precios.";
					case 13:
						return "¡Vaya! Desde aquí se oye cómo discuten " + MechanicName + " y " + NurseName + ".";
					case 14:
						return "¿Has visto a Chith... esto... Shith... eh... Chat...? Vamos, ¿al gran Ojo?";
					case 15:
						return "Oye, esta casa es segura, ¿verdad? ¿Verdad? " + PlayerName + "...";
					case 16:
						return "Ni siquiera una luna de sangre detendría el capitalismo. Así que vamos a hacer negocios.";
					case 17:
						return "No pierdas de vista tus sueños. ¡Compra una lente!";
					case 18:
						return "Kosh, kapleck Mog. Lo siento, hablaba en klingon... quiere decir \"Compra algo o muere\".";
					case 19:
						return "¿Eres tú, " + PlayerName + "? ¡Me han hablado bien de ti, amigo!";
					case 20:
						return "Dicen que aquí hay un tesoro escondido... Oh, olvídalo...";
					case 21:
						return "¿La estatua de un ángel? Lo siento pero no vendo cosas de segunda mano.";
					case 22:
						return "El último tipo que estuvo aquí me dejó algunos trastos viejos... ¡Bueno, en realidad eran tesoros!";
					case 23:
						return "Me pregunto si la luna estará hecha de queso... Eh... esto... ¿Querías comprar algo?";
					case 24:
						return "¿Has dicho oro? Me lo quedo.";
					case 25:
						return "Será mejor que no me manches de sangre.";
					case 26:
						return "Date prisa... y deja ya de sangrar.";
					case 27:
						return "Si te vas a morir hazlo fuera, por favor.";
					case 28:
						return "¿Y eso qué quiere decir?";
					case 29:
						return "No me gusta el tono que empleas.";
					case 30:
						return "¿Por qué sigues aquí? Si no te estás desangrando, aquí no pintas nada. Lárgate.";
					case 31:
						return "¿¡CÓMO!?";
					case 32:
						return "¿Has visto a ese anciano que deambula por la mazmorra? Parece que tiene problemas.";
					case 33:
						return "Ojalá " + DemoName + " tuviera más cuidado. Ya me estoy hartando de tener que coserle las extremidades todos los días.";
					case 34:
						return "Oye, por curiosidad, ¿ha dicho " + DealerName + " por qué tiene que ir al médico?";
					case 35:
						return "Debo hablar en serio con " + GuideName + ". ¿Cuántas veces crees que puedes venir en una semana con quemaduras de lava graves?";
					case 36:
						return "Creo que así estarás mejor.";
					case 37:
						return "Eh... ¿Qué te ha pasado en la cara?";
					case 38:
						return "¡DIOS MÍO! Soy buena en mi trabajo, pero no tanto.";
					case 39:
						return "Queridos amigos, nos hemos reunido hoy aquí para decir adiós a... ¡Era broma! Saldrás de esta.";
					case 40:
						return "Te dejaste el brazo por ahí. Deja que te ayude...";
					case 41:
						return "¡Deja de comportarte como un bebé! He visto cosas peores.";
					case 42:
						return "¡Voy a tener que darte puntos!";
					case 43:
						return "¿Ya te has vuelto a meter en líos?";
					case 44:
						return "Aguanta, por aquí tengo unas tiritas infantiles chulísimas.";
					case 45:
						return "Anda ya, " + PlayerName + ", te pondrás bien. Serás nenaza...";
					case 46:
						return "Así que te duele cuando haces eso... Pues no lo hagas.";
					case 47:
						return "Vienes como si estuvieras a medio digerir. ¿Has estado cazando slimes otra vez?";
					case 48:
						return "Gira la cabeza y tose.";
					case 49:
						return "No es de las peores heridas que he visto... Sin duda, he visto heridas más grandes que esta.";
					case 50:
						return "¿Quieres una piruleta, chiquitín?";
					case 51:
						return "A ver... ¿Dónde te duele?";
					case 52:
						return "Lo siento, pero no trabajo por caridad.";
					case 53:
						return "Vas a necesitar más oro del que traes.";
					case 54:
						return "Oye, yo no trabajo gratis.";
					case 55:
						return "No tengo una varita mágica.";
					case 56:
						return "Esto es todo lo que puedo hacer por ti... Necesitas cirugía plástica.";
					case 57:
						return "No me hagas perder el tiempo.";
					case 227:
						return "Me las arreglé para coserte la cara de nuevo. Ten más cuidado la próxima vez.";
					case 228:
						return "Seguramente te quede una cicatriz.";
					case 229:
						return "Ya está. No quiero verte saltar por más acantilados.";
					case 230:
						return "No ha sido para tanto, ¿verdad?";
					case 58:
						return "Dicen que en alguna parte del Inframundo hay una muñeca que se parece mucho a " + GuideName + ". Ojalá pudiera usarla para practicar el tiro al blanco.";
					case 59:
						return "¡Date prisa! Tengo una cita con " + NurseName + " dentro de una hora.";
					case 60:
						return "Quiero lo que vende " + NurseName + ". ¿Cómo dices? ¿Que no vende nada?";
					case 61:
						return DryadName + " es una monada. Es una lástima que sea tan mojigata.";
					case 62:
						return "Olvídate de " + DemoName + ", yo tengo todo lo que necesitas aquí y ahora.";
					case 63:
						return "¿Qué mosca le ha picado a " + DemoName + "? ¿Aún no sabe que vendemos cosas totalmente distintas?";
					case 64:
						return "Oye, hace una noche magnífica para no hablar con nadie, ¿no crees, " + PlayerName + "?";
					case 65:
						return "Me encantan estas noches. ¡Siempre encuentras algo que matar!";
					case 66:
						return "Veo que le has echado el ojo al Minitiburón. Será mejor que no sepas de qué está hecho.";
					case 67:
						return "Eh, amigo, que esto no es una película. La munición va aparte.";
					case 68:
						return "¡Aparta esas manos de mi pistola, colega!";
					case 69:
						return "¿Has probado a usar polvos de purificación sobre la piedra de ébano corrupta?";
					case 70:
						return "Ojalá " + DealerName + " dejara de flirtear conmigo. ¿No se da cuenta de que tengo 500 años?";
					case 71:
						return "¿Por qué se empeña " + MerchantName + " en intentar venderme una estatua de ángel? Todo el mundo sabe que no sirven para nada.";
					case 72:
						return "¿Has visto a ese anciano que deambula por la mazmorra? No tiene muy buen aspecto...";
					case 73:
						return "¡Yo vendo lo que quiero! Si no te gusta, mala suerte.";
					case 74:
						return "¿Por qué tienes que ser tan beligerante en estos tiempos que corren?";
					case 75:
						return "No quiero que compres mis artículos. Quiero que desees comprar mis artículos, ¿entiendes?";
					case 76:
						return "Oye, ¿soy yo o esta noche han salido de juerga un millón de zombis?";
					case 77:
						return "Debes erradicar la corrupción de este mundo.";
					case 78:
						return "Ponte a salvo; ¡Terraria te necesita!";
					case 79:
						return "Fluyen las arenas del tiempo. Y la verdad, no estás envejeciendo con mucha elegancia.";
					case 80:
						return "¿Qué tiene que ver conmigo eso de perro ladrador?";
					case 81:
						return "Entra un duende en un bar y dice el dueño: \"A ver, quiero control, ¿eh?\". Y dice el duende: \"No, sin trol, sin trol\".";
					case 82:
						return "No puedo dejarte entrar hasta que me liberes de esta maldición.";
					case 83:
						return "Si quieres entrar, vuelve por la noche.";
					case 84:
						return "No se puede invocar al maestro a la luz del día.";
					case 85:
						return "Eres demasiado débil para romper esta maldición. Vuelve cuando seas de más utilidad.";
					case 86:
						return "Eres patético. No esperes presentarte ante el maestro tal como eres.";
					case 87:
						return "Espero que hayas venido con varios amigos...";
					case 88:
						return "No lo hagas, forastero. Sería un suicidio.";
					case 89:
						return "Tal vez seas lo bastante fuerte para poder librarme de esta maldición...";
					case 90:
						return "Forastero, ¿te crees con fuerzas para derrotar al maestro?";
					case 91:
						return "¡Por favor! ¡Lucha con mi raptor y libérame! ¡Te lo suplico!";
					case 92:
						return "Derrota al maestro y te permitiré entrar a la mazmorra.";
					case 93:
						return "¿Conque intentando librarte de esa piedra de ébano, eh? ¿Por qué pruebas con estos explosivos?";
					case 94:
						return "Eh, ¿has visto a un payaso por aquí?";
					case 95:
						return "Había una bomba aquí mismo, y ahora no soy capaz de encontrarla...";
					case 96:
						return "¡Yo les daré a esos zombis lo que necesitan!";
					case 97:
						return "¡Incluso " + DealerName + " quiere lo que vendo!";
					case 98:
						return "Y pensé: ¿Qué prefieres? ¿Un agujero de bala o de granada?";
					case 99:
						return "Seguro que " + NurseName + " te ayudará si pierdes una extremidad jugando con estas monadas...";
					case 100:
						return "¿Por qué purificar el mundo cuando puedes volarlo en pedazos?";
					case 101:
						return "¡Si lanzas uno de estos en la bañera y cierras todas las ventanas, te despejará la nariz y los oídos!";
					case 102:
						return "¿Quieres jugar con fuego, gallina?";
					case 103:
						return "Oye, ¿firmarías esta renuncia de daños y perjuicios?";
					case 104:
						return "¡AQUÍ NO SE PUEDE FUMAR!";
					case 105:
						return "Los explosivos están de moda hoy en día. ¡Llévate unos cuantos!";
					case 106:
						return "¡Es un buen día para morir!";
					case 107:
						return "Y qué pasa si... (¡BUM!)... Oh, lo siento, ¿usabas mucho esa pierna?";
					case 108:
						return "Dinamita, mi propia panacea para todos los males.";
					case 109:
						return "Echa un vistazo a este género; ¡los precios son una bomba!";
					case 110:
						return "Recuerdo vagamente haber atado a una mujer y haberla arrojado a una mazmorra.";
					case 111:
						return "¡Tenemos un problema! ¡Hoy tenemos luna de sangre!";
					case 112:
						return "Si fuera más joven, invitaría a " + NurseName + " a salir. Yo antes era todo un galán.";
					case 113:
						return "Ese sombrero rojo me resulta familiar...";
					case 114:
						return "Gracias otra vez por librarme de esta maldición. Sentí como si algo me hubiera saltado encima y me hubiera mordido.";
					case 115:
						return "Mamá siempre dijo que yo sería un buen sastre.";
					case 116:
						return "La vida es como un cajón de la ropa; ¡nunca sabes qué te vas a poner!";
					case 117:
						return "¡Desde luego bordar es una tarea difícil! ¡Si no fuera así, nadie lo haría! Eso es lo que la hace tan genial.";
					case 118:
						return "Sé todo lo que hay que saber sobre el negocio de la confección.";
					case 119:
						return "La maldición me ha convertido en un ser solitario; una vez me hice amigo de un muñeco de cuero. Lo llamaba Wilson.";
					case 120:
						return "Gracias por liberarme, humano. Los otros duendes me ataron y me dejaron aquí. Te puedes imaginar que no nos llevamos muy bien.";
					case 121:
						return "¡No puedo creer que me ataran y me dejaran aquí solo por decirles que no se dirigían al este!";
					case 122:
						return "Ahora que soy un proscrito, ¿puedo tirar ya estas bolas de pinchos? Tengo los bolsillos destrozados.";
					case 123:
						return "¿Buscas un experto en artilugios? ¡Yo soy tu duende!";
					case 124:
						return "Gracias por tu ayuda. Tengo que dejar de vagar por ahí sin rumbo. Seguro que nos volvemos a ver.";
					case 125:
						return "Creía que eras más alto.";
					case 126:
						return "Oye... ¿Qué trama " + MechanicName + "? ¿Tú... has hablado con ella, por un casual?";
					case 127:
						return "Eh, ¿quieres un motor para tu sombrero? Creo que tengo un motor que quedaría de perlas en ese sombrero.";
					case 128:
						return "Oye, he oído que te gustan los cohetes y las botas de correr, así que he puesto unos cohetes en tus botas.";
					case 129:
						return "Mi reino por un poco de cinta adhesiva...";
					case 130:
						return "Pues claro, el oro es más resistente que el hierro. ¿Pero qué os enseñan estos humanos de hoy?";
					case 131:
						return "En fin, la idea de un casco de minero con alas quedaba mucho mejor sobre el papel.";
					case 132:
						return "Los duendes tienen una increíble predisposición al enfado. ¡De hecho, podrían declarar una guerra por una discusión sobre ropa!";
					case 133:
						return "Sinceramente, la mayoría de los duendes no son precisamente unos genios. Bueno, algunos sí.";
					case 134:
						return "¿Tú sabes por qué llevamos estas bolas con pinchos? Porque yo no.";
					case 135:
						return "¡Acabo de terminar mi última creación! Esta versión no explota con violencia si respiras encima.";
					case 136:
						return "Los duendes ladrones no son muy buenos en lo suyo. ¡Ni siquiera saben robar un cofre abierto!";
					case 137:
						return "¡Gracias por salvarme! Estas ataduras me estaban haciendo rozaduras.";
					case 138:
						return "¡Oh, te debo la vida!";
					case 139:
						return "¡Oh, qué heroico! ¡Gracias por salvarme, jovencita!";
					case 140:
						return "¡Oh, qué heroico por tu parte! ¡Gracias por salvarme, jovencito!";
					case 141:
						return "Ahora que nos conocemos, ¿me puedo ir a vivir contigo, verdad?";
					case 142:
						return "¡Eh, hola, " + GuideName + "! ¿Qué puedo hacer hoy por ti?";
					case 143:
						return "¡Eh, hola, " + DemoName + "! ¿Qué puedo hacer hoy por ti?";
					case 144:
						return "¡Eh, hola, " + GoblinName + "! ¿Qué puedo hacer hoy por ti?";
					case 145:
						return "¡Eh, hola, " + NurseName + "! ¿Qué puedo hacer hoy por ti?";
					case 146:
						return "¡Eh, hola, " + MechanicName + "! ¿Qué puedo hacer hoy por ti?";
					case 147:
						return "¡Eh, hola, " + DryadName + "! ¿Qué puedo hacer hoy por ti?";
					case 148:
						return "¿Quieres que saque un conejo de tu chistera? ¿No? Pues nada.";
					case 149:
						return "¿Quieres un caramelo mágico? ¿No? Vale.";
					case 150:
						return "Si te gusta, te puedo hacer un delicioso chocolate calentito... ¿Tampoco? Vale, está bien.";
					case 151:
						return "¿Has venido a echar un ojo a mi bola de cristal?";
					case 152:
						return "¿Nunca has deseado tener un anillo mágico que convierta las piedras en slimes? La verdad es que yo tampoco.";
					case 153:
						return "Una vez me dijeron que la amistad es algo mágico. ¡Ridículo! No puedes convertir a nadie en rana con la amistad.";
					case 154:
						return "Veo tu futuro... ¡Vas a comprarme un montón de artículos!";
					case 155:
						return "En cierta ocasión intenté devolverle la vida a una estatua de ángel. Pero no pasó nada.";
					case 156:
						return "¡Gracias! Un poco más y habría acabado como los demás esqueletos de ahí abajo.";
					case 157:
						return "¡Eh, mira por dónde vas! ¡Llevo ahí desde hace... un rato!";
					case 158:
						return "Espera un momento, ya casi he conseguido que funcione el wifi.";
					case 159:
						return "¡Casi había acabado de poner luces intermitentes aquí arriba!";
					case 160:
						return "¡No te muevas! ¡Se me ha caído una lentilla!";
					case 161:
						return "Lo único que quiero es que el conmutador haga... ¿Qué?";
					case 162:
						return "A ver si lo adivino. No has comprado suficiente cable. ¡Ya te vale!";
					case 163:
						return "¿Podrías...? Solo... ¿Por favor...? ¿Vale? Está bien. Arrg.";
					case 164:
						return "No me gusta cómo me miras. Ahora estoy TRABAJANDO.";
					case 165:
						return "Eh, " + PlayerName + ", ¿acabas de llegar de la casa de " + GoblinName + "? ¿Por casualidad no te hablaría de mí?";
					case 166:
						return DealerName + " sigue insistiendo en pulir mi place de presión. Ya le he dicho que funciona pisándola.";
					case 167:
						return "¡Siempre compras más cable del que necesitas!";
					case 168:
						return "¿Has comprobado si tu dispositivo está enchufado?";
					case 169:
						return "Oh, ¿sabes lo que necesita esta casa? Más luces intermitentes.";
					case 170:
						return "Sabrás que se avecina una luna de sangre cuando el cielo se tiña de rojo. Hay algo en ella que hace que los monstruos ataquen en grupo.";
					case 171:
						return "Eh, amigo, ¿sabes dónde hay por aquí malahierba? Oh, no es por nada, solo preguntaba, nada más.";
					case 172:
						return "Si miraras hacia arriba, verías que ahora mismo la luna está roja.";
					case 173:
						return "Deberías quedarte en casa por la noche. Es muy peligroso andar por ahí en la oscuridad.";
					case 174:
						return "Saludos, " + PlayerName + ". ¿Te puedo ayudar en algo?";
					case 175:
						return "Estoy aquí para aconsejarte sobre lo que debes ir haciendo. Te aconsejo que hables conmigo cuando estés atascado.";
					case 176:
						return "Dicen que hay una persona que te dirá cómo sobrevivir en esta tierra... ¡Oh, espera, sí soy yo!";
					case 177:
						return "Puedes usar el pico para cavar en la tierra y el hacha para talar árboles. Sitúa el cursor sobre el ladrillo y pulsa " + RightTrigger + ".";
					case 178:
						return "Si quieres sobrevivir, tendrás que crear armas y un cobijo. Empieza talando árboles y recogiendo madera.";
					case 179:
						return "Pulsa  " + YButton + " para acceder al menú de creación. Cuando tengas suficiente madera, crea un banco de trabajo. De este modo podrás crear objetos más elaborados siempre que permanezcas cerca del banco.";
					case 180:
						return "Puedes construir un cobijo juntando madera y otros bloques que hay por el mundo. No olvides levantar y colocar paredes.";
					case 181:
						return "En cuanto tengas una espada de madera, puedes intentar recoger el gel de los slimes. Mezcla madera y gel para hacer una antorcha.";
					case 182:
						return "Usa un martillo para interactuar con el entorno y colocar objetos.";
					case 183:
						return "Deberías cavar una mina para encontrar vetas de mineral. Así podrás crear objetos muy útiles.";
					case 184:
						return "Ahora que tienes minerales, tendrás que convertirlos en un lingote para fabricar objetos con ellos. Para ello necesitas una forja.";
					case 185:
						return "Puedes construir una forja con antorchas, madera y piedra. Asegúrate de no alejarte del banco de trabajo.";
					case 186:
						return "Necesitarás un yunque para crear objetos con los lingotes de metal.";
					case 187:
						return "Los yunques se pueden hacer de hierro o bien comprarse a un mercader.";
					case 188:
						return "En el subsuelo hay cristales de corazón que puedes usar para aumentar al máximo tu vida. Para recogerlos, necesitarás un martillo.";
					case 189:
						return "Si recoges 10 estrellas fugaces, podrás combinarlas para crear un objeto que aumente tu poder mágico.";
					case 190:
						return "Las estrellas fugaces caen del cielo a la tierra por la noche. Se pueden utilizar para toda clase de objetos útiles. Si ves una date prisa en cogerla, ya que desaparecen al amanecer.";
					case 191:
						return "Hay muchas formas de hacer que los demás se muden a nuestra ciudad. Por supuesto, necesitarán una casa en la que vivir.";
					case 192:
						return "Para que una habitación pueda ser considerada un hogar, debe tener una puerta, una silla, una mesa y una fuente de luz. Y paredes, claro.";
					case 193:
						return "En la misma casa no pueden vivir dos personas. Además, si se destruye una casa, esa persona deberá buscar un nuevo lugar donde vivir.";
					case 194:
						return "En la interfaz de Cobijo puedes ver y asignar viviendas. Abre tu inventario y haz clic en el icono de casa.";
					case 195:
						return "Si quieres que un mercader se mude a una casa, deberás recoger una gran cantidad de dinero. Bastará con 50 monedas de plata.";
					case 196:
						return "Para que se mude una enfermera, tendrías que aumentar al máximo tu nivel de vida.";
					case 197:
						return "Si tuvieras alguna pistola, seguro que aparecería algún traficante de armas para venderte municiones.";
					case 198:
						return "Deberías ponerte a prueba y derrotar a un monstruo corpulento. Eso llamaría la atención de una dríada.";
					case 199:
						return "Asegúrate de explorar la mazmorra a fondo. Podría haber prisioneros retenidos en la parte más profunda.";
					case 200:
						return "Quizás el anciano de la mazmorra quiera unirse a nosotros ahora que su maldición ha desaparecido.";
					case 201:
						return "Guarda bien las bombas que encuentres. Algún demoledor querrá echarles un vistazo.";
					case 202:
						return "¿En realidad los duendes son tan distintos a nosotros que no podríamos vivir juntos en paz?";
					case 203:
						return "He oído que por esta región vive un poderoso mago. Estate muy atento por si lo ves la próxima vez que viajes al subsuelo.";
					case 204:
						return "Si juntas varias lentes en un altar demoníaco, tal vez encuentres la forma de invocar a un monstruo poderoso. Aunque te conviene esperar hasta la noche para hacerlo.";
					case 205:
						return "Puedes hacer cebo de gusanos con trozos podridos y polvo vil. Asegúrate de estar en una zona corrompida antes de usarlo.";
					case 206:
						return "Los altares demoníacos se suelen encontrar en territorio corrompido. Deberás estar cerca de ellos para crear ciertos objetos.";
					case 207:
						return "Puedes hacerte un garfio de escalada con un garfio y tres cadenas. Los esqueletos se encuentran en las profundidades del subsuelo y suelen llevar ganchos. En cuanto a las cadenas, se pueden fabricar con lingotes de hierro.";
					case 208:
						return "Si ves un jarrón, ábrelo aunque sea a golpes. Contienen toda clase de suministros de utilidad.";
					case 209:
						return "Hay tesoros escondidos por todo el mundo. ¡En las profundidades del subsuelo se pueden encontrar objetos maravillosos!";
					case 210:
						return "Romper un orbe sombrío a veces provoca la caída de un meteorito del cielo. Los orbes sombríos se suelen encontrar en los abismos que rodean las zonas corrompidas";
					case 211:
						return "Deberías dedicarte a recoger más cristal de corazón para aumentar tu nivel de vida hasta el máximo.";
					case 212:
						return "El equipo que llevas sencillamente no sirve. Debes mejorar tu armadura.";
					case 213:
						return "Creo que ya estás listo para tu primera gran batalla. Recoge de noche algunas lentes de los ojos y llévalas a un altar demoníaco.";
					case 214:
						return "Te conviene aumentar tu nivel de vida antes de enfrentarte al siguiente desafío. Con 15 corazones bastará.";
					case 215:
						return "La piedra de ébano que se encuentra en el territorio corrompido se puede purificar usando un poco de polvo de dríada, o destruirla con explosivos.";
					case 216:
						return "El siguiente paso debería ser explorar los abismos corrompidos. Encuentra y destruye todos los orbes sombríos que encuentres.";
					case 217:
						return "No muy lejos de aquí hay una antigua mazmorra. Ahora sería un buen momento para ir a echar un vistazo.";
					case 218:
						return "Deberías intentar aumentar al máximo tu nivel de vida. Intenta conseguir 20 corazones.";
					case 219:
						return "Hay muchos tesoros por descubrir en la selva si estás dispuesto a cavar a suficiente profundidad.";
					case 220:
						return "El Inframundo se compone de un material llamado piedra infernal, perfecto para hacer armas y armaduras.";
					case 221:
						return "Cuando estés preparado para desafiar al guardián del Inframundo, tendrás que hacer un sacrificio viviente. Todo lo que necesitas para hacerlo lo encontrarás en el Inframundo.";
					case 222:
						return "No dejes de destruir todos los altares demoníacos que encuentres. ¡Algo bueno te sucederá si lo haces!";
					case 223:
						return "A veces puedes recuperar el alma de las criaturas caídas en lugares de extrema luminosidad u oscuridad.";
					case 224:
						return "Ho, ho, ho y una botella de... ¡ponche de huevo!";
					case 225:
						return "¿Me preparas unas galletitas?";
					case 226:
						return "¿Qué? ¿Creías que no existía?";
				}
			}
			return null;
		}

		public static string SetBonus(int BonusID)
		{
			if (LangOption <= (int)ID.ENGLISH)
			{
				switch (BonusID)
				{
					case 0:
						return "2 defense";
					case 1:
						return "3 defense";
					case 2:
						return "15% increased movement speed";
					case 3:
						return "Space Gun costs 0 mana";
					case 4:
						return "20% chance to not consume ammo";
					case 5:
						return "16% reduced mana usage";
					case 6:
						return "17% extra melee damage";
					case 7:
						return "20% increased mining speed";
					case 8:
						return "14% reduced mana usage";
					case 9:
						return "15% increased melee speed";
					case 10:
						return "20% chance to not consume ammo";
					case 11:
						return "17% reduced mana usage";
					case 12:
						return "5% increased melee critical strike chance";
					case 13:
						return "20% chance to not consume ammo";
					case 14:
						return "19% reduced mana usage";
					case 15:
						return "18% increased melee and movement speed";
					case 16:
						return "25% chance to not consume ammo";
					case 17:
						return "20% reduced mana usage";
					case 18:
						return "19% increased melee and movement speed";
					case 19:
						return "25% chance to not consume ammo";
					case 20:
						return "23% reduced mana usage";
					case 21:
						return "21% increased melee and movement speed";
					case 22:
						return "28% chance to not consume ammo";
#if VERSION_101
					case 23:
						return "1 defense";
#endif
				}
			}
			else if (LangOption == (int)ID.GERMAN)
			{
				switch (BonusID)
				{
					case 0:
						return "2 Abwehr";
					case 1:
						return "3 Abwehr";
					case 2:
						return "Um 15% erhöhtes Bewegungstempo";
					case 3:
						return "Weltraumpistole kostet 0 Mana";
					case 4:
						return "20%ige Chance, keine Munition zu verbrauchen";
					case 5:
						return "Um 16% reduzierte Mananutzung";
					case 6:
						return "17% extra Nahkampfschaden";
					case 7:
						return "Um 20% erhöhtes Abbautempo";
					case 8:
						return "Um 14% reduzierte Mananutzung";
					case 9:
						return "Um 15% erhöhtes Nahkampftempo";
					case 10:
						return "20%ige Chance, keine Munition  zu verbrauchen";
					case 11:
						return "Um 17% reduzierte Mananutzung";
					case 12:
						return "5% Erhöhte kritische Nahkampf-Trefferchance";
					case 13:
						return "20%ige Chance, keine Munition zu verbrauchen";
					case 14:
						return "Um 19% reduzierte Mananutzung";
					case 15:
						return "18% Erhöhtes Nahkampf-und Bewegungstempo";
					case 16:
						return "25%ige Chance, keine Munition  zu verbrauchen";
					case 17:
						return "Um 20% reduzierte Mananutzung";
					case 18:
						return "19% Erhöhtes Nahkampf-und Bewegungstempo";
					case 19:
						return "25%ige Chance, keine Munition zu verbrauchen";
					case 20:
						return "Um 23% reduzierte Mananutzung";
					case 21:
						return "21% Erhöhtes Nahkampf-und Bewegungstempo";
					case 22:
						return "28%ige Chance, keine Munition zu verbrauchen";
#if VERSION_101
					case 23:
						return "1 Abwehr";
#endif
				}
			}
			else if (LangOption == (int)ID.ITALIAN)
			{
				switch (BonusID)
				{
					case 0:
						return "2 difesa";
					case 1:
						return "3 difesa";
					case 2:
						return "Velocità di movimento aumentata del 15%";
					case 3:
						return "La pistola spaziale costa 0 mana";
					case 4:
						return "20% di possibilità di non consumare munizioni";
					case 5:
						return "Consumo mana ridotto del 16%";
					case 6:
						return "17% danni da mischia in più";
					case 7:
						return "Velocità di estrazione aumentata del 20%";
					case 8:
						return "Consumo mana ridotto del 14%";
					case 9:
						return "Velocità del corpo a corpo aumentata del 15%";
					case 10:
						return "20% di possibilità di non consumare munizioni";
					case 11:
						return "Consumo mana ridotto del 17%";
					case 12:
						return "Possibilità di colpo critico nel corpo a corpo aumentata del 5%";
					case 13:
						return "20% di possibilità di non consumare munizioni";
					case 14:
						return "Consumo mana ridotto del 19%";
					case 15:
						return "Velocità di corpo a corpo e movimento aumentata del 18%";
					case 16:
						return "25% di possibilità di non consumare munizioni";
					case 17:
						return "Consumo mana ridotto del 20%";
					case 18:
						return "Velocità di corpo a corpo e movimento aumentate del 19%";
					case 19:
						return "25% di possibilità di non consumare munizioni";
					case 20:
						return "Consumo mana ridotto del 23%";
					case 21:
						return "Velocità di corpo a corpo e movimento aumentate del 21%";
					case 22:
						return "28% di possibilità di non consumare munizioni";
#if VERSION_101
					case 23:
						return "1 difesa";
#endif
				}
			}
			else if (LangOption == (int)ID.FRENCH)
			{
				switch (BonusID)
				{
					case 0:
						return "2 de défense";
					case 1:
						return "3 de défense";
					case 2:
						return "Vitesse de déplacement augmentée de 15 %";
					case 3:
						return "Le fusil de l'espace coûte 0 mana";
					case 4:
						return "20 % de chance de n'utiliser aucune munition";
					case 5:
						return "Utilisation de mana réduite de 16 %";
					case 6:
						return "17% de dégâts de mêlée supplémentaires";
					case 7:
						return "Vitesse d'extraction minière augmentée de 20 %";
					case 8:
						return "Utilisation de mana réduite de 14 %";
					case 9:
						return "Vitesse de mêlée augmentée de 15 %";
					case 10:
						return "20 % de chance de n'utiliser aucune munition";
					case 11:
						return "Utilisation de mana réduite de 17 %";
					case 12:
						return "Chance de coup critique de mêlée augmentée de 5\u00a0%";
					case 13:
						return "20 % de chance de n'utiliser aucune munition";
					case 14:
						return "Utilisation de mana réduite de 19 %";
					case 15:
						return "Vitesse de déplacement et de mêlée augmentée de 18\u00a0%";
					case 16:
						return "25 % de chance de n'utiliser aucune munition";
					case 17:
						return "Utilisation de mana réduite de 20 %";
					case 18:
						return "Vitesse de déplacement et de mêlée augmentée de 19\u00a0%";
					case 19:
						return "25 % de chance de n'utiliser aucune munition";
					case 20:
						return "Utilisation de mana réduite de 23 %";
					case 21:
						return "Vitesse de déplacement et de mêlée augmentée de 21\u00a0%";
					case 22:
						return "28 % de chance de n'utiliser aucune munition";
#if VERSION_101
					case 23:
						return "1 de defense";
#endif
				}
			}
			else if (LangOption == (int)ID.SPANISH)
			{
				switch (BonusID)
				{
					case 0:
						return "2 defensa";
					case 1:
						return "3 defensa";
					case 2:
						return "Aumenta en un 15% la velocidad de movimiento";
					case 3:
						return "La pistola espacial no cuesta maná";
					case 4:
						return "Probabilidad del 20% de no gastar munición";
					case 5:
						return "Reduce el uso de maná en un 16%";
					case 6:
						return "Aumenta en un 17% el daño de los ataques cuerpo a cuerpo";
					case 7:
						return "Aumenta en un 20% la velocidad de excavación";
					case 8:
						return "Reduce el uso de maná en un 14%";
					case 9:
						return "Aumenta un 15% la velocidad de los ataques cuerpo a cuerpo";
					case 10:
						return "Probabilidad del 20% de no gastar munición";
					case 11:
						return "Reduce el uso de maná en un 17%";
					case 12:
						return "Aumenta la probabilidad de conseguir ataques críticos cuerpo a cuerpo";
					case 13:
						return "Probabilidad del 20% de no gastar munición";
					case 14:
						return "Reduce el uso de maná en un 19%";
					case 15:
						return "Aumenta en un 18% la velocidad de movimiento y de los ataques cuerpo a cuerpo";
					case 16:
						return "Probabilidad del 25% de no gastar munición";
					case 17:
						return "Reduce el uso de maná en un 20%";
					case 18:
						return "19% Aumenta la velocidad de movimiento y en el cuerpo a cuerpo";
					case 19:
						return "Probabilidad del 25% de no gastar munición";
					case 20:
						return "Reduce el uso de maná en un 23%";
					case 21:
						return "21% Aumenta la velocidad de movimiento y en el cuerpo a cuerpo";
					case 22:
						return "Probabilidad del 28% de no gastar munición";
#if VERSION_101
					case 23:
						return "1 defensa";
#endif
				}
			}
			return null;
		}

		public static string NpcName(int l)
		{
			if (LangOption <= (int)ID.ENGLISH)
			{
				switch ((EntityID.NPCID)l)
				{
					case EntityID.NPCID.SLIMELING2:
					case EntityID.NPCID.SLIMELING:
						return "Slimeling";
					case EntityID.NPCID.SLIMER2:
						return "Slimer";
					case EntityID.NPCID.GREEN_SLIME:
						return "Green Slime";
					case EntityID.NPCID.PINKY:
						return "Pinky";
					case EntityID.NPCID.BABY_SLIME:
						return "Baby Slime";
					case EntityID.NPCID.BLACK_SLIME:
						return "Black Slime";
					case EntityID.NPCID.PURPLE_SLIME:
						return "Purple Slime";
					case EntityID.NPCID.RED_SLIME:
						return "Red Slime";
					case EntityID.NPCID.YELLOW_SLIME:
						return "Yellow Slime";
					case EntityID.NPCID.JUNGLE_SLIME:
						return "Jungle Slime";
#if VERSION_101
					case EntityID.NPCID.LITTLE_EATER:
					case EntityID.NPCID.BIG_EATER:
						return "Eater of Souls";
					case EntityID.NPCID.SHORT_BONES:
					case EntityID.NPCID.BIG_BONED:
						return "Angry Bones";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Armored Skeleton";
					case EntityID.NPCID.LITTLE_STINGER:
					case EntityID.NPCID.BIG_STINGER:
						return "Hornet";
					case EntityID.NPCID.SMALL_ZOMBIE:
					case EntityID.NPCID.BIG_ZOMBIE:
					case EntityID.NPCID.SMALL_BALD_ZOMBIE:
					case EntityID.NPCID.BIG_BALD_ZOMBIE:
					case EntityID.NPCID.SMALL_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.BIG_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SMALL_SLIMED_ZOMBIE:
					case EntityID.NPCID.BIG_SLIMED_ZOMBIE:
					case EntityID.NPCID.SMALL_SWAMP_ZOMBIE:
					case EntityID.NPCID.BIG_SWAMP_ZOMBIE:
					case EntityID.NPCID.SMALL_TWIGGY_ZOMBIE:
					case EntityID.NPCID.BIG_TWIGGY_ZOMBIE:
					case EntityID.NPCID.SMALL_FEMALE_ZOMBIE:
					case EntityID.NPCID.BIG_FEMALE_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.CATARACT_EYE2:
					case EntityID.NPCID.SLEEPY_EYE2:
					case EntityID.NPCID.DIALATED_EYE2:
					case EntityID.NPCID.GREEN_EYE2:
					case EntityID.NPCID.PURPLE_EYE2:
					case EntityID.NPCID.DEMON_EYE2:
						return "Demon Eye";
#else
					case EntityID.NPCID.LITTLE_EATER:
						return "Little Eater";
					case EntityID.NPCID.BIG_EATER:
						return "Big Eater";
					case EntityID.NPCID.SHORT_BONES:
						return "Short Bones";
					case EntityID.NPCID.BIG_BONED:
						return "Big Boned";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Heavy Skeleton";
					case EntityID.NPCID.LITTLE_STINGER:
						return "Little Stinger";
					case EntityID.NPCID.BIG_STINGER:
						return "Big Stinger";
#endif
					case EntityID.NPCID.SLIME:
						return "Blue Slime";
					case EntityID.NPCID.DEMON_EYE:
						return "Demon Eye";
					case EntityID.NPCID.ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.EYE_OF_CTHULHU:
						return "Eye of Cthulhu";
					case EntityID.NPCID.SERVANT_OF_CTHULHU:
						return "Servant of Cthulhu";
					case EntityID.NPCID.EATER_OF_SOULS:
						return "Eater of Souls";
					case EntityID.NPCID.DEVOURER_HEAD:
					case EntityID.NPCID.DEVOURER_BODY:
					case EntityID.NPCID.DEVOURER_TAIL:
						return "Devourer";
					case EntityID.NPCID.GIANT_WORM_HEAD:
					case EntityID.NPCID.GIANT_WORM_BODY:
					case EntityID.NPCID.GIANT_WORM_TAIL:
						return "Giant Worm";
					case EntityID.NPCID.EATER_OF_WORLDS_HEAD:
					case EntityID.NPCID.EATER_OF_WORLDS_BODY:
					case EntityID.NPCID.EATER_OF_WORLDS_TAIL:
						return "Eater of Worlds";
					case EntityID.NPCID.MOTHER_SLIME:
						return "Mother Slime";
					case EntityID.NPCID.MERCHANT:
						return "Merchant";
					case EntityID.NPCID.NURSE:
						return "Nurse";
					case EntityID.NPCID.ARMS_DEALER:
						return "Arms Dealer";
					case EntityID.NPCID.DRYAD:
						return "Dryad";
					case EntityID.NPCID.SKELETON:
						return "Skeleton";
					case EntityID.NPCID.GUIDE:
						return "Guide";
					case EntityID.NPCID.METEOR_HEAD:
						return "Meteor Head";
					case EntityID.NPCID.FIRE_IMP:
						return "Fire Imp";
					case EntityID.NPCID.BURNING_SPHERE:
						return "Burning Sphere";
					case EntityID.NPCID.GOBLIN_PEON:
						return "Goblin Peon";
					case EntityID.NPCID.GOBLIN_THIEF:
						return "Goblin Thief";
					case EntityID.NPCID.GOBLIN_WARRIOR:
						return "Goblin Warrior";
					case EntityID.NPCID.GOBLIN_SORCERER:
						return "Goblin Sorcerer";
					case EntityID.NPCID.CHAOS_BALL:
						return "Chaos Ball";
					case EntityID.NPCID.BONES:
						return "Angry Bones";
					case EntityID.NPCID.DARK_CASTER:
						return "Dark Caster";
					case EntityID.NPCID.WATER_SPHERE:
						return "Water Sphere";
					case EntityID.NPCID.CURSED_SKULL:
						return "Cursed Skull";
					case EntityID.NPCID.SKELETRON_HEAD:
					case EntityID.NPCID.SKELETRON_HAND:
						return "Skeletron";
					case EntityID.NPCID.OLD_MAN:
						return "Old Man";
					case EntityID.NPCID.DEMOLITIONIST:
						return "Demolitionist";
					case EntityID.NPCID.BONE_SERPENT_HEAD:
					case EntityID.NPCID.BONE_SERPENT_BODY:
					case EntityID.NPCID.BONE_SERPENT_TAIL:
						return "Bone Serpent";
					case EntityID.NPCID.HORNET:
						return "Hornet";
					case EntityID.NPCID.MAN_EATER:
						return "Man Eater";
					case EntityID.NPCID.UNDEAD_MINER:
						return "Undead Miner";
					case EntityID.NPCID.TIM:
						return "Tim";
					case EntityID.NPCID.BUNNY:
						return "Bunny";
					case EntityID.NPCID.CORRUPT_BUNNY:
						return "Corrupt Bunny";
					case EntityID.NPCID.HARPY:
						return "Harpy";
					case EntityID.NPCID.CAVE_BAT:
						return "Cave Bat";
					case EntityID.NPCID.KING_SLIME:
						return "King Slime";
					case EntityID.NPCID.JUNGLE_BAT:
						return "Jungle Bat";
					case EntityID.NPCID.DOCTOR_BONES:
						return "Doctor Bones";
					case EntityID.NPCID.THE_GROOM:
						return "The Groom";
					case EntityID.NPCID.CLOTHIER:
						return "Clothier";
					case EntityID.NPCID.GOLDFISH:
						return "Goldfish";
					case EntityID.NPCID.SNATCHER:
						return "Snatcher";
					case EntityID.NPCID.CORRUPT_GOLDFISH:
						return "Corrupt Goldfish";
					case EntityID.NPCID.PIRANHA:
						return "Piranha";
					case EntityID.NPCID.LAVA_SLIME:
						return "Lava Slime";
					case EntityID.NPCID.HELLBAT:
						return "Hellbat";
					case EntityID.NPCID.VULTURE:
						return "Vulture";
					case EntityID.NPCID.DEMON:
						return "Demon";
					case EntityID.NPCID.BLUE_JELLYFISH:
						return "Blue Jellyfish";
					case EntityID.NPCID.PINK_JELLYFISH:
						return "Pink Jellyfish";
					case EntityID.NPCID.SHARK:
						return "Shark";
					case EntityID.NPCID.VOODOO_DEMON:
						return "Voodoo Demon";
					case EntityID.NPCID.CRAB:
						return "Crab";
					case EntityID.NPCID.DUNGEON_GUARDIAN:
						return "Dungeon Guardian";
					case EntityID.NPCID.ANTLION:
						return "Antlion";
					case EntityID.NPCID.SPIKE_BALL:
						return "Spike Ball";
					case EntityID.NPCID.DUNGEON_SLIME:
						return "Dungeon Slime";
					case EntityID.NPCID.BLAZING_WHEEL:
						return "Blazing Wheel";
					case EntityID.NPCID.GOBLIN_SCOUT:
						return "Goblin Scout";
					case EntityID.NPCID.BIRD:
						return "Bird";
					case EntityID.NPCID.PIXIE:
						return "Pixie";
					case EntityID.NPCID.ARMORED_SKELETON:
						return "Armored Skeleton";
					case EntityID.NPCID.MUMMY:
						return "Mummy";
					case EntityID.NPCID.DARK_MUMMY:
						return "Dark Mummy";
					case EntityID.NPCID.LIGHT_MUMMY:
						return "Light Mummy";
					case EntityID.NPCID.CORRUPT_SLIME:
						return "Corrupt Slime";
					case EntityID.NPCID.WRAITH:
						return "Wraith";
					case EntityID.NPCID.CURSED_HAMMER:
						return "Cursed Hammer";
					case EntityID.NPCID.ENCHANTED_SWORD:
						return "Enchanted Sword";
					case EntityID.NPCID.MIMIC:
						return "Mimic";
					case EntityID.NPCID.UNICORN:
						return "Unicorn";
					case EntityID.NPCID.WYVERN_HEAD:
					case EntityID.NPCID.WYVERN_LEGS:
					case EntityID.NPCID.WYVERN_BODY1:
					case EntityID.NPCID.WYVERN_BODY2:
					case EntityID.NPCID.WYVERN_BODY3:
					case EntityID.NPCID.WYVERN_TAIL:
						return "Wyvern";
					case EntityID.NPCID.GIANT_BAT:
						return "Giant Bat";
					case EntityID.NPCID.CORRUPTOR:
						return "Corruptor";
					case EntityID.NPCID.DIGGER_HEAD:
					case EntityID.NPCID.DIGGER_BODY:
					case EntityID.NPCID.DIGGER_TAIL:
						return "Digger";
					case EntityID.NPCID.SEEKER_HEAD:
					case EntityID.NPCID.SEEKER_BODY:
					case EntityID.NPCID.SEEKER_TAIL:
						return "World Feeder";
					case EntityID.NPCID.CLINGER:
						return "Clinger";
					case EntityID.NPCID.ANGLER_FISH:
						return "Angler Fish";
					case EntityID.NPCID.GREEN_JELLYFISH:
						return "Green Jellyfish";
					case EntityID.NPCID.WEREWOLF:
						return "Werewolf";
					case EntityID.NPCID.BOUND_GOBLIN:
						return "Bound Goblin";
					case EntityID.NPCID.BOUND_WIZARD:
						return "Bound Wizard";
					case EntityID.NPCID.GOBLIN_TINKERER:
						return "Goblin Tinkerer";
					case EntityID.NPCID.WIZARD:
						return "Wizard";
					case EntityID.NPCID.CLOWN:
						return "Clown";
					case EntityID.NPCID.SKELETON_ARCHER:
						return "Skeleton Archer";
					case EntityID.NPCID.GOBLIN_ARCHER:
						return "Goblin Archer";
					case EntityID.NPCID.VILE_SPIT:
						return "Vile Spit";
					case EntityID.NPCID.WALL_OF_FLESH:
					case EntityID.NPCID.WALL_OF_FLESH_EYE:
						return "Wall of Flesh";
					case EntityID.NPCID.THE_HUNGRY:
					case EntityID.NPCID.THE_HUNGRY_II:
						return "The Hungry";
					case EntityID.NPCID.LEECH_HEAD:
					case EntityID.NPCID.LEECH_BODY:
					case EntityID.NPCID.LEECH_TAIL:
						return "Leech";
					case EntityID.NPCID.CHAOS_ELEMENTAL:
						return "Chaos Elemental";
					case EntityID.NPCID.SLIMER:
						return "Slimer";
					case EntityID.NPCID.GASTROPOD:
						return "Gastropod";
					case EntityID.NPCID.BOUND_MECHANIC:
						return "Bound Mechanic";
					case EntityID.NPCID.MECHANIC:
						return "Mechanic";
					case EntityID.NPCID.RETINAZER:
						return "Retinazer";
					case EntityID.NPCID.SPAZMATISM:
						return "Spazmatism";
					case EntityID.NPCID.SKELETRON_PRIME:
						return "Skeletron Prime";
					case EntityID.NPCID.PRIME_CANNON:
						return "Prime Cannon";
					case EntityID.NPCID.PRIME_SAW:
						return "Prime Saw";
					case EntityID.NPCID.PRIME_VICE:
						return "Prime Vice";
					case EntityID.NPCID.PRIME_LASER:
						return "Prime Laser";
					case EntityID.NPCID.BALD_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.WANDERING_EYE:
						return "Wandering Eye";
					case EntityID.NPCID.THE_DESTROYER_HEAD:
					case EntityID.NPCID.THE_DESTROYER_BODY:
					case EntityID.NPCID.THE_DESTROYER_TAIL:
						return "The Destroyer";
					case EntityID.NPCID.ILLUMINANT_BAT:
						return "Illuminant Bat";
					case EntityID.NPCID.ILLUMINANT_SLIME:
						return "Illuminant Slime";
					case EntityID.NPCID.PROBE:
						return "Probe";
					case EntityID.NPCID.POSSESSED_ARMOR:
						return "Possessed Armor";
					case EntityID.NPCID.TOXIC_SLUDGE:
						return "Toxic Sludge";
					case EntityID.NPCID.SANTA_CLAUS:
						return "Santa Claus";
					case EntityID.NPCID.SNOWMAN_GANGSTA:
						return "Snowman Gangsta";
					case EntityID.NPCID.MISTER_STABBY:
						return "Mister Stabby";
					case EntityID.NPCID.SNOW_BALLA:
						return "Snow Balla";
					case EntityID.NPCID.ALBINO_ANTLION:
						return "Albino Antlion";
					case EntityID.NPCID.ORKA:
						return "Orca";
					case EntityID.NPCID.VAMPIRE_MINER:
						return "Vampire Miner";
					case EntityID.NPCID.SHADOW_SLIME:
						return "Shadow Slime";
					case EntityID.NPCID.SHADOW_HAMMER:
						return "Shadow Hammer";
					case EntityID.NPCID.SHADOW_MUMMY:
						return "Shadow Mummy";
					case EntityID.NPCID.SPECTRAL_GASTROPOD:
						return "Spectral Gastropod";
					case EntityID.NPCID.SPECTRAL_ELEMENTAL:
						return "Spectral Elemental";
					case EntityID.NPCID.SPECTRAL_MUMMY:
						return "Spectral Mummy";
					case EntityID.NPCID.DRAGON_SNATCHER:
						return "Dragon Snatcher";
					case EntityID.NPCID.DRAGON_HORNET:
						return "Dragon Hornet";
					case EntityID.NPCID.DRAGON_SKULL:
						return "Dragon Skull";
					case EntityID.NPCID.ARCH_WYVERN_HEAD:
					case EntityID.NPCID.ARCH_WYVERN_LEGS:
					case EntityID.NPCID.ARCH_WYVERN_BODY1:
					case EntityID.NPCID.ARCH_WYVERN_BODY2:
					case EntityID.NPCID.ARCH_WYVERN_BODY3:
					case EntityID.NPCID.ARCH_WYVERN_TAIL:
						return "Arch Wyvern";
					case EntityID.NPCID.ARCH_DEMON:
						return "Arch Demon";
					case EntityID.NPCID.OCRAM:
						return "Ocram";
					case EntityID.NPCID.SERVANT_OF_OCRAM:
						return "Servant of Ocram";
#if VERSION_101
					case EntityID.NPCID.CATARACT_EYE:
					case EntityID.NPCID.SLEEPY_EYE:
					case EntityID.NPCID.DIALATED_EYE:
					case EntityID.NPCID.GREEN_EYE:
					case EntityID.NPCID.PURPLE_EYE:
						return "Demon Eye";
					case EntityID.NPCID.PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SLIMED_ZOMBIE:
					case EntityID.NPCID.SWAMP_ZOMBIE:
					case EntityID.NPCID.TWIGGY_ZOMBIE:
					case EntityID.NPCID.FEMALE_ZOMBIE:
					case EntityID.NPCID.ZOMBIE_MUSHROOM:
					case EntityID.NPCID.ZOMBIE_MUSHROOM_HAT:
						return "Zombie";
#endif
					default:
						return "";
				}
			}
			if (LangOption == (int)ID.GERMAN)
			{
				switch ((EntityID.NPCID)l)
				{
					case EntityID.NPCID.SLIMELING2:
					case EntityID.NPCID.SLIMELING:
						return "Schleimling";
					case EntityID.NPCID.SLIMER2:
						return "Flugschleimi";
					case EntityID.NPCID.GREEN_SLIME:
						return "Grüner Schleim";
					case EntityID.NPCID.PINKY:
						return "Pinky";
					case EntityID.NPCID.BABY_SLIME:
						return "Schleimbaby";
					case EntityID.NPCID.BLACK_SLIME:
						return "Schwarzer Schleim";
					case EntityID.NPCID.PURPLE_SLIME:
						return "Lila Schleim";
					case EntityID.NPCID.RED_SLIME:
						return "Roter Schleim";
					case EntityID.NPCID.YELLOW_SLIME:
						return "Gelber Schleim";
					case EntityID.NPCID.JUNGLE_SLIME:
						return "Dschungelschleim";
#if VERSION_101
					case EntityID.NPCID.LITTLE_EATER:
					case EntityID.NPCID.BIG_EATER:
						return "Seelenfresser";
					case EntityID.NPCID.SHORT_BONES:
					case EntityID.NPCID.BIG_BONED:
						return "Wutknochen";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Gepanzertes Skelett";
					case EntityID.NPCID.LITTLE_STINGER:
					case EntityID.NPCID.BIG_STINGER:
						return "Hornisse";
					case EntityID.NPCID.SMALL_ZOMBIE:
					case EntityID.NPCID.BIG_ZOMBIE:
					case EntityID.NPCID.SMALL_BALD_ZOMBIE:
					case EntityID.NPCID.BIG_BALD_ZOMBIE:
					case EntityID.NPCID.SMALL_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.BIG_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SMALL_SLIMED_ZOMBIE:
					case EntityID.NPCID.BIG_SLIMED_ZOMBIE:
					case EntityID.NPCID.SMALL_SWAMP_ZOMBIE:
					case EntityID.NPCID.BIG_SWAMP_ZOMBIE:
					case EntityID.NPCID.SMALL_TWIGGY_ZOMBIE:
					case EntityID.NPCID.BIG_TWIGGY_ZOMBIE:
					case EntityID.NPCID.SMALL_FEMALE_ZOMBIE:
					case EntityID.NPCID.BIG_FEMALE_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.CATARACT_EYE2:
					case EntityID.NPCID.SLEEPY_EYE2:
					case EntityID.NPCID.DIALATED_EYE2:
					case EntityID.NPCID.GREEN_EYE2:
					case EntityID.NPCID.PURPLE_EYE2:
					case EntityID.NPCID.DEMON_EYE2:
						return "Dämonenauge";
#else
					case EntityID.NPCID.LITTLE_EATER:
						return "Minifresser";
					case EntityID.NPCID.BIG_EATER:
						return "Maxifresser";
					case EntityID.NPCID.SHORT_BONES:
						return "Kleinknochen";
					case EntityID.NPCID.BIG_BONED:
						return "Großknochen";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Mammutskelett";
					case EntityID.NPCID.LITTLE_STINGER:
						return "Minihornisse";
					case EntityID.NPCID.BIG_STINGER:
						return "Riesenhornisse";
#endif
					case EntityID.NPCID.SLIME:
						return "Blauer Schleim";
					case EntityID.NPCID.DEMON_EYE:
						return "Dämonenauge";
					case EntityID.NPCID.ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.EYE_OF_CTHULHU:
						return "Auge von Cthulhu";
					case EntityID.NPCID.SERVANT_OF_CTHULHU:
						return "Diener von Cthulhu";
					case EntityID.NPCID.EATER_OF_SOULS:
						return "Seelenfresser";
					case EntityID.NPCID.DEVOURER_HEAD:
					case EntityID.NPCID.DEVOURER_BODY:
					case EntityID.NPCID.DEVOURER_TAIL:
						return "Verschlinger";
					case EntityID.NPCID.GIANT_WORM_HEAD:
					case EntityID.NPCID.GIANT_WORM_BODY:
					case EntityID.NPCID.GIANT_WORM_TAIL:
						return "Riesenwurm";
					case EntityID.NPCID.EATER_OF_WORLDS_HEAD:
					case EntityID.NPCID.EATER_OF_WORLDS_BODY:
					case EntityID.NPCID.EATER_OF_WORLDS_TAIL:
						return "Weltenfresser";
					case EntityID.NPCID.MOTHER_SLIME:
						return "Schleimmami";
					case EntityID.NPCID.MERCHANT:
						return "Händler";
					case EntityID.NPCID.NURSE:
						return "Krankenschwester";
					case EntityID.NPCID.ARMS_DEALER:
						return "Waffenhändler";
					case EntityID.NPCID.DRYAD:
						return "Dryade";
					case EntityID.NPCID.SKELETON:
						return "Skelett";
					case EntityID.NPCID.GUIDE:
						return "Fremdenführer";
					case EntityID.NPCID.METEOR_HEAD:
						return "Meteorenkopf";
					case EntityID.NPCID.FIRE_IMP:
						return "Feuer-Imp";
					case EntityID.NPCID.BURNING_SPHERE:
						return "Flammenkugel";
					case EntityID.NPCID.GOBLIN_PEON:
						return "Goblin-Arbeiter";
					case EntityID.NPCID.GOBLIN_THIEF:
						return "Goblin-Dieb";
					case EntityID.NPCID.GOBLIN_WARRIOR:
						return "Goblin-Krieger";
					case EntityID.NPCID.GOBLIN_SORCERER:
						return "Goblin-Hexer";
					case EntityID.NPCID.CHAOS_BALL:
						return "Chaoskugel";
					case EntityID.NPCID.BONES:
						return "Wutknochen";
					case EntityID.NPCID.DARK_CASTER:
						return "Düstermagier";
					case EntityID.NPCID.WATER_SPHERE:
						return "Wasserkugel";
					case EntityID.NPCID.CURSED_SKULL:
						return "Fluchschädel";
					case EntityID.NPCID.SKELETRON_HEAD:
					case EntityID.NPCID.SKELETRON_HAND:
						return "Skeletron";
					case EntityID.NPCID.OLD_MAN:
						return "Greis";
					case EntityID.NPCID.DEMOLITIONIST:
						return "Sprengmeister";
					case EntityID.NPCID.BONE_SERPENT_HEAD:
					case EntityID.NPCID.BONE_SERPENT_BODY:
					case EntityID.NPCID.BONE_SERPENT_TAIL:
						return "Knochenschlange";
					case EntityID.NPCID.HORNET:
						return "Hornisse";
					case EntityID.NPCID.MAN_EATER:
						return "Menschenfresser";
					case EntityID.NPCID.UNDEAD_MINER:
						return "Untoter Minenarbeiter";
					case EntityID.NPCID.TIM:
						return "Tim";
					case EntityID.NPCID.BUNNY:
						return "Hase";
					case EntityID.NPCID.CORRUPT_BUNNY:
						return "Verderbnishase";
					case EntityID.NPCID.HARPY:
						return "Harpyie";
					case EntityID.NPCID.CAVE_BAT:
						return "Höhlenfledermaus";
					case EntityID.NPCID.KING_SLIME:
						return "Schleimkönig";
					case EntityID.NPCID.JUNGLE_BAT:
						return "Dschungelfledermaus";
					case EntityID.NPCID.DOCTOR_BONES:
						return "Doktor Bones";
					case EntityID.NPCID.THE_GROOM:
						return "Bräutigam";
					case EntityID.NPCID.CLOTHIER:
						return "Schneider";
					case EntityID.NPCID.GOLDFISH:
						return "Goldfisch";
					case EntityID.NPCID.SNATCHER:
						return "Schnapper";
					case EntityID.NPCID.CORRUPT_GOLDFISH:
						return "Verderbnisgoldfisch";
					case EntityID.NPCID.PIRANHA:
						return "Piranha";
					case EntityID.NPCID.LAVA_SLIME:
						return "Lavaschleim";
					case EntityID.NPCID.HELLBAT:
						return "Höllenfledermaus";
					case EntityID.NPCID.VULTURE:
						return "Geier";
					case EntityID.NPCID.DEMON:
						return "Dämon";
					case EntityID.NPCID.BLUE_JELLYFISH:
						return "Blauqualle";
					case EntityID.NPCID.PINK_JELLYFISH:
						return "Pinkqualle";
					case EntityID.NPCID.SHARK:
						return "Hai";
					case EntityID.NPCID.VOODOO_DEMON:
						return "Voodoo-Dämon";
					case EntityID.NPCID.CRAB:
						return "Krabbe";
					case EntityID.NPCID.DUNGEON_GUARDIAN:
						return "Verlies-Wächter";
					case EntityID.NPCID.ANTLION:
						return "Ameisenlöwe";
					case EntityID.NPCID.SPIKE_BALL:
						return "Nagelball";
					case EntityID.NPCID.DUNGEON_SLIME:
						return "Verliesschleim";
					case EntityID.NPCID.BLAZING_WHEEL:
						return "Flammenrad";
					case EntityID.NPCID.GOBLIN_SCOUT:
						return "Goblin-Späher";
					case EntityID.NPCID.BIRD:
						return "Vogel";
					case EntityID.NPCID.PIXIE:
						return "Pixie";
					case EntityID.NPCID.ARMORED_SKELETON:
						return "Gepanzertes Skelett";
					case EntityID.NPCID.MUMMY:
						return "Mumie";
					case EntityID.NPCID.DARK_MUMMY:
						return "Dunkle Mumie";
					case EntityID.NPCID.LIGHT_MUMMY:
						return "Helle Mumie";
					case EntityID.NPCID.CORRUPT_SLIME:
						return "Verderbnisschleimi";
					case EntityID.NPCID.WRAITH:
						return "Monstergeist";
					case EntityID.NPCID.CURSED_HAMMER:
						return "Verfluchter Hammer";
					case EntityID.NPCID.ENCHANTED_SWORD:
						return "Verzaubertes Schwert";
					case EntityID.NPCID.MIMIC:
						return "Mimic";
					case EntityID.NPCID.UNICORN:
						return "Einhorn";
					case EntityID.NPCID.WYVERN_HEAD:
					case EntityID.NPCID.WYVERN_LEGS:
					case EntityID.NPCID.WYVERN_BODY1:
					case EntityID.NPCID.WYVERN_BODY2:
					case EntityID.NPCID.WYVERN_BODY3:
					case EntityID.NPCID.WYVERN_TAIL:
						return "Lindwurm";
					case EntityID.NPCID.GIANT_BAT:
						return "Riesenfledermaus";
					case EntityID.NPCID.CORRUPTOR:
						return "Verderber";
					case EntityID.NPCID.DIGGER_HEAD:
					case EntityID.NPCID.DIGGER_BODY:
					case EntityID.NPCID.DIGGER_TAIL:
						return "Gräber";
					case EntityID.NPCID.SEEKER_HEAD:
					case EntityID.NPCID.SEEKER_BODY:
					case EntityID.NPCID.SEEKER_TAIL:
						return "Weltspeiser";
					case EntityID.NPCID.CLINGER:
						return "Klette";
					case EntityID.NPCID.ANGLER_FISH:
						return "Seeteufel";
					case EntityID.NPCID.GREEN_JELLYFISH:
						return "Grüne Qualle";
					case EntityID.NPCID.WEREWOLF:
						return "Werwolf";
					case EntityID.NPCID.BOUND_GOBLIN:
						return "Gebundener Goblin";
					case EntityID.NPCID.BOUND_WIZARD:
						return "Gebundener Zauberer";
					case EntityID.NPCID.GOBLIN_TINKERER:
						return "Goblin-Tüftler";
					case EntityID.NPCID.WIZARD:
						return "Zauberer";
					case EntityID.NPCID.CLOWN:
						return "Clown";
					case EntityID.NPCID.SKELETON_ARCHER:
						return "Skelettbogenschütze";
					case EntityID.NPCID.GOBLIN_ARCHER:
						return "Goblin-Bogenschütze";
					case EntityID.NPCID.VILE_SPIT:
						return "Ekelspeichel";
					case EntityID.NPCID.WALL_OF_FLESH:
					case EntityID.NPCID.WALL_OF_FLESH_EYE:
						return "Fleischwand";
					case EntityID.NPCID.THE_HUNGRY:
					case EntityID.NPCID.THE_HUNGRY_II:
						return "Fressmaul";
					case EntityID.NPCID.LEECH_HEAD:
					case EntityID.NPCID.LEECH_BODY:
					case EntityID.NPCID.LEECH_TAIL:
						return "Blutegel";
					case EntityID.NPCID.CHAOS_ELEMENTAL:
						return "Chaos Elementar";
					case EntityID.NPCID.SLIMER:
						return "Flugschleim";
					case EntityID.NPCID.GASTROPOD:
						return "Bauchfüßler";
					case EntityID.NPCID.BOUND_MECHANIC:
						return "Gebundene Mechanikerin";
					case EntityID.NPCID.MECHANIC:
						return "Mechanikerin";
					case EntityID.NPCID.RETINAZER:
						return "Retinazer";
					case EntityID.NPCID.SPAZMATISM:
						return "Spazmatism";
					case EntityID.NPCID.SKELETRON_PRIME:
						return "Skeletron Prime";
					case EntityID.NPCID.PRIME_CANNON:
						return "Super-Kanone";
					case EntityID.NPCID.PRIME_SAW:
						return "Super-Säge";
					case EntityID.NPCID.PRIME_VICE:
						return "Super-Zange";
					case EntityID.NPCID.PRIME_LASER:
						return "Super-Laser";
					case EntityID.NPCID.BALD_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.WANDERING_EYE:
						return "Wanderndes Auge";
					case EntityID.NPCID.THE_DESTROYER_HEAD:
					case EntityID.NPCID.THE_DESTROYER_BODY:
					case EntityID.NPCID.THE_DESTROYER_TAIL:
						return "Der Zerstörer";
					case EntityID.NPCID.ILLUMINANT_BAT:
						return "Leuchtfledermaus";
					case EntityID.NPCID.ILLUMINANT_SLIME:
						return "Leuchtender Schleim";
					case EntityID.NPCID.PROBE:
						return "Sonde";
					case EntityID.NPCID.POSSESSED_ARMOR:
						return "Geisterrüstung";
					case EntityID.NPCID.TOXIC_SLUDGE:
						return "Giftiger Schlamm";
					case EntityID.NPCID.SANTA_CLAUS:
						return "Weihnachtsmann";
					case EntityID.NPCID.SNOWMAN_GANGSTA:
						return "Gangster Schneemann";
					case EntityID.NPCID.MISTER_STABBY:
						return "Herr Stabby";
					case EntityID.NPCID.SNOW_BALLA:
						return "Schnee Balla";
					case EntityID.NPCID.ALBINO_ANTLION:
						return "Albino Ameisenlöwe";
					case EntityID.NPCID.ORKA:
						return "Orca";
					case EntityID.NPCID.VAMPIRE_MINER:
						return "Vampire Miner";
					case EntityID.NPCID.SHADOW_SLIME:
						return "Schattenschleim";
					case EntityID.NPCID.SHADOW_HAMMER:
						return "Schattenhammer";
					case EntityID.NPCID.SHADOW_MUMMY:
						return "Schattenmumie";
					case EntityID.NPCID.SPECTRAL_GASTROPOD:
						return "Gespenstischer Bauchfüßler";
					case EntityID.NPCID.SPECTRAL_ELEMENTAL:
						return "Spectral Elemental";
					case EntityID.NPCID.SPECTRAL_MUMMY:
						return "Gespenstische Mumie";
					case EntityID.NPCID.DRAGON_SNATCHER:
						return "Drachen-Schnapper";
					case EntityID.NPCID.DRAGON_HORNET:
						return "Drachenhornisse";
					case EntityID.NPCID.DRAGON_SKULL:
						return "Drachenschädel";
					case EntityID.NPCID.ARCH_WYVERN_HEAD:
					case EntityID.NPCID.ARCH_WYVERN_LEGS:
					case EntityID.NPCID.ARCH_WYVERN_BODY1:
					case EntityID.NPCID.ARCH_WYVERN_BODY2:
					case EntityID.NPCID.ARCH_WYVERN_BODY3:
					case EntityID.NPCID.ARCH_WYVERN_TAIL:
						return "Erz-Lindwurm";
					case EntityID.NPCID.ARCH_DEMON:
						return "Erz-Dämon";
					case EntityID.NPCID.OCRAM:
						return "Ocram";
					case EntityID.NPCID.SERVANT_OF_OCRAM:
						return "Diener von Ocram";
#if VERSION_101
					case EntityID.NPCID.CATARACT_EYE:
					case EntityID.NPCID.SLEEPY_EYE:
					case EntityID.NPCID.DIALATED_EYE:
					case EntityID.NPCID.GREEN_EYE:
					case EntityID.NPCID.PURPLE_EYE:
						return "Dämonenauge";
					case EntityID.NPCID.PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SLIMED_ZOMBIE:
					case EntityID.NPCID.SWAMP_ZOMBIE:
					case EntityID.NPCID.TWIGGY_ZOMBIE:
					case EntityID.NPCID.FEMALE_ZOMBIE:
					case EntityID.NPCID.ZOMBIE_MUSHROOM:
					case EntityID.NPCID.ZOMBIE_MUSHROOM_HAT:
						return "Zombie";
#endif
					default:
						return "";
				}
			}
			if (LangOption == (int)ID.ITALIAN)
			{
				switch ((EntityID.NPCID)l)
				{
					case EntityID.NPCID.SLIMELING2:
					case EntityID.NPCID.SLIMELING:
						return "Slimeling";
					case EntityID.NPCID.SLIMER2:
						return "Slimer";
					case EntityID.NPCID.GREEN_SLIME:
						return "Slime verde";
					case EntityID.NPCID.PINKY:
						return "Mignolo";
					case EntityID.NPCID.BABY_SLIME:
						return "Slime baby";
					case EntityID.NPCID.BLACK_SLIME:
						return "Slime nero";
					case EntityID.NPCID.PURPLE_SLIME:
						return "Slime viola";
					case EntityID.NPCID.RED_SLIME:
						return "Slime rosso";
					case EntityID.NPCID.YELLOW_SLIME:
						return "Slime giallo";
					case EntityID.NPCID.JUNGLE_SLIME:
						return "Slime della giungla";
#if VERSION_101
					case EntityID.NPCID.LITTLE_EATER:
					case EntityID.NPCID.BIG_EATER:
						return "Mangiatore di anime";
					case EntityID.NPCID.SHORT_BONES:
					case EntityID.NPCID.BIG_BONED:
						return "Ossa arrabbiate";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Scheletro corazzato";
					case EntityID.NPCID.LITTLE_STINGER:
					case EntityID.NPCID.BIG_STINGER:
						return "Calabrone";
					case EntityID.NPCID.SMALL_ZOMBIE:
					case EntityID.NPCID.BIG_ZOMBIE:
					case EntityID.NPCID.SMALL_BALD_ZOMBIE:
					case EntityID.NPCID.BIG_BALD_ZOMBIE:
					case EntityID.NPCID.SMALL_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.BIG_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SMALL_SLIMED_ZOMBIE:
					case EntityID.NPCID.BIG_SLIMED_ZOMBIE:
					case EntityID.NPCID.SMALL_SWAMP_ZOMBIE:
					case EntityID.NPCID.BIG_SWAMP_ZOMBIE:
					case EntityID.NPCID.SMALL_TWIGGY_ZOMBIE:
					case EntityID.NPCID.BIG_TWIGGY_ZOMBIE:
					case EntityID.NPCID.SMALL_FEMALE_ZOMBIE:
					case EntityID.NPCID.BIG_FEMALE_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.CATARACT_EYE2:
					case EntityID.NPCID.SLEEPY_EYE2:
					case EntityID.NPCID.DIALATED_EYE2:
					case EntityID.NPCID.GREEN_EYE2:
					case EntityID.NPCID.PURPLE_EYE2:
					case EntityID.NPCID.DEMON_EYE2:
						return "Occhio del Demone";
#else
					case EntityID.NPCID.LITTLE_EATER:
						return "Piccolo mangiatore";
					case EntityID.NPCID.BIG_EATER:
						return "Grande mangiatore";
					case EntityID.NPCID.SHORT_BONES:
						return "Ossa corte";
					case EntityID.NPCID.BIG_BONED:
						return "Disossato";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Scheletro pesante";
					case EntityID.NPCID.LITTLE_STINGER:
						return "Vespa piccola";
					case EntityID.NPCID.BIG_STINGER:
						return "Vespa grande";
#endif
					case EntityID.NPCID.SLIME:
						return "Slime blu";
					case EntityID.NPCID.DEMON_EYE:
						return "Occhio del Demone";
					case EntityID.NPCID.ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.EYE_OF_CTHULHU:
						return "Occhio di Cthulhu";
					case EntityID.NPCID.SERVANT_OF_CTHULHU:
						return "Servo di Cthulhu";
					case EntityID.NPCID.EATER_OF_SOULS:
						return "Mangiatore di anime";
					case EntityID.NPCID.DEVOURER_HEAD:
					case EntityID.NPCID.DEVOURER_BODY:
					case EntityID.NPCID.DEVOURER_TAIL:
						return "Divoratore";
					case EntityID.NPCID.GIANT_WORM_HEAD:
					case EntityID.NPCID.GIANT_WORM_BODY:
					case EntityID.NPCID.GIANT_WORM_TAIL:
						return "Verme gigante";
					case EntityID.NPCID.EATER_OF_WORLDS_HEAD:
					case EntityID.NPCID.EATER_OF_WORLDS_BODY:
					case EntityID.NPCID.EATER_OF_WORLDS_TAIL:
						return "Mangiatore di mondi";
					case EntityID.NPCID.MOTHER_SLIME:
						return "Slime madre";
					case EntityID.NPCID.MERCHANT:
						return "Mercante";
					case EntityID.NPCID.NURSE:
						return "Infermiera";
					case EntityID.NPCID.ARMS_DEALER:
						return "Mercante di armi";
					case EntityID.NPCID.DRYAD:
						return "Driade";
					case EntityID.NPCID.SKELETON:
						return "Scheletro";
					case EntityID.NPCID.GUIDE:
						return "Guida";
					case EntityID.NPCID.METEOR_HEAD:
						return "Testa di meteorite";
					case EntityID.NPCID.FIRE_IMP:
						return "Diavoletto di fuoco";
					case EntityID.NPCID.BURNING_SPHERE:
						return "Sfera infuocata";
					case EntityID.NPCID.GOBLIN_PEON:
						return "Goblin operaio";
					case EntityID.NPCID.GOBLIN_THIEF:
						return "Goblin ladro";
					case EntityID.NPCID.GOBLIN_WARRIOR:
						return "Goblin guerriero";
					case EntityID.NPCID.GOBLIN_SORCERER:
						return "Goblin stregone";
					case EntityID.NPCID.CHAOS_BALL:
						return "Palla del caos";
					case EntityID.NPCID.BONES:
						return "Ossa arrabbiate";
					case EntityID.NPCID.DARK_CASTER:
						return "Lanciatore oscuro";
					case EntityID.NPCID.WATER_SPHERE:
						return "Sfera d'acqua";
					case EntityID.NPCID.CURSED_SKULL:
						return "Teschio maledetto";
					case EntityID.NPCID.SKELETRON_HEAD:
					case EntityID.NPCID.SKELETRON_HAND:
						return "Skeletron";
					case EntityID.NPCID.OLD_MAN:
						return "Vecchio";
					case EntityID.NPCID.DEMOLITIONIST:
						return "Esperto in demolizioni";
					case EntityID.NPCID.BONE_SERPENT_HEAD:
					case EntityID.NPCID.BONE_SERPENT_BODY:
					case EntityID.NPCID.BONE_SERPENT_TAIL:
						return "Serpente di ossa";
					case EntityID.NPCID.HORNET:
						return "Calabrone";
					case EntityID.NPCID.MAN_EATER:
						return "Mangiauomini";
					case EntityID.NPCID.UNDEAD_MINER:
						return "Minatore non-morto";
					case EntityID.NPCID.TIM:
						return "Tim";
					case EntityID.NPCID.BUNNY:
						return "Coniglio";
					case EntityID.NPCID.CORRUPT_BUNNY:
						return "Coniglio corrotto";
					case EntityID.NPCID.HARPY:
						return "Arpia";
					case EntityID.NPCID.CAVE_BAT:
						return "Pipistrello della caverna";
					case EntityID.NPCID.KING_SLIME:
						return "Slime re";
					case EntityID.NPCID.JUNGLE_BAT:
						return "Pipistrello della giungla";
					case EntityID.NPCID.DOCTOR_BONES:
						return "Dottor ossa";
					case EntityID.NPCID.THE_GROOM:
						return "Lo sposo";
					case EntityID.NPCID.CLOTHIER:
						return "Mercante di abiti";
					case EntityID.NPCID.GOLDFISH:
						return "Pesce rosso";
					case EntityID.NPCID.SNATCHER:
						return "Pianta afferratrice";
					case EntityID.NPCID.CORRUPT_GOLDFISH:
						return "Pesce rosso corrotto";
					case EntityID.NPCID.PIRANHA:
						return "Piranha";
					case EntityID.NPCID.LAVA_SLIME:
						return "Slime di lava";
					case EntityID.NPCID.HELLBAT:
						return "Pipistrello dell'inferno";
					case EntityID.NPCID.VULTURE:
						return "Avvoltoio";
					case EntityID.NPCID.DEMON:
						return "Demone";
					case EntityID.NPCID.BLUE_JELLYFISH:
						return "Medusa blu";
					case EntityID.NPCID.PINK_JELLYFISH:
						return "Medusa rosa";
					case EntityID.NPCID.SHARK:
						return "Squalo";
					case EntityID.NPCID.VOODOO_DEMON:
						return "Demone voodoo";
					case EntityID.NPCID.CRAB:
						return "Granchio";
					case EntityID.NPCID.DUNGEON_GUARDIAN:
						return "Guardiano della Dungeon";
					case EntityID.NPCID.ANTLION:
						return "Formicaleone";
					case EntityID.NPCID.SPIKE_BALL:
						return "Sfera con spuntoni";
					case EntityID.NPCID.DUNGEON_SLIME:
						return "Slime della Dungeon";
					case EntityID.NPCID.BLAZING_WHEEL:
						return "Ruota ardente";
					case EntityID.NPCID.GOBLIN_SCOUT:
						return "Goblin ricognitore";
					case EntityID.NPCID.BIRD:
						return "Uccello";
					case EntityID.NPCID.PIXIE:
						return "Folletto";
					case EntityID.NPCID.XXX_UNUSED_XXX:
						return "";
					case EntityID.NPCID.ARMORED_SKELETON:
						return "Scheletro corazzato";
					case EntityID.NPCID.MUMMY:
						return "Mummia";
					case EntityID.NPCID.DARK_MUMMY:
						return "Mummia oscura";
					case EntityID.NPCID.LIGHT_MUMMY:
						return "Mummia chiara";
					case EntityID.NPCID.CORRUPT_SLIME:
						return "Slime corrotto";
					case EntityID.NPCID.WRAITH:
						return "Fantasma";
					case EntityID.NPCID.CURSED_HAMMER:
						return "Martello maledetto";
					case EntityID.NPCID.ENCHANTED_SWORD:
						return "Spada incantata";
					case EntityID.NPCID.MIMIC:
						return "Sosia";
					case EntityID.NPCID.UNICORN:
						return "Unicorno";
					case EntityID.NPCID.WYVERN_HEAD:
					case EntityID.NPCID.WYVERN_LEGS:
					case EntityID.NPCID.WYVERN_BODY1:
					case EntityID.NPCID.WYVERN_BODY2:
					case EntityID.NPCID.WYVERN_BODY3:
					case EntityID.NPCID.WYVERN_TAIL:
						return "Viverna";
					case EntityID.NPCID.GIANT_BAT:
						return "Pipistrello gigante";
					case EntityID.NPCID.CORRUPTOR:
						return "Corruttore";
					case EntityID.NPCID.DIGGER_HEAD:
					case EntityID.NPCID.DIGGER_BODY:
					case EntityID.NPCID.DIGGER_TAIL:
						return "Scavatore";
					case EntityID.NPCID.SEEKER_HEAD:
					case EntityID.NPCID.SEEKER_BODY:
					case EntityID.NPCID.SEEKER_TAIL:
						return "Alimentatore del mondo";
					case EntityID.NPCID.CLINGER:
						return "Appiccicoso";
					case EntityID.NPCID.ANGLER_FISH:
						return "Rana pescatrice";
					case EntityID.NPCID.GREEN_JELLYFISH:
						return "Medusa verde";
					case EntityID.NPCID.WEREWOLF:
						return "Lupo mannaro";
					case EntityID.NPCID.BOUND_GOBLIN:
						return "Goblin legato";
					case EntityID.NPCID.BOUND_WIZARD:
						return "Stregone legato";
					case EntityID.NPCID.GOBLIN_TINKERER:
						return "Goblin inventore";
					case EntityID.NPCID.WIZARD:
						return "Stregone";
					case EntityID.NPCID.CLOWN:
						return "Clown";
					case EntityID.NPCID.SKELETON_ARCHER:
						return "Scheletro arciere";
					case EntityID.NPCID.GOBLIN_ARCHER:
						return "Goblin arciere";
					case EntityID.NPCID.VILE_SPIT:
						return "Bava disgustosa";
					case EntityID.NPCID.WALL_OF_FLESH:
					case EntityID.NPCID.WALL_OF_FLESH_EYE:
						return "Muro di carne";
					case EntityID.NPCID.THE_HUNGRY:
					case EntityID.NPCID.THE_HUNGRY_II:
						return "L'Affamato";
					case EntityID.NPCID.LEECH_HEAD:
					case EntityID.NPCID.LEECH_BODY:
					case EntityID.NPCID.LEECH_TAIL:
						return "Sanguisuga";
					case EntityID.NPCID.CHAOS_ELEMENTAL:
						return "Elementale del caos";
					case EntityID.NPCID.SLIMER:
						return "Slimer";
					case EntityID.NPCID.GASTROPOD:
						return "Gasteropodo";
					case EntityID.NPCID.BOUND_MECHANIC:
						return "Meccanico legato";
					case EntityID.NPCID.MECHANIC:
						return "Meccanico";
					case EntityID.NPCID.RETINAZER:
						return "Retinazer";
					case EntityID.NPCID.SPAZMATISM:
						return "Spazmatism";
					case EntityID.NPCID.SKELETRON_PRIME:
						return "Skeletron primario";
					case EntityID.NPCID.PRIME_CANNON:
						return "Cannone primario";
					case EntityID.NPCID.PRIME_SAW:
						return "Sega primaria";
					case EntityID.NPCID.PRIME_VICE:
						return "Morsa primaria";
					case EntityID.NPCID.PRIME_LASER:
						return "Laser primario";
					case EntityID.NPCID.BALD_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.WANDERING_EYE:
						return "Occhio errante";
					case EntityID.NPCID.THE_DESTROYER_HEAD:
					case EntityID.NPCID.THE_DESTROYER_BODY:
					case EntityID.NPCID.THE_DESTROYER_TAIL:
						return "Il Distruttore";
					case EntityID.NPCID.ILLUMINANT_BAT:
						return "Pipistrello illuminante";
					case EntityID.NPCID.ILLUMINANT_SLIME:
						return "Slime illuminante";
					case EntityID.NPCID.PROBE:
						return "Sonda";
					case EntityID.NPCID.POSSESSED_ARMOR:
						return "Armatura posseduta";
					case EntityID.NPCID.TOXIC_SLUDGE:
						return "Fango tossico";
					case EntityID.NPCID.SANTA_CLAUS:
						return "Babbo Natale";
					case EntityID.NPCID.SNOWMAN_GANGSTA:
						return "Pupazzo di neve Gangsta";
					case EntityID.NPCID.MISTER_STABBY:
						return "Signor Stabby";
					case EntityID.NPCID.SNOW_BALLA:
						return "Neve Balla";
					case EntityID.NPCID.ALBINO_ANTLION:
						return "Formicaleone albino";
					case EntityID.NPCID.ORKA:
						return "Orca";
					case EntityID.NPCID.VAMPIRE_MINER:
						return "Minatore vampiro";
					case EntityID.NPCID.SHADOW_SLIME:
						return "Slime ombra";
					case EntityID.NPCID.SHADOW_HAMMER:
						return "Mummia ombra";
					case EntityID.NPCID.SHADOW_MUMMY:
						return "Shadow Mummy";
					case EntityID.NPCID.SPECTRAL_GASTROPOD:
						return "Gasteropode spettrale";
					case EntityID.NPCID.SPECTRAL_ELEMENTAL:
						return "Elementale spettrale";
					case EntityID.NPCID.SPECTRAL_MUMMY:
						return "Mummia spettrale";
					case EntityID.NPCID.DRAGON_SNATCHER:
						return "Pianta afferratrice del Drago";
					case EntityID.NPCID.DRAGON_HORNET:
						return "Calabrone del Drago";
					case EntityID.NPCID.DRAGON_SKULL:
						return "Teschio del Drago";
					case EntityID.NPCID.ARCH_WYVERN_HEAD:
					case EntityID.NPCID.ARCH_WYVERN_LEGS:
					case EntityID.NPCID.ARCH_WYVERN_BODY1:
					case EntityID.NPCID.ARCH_WYVERN_BODY2:
					case EntityID.NPCID.ARCH_WYVERN_BODY3:
					case EntityID.NPCID.ARCH_WYVERN_TAIL:
						return "Arciviverna";
					case EntityID.NPCID.ARCH_DEMON:
						return "Arcidiavolo";
					case EntityID.NPCID.OCRAM:
						return "Ocram";
					case EntityID.NPCID.SERVANT_OF_OCRAM:
						return "Servo di Ocram";
#if VERSION_101
					case EntityID.NPCID.CATARACT_EYE:
					case EntityID.NPCID.SLEEPY_EYE:
					case EntityID.NPCID.DIALATED_EYE:
					case EntityID.NPCID.GREEN_EYE:
					case EntityID.NPCID.PURPLE_EYE:
						return "Occhio del Demone";
					case EntityID.NPCID.PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SLIMED_ZOMBIE:
					case EntityID.NPCID.SWAMP_ZOMBIE:
					case EntityID.NPCID.TWIGGY_ZOMBIE:
					case EntityID.NPCID.FEMALE_ZOMBIE:
					case EntityID.NPCID.ZOMBIE_MUSHROOM:
					case EntityID.NPCID.ZOMBIE_MUSHROOM_HAT:
						return "Zombie";
#endif
					default:
						return "";
				}
			}
			if (LangOption == (int)ID.FRENCH)
			{
				switch ((EntityID.NPCID)l)
				{
					case EntityID.NPCID.SLIMELING2:
					case EntityID.NPCID.SLIMELING:
						return "Slimeling";
					case EntityID.NPCID.SLIMER2:
						return "Slimer";
					case EntityID.NPCID.GREEN_SLIME:
						return "Slime vert";
					case EntityID.NPCID.PINKY:
						return "Pinky";
					case EntityID.NPCID.BABY_SLIME:
						return "Bébé slime";
					case EntityID.NPCID.BLACK_SLIME:
						return "Slime noir";
					case EntityID.NPCID.PURPLE_SLIME:
						return "Slime violet";
					case EntityID.NPCID.RED_SLIME:
						return "Slime rouge";
					case EntityID.NPCID.YELLOW_SLIME:
						return "Slime jaune";
					case EntityID.NPCID.JUNGLE_SLIME:
						return "Slime de la jungle";
#if VERSION_101
					case EntityID.NPCID.LITTLE_EATER:
					case EntityID.NPCID.BIG_EATER:
						return "Dévoreur d'âmes";
					case EntityID.NPCID.SHORT_BONES:
					case EntityID.NPCID.BIG_BONED:
						return "Squelette furieux";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Squelette en armure";
					case EntityID.NPCID.LITTLE_STINGER:
					case EntityID.NPCID.BIG_STINGER:
						return "Frelon";
					case EntityID.NPCID.SMALL_ZOMBIE:
					case EntityID.NPCID.BIG_ZOMBIE:
					case EntityID.NPCID.SMALL_BALD_ZOMBIE:
					case EntityID.NPCID.BIG_BALD_ZOMBIE:
					case EntityID.NPCID.SMALL_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.BIG_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SMALL_SLIMED_ZOMBIE:
					case EntityID.NPCID.BIG_SLIMED_ZOMBIE:
					case EntityID.NPCID.SMALL_SWAMP_ZOMBIE:
					case EntityID.NPCID.BIG_SWAMP_ZOMBIE:
					case EntityID.NPCID.SMALL_TWIGGY_ZOMBIE:
					case EntityID.NPCID.BIG_TWIGGY_ZOMBIE:
					case EntityID.NPCID.SMALL_FEMALE_ZOMBIE:
					case EntityID.NPCID.BIG_FEMALE_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.CATARACT_EYE2:
					case EntityID.NPCID.SLEEPY_EYE2:
					case EntityID.NPCID.DIALATED_EYE2:
					case EntityID.NPCID.GREEN_EYE2:
					case EntityID.NPCID.PURPLE_EYE2:
					case EntityID.NPCID.DEMON_EYE2:
						return "Œil de démon";
#else
					case EntityID.NPCID.LITTLE_EATER:
						return "Petit dévoreur";
					case EntityID.NPCID.BIG_EATER:
						return "Grand dévoreur";
					case EntityID.NPCID.SHORT_BONES:
						return "Petit squelette";
					case EntityID.NPCID.BIG_BONED:
						return "Grand squelette";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Squelette lourd";
					case EntityID.NPCID.LITTLE_STINGER:
						return "Petit frelon";
					case EntityID.NPCID.BIG_STINGER:
						return "Gros frelon";
#endif
					case EntityID.NPCID.SLIME:
						return "Slime bleu";
					case EntityID.NPCID.DEMON_EYE:
						return "Œil de démon";
					case EntityID.NPCID.ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.EYE_OF_CTHULHU:
						return "Œil de Cthulhu";
					case EntityID.NPCID.SERVANT_OF_CTHULHU:
						return "Servant de Cthulhu";
					case EntityID.NPCID.EATER_OF_SOULS:
						return "Dévoreur d'âmes";
					case EntityID.NPCID.DEVOURER_HEAD:
					case EntityID.NPCID.DEVOURER_BODY:
					case EntityID.NPCID.DEVOURER_TAIL:
						return "Dévoreur";
					case EntityID.NPCID.GIANT_WORM_HEAD:
					case EntityID.NPCID.GIANT_WORM_BODY:
					case EntityID.NPCID.GIANT_WORM_TAIL:
						return "Ver géant";
					case EntityID.NPCID.EATER_OF_WORLDS_HEAD:
					case EntityID.NPCID.EATER_OF_WORLDS_BODY:
					case EntityID.NPCID.EATER_OF_WORLDS_TAIL:
						return "Dévoreur de mondes";
					case EntityID.NPCID.MOTHER_SLIME:
						return "Mère slime";
					case EntityID.NPCID.MERCHANT:
						return "Marchand";
					case EntityID.NPCID.NURSE:
						return "Infirmière";
					case EntityID.NPCID.ARMS_DEALER:
						return "Marchand d'armes";
					case EntityID.NPCID.DRYAD:
						return "Dryade";
					case EntityID.NPCID.SKELETON:
						return "Squelette";
					case EntityID.NPCID.GUIDE:
						return "Guide";
					case EntityID.NPCID.METEOR_HEAD:
						return "Tête de météorite";
					case EntityID.NPCID.FIRE_IMP:
						return "Diablotin de feu";
					case EntityID.NPCID.BURNING_SPHERE:
						return "Sphère brûlante";
					case EntityID.NPCID.GOBLIN_PEON:
						return "Péon gobelin";
					case EntityID.NPCID.GOBLIN_THIEF:
						return "Voleur gobelin";
					case EntityID.NPCID.GOBLIN_WARRIOR:
						return "Guerrier gobelin";
					case EntityID.NPCID.GOBLIN_SORCERER:
						return "Sorcier gobelin";
					case EntityID.NPCID.CHAOS_BALL:
						return "Boule de chaos";
					case EntityID.NPCID.BONES:
						return "Squelette furieux";
					case EntityID.NPCID.DARK_CASTER:
						return "Magicien noir";
					case EntityID.NPCID.WATER_SPHERE:
						return "Sphère d'eau";
					case EntityID.NPCID.CURSED_SKULL:
						return "Crâne maudit";
					case EntityID.NPCID.SKELETRON_HEAD:
						return "Squeletron";
					case EntityID.NPCID.SKELETRON_HAND:
						return "Squeletron";
					case EntityID.NPCID.OLD_MAN:
						return "Vieil homme";
					case EntityID.NPCID.DEMOLITIONIST:
						return "Démolisseur";
					case EntityID.NPCID.BONE_SERPENT_HEAD:
					case EntityID.NPCID.BONE_SERPENT_BODY:
					case EntityID.NPCID.BONE_SERPENT_TAIL:
						return "Serpent d'os";
					case EntityID.NPCID.HORNET:
						return "Frelon";
					case EntityID.NPCID.MAN_EATER:
						return "Mangeur d'hommes";
					case EntityID.NPCID.UNDEAD_MINER:
						return "Mineur mort-vivant";
					case EntityID.NPCID.TIM:
						return "Tim";
					case EntityID.NPCID.BUNNY:
						return "Lapin";
					case EntityID.NPCID.CORRUPT_BUNNY:
						return "Lapin corrompu";
					case EntityID.NPCID.HARPY:
						return "Harpie";
					case EntityID.NPCID.CAVE_BAT:
						return "Chauve-souris";
					case EntityID.NPCID.KING_SLIME:
						return "Roi slime";
					case EntityID.NPCID.JUNGLE_BAT:
						return "Chauve-souris de la jungle";
					case EntityID.NPCID.DOCTOR_BONES:
						return "Docteur Bones";
					case EntityID.NPCID.THE_GROOM:
						return "Le jeune marié";
					case EntityID.NPCID.CLOTHIER:
						return "Tailleur";
					case EntityID.NPCID.GOLDFISH:
						return "Poisson rouge";
					case EntityID.NPCID.SNATCHER:
						return "Ravisseur";
					case EntityID.NPCID.CORRUPT_GOLDFISH:
						return "Poisson rouge corrompu";
					case EntityID.NPCID.PIRANHA:
						return "Piranha";
					case EntityID.NPCID.LAVA_SLIME:
						return "Slime de l'enfer";
					case EntityID.NPCID.HELLBAT:
						return "Chauve-souris de l'enfer";
					case EntityID.NPCID.VULTURE:
						return "Vautour";
					case EntityID.NPCID.DEMON:
						return "Démon";
					case EntityID.NPCID.BLUE_JELLYFISH:
						return "Méduse bleue";
					case EntityID.NPCID.PINK_JELLYFISH:
						return "Méduse rose";
					case EntityID.NPCID.SHARK:
						return "Requin";
					case EntityID.NPCID.VOODOO_DEMON:
						return "Démon vaudou";
					case EntityID.NPCID.CRAB:
						return "Crabe";
					case EntityID.NPCID.DUNGEON_GUARDIAN:
						return "Gardien du donjon";
					case EntityID.NPCID.ANTLION:
						return "Fourmilion";
					case EntityID.NPCID.SPIKE_BALL:
						return "Boule piquante";
					case EntityID.NPCID.DUNGEON_SLIME:
						return "Slime des donjons";
					case EntityID.NPCID.BLAZING_WHEEL:
						return "Roue de feu";
					case EntityID.NPCID.GOBLIN_SCOUT:
						return "Scout gobelin";
					case EntityID.NPCID.BIRD:
						return "Oiseau";
					case EntityID.NPCID.PIXIE:
						return "Lutin";
					case EntityID.NPCID.XXX_UNUSED_XXX:
						return "";
					case EntityID.NPCID.ARMORED_SKELETON:
						return "Squelette en armure";
					case EntityID.NPCID.MUMMY:
						return "Momie";
					case EntityID.NPCID.DARK_MUMMY:
						return "Momie de l'ombre";
					case EntityID.NPCID.LIGHT_MUMMY:
						return "Momie de lumière";
					case EntityID.NPCID.CORRUPT_SLIME:
						return "Slime corrompu";
					case EntityID.NPCID.WRAITH:
						return "Spectre";
					case EntityID.NPCID.CURSED_HAMMER:
						return "Marteau maudit";
					case EntityID.NPCID.ENCHANTED_SWORD:
						return "Épée enchantée";
					case EntityID.NPCID.MIMIC:
						return "Imitateur";
					case EntityID.NPCID.UNICORN:
						return "Licorne";
					case EntityID.NPCID.WYVERN_HEAD:
					case EntityID.NPCID.WYVERN_LEGS:
					case EntityID.NPCID.WYVERN_BODY1:
					case EntityID.NPCID.WYVERN_BODY2:
					case EntityID.NPCID.WYVERN_BODY3:
					case EntityID.NPCID.WYVERN_TAIL:
						return "Wyverne";
					case EntityID.NPCID.GIANT_BAT:
						return "Chauve-souris géante";
					case EntityID.NPCID.CORRUPTOR:
						return "Corrupteur";
					case EntityID.NPCID.DIGGER_HEAD:
					case EntityID.NPCID.DIGGER_BODY:
					case EntityID.NPCID.DIGGER_TAIL:
						return "Fouisseur";
					case EntityID.NPCID.SEEKER_HEAD:
					case EntityID.NPCID.SEEKER_BODY:
					case EntityID.NPCID.SEEKER_TAIL:
						return "Nourricier";
					case EntityID.NPCID.CLINGER:
						return "Accrocheur";
					case EntityID.NPCID.ANGLER_FISH:
						return "Baudroie";
					case EntityID.NPCID.GREEN_JELLYFISH:
						return "Méduse verte";
					case EntityID.NPCID.WEREWOLF:
						return "Loup-garou";
					case EntityID.NPCID.BOUND_GOBLIN:
						return "Gobelin attaché";
					case EntityID.NPCID.BOUND_WIZARD:
						return "Magicien attaché";
					case EntityID.NPCID.GOBLIN_TINKERER:
						return "Gobelin bricoleur";
					case EntityID.NPCID.WIZARD:
						return "Magicien";
					case EntityID.NPCID.CLOWN:
						return "Clown";
					case EntityID.NPCID.SKELETON_ARCHER:
						return "Archer squelette";
					case EntityID.NPCID.GOBLIN_ARCHER:
						return "Archer gobelin";
					case EntityID.NPCID.VILE_SPIT:
						return "Immonde crachat";
					case EntityID.NPCID.WALL_OF_FLESH:
					case EntityID.NPCID.WALL_OF_FLESH_EYE:
						return "Mur de chair";
					case EntityID.NPCID.THE_HUNGRY:
					case EntityID.NPCID.THE_HUNGRY_II:
						return "L'affamé";
					case EntityID.NPCID.LEECH_HEAD:
					case EntityID.NPCID.LEECH_BODY:
					case EntityID.NPCID.LEECH_TAIL:
						return "Sangsue";
					case EntityID.NPCID.CHAOS_ELEMENTAL:
						return "Élémentaire du chaos";
					case EntityID.NPCID.SLIMER:
						return "Slimer";
					case EntityID.NPCID.GASTROPOD:
						return "Gastropode";
					case EntityID.NPCID.BOUND_MECHANIC:
						return "Mécanicienne attachée";
					case EntityID.NPCID.MECHANIC:
						return "Mécanicienne";
					case EntityID.NPCID.RETINAZER:
						return "Rétinazer";
					case EntityID.NPCID.SPAZMATISM:
						return "Spazmatisme";
					case EntityID.NPCID.SKELETRON_PRIME:
						return "Skeletron Prime";
					case EntityID.NPCID.PRIME_CANNON:
						return "Canon primaire";
					case EntityID.NPCID.PRIME_SAW:
						return "Scie primaire";
					case EntityID.NPCID.PRIME_VICE:
						return "Étau principal";
					case EntityID.NPCID.PRIME_LASER:
						return "Laser principal";
					case EntityID.NPCID.BALD_ZOMBIE:
						return "Zombie";
					case EntityID.NPCID.WANDERING_EYE:
						return "Œil vagabond";
					case EntityID.NPCID.THE_DESTROYER_HEAD:
					case EntityID.NPCID.THE_DESTROYER_BODY:
					case EntityID.NPCID.THE_DESTROYER_TAIL:
						return "Le destructeur";
					case EntityID.NPCID.ILLUMINANT_BAT:
						return "Chauve-souris illuminée";
					case EntityID.NPCID.ILLUMINANT_SLIME:
						return "Slime illuminé";
					case EntityID.NPCID.PROBE:
						return "Sonde";
					case EntityID.NPCID.POSSESSED_ARMOR:
						return "Armure possédée";
					case EntityID.NPCID.TOXIC_SLUDGE:
						return "Boue toxique";
					case EntityID.NPCID.SANTA_CLAUS:
						return "Père Noël";
					case EntityID.NPCID.SNOWMAN_GANGSTA:
						return "Snowman Gangsta";
					case EntityID.NPCID.MISTER_STABBY:
						return "Monsieur Stabby";
					case EntityID.NPCID.SNOW_BALLA:
						return "Neige Balla";
					case EntityID.NPCID.ALBINO_ANTLION:
						return "Fourmilion albinos";
					case EntityID.NPCID.ORKA:
						return "Orca";
					case EntityID.NPCID.VAMPIRE_MINER:
						return "Mineur vampire";
					case EntityID.NPCID.SHADOW_SLIME:
						return "Slime de l'ombre";
					case EntityID.NPCID.SHADOW_HAMMER:
						return "Marteau de l'ombre";
					case EntityID.NPCID.SHADOW_MUMMY:
						return "Momie de l'ombre";
					case EntityID.NPCID.SPECTRAL_GASTROPOD:
						return "Gastropode spectral";
					case EntityID.NPCID.SPECTRAL_ELEMENTAL:
						return "Élémentaire spectral";
					case EntityID.NPCID.SPECTRAL_MUMMY:
						return "Momie spectrale";
					case EntityID.NPCID.DRAGON_SNATCHER:
						return "Dragon ravisseur";
					case EntityID.NPCID.DRAGON_HORNET:
						return "Frelon dragon";
					case EntityID.NPCID.DRAGON_SKULL:
						return "Crâne de dragon";
					case EntityID.NPCID.ARCH_WYVERN_HEAD:
					case EntityID.NPCID.ARCH_WYVERN_LEGS:
					case EntityID.NPCID.ARCH_WYVERN_BODY1:
					case EntityID.NPCID.ARCH_WYVERN_BODY2:
					case EntityID.NPCID.ARCH_WYVERN_BODY3:
					case EntityID.NPCID.ARCH_WYVERN_TAIL:
						return "Arche Wyvern";
					case EntityID.NPCID.ARCH_DEMON:
						return "Arche démon";
					case EntityID.NPCID.OCRAM:
						return "Ocram";
					case EntityID.NPCID.SERVANT_OF_OCRAM:
						return "Serviteur d'Ocram";
#if VERSION_101
					case EntityID.NPCID.CATARACT_EYE:
					case EntityID.NPCID.SLEEPY_EYE:
					case EntityID.NPCID.DIALATED_EYE:
					case EntityID.NPCID.GREEN_EYE:
					case EntityID.NPCID.PURPLE_EYE:
						return "Œil de démon";
					case EntityID.NPCID.PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SLIMED_ZOMBIE:
					case EntityID.NPCID.SWAMP_ZOMBIE:
					case EntityID.NPCID.TWIGGY_ZOMBIE:
					case EntityID.NPCID.FEMALE_ZOMBIE:
					case EntityID.NPCID.ZOMBIE_MUSHROOM:
					case EntityID.NPCID.ZOMBIE_MUSHROOM_HAT:
						return "Zombie";
#endif
					default:
						return "";
				}
			}
			if (LangOption == (int)ID.SPANISH)
			{
				switch ((EntityID.NPCID)l)
				{
					case EntityID.NPCID.SLIMELING2:
					case EntityID.NPCID.SLIMELING:
						return "Slimeling";
					case EntityID.NPCID.SLIMER2:
						return "Slimer";
					case EntityID.NPCID.GREEN_SLIME:
						return "Slime verde";
					case EntityID.NPCID.PINKY:
						return "Slime rosa";
					case EntityID.NPCID.BABY_SLIME:
						return "Bebé slime";
					case EntityID.NPCID.BLACK_SLIME:
						return "Slime negro";
					case EntityID.NPCID.PURPLE_SLIME:
						return "Slime morado";
					case EntityID.NPCID.RED_SLIME:
						return "Slime rojo";
					case EntityID.NPCID.YELLOW_SLIME:
						return "Slime amarillo";
					case EntityID.NPCID.JUNGLE_SLIME:
						return "Slime selvático";
#if VERSION_101
					case EntityID.NPCID.LITTLE_EATER:
					case EntityID.NPCID.BIG_EATER:
						return "Devoraalmas";
					case EntityID.NPCID.SHORT_BONES:
					case EntityID.NPCID.BIG_BONED:
						return "Huesitos furioso";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Esqueleto con armadura";
					case EntityID.NPCID.LITTLE_STINGER:
					case EntityID.NPCID.BIG_STINGER:
						return "Avispón";
					case EntityID.NPCID.SMALL_ZOMBIE:
					case EntityID.NPCID.BIG_ZOMBIE:
					case EntityID.NPCID.SMALL_BALD_ZOMBIE:
					case EntityID.NPCID.BIG_BALD_ZOMBIE:
					case EntityID.NPCID.SMALL_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.BIG_PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SMALL_SLIMED_ZOMBIE:
					case EntityID.NPCID.BIG_SLIMED_ZOMBIE:
					case EntityID.NPCID.SMALL_SWAMP_ZOMBIE:
					case EntityID.NPCID.BIG_SWAMP_ZOMBIE:
					case EntityID.NPCID.SMALL_TWIGGY_ZOMBIE:
					case EntityID.NPCID.BIG_TWIGGY_ZOMBIE:
					case EntityID.NPCID.SMALL_FEMALE_ZOMBIE:
					case EntityID.NPCID.BIG_FEMALE_ZOMBIE:
						return "Zombi";
					case EntityID.NPCID.CATARACT_EYE2:
					case EntityID.NPCID.SLEEPY_EYE2:
					case EntityID.NPCID.DIALATED_EYE2:
					case EntityID.NPCID.GREEN_EYE2:
					case EntityID.NPCID.PURPLE_EYE2:
					case EntityID.NPCID.DEMON_EYE2:
						return "Ojo demoníaco";
#else
					case EntityID.NPCID.LITTLE_EATER:
						return "Pequeño devorador";
					case EntityID.NPCID.BIG_EATER:
						return "Gran devorador";
					case EntityID.NPCID.SHORT_BONES:
						return "Pequeño huesitos";
					case EntityID.NPCID.BIG_BONED:
						return "Gran huesitos";
					case EntityID.NPCID.HEAVY_SKELETON:
						return "Esqueleto pesado";
					case EntityID.NPCID.LITTLE_STINGER:
						return "Avispa pequeña";
					case EntityID.NPCID.BIG_STINGER:
						return "Gran avispa";
#endif
					case EntityID.NPCID.SLIME:
						return "Slime azul";
					case EntityID.NPCID.DEMON_EYE:
						return "Ojo demoníaco";
					case EntityID.NPCID.ZOMBIE:
						return "Zombi";
					case EntityID.NPCID.EYE_OF_CTHULHU:
						return "Ojo Cthulhu";
					case EntityID.NPCID.SERVANT_OF_CTHULHU:
						return "Siervo de Cthulhu";
					case EntityID.NPCID.EATER_OF_SOULS:
						return "Devoraalmas";
					case EntityID.NPCID.DEVOURER_HEAD:
					case EntityID.NPCID.DEVOURER_BODY:
					case EntityID.NPCID.DEVOURER_TAIL:
						return "Gusano devorador";
					case EntityID.NPCID.GIANT_WORM_HEAD:
					case EntityID.NPCID.GIANT_WORM_BODY:
					case EntityID.NPCID.GIANT_WORM_TAIL:
						return "Gusano gigante";
					case EntityID.NPCID.EATER_OF_WORLDS_HEAD:
					case EntityID.NPCID.EATER_OF_WORLDS_BODY:
					case EntityID.NPCID.EATER_OF_WORLDS_TAIL:
						return "Devoramundos";
					case EntityID.NPCID.MOTHER_SLIME:
						return "Mamá slime";
					case EntityID.NPCID.MERCHANT:
						return "Mercader";
					case EntityID.NPCID.NURSE:
						return "Enfermera";
					case EntityID.NPCID.ARMS_DEALER:
						return "Traficante de armas";
					case EntityID.NPCID.DRYAD:
						return "Dríada";
					case EntityID.NPCID.SKELETON:
						return "Esqueleto";
					case EntityID.NPCID.GUIDE:
						return "Guía";
					case EntityID.NPCID.METEOR_HEAD:
						return "Cabeza meteorito";
					case EntityID.NPCID.FIRE_IMP:
						return "Diablillo de fuego";
					case EntityID.NPCID.BURNING_SPHERE:
						return "Esfera ardiente";
					case EntityID.NPCID.GOBLIN_PEON:
						return "Duende peón";
					case EntityID.NPCID.GOBLIN_THIEF:
						return "Duende ladrón";
					case EntityID.NPCID.GOBLIN_WARRIOR:
						return "Duende guerrero";
					case EntityID.NPCID.GOBLIN_SORCERER:
						return "Duende hechicero";
					case EntityID.NPCID.CHAOS_BALL:
						return "Bola del caos";
					case EntityID.NPCID.BONES:
						return "Huesitos furioso";
					case EntityID.NPCID.DARK_CASTER:
						return "Mago siniestro";
					case EntityID.NPCID.WATER_SPHERE:
						return "Esfera de agua";
					case EntityID.NPCID.CURSED_SKULL:
						return "Cráneo maldito";
					case EntityID.NPCID.SKELETRON_HEAD:
						return "Esqueletrón";
					case EntityID.NPCID.SKELETRON_HAND:
						return "Esqueletrón";
					case EntityID.NPCID.OLD_MAN:
						return "Anciano";
					case EntityID.NPCID.DEMOLITIONIST:
						return "Demoledor";
					case EntityID.NPCID.BONE_SERPENT_HEAD:
					case EntityID.NPCID.BONE_SERPENT_BODY:
					case EntityID.NPCID.BONE_SERPENT_TAIL:
						return "Esqueleto de serpiente";
					case EntityID.NPCID.HORNET:
						return "Avispón";
					case EntityID.NPCID.MAN_EATER:
						return "Devorahombres";
					case EntityID.NPCID.UNDEAD_MINER:
						return "Minero zombi";
					case EntityID.NPCID.TIM:
						return "Tim";
					case EntityID.NPCID.BUNNY:
						return "Conejito";
					case EntityID.NPCID.CORRUPT_BUNNY:
						return "Conejito corrompido";
					case EntityID.NPCID.HARPY:
						return "Arpía";
					case EntityID.NPCID.CAVE_BAT:
						return "Murciélago de cueva";
					case EntityID.NPCID.KING_SLIME:
						return "Rey slime";
					case EntityID.NPCID.JUNGLE_BAT:
						return "Murciélago de selva";
					case EntityID.NPCID.DOCTOR_BONES:
						return "Doctor Látigo";
					case EntityID.NPCID.THE_GROOM:
						return "El novio zombi";
					case EntityID.NPCID.CLOTHIER:
						return "Buhonero";
					case EntityID.NPCID.GOLDFISH:
						return "Pececillo";
					case EntityID.NPCID.SNATCHER:
						return "Atrapadora";
					case EntityID.NPCID.CORRUPT_GOLDFISH:
						return "Pececillo corrompido";
					case EntityID.NPCID.PIRANHA:
						return "Piraña";
					case EntityID.NPCID.LAVA_SLIME:
						return "Babosa de lava";
					case EntityID.NPCID.HELLBAT:
						return "Murciélago infernal";
					case EntityID.NPCID.VULTURE:
						return "Buitre";
					case EntityID.NPCID.DEMON:
						return "Demonio";
					case EntityID.NPCID.BLUE_JELLYFISH:
						return "Medusa azul";
					case EntityID.NPCID.PINK_JELLYFISH:
						return "Medusa rosa";
					case EntityID.NPCID.SHARK:
						return "Tiburón";
					case EntityID.NPCID.VOODOO_DEMON:
						return "Demonio vudú";
					case EntityID.NPCID.CRAB:
						return "Cangrejo";
					case EntityID.NPCID.DUNGEON_GUARDIAN:
						return "Guardián de la mazmorra";
					case EntityID.NPCID.ANTLION:
						return "Hormiga león";
					case EntityID.NPCID.SPIKE_BALL:
						return "Bola de pinchos";
					case EntityID.NPCID.DUNGEON_SLIME:
						return "Slime de las mazmorras";
					case EntityID.NPCID.BLAZING_WHEEL:
						return "Rueda ardiente";
					case EntityID.NPCID.GOBLIN_SCOUT:
						return "Duende explorador";
					case EntityID.NPCID.BIRD:
						return "Pájaro";
					case EntityID.NPCID.PIXIE:
						return "Duendecillo";
					case EntityID.NPCID.ARMORED_SKELETON:
						return "Esqueleto con armadura";
					case EntityID.NPCID.MUMMY:
						return "Momia";
					case EntityID.NPCID.DARK_MUMMY:
						return "Momia de la oscuridad";
					case EntityID.NPCID.LIGHT_MUMMY:
						return "Momia de la luz";
					case EntityID.NPCID.CORRUPT_SLIME:
						return "Slime corrompido";
					case EntityID.NPCID.WRAITH:
						return "Espectro";
					case EntityID.NPCID.CURSED_HAMMER:
						return "Martillo maldito";
					case EntityID.NPCID.ENCHANTED_SWORD:
						return "Espada encantada";
					case EntityID.NPCID.MIMIC:
						return "Cofre falso";
					case EntityID.NPCID.UNICORN:
						return "Unicornio";
					case EntityID.NPCID.WYVERN_HEAD:
					case EntityID.NPCID.WYVERN_LEGS:
					case EntityID.NPCID.WYVERN_BODY1:
					case EntityID.NPCID.WYVERN_BODY2:
					case EntityID.NPCID.WYVERN_BODY3:
					case EntityID.NPCID.WYVERN_TAIL:
						return "Guiverno";
					case EntityID.NPCID.GIANT_BAT:
						return "Murciélago gigante";
					case EntityID.NPCID.CORRUPTOR:
						return "Corruptor";
					case EntityID.NPCID.DIGGER_HEAD:
					case EntityID.NPCID.DIGGER_BODY:
					case EntityID.NPCID.DIGGER_TAIL:
						return "Excavador";
					case EntityID.NPCID.SEEKER_HEAD:
					case EntityID.NPCID.SEEKER_BODY:
					case EntityID.NPCID.SEEKER_TAIL:
						return "Tragamundos";
					case EntityID.NPCID.CLINGER:
						return "Lapa";
					case EntityID.NPCID.ANGLER_FISH:
						return "Pez abisal";
					case EntityID.NPCID.GREEN_JELLYFISH:
						return "Medusa verde";
					case EntityID.NPCID.WEREWOLF:
						return "Hombre lobo";
					case EntityID.NPCID.BOUND_GOBLIN:
						return "Duende cautivo";
					case EntityID.NPCID.BOUND_WIZARD:
						return "Mago cautivo";
					case EntityID.NPCID.GOBLIN_TINKERER:
						return "Duende chapucero";
					case EntityID.NPCID.WIZARD:
						return "Mago";
					case EntityID.NPCID.CLOWN:
						return "Payaso";
					case EntityID.NPCID.SKELETON_ARCHER:
						return "Esqueleto arquero";
					case EntityID.NPCID.GOBLIN_ARCHER:
						return "Duende arquero";
					case EntityID.NPCID.VILE_SPIT:
						return "Escupitajo vil";
					case EntityID.NPCID.WALL_OF_FLESH:
					case EntityID.NPCID.WALL_OF_FLESH_EYE:
						return "Muro carnoso";
					case EntityID.NPCID.THE_HUNGRY:
					case EntityID.NPCID.THE_HUNGRY_II:
						return "El Famélico";
					case EntityID.NPCID.LEECH_HEAD:
					case EntityID.NPCID.LEECH_BODY:
					case EntityID.NPCID.LEECH_TAIL:
						return "Sanguijuela";
					case EntityID.NPCID.CHAOS_ELEMENTAL:
						return "Caos elemental";
					case EntityID.NPCID.SLIMER:
						return "Slimer";
					case EntityID.NPCID.GASTROPOD:
						return "Gasterópodo";
					case EntityID.NPCID.BOUND_MECHANIC:
						return "Mecánico cautivo";
					case EntityID.NPCID.MECHANIC:
						return "Mecánico";
					case EntityID.NPCID.RETINAZER:
						return "Retinator";
					case EntityID.NPCID.SPAZMATISM:
						return "Espasmatizador";
					case EntityID.NPCID.SKELETRON_PRIME:
						return "Esqueletrón mayor";
					case EntityID.NPCID.PRIME_CANNON:
						return "Cañón mayor";
					case EntityID.NPCID.PRIME_SAW:
						return "Sierra mayor";
					case EntityID.NPCID.PRIME_VICE:
						return "Torno mayor";
					case EntityID.NPCID.PRIME_LASER:
						return "Láser mayor";
					case EntityID.NPCID.BALD_ZOMBIE:
						return "Zombi";
					case EntityID.NPCID.WANDERING_EYE:
						return "Ojo errante";
					case EntityID.NPCID.THE_DESTROYER_HEAD:
					case EntityID.NPCID.THE_DESTROYER_BODY:
					case EntityID.NPCID.THE_DESTROYER_TAIL:
						return "El Destructor";
					case EntityID.NPCID.ILLUMINANT_BAT:
						return "Murciélago luminoso";
					case EntityID.NPCID.ILLUMINANT_SLIME:
						return "Slime luminoso";
					case EntityID.NPCID.PROBE:
						return "Sonda";
					case EntityID.NPCID.POSSESSED_ARMOR:
						return "Armadura poseída";
					case EntityID.NPCID.TOXIC_SLUDGE:
						return "Fango tóxico";
					case EntityID.NPCID.SANTA_CLAUS:
						return "Papá Noel";
					case EntityID.NPCID.SNOWMAN_GANGSTA:
						return "Muñeco de nieve malote";
					case EntityID.NPCID.MISTER_STABBY:
						return "Señor Stabby";
					case EntityID.NPCID.SNOW_BALLA:
						return "Triunfador de nieve";
					case EntityID.NPCID.ALBINO_ANTLION:
						return "Hormiga león albina";
					case EntityID.NPCID.ORKA:
						return "Orca";
					case EntityID.NPCID.VAMPIRE_MINER:
						return "Minero vampiro";
					case EntityID.NPCID.SHADOW_SLIME:
						return "Slime sombrío";
					case EntityID.NPCID.SHADOW_HAMMER:
						return "Martillo sombrío";
					case EntityID.NPCID.SHADOW_MUMMY:
						return "Momia sombría";
					case EntityID.NPCID.SPECTRAL_GASTROPOD:
						return "Gasterópodo espectral";
					case EntityID.NPCID.SPECTRAL_ELEMENTAL:
						return "Elemental espectral";
					case EntityID.NPCID.SPECTRAL_MUMMY:
						return "Momia espectral";
					case EntityID.NPCID.DRAGON_SNATCHER:
						return "Raptor de dragones";
					case EntityID.NPCID.DRAGON_HORNET:
						return "Avispa dragón";
					case EntityID.NPCID.DRAGON_SKULL:
						return "Calavera de dragón";
					case EntityID.NPCID.ARCH_WYVERN_HEAD:
					case EntityID.NPCID.ARCH_WYVERN_LEGS:
					case EntityID.NPCID.ARCH_WYVERN_BODY1:
					case EntityID.NPCID.ARCH_WYVERN_BODY2:
					case EntityID.NPCID.ARCH_WYVERN_BODY3:
					case EntityID.NPCID.ARCH_WYVERN_TAIL:
						return "Archiguiverno";
					case EntityID.NPCID.ARCH_DEMON:
						return "Archidemonio";
					case EntityID.NPCID.OCRAM:
						return "Ocram";
					case EntityID.NPCID.SERVANT_OF_OCRAM:
						return "Siervo de Ocram";
#if VERSION_101
					case EntityID.NPCID.CATARACT_EYE:
					case EntityID.NPCID.SLEEPY_EYE:
					case EntityID.NPCID.DIALATED_EYE:
					case EntityID.NPCID.GREEN_EYE:
					case EntityID.NPCID.PURPLE_EYE:
						return "Ojo demoníaco";
					case EntityID.NPCID.PINCUSHION_ZOMBIE:
					case EntityID.NPCID.SLIMED_ZOMBIE:
					case EntityID.NPCID.SWAMP_ZOMBIE:
					case EntityID.NPCID.TWIGGY_ZOMBIE:
					case EntityID.NPCID.FEMALE_ZOMBIE:
					case EntityID.NPCID.ZOMBIE_MUSHROOM:
					case EntityID.NPCID.ZOMBIE_MUSHROOM_HAT:
						return "Zombi";
#endif
					default:
						return "";
				}
			}
			return null;
		}

		public static string ToolTip(int l)
		{
			if (LangOption <= (int)ID.ENGLISH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Can mine Meteorite";
					case EntityID.ItemID.TORCH:
						return "Provides light";
					case EntityID.ItemID.COPPER_WATCH:
					case EntityID.ItemID.SILVER_WATCH:
					case EntityID.ItemID.GOLD_WATCH:
						return "Tells the time";
					case EntityID.ItemID.DEPTH_METER:
						return "Shows depth";
					case EntityID.ItemID.GEL:
						return "'Both tasty and flammable'";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Permanently increases maximum life by 20";
					case EntityID.ItemID.FURNACE:
						return "Used for smelting ore";
					case EntityID.ItemID.IRON_ANVIL:
						return "Used to craft items from metal bars";
					case EntityID.ItemID.WORK_BENCH:
						return "Used for basic crafting";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Summons the Eye of Cthulhu";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Slowly regenerates life";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Gaze in the mirror to return home";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Allows the holder to double jump";
					case EntityID.ItemID.HERMES_BOOTS:
						return "The wearer can run super fast";
					case EntityID.ItemID.DEMONITE_ORE:
					case EntityID.ItemID.DEMONITE_BAR:
						return "'Pulsing with dark energy'";
					case EntityID.ItemID.VILETHORN:
						return "Summons a vile thorn";
					case EntityID.ItemID.STARFURY:
						return "Causes stars to rain from the sky";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Cleanses the corruption";
					case EntityID.ItemID.VILE_POWDER:
						return "Removes the Hallow";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "'Looks tasty!'";
					case EntityID.ItemID.WORM_FOOD:
						return "Summons the Eater of Worlds";
					case EntityID.ItemID.FALLEN_STAR:
						return "Disappears after the sunrise";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "'Get over here!'";
					case EntityID.ItemID.MINING_HELMET:
						return "Provides light when worn";
					case EntityID.ItemID.MINISHARK:
						return "33% chance to not consume ammo";
					case EntityID.ItemID.SHADOW_GREAVES:
					case EntityID.ItemID.SHADOW_SCALEMAIL:
					case EntityID.ItemID.SHADOW_HELMET:
						return "7% increased melee speed";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Able to mine Hellstone";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Permanently increases maximum mana by 20";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Increases maximum mana by 20";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Throws balls of fire";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Casts a controllable missile";
					case EntityID.ItemID.DIRT_ROD:
						return "Magically moves dirt";

#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Creates a magical orb of light";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Creates a magical shadow orb";
#endif
					case EntityID.ItemID.METEORITE_BAR:
						return "'Warm to the touch'";
					case EntityID.ItemID.HOOK:
						return "Sometimes dropped by Skeletons and Piranha";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Lights wooden arrows ablaze";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "'It's made out of fire!'";
					case EntityID.ItemID.METEOR_HELMET:
					case EntityID.ItemID.METEOR_SUIT:
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "5% increased magic damage";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Allows flight";
					case EntityID.ItemID.WATER_CANDLE:
						return "Holding this may attract unwanted attention";
					case EntityID.ItemID.BOOK:
						return "'It contains strange symbols'";
					case EntityID.ItemID.NECRO_HELMET:
					case EntityID.ItemID.NECRO_BREASTPLATE:
					case EntityID.ItemID.NECRO_GREAVES:
						return "4% increased ranged damage.";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Grants immunity to knockback";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Sprays out a shower of water";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Negates fall damage";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Increases jump height";
					case EntityID.ItemID.WATER_BOLT:
						return "Casts a slow moving bolt of water";
					case EntityID.ItemID.BOMB:
						return "A small explosion that will destroy some tiles";
					case EntityID.ItemID.DYNAMITE:
						return "A large explosion that will destroy most tiles";
					case EntityID.ItemID.GRENADE:
						return "A small explosion that will not destroy tiles";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "'Hot to the touch'";
					case EntityID.ItemID.BREATHING_REED:
						return "'Because not drowning is kinda nice'";
					case EntityID.ItemID.FLIPPER:
						return "Grants the ability to swim";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Grants immunity to fire blocks";
					case EntityID.ItemID.STAR_CANNON:
						return "Shoots fallen stars";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "'It's pretty, oh so pretty'";
					case EntityID.ItemID.FERAL_CLAWS:
						return "12% increased melee speed";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "10% increased movement speed";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Creates grass on dirt";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "'May annoy others'";
					case EntityID.ItemID.FLAMELASH:
						return "Summons a controllable ball of fire";
					case EntityID.ItemID.CLAY_POT:
						return "Grows plants";
					case EntityID.ItemID.NATURES_GIFT:
						return "6% reduced mana usage";
					case EntityID.ItemID.JUNGLE_HAT:
					case EntityID.ItemID.JUNGLE_SHIRT:
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Increases maximum mana by 20";
					case EntityID.ItemID.STICKY_BOMB:
						return "'Tossing may be difficult.'";
					case EntityID.ItemID.SUNGLASSES:
						return "'Makes you look cool!'";
					case EntityID.ItemID.WIZARD_HAT:
						return "15% increased magic damage";
					case EntityID.ItemID.GOLDFISH:
						return "'It's smiling, might be a good snack'";
					case EntityID.ItemID.SANDGUN:
						return "'This is a good idea!'";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "'You are a terrible person.'";
					case EntityID.ItemID.DIVING_HELMET:
						return "Greatly extends underwater breathing";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Casts a demon scythe";
					case EntityID.ItemID.BLOWPIPE:
						return "Allows the collection of seeds for ammo";
					case EntityID.ItemID.GLOWSTICK:
						return "Works when wet";
					case EntityID.ItemID.SEED:
						return "For use with Blowpipe";
					case EntityID.ItemID.AGLET:
						return "5% increased movement speed";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Provides immunity to lava";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Provides life regeneration";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "25% increased movement speed";
					case EntityID.ItemID.GILLS_POTION:
						return "Breathe water instead of air";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Increase defense by 8";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Increased mana regeneration";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "20% increased magic damage";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Slows falling speed";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Shows the location of treasure and ore";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Grants invisibility";
					case EntityID.ItemID.SHINE_POTION:
						return "Emits an aura of light";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Increases night vision";
					case EntityID.ItemID.BATTLE_POTION:
						return "Increases enemy spawn rate";
					case EntityID.ItemID.THORNS_POTION:
						return "Attackers also take damage";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Allows the ability to walk on water";
					case EntityID.ItemID.ARCHERY_POTION:
						return "20% increased arrow speed and damage";
					case EntityID.ItemID.HUNTER_POTION:
						return "Shows the location of enemies";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Allows the control of gravity";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "'Banned in most places'";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Opens one Gold Chest";
					case EntityID.ItemID.SHADOW_KEY:
						return "Opens all Shadow Chests";
					case EntityID.ItemID.LOOM:
						return "Used for crafting cloth";
					case EntityID.ItemID.KEG:
						return "Used for brewing ale";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Minor improvements to all stats";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Summons a Goblin Army";
					case EntityID.ItemID.SAWMILL:
						return "Used for advanced wood crafting";
					case EntityID.ItemID.PWNHAMMER:
						return "Strong enough to destroy Demon Altars";
					case EntityID.ItemID.COBALT_HAT:
						return "Increases maximum mana by 40";
					case EntityID.ItemID.COBALT_HELMET:
						return "7% increased movement speed";
					case EntityID.ItemID.COBALT_MASK:
						return "10% increased ranged damage";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Increases maximum mana by 60";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "5% increased melee critical strike chance";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "12% increased ranged damage";
					case EntityID.ItemID.COBALT_DRILL:
						return "Can mine Mythril";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Can mine Adamantite";
					case EntityID.ItemID.DAO_OF_POW:
						return "Has a chance to confuse";
					case EntityID.ItemID.COMPASS:
						return "Shows horizontal position";
					case EntityID.ItemID.DIVING_GEAR:
						return "Grants the ability to swim";
					case EntityID.ItemID.GPS:
						return "Shows position";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Negates fall damage";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Grants immunity to knockback";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Allows the combining of some accessories";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Allows the holder to double jump";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Increases maximum mana by 80";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "7% increased melee critical strike chance";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "14% increased ranged damage";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "6% increased damage";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "4% increased critical strike chance";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Allows flight";
					case EntityID.ItemID.TOOLBELT:
						return "Increases block placement range";
					case EntityID.ItemID.HOLY_WATER:
						return "Spreads the Hallow to some blocks";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Spreads the corruption to some blocks";
					case EntityID.ItemID.FAIRY_BELL:
						return "Summons a magical fairy";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Three round burst";
					case EntityID.ItemID.MOON_CHARM:
						return "Turns the holder into a werewolf on full moons";
					case EntityID.ItemID.RULER:
						return "Creates a grid on screen for block placement";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "15% increased magic damage";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "15% increased melee damage";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "15% increased ranged damage";
					case EntityID.ItemID.DEMON_WINGS:
					case EntityID.ItemID.ANGEL_WINGS:
#if VERSION_101
					case EntityID.ItemID.FABULOUS_RIBBON: // This is actually defined for the ribbon, and it is completely untrue; Only English will have this due to its erroneous nature.
					case EntityID.ItemID.SPARKLY_WINGS:
#endif
						return "Allows flight and slow fall";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Casts a controllable rainbow";
					case EntityID.ItemID.ICE_ROD:
						return "Summons a block of ice";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Transforms the holder into merfolk when entering water";
					case EntityID.ItemID.FLAMETHROWER:
						return "Uses gel for ammo";
					case EntityID.ItemID.WRENCH:
						return "Places wire";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Removes wire";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Creates several crystal shards on impact";
					case EntityID.ItemID.HOLY_ARROW:
						return "Summons falling stars on impact";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "A magical returning dagger";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Summons rapid fire crystal shards";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Summons unholy fire balls";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "'The essence of light creatures'";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "'The essence of dark creatures'";
					case EntityID.ItemID.CURSED_FLAME:
						return "'Not even water can put the flame out'";
					case EntityID.ItemID.CURSED_TORCH:
						return "Can be placed in water";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Used to smelt adamantite ore";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Used to craft items from mythril and adamantite bars";
					case EntityID.ItemID.UNICORN_HORN:
						return "'Sharp and magical!'";
					case EntityID.ItemID.DARK_SHARD:
						return "'Sometimes carried by creatures in corrupt deserts'";
					case EntityID.ItemID.LIGHT_SHARD:
						return "'Sometimes carried by creatures in light deserts'";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Activates when stepped on";
					case EntityID.ItemID.SPELL_TOME:
						return "Can be enchanted";
					case EntityID.ItemID.STAR_CLOAK:
						return "Causes stars to fall when injured";
					case EntityID.ItemID.MEGASHARK:
						return "50% chance to not consume ammo";
					case EntityID.ItemID.SHOTGUN:
						return "Fires a spread of bullets";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Reduces the cooldown of healing potions";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Increases melee knockback";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Activates when stepped on";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Summons The Twins";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "'The essence of pure terror'";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "'The essence of the destroyer'";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "'The essence of omniscient watchers'";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "7% increased critical strike chance";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "7% increased damage";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "15% increased ranged damage";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Increases length of invincibility after taking damage";
					case EntityID.ItemID.MANA_FLOWER:
						return "8% reduced mana usage";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Summons Destroyer";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Summons Skeletron Prime";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Increases maximum mana by 100";
					case EntityID.ItemID.HALLOWED_MASK:
						return "10% increased melee damage and critical strike chance";
					case EntityID.ItemID.SLIME_CROWN:
						return "Summons King Slime";
					case EntityID.ItemID.LIGHT_DISC:
						return "Stacks up to 5";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "'The essence of powerful flying creatures'";
					case EntityID.ItemID.MUSIC_BOX:
						return "Has a chance to record songs";
					case EntityID.ItemID.HAMDRAX:
						return "'Not to be confused with a hamsaw'";
					case EntityID.ItemID.EXPLOSIVES:
						return "Explodes when activated";
					case EntityID.ItemID.INLET_PUMP:
						return "Sends water to outlet pumps";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Receives water from inlet pumps";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "Activates every second";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "Activates every 3 seconds";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "Activates every 5 seconds";
					case EntityID.ItemID.BLUE_PRESENT:
					case EntityID.ItemID.GREEN_PRESENT:
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Press " + RightTrigger + " to open";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Summons the Frost Legion";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Summons a pet guinea pig";
					case EntityID.ItemID.DRAGON_MASK:
						return "15% increased melee damage and critical strike chance";
					case EntityID.ItemID.TITAN_HELMET:
						return "15% increased ranged damage, 5% chance to not consume ammo";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Increases maximum mana by 120";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "10% increased critical strike chance";
					case EntityID.ItemID.TITAN_MAIL:
						return "5% increased ranged damage, 5% chance to not consume ammo";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "5% increased magical damage, 10% reduced mana use";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "12% increased movement speed";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "10% increased movement speed and ranged damage";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "10% increased movement speed and magical damage";
					case EntityID.ItemID.TIZONA:
						return "Has a chance to cause bleeding";
					case EntityID.ItemID.TONBOGIRI:
						return "A legendary Japanese spear coated in venom";
					case EntityID.ItemID.SHARANGA:
						return "Transforms any suitable ammo into Spectral Arrows";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Transforms any suitable ammo into Vulcan Bolts";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Summons Ocram";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "'The essence of infected creatures'";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Summons a pet slime";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Summons a pet tiphia";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Summons a pet bat";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Summons a pet werewolf";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Summons a pet zombie";
#if VERSION_101
					case EntityID.ItemID.GEORGES_HAT:
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Oh myyyyy!";
					case EntityID.ItemID.CAMPFIRE:
						return "Life regen is increased when near a campfire";
#endif
				}
			}
			else if (LangOption == (int)ID.GERMAN)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Kann Meteorite abbauen";
					case EntityID.ItemID.TORCH:
						return "Verströmt Licht";
					case EntityID.ItemID.COPPER_WATCH:
						return "Zeigt die Zeit an";
					case EntityID.ItemID.SILVER_WATCH:
						return "Zeigt die Zeit an";
					case EntityID.ItemID.GOLD_WATCH:
						return "Zeigt die Zeit an";
					case EntityID.ItemID.DEPTH_METER:
						return "Zeigt die Tiefe an";
					case EntityID.ItemID.GEL:
						return "'Lecker und brennbar'";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Erhöht dauerhaft die maximale Lebensspanne um 20";
					case EntityID.ItemID.FURNACE:
						return "Wird für die Verhüttung von Erz verwendet";
					case EntityID.ItemID.IRON_ANVIL:
						return "Wird verwendet, um Items aus Metallbarren herzustellen";
					case EntityID.ItemID.WORK_BENCH:
						return "Wird zur einfachen Herstellung verwendet";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Ruft das Auge von Cthulhu herbei";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Belebt langsam wieder";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Ein Blick in den Spiegel bringt einen zurück nach Hause";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Berechtigt den Inhaber zum Doppelsprung";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Der Träger kann superschnell rennen";
					case EntityID.ItemID.DEMONITE_ORE:
						return "'Durchpulst von dunkler Energie'";
					case EntityID.ItemID.DEMONITE_BAR:
						return "'Durchpulst von dunkler Energie'";
					case EntityID.ItemID.VILETHORN:
						return "Ruft einen Ekeldorn herbei";
					case EntityID.ItemID.STARFURY:
						return "Lässt Sterne vom Himmel regnen";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Reinigt das Verderben";
					case EntityID.ItemID.VILE_POWDER:
						return "Entfernt das Heilige";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "'Sieht lecker aus!'";
					case EntityID.ItemID.WORM_FOOD:
						return "Ruft den Weltenfresser herbei";
					case EntityID.ItemID.FALLEN_STAR:
						return "Verschwindet nach Sonnenaufgang";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "'Komm hier rüber!'";
					case EntityID.ItemID.MINING_HELMET:
						return "Verströmt beim Tragen Licht";
					case EntityID.ItemID.MINISHARK:
						return "33%ige Chance, keine Munition zu verbrauchen";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Um 7% erhoehtes Nahkampftempo";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Um 7% erhoehtes Nahkampftempo";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Um 7% erhoehtes Nahkampftempo";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Kann Höllenstein abbauen";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Erhöht maximales Mana um 20";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Erhöht die maximale Mana um 20";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Schießt Feuerbälle ab";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Wirft eine steuerbare Rakete aus";
					case EntityID.ItemID.DIRT_ROD:
						return "Bewegt magisch Dreck";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Erschafft eine magische Lichtkugel";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Erschafft eine magische Schattenkugel";
#endif
					case EntityID.ItemID.METEORITE_BAR:
						return "'Fühlt sich warm an'";
					case EntityID.ItemID.HOOK:
						return "Fällt mitunter von Skeletten und Piranhas herab";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Entfacht lodernde Holzpfeile";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "'Ist ganz aus Feuer!'";
					case EntityID.ItemID.METEOR_HELMET:
						return "Um 5% erhoehter magischer Schaden";
					case EntityID.ItemID.METEOR_SUIT:
						return "Um 5% erhoehter magischer Schaden";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Um 5% erhöhter magischer Schaden";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Lässt fliegen";
					case EntityID.ItemID.WATER_CANDLE:
						return "Kann unerwünschte Aufmerksamkeit erwecken";
					case EntityID.ItemID.BOOK:
						return "'Es enthält seltsame Symbole'";
					case EntityID.ItemID.NECRO_HELMET:
						return "Um 4% erhöhter Fernkampf-Schaden";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Um 4% erhöhter Fernkampf-Schaden";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Um 4% erhöhter Fernkampf-Schaden";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Macht immun gegen Rückstoß";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Versprüht eine Wasserdusche";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Hebt Sturzschaden auf";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Vergrößert die Sprunghöhe";
					case EntityID.ItemID.WATER_BOLT:
						return "Wirft einen sich langsam bewegenden Wasserbolzen aus";
					case EntityID.ItemID.BOMB:
						return "Eine kleine Explosion, die einige Felder zerstören wird";
					case EntityID.ItemID.DYNAMITE:
						return "Eine große Explosion, die die meisten Felder zerstört";
					case EntityID.ItemID.GRENADE:
						return "Eine kleine Explosion, die keine Felder zerstört";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "'Heiß, heiß, heiß!'";
					case EntityID.ItemID.BREATHING_REED:
						return "'Ganz nett, nicht ertrinken zu müssen'";
					case EntityID.ItemID.FLIPPER:
						return "Befähigt zum Schwimmen";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Macht immun gegen Feuer-Blöcke";
					case EntityID.ItemID.STAR_CANNON:
						return "Schießt Sternschnuppen herunter";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "'Oh, ist das hübsch!'";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Um 12% erhöhtes Nahkampftempo";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Um 10% erhöhtes Bewegungstempo";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Lässt Gras auf Schmutz wachsen";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "'Kann Ärger erregen'";
					case EntityID.ItemID.FLAMELASH:
						return "Ruft einen steuerbaren Feuerball herbei";
					case EntityID.ItemID.CLAY_POT:
						return "Lässt Pflanzen wachsen";
					case EntityID.ItemID.NATURES_GIFT:
						return "Um 6% reduzierte Mana-Nutzung";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Erhoeht die maximale Mana um 20";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Erhoeht die maximale Mana um 20";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Erhöht die maximale Mana um 20";
					case EntityID.ItemID.STICKY_BOMB:
						return "'Werfen könnte schwierig werden.'";
					case EntityID.ItemID.SUNGLASSES:
						return "'Damit siehst du cool aus!'";
					case EntityID.ItemID.WIZARD_HAT:
						return "Um 15% erhöhter magischer Schaden";
					case EntityID.ItemID.GOLDFISH:
						return "'Er lächelt - vielleicht schmeckt er auch gut...'";
					case EntityID.ItemID.SANDGUN:
						return "'Das ist eine gute Idee!'";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "'Du bist ein schrecklicher Mensch.'";
					case EntityID.ItemID.DIVING_HELMET:
						return "Verleiht deutlich mehr Atemluft unter Wasser";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Wirft eine Dämonensense aus";
					case EntityID.ItemID.BLOWPIPE:
						return "Zum Erstellen einer Saatsammlung als Munition";
					case EntityID.ItemID.GLOWSTICK:
						return "Funktioniert bei Naesse";
					case EntityID.ItemID.SEED:
						return "Zur Verwendung im Blasrohr";
					case EntityID.ItemID.AGLET:
						return "Um 5% erhöhtes Bewegungstempo";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Macht immun gegen Lava";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Belebt wieder";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Erhöht Bewegungstempo um 25%";
					case EntityID.ItemID.GILLS_POTION:
						return "Wasser statt Luft atmen";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Erhöht die Abwehr um 8";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Erhöhte Mana-Wiederherstellung";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Erhöht magischen Schaden um 20%";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Verlangsamt das Sturztempo";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Zeigt den Fundort von Schätzen und Erz";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Macht unsichtbar";
					case EntityID.ItemID.SHINE_POTION:
						return "Verströmt eine Aura aus Licht";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Erhöht die Nachtsicht";
					case EntityID.ItemID.BATTLE_POTION:
						return "Erhöht Feind-Spawnquote";
					case EntityID.ItemID.THORNS_POTION:
						return "Auch die Angreifer erleiden Schaden";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Befähigt, auf dem Wasser zu gehen";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Erhöht Pfeiltempo und Schaden um 20%";
					case EntityID.ItemID.HUNTER_POTION:
						return "Zeigt die Position von Feinden";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Zur Steuerung der Schwerkraft";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "'An den meisten Orten verboten'";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Öffnet eine Goldtruhe";
					case EntityID.ItemID.SHADOW_KEY:
						return "Öffnet alle Schattentruhen";
					case EntityID.ItemID.LOOM:
						return "Verwendet für die Herstellung von Kleidung";
					case EntityID.ItemID.KEG:
						return "Zum Bierbrauen";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Geringe Anhebung aller Werte";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Ruft eine Goblin-Armee herbei";
					case EntityID.ItemID.SAWMILL:
						return "Für fortgeschrittene Holzherstellung";
					case EntityID.ItemID.PWNHAMMER:
						return "Stark genug, um Dämonenaltäre zu zerstören";
					case EntityID.ItemID.COBALT_HAT:
						return "Erhöht die maximale Mana um 40";
					case EntityID.ItemID.COBALT_HELMET:
						return "Um 7% erhöhtes Bewegungstempo";
					case EntityID.ItemID.COBALT_MASK:
						return "Um 10% erhöhter Fernkampfschaden";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Erhöht die maximale Mana um 60";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Um 5% erhöhte kritische Nahkampf-Trefferchance";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Um 12% erhöhter Fernkampf-Schaden";
					case EntityID.ItemID.COBALT_DRILL:
						return "Kann Mithril abbauen";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Kann Adamantit abbauen";
					case EntityID.ItemID.DAO_OF_POW:
						return "Kann Verwirrung stiften";
					case EntityID.ItemID.COMPASS:
						return "Zeigt horizontale Position";
					case EntityID.ItemID.DIVING_GEAR:
						return "Befähigt zum Schwimmen";
					case EntityID.ItemID.GPS:
						return "Zeigt Position an";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Hebt Sturzschaden auf";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Macht immun gegen Rückstoß";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Ermöglicht die Kombination von Zubehör";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Berechtigt den Inhaber zum Doppelsprung";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Erhöht die maximale Mana um 80";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Um 7% erhöhte kritische Nahkampf-Trefferchance";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Um 14% erhöhter Fernkampfschaden";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Um 6% erhöhter Schaden";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Um 4% erhöhte kritische Trefferchance";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Lässt fliegen";
					case EntityID.ItemID.TOOLBELT:
						return "Erweitert den Platzierbereich von Blöcken";
					case EntityID.ItemID.HOLY_WATER:
						return "Verspritzt Heil auf einige Blöcke";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Verteilt Verderben auf einige Blöcke";
					case EntityID.ItemID.FAIRY_BELL:
						return "Ruft eine magische Fee herbei";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Dreifachschuss";
					case EntityID.ItemID.MOON_CHARM:
						return "Verwandelt den Inhaber bei Vollmond in einen Werwolf";
					case EntityID.ItemID.RULER:
						return "Erstellt ein Raster auf dem Bildschirm zum Platzieren der Blöcke";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Um 15% erhöhter magischer Schaden";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Um 15% erhöhter Nahkampfschaden";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Um 15% erhöhter Fernkampfschaden";
#if VERSION_INITIAL
					case EntityID.ItemID.DEMON_WINGS:
						return "Ermoeglicht Flug und langsamen Fall";
#else
					case EntityID.ItemID.DEMON_WINGS:
#endif
					case EntityID.ItemID.ANGEL_WINGS:
#if VERSION_101
					case EntityID.ItemID.SPARKLY_WINGS:
#endif
						return "Ermöglicht Flug und langsamen Fall";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Wirft einen steuerbaren Regenbogen aus";
					case EntityID.ItemID.ICE_ROD:
						return "Ruft einen Eisblock herbei";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Verwandelt den Besitzer beim Hineingehen ins Wasser in Meermenschen";
					case EntityID.ItemID.FLAMETHROWER:
						return "Verwendet Glibber als Munition";
					case EntityID.ItemID.WRENCH:
						return "Platziert Kabel";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Entfernt Kabel";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Erzeugt beim Aufprall mehrere Kristallscherben";
					case EntityID.ItemID.HOLY_ARROW:
						return "Ruft beim Aufprall Sternschnuppen herbei";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Ein Dolch, der magisch zurückkehrt";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Ruft schnelle Feuerkristallscherben herbei";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Ruft unheilige Feuerbälle herbei";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "'Die Essenz von Lichtkreaturen'";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "'Die Essenz von Finsterkreaturen'";
					case EntityID.ItemID.CURSED_FLAME:
						return "'Nicht einmal Wasser löscht diese Flamme'";
					case EntityID.ItemID.CURSED_TORCH:
						return "Kann in Wasser platziert werden";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Zum Schmelzen von Adamantiterz";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Zur Herstellung von Items aus Mithril- und Adamantitbarren";
					case EntityID.ItemID.UNICORN_HORN:
						return "'Scharf und magisch!'";
					case EntityID.ItemID.DARK_SHARD:
						return "'Kreaturen in verderbten Wüsten tragen sie mitunter'";
					case EntityID.ItemID.LIGHT_SHARD:
						return "'Werden mitunter von Kreaturen in Lichtwüsten getragen'";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Wird beim Betreten aktiviert";
					case EntityID.ItemID.SPELL_TOME:
						return "Zum Zaubern";
					case EntityID.ItemID.STAR_CLOAK:
						return "Lässt Sterne bei Verletzung herabfallen";
					case EntityID.ItemID.MEGASHARK:
						return "50%ige Chance, keine Munition zu verbrauchen";
					case EntityID.ItemID.SHOTGUN:
						return "Feuert einen Kugelregen ab";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Verringert die Abklingzeit von Heiltränken";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Erhöht Nahkampf-Rückstoss";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Wird beim Betreten aktiviert";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Wird beim Betreten aktiviert";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Wird beim Betreten aktiviert";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Ruft die Zwillinge herbei";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "'Die Essenz reinen Schreckens'";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "'Die Essenz des Zerstörers'";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "'Die Essenz der allwissenden Beobachter'";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Um 7% erhöhte kritische Trefferchance";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Um 7% erhöhter Schaden";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Um 15% erhöhter Fernkampfschaden";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Verlängert die Unbesiegbarkeit nach erlittenem Schaden";
					case EntityID.ItemID.MANA_FLOWER:
						return "Um 8% reduzierte Mananutzung";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Ruft den Zerstörer";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Ruft Skeletron Prime herbei";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Erhöht die maximale Mana um 100";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Nahkampfschaden und kritische Trefferchance um 10% erhöht";
					case EntityID.ItemID.SLIME_CROWN:
						return "Ruft Schleimkönig herbei";
					case EntityID.ItemID.LIGHT_DISC:
						return "Kann bis zu 5 stapeln";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "'Essenz mächtiger fliegender Kreaturen'";
					case EntityID.ItemID.MUSIC_BOX:
						return "Kann Songs aufzeichnen";
					case EntityID.ItemID.HAMDRAX:
						return "'Nicht mit einer Hamsäge zu verwechseln'";
					case EntityID.ItemID.EXPLOSIVES:
						return "Explodiert bei Aktivierung";
					case EntityID.ItemID.INLET_PUMP:
						return "Sendet Wasser zu Auslasspumpen";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Empfängt Wasser von Einlasspumpen";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "Aktiviert jede Sekunde";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "Aktiviert alle 3 Sekunden";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "Aktiviert alle 5 Sekunden";
					case EntityID.ItemID.BLUE_PRESENT:
					case EntityID.ItemID.GREEN_PRESENT:
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Drücke " + RightTrigger + " zum Öffnen";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Beschwört die Frost Legion";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Ruft ein Haustier-Meerschweinchen herbei";
					case EntityID.ItemID.DRAGON_MASK:
						return "Nahkampfschaden und kritische Trefferchance um 15% erhöht";
					case EntityID.ItemID.TITAN_HELMET:
						return "Um 15% erhöhter Fernkampf-Schaden, 5%ige Chance, keine Munition zu verbrauchen";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Erhöht maximales Mana um 120";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Kritische Trefferchance um 10% erhöht";
					case EntityID.ItemID.TITAN_MAIL:
						return "Um 5% erhöhter Fernkampf-Schaden, 5%ige Chance, keine Munition zu verbrauchen";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Um 5% erhöhter Magieschaden, um 10% reduzierte Mana-Nutzung";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Um 10% erhöhtes Bewegungstempo";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Um 10% erhöhtes Bewegungstempo und Fernkampf-Schaden";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Um 10% erhöhtes Bewegungstempo und Magieschaden";
					case EntityID.ItemID.TIZONA:
						return "Kann Blutungen verursachen";
					case EntityID.ItemID.TONBOGIRI:
						return "Ein legendärer japanischer Speer, der in Gift getaucht wurde";
					case EntityID.ItemID.SHARANGA:
						return "Verwandelt jede passende Munition in Spektralpfeile";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Verwandelt jede passende Munition in Vulkanbolzen";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Ruft Ocram herbei";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "'Die Essenz von infizierten Kreaturen'";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Ruft einen Haustier-Schleim herbei";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Ruft eine Haustier-Tiphia herbei";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Ruft eine Haustier-Fledermaus herbei";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Ruft einen Haustier-Werwolf herbei";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Ruft einen Haustier-Zombie herbei";
#if VERSION_101
					case EntityID.ItemID.GEORGES_HAT:
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Ach, herrje...";
					case EntityID.ItemID.CAMPFIRE:
						return "Schnellere Wiederbelebung in der Nähe eines Lagerfeuers";
						// This erroneous translation refers to faster reviving, rather than faster healing; It does neither in v1.01.
#endif
				}
			}
			else if (LangOption == (int)ID.ITALIAN)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Può estrarre meteorite";
					case EntityID.ItemID.TORCH:
						return "Fornisce luce";
					case EntityID.ItemID.COPPER_WATCH:
						return "Indica il tempo";
					case EntityID.ItemID.SILVER_WATCH:
						return "Indica il tempo";
					case EntityID.ItemID.GOLD_WATCH:
						return "Indica il tempo";
					case EntityID.ItemID.DEPTH_METER:
						return "Mostra la profondità";
					case EntityID.ItemID.GEL:
						return "'Sia gustoso che infiammabile'";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Aumenta in maniera permanente la vita massima di 20";
					case EntityID.ItemID.FURNACE:
						return "Utilizzato per fondere i minerali";
					case EntityID.ItemID.IRON_ANVIL:
						return "Utilizzato per creare oggetti dalle barre di metallo";
					case EntityID.ItemID.WORK_BENCH:
						return "Utilizzato per la creazione di base";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Evoca l'Occhio di Cthulhu";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Rigenera la vita lentamente";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Guarda nello specchio per tornare a casa";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Permette il salto doppio";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Colui che li indossa può correre velocissimo";
					case EntityID.ItemID.DEMONITE_ORE:
						return "'Pulsa di energia oscura'";
					case EntityID.ItemID.DEMONITE_BAR:
						return "'Pulsa di energia oscura'";
					case EntityID.ItemID.VILETHORN:
						return "Evoca una spina vile";
					case EntityID.ItemID.STARFURY:
						return "Fa piovere le stelle dal cielo";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Ripulisce la corruzione";
					case EntityID.ItemID.VILE_POWDER:
						return "Rimuove il consacrato";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "'Gustoso!'";
					case EntityID.ItemID.WORM_FOOD:
						return "Evoca il Mangiatore di Mondi";
					case EntityID.ItemID.FALLEN_STAR:
						return "Sparisce dopo l'alba";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "'Vieni qui!'";
					case EntityID.ItemID.MINING_HELMET:
						return "Fa luce una volta indossato";
					case EntityID.ItemID.MINISHARK:
						return "33% di possibilità di non consumare munizioni";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Velocità del corpo a corpo aumentata del 7%";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Velocità del corpo a corpo aumentata del 7%";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Velocità del corpo a corpo aumentata del 7%";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "In grado di estrarre la pietra infernale";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Aumenta in maniera permanente il mana massimo di 20";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Aumenta il mana massimo di 20";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Tira palle di fuoco";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Scaglia un missile guidato";
					case EntityID.ItemID.DIRT_ROD:
						return "Muovi magicamente la terra";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Crea una sfera di luce magica";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Crea un'orbita d'ombra magica";
#endif
					case EntityID.ItemID.METEORITE_BAR:
						return "'Calda al tocco'";
					case EntityID.ItemID.HOOK:
						return "Lanciato a volte da Scheletri e Piranha";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Incendia le frecce di legno";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "'Creato dal fuoco!'";
					case EntityID.ItemID.METEOR_HELMET:
						return "Danno magico aumentato del 5%";
					case EntityID.ItemID.METEOR_SUIT:
						return "Danno magico aumentato del 5%";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Danno magico aumentato del 5%";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Permettono di volare";
					case EntityID.ItemID.WATER_CANDLE:
						return "Avere questo oggetto potrebbe attirare attenzione non desiderata";
					case EntityID.ItemID.BOOK:
						return "'Contiene simboli strani'";
					case EntityID.ItemID.NECRO_HELMET:
						return "Danno boomerang aumentato del 4%";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Danno boomerang aumentato del 4%";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Danno boomerang aumentato del 4%";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Permette immunità allo spintone";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Spruzza una cascata d'acqua";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Annulla i danni da caduta";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Aumenta l'altezza del salto";
					case EntityID.ItemID.WATER_BOLT:
						return "Lancia un dardo di acqua lento";
					case EntityID.ItemID.BOMB:
						return "Una piccola esplosione che distruggerà alcune mattonelle";
					case EntityID.ItemID.DYNAMITE:
						return "Una grande esplosione che distruggerà molte mattonelle";
					case EntityID.ItemID.GRENADE:
						return "Una piccola esplosione che non distruggerà mattonelle";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "'Calda al tocco'";
					case EntityID.ItemID.BREATHING_REED:
						return "'Perché non annegare è alquanto piacevole'";
					case EntityID.ItemID.FLIPPER:
						return "Abilita al nuoto";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Permette immunità ai blocchi di fuoco";
					case EntityID.ItemID.STAR_CANNON:
						return "Spara stelle cadenti";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "'Graziosa, oh com'è graziosa'";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Velocità del corpo a corpo aumentata del 12%";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Velocità di movimento aumentata del 10%";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Crea erba dalla terra";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "'Può disturbare gli altri'";
					case EntityID.ItemID.FLAMELASH:
						return "Evoca una palla di fuoco guidata";
					case EntityID.ItemID.CLAY_POT:
						return "Fa crescere le piante";
					case EntityID.ItemID.NATURES_GIFT:
						return "Consumo mana ridotto del 6%";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Aumenta il mana massimo di 20";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Aumenta il mana massimo di 20";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Aumenta il mana massimo di 20";
					case EntityID.ItemID.STICKY_BOMB:
						return "'Lanciare potrebbe essere difficile.'";
					case EntityID.ItemID.SUNGLASSES:
						return "'Migliora il tuo look!'";
					case EntityID.ItemID.WIZARD_HAT:
						return "Danno magico aumentato del 15%";
					case EntityID.ItemID.GOLDFISH:
						return "'Sta ridendo, potrebbe essere uno spuntino appetitoso'";
					case EntityID.ItemID.SANDGUN:
						return "'Buona idea!'";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "'Sei una persona terribile.'";
					case EntityID.ItemID.DIVING_HELMET:
						return "Aumenta moltissimo il respiro sott'acqua";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Evoca una falce demoniaca";
					case EntityID.ItemID.BLOWPIPE:
						return "Permette la raccolta di semi come munizioni";
					case EntityID.ItemID.GLOWSTICK:
						return "Funziona da bagnato";
					case EntityID.ItemID.SEED:
						return "Da utilizzare con la Cerbottana";
					case EntityID.ItemID.AGLET:
						return "Velocità di movimento aumentata del 5%";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Fornisce immunità alla lava";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Rigenera la vita";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Velocità di movimento aumentata del 25%";
					case EntityID.ItemID.GILLS_POTION:
						return "Respira acqua invece di aria";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Aumenta la difesa di 8";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Aumenta la rigenerazione del mana";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Danno magico aumentato del 20%";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Velocità di caduta lenta";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Mostra l'ubicazione di tesori e dei minerali";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Rende invisibili";
					case EntityID.ItemID.SHINE_POTION:
						return "Emette un'aura di luce";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Migliora la visione notturna";
					case EntityID.ItemID.BATTLE_POTION:
						return "Aumenta il ritmo di generazone dei nemici";
					case EntityID.ItemID.THORNS_POTION:
						return "Anche gli aggressori subiscono danni";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Consente di camminare sull'acqua";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Velocità e danni della freccia aumentati del 20%";
					case EntityID.ItemID.HUNTER_POTION:
						return "Mostra la posizione dei nemici";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Permette il controllo della gravità";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "'Bandita in molti luoghi'";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Apre una Cassa d'oro";
					case EntityID.ItemID.SHADOW_KEY:
						return "Apre tutte le Casse ombra";
					case EntityID.ItemID.LOOM:
						return "Utilizzato per creare abiti";
					case EntityID.ItemID.KEG:
						return "Utilizzato per produrre birra";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Migliorie minori a tutti i parametri";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Evoca un Esercito dei Goblin";
					case EntityID.ItemID.SAWMILL:
						return "Utilizzata per una lavorazione del legno avanzata";
					case EntityID.ItemID.PWNHAMMER:
						return "Abbastanza forte per distruggere gli Altari dei demoni";
					case EntityID.ItemID.COBALT_HAT:
						return "Aumenta il mana massimo di 40";
					case EntityID.ItemID.COBALT_HELMET:
						return "Velocità di movimento aumentata del 7%";
					case EntityID.ItemID.COBALT_MASK:
						return "Danno boomerang aumentato del 10%";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Aumenta il mana massimo di 60";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Possibilità di colpo critico nel corpo a corpo aumentata del 5%";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Danno boomerang aumentato del 12%";
					case EntityID.ItemID.COBALT_DRILL:
						return "Può estrarre Mitrilio";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Può estrarre Adamantio";
					case EntityID.ItemID.DAO_OF_POW:
						return "Può confondere";
					case EntityID.ItemID.COMPASS:
						return "Mostra posizione orizzontale";
					case EntityID.ItemID.DIVING_GEAR:
						return "Abilita al nuoto";
					case EntityID.ItemID.GPS:
						return "Mostra posizione";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Annulla i danni da caduta";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Permette immunità allo spintone";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Permette la combinazione di alcuni accessori";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Permette il salto doppio";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Aumenta il mana massimo di 80";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Possibilità di colpo critico nel corpo a corpo aumentata del 7%";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Danno boomerang aumentato del 14%";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Danno aumentato del 6%";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Possibilità di colpo critico aumetata del 4%";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Permettono di volare";
					case EntityID.ItemID.TOOLBELT:
						return "Aumenta la possibilità di posizionamento dei blocchi";
					case EntityID.ItemID.HOLY_WATER:
						return "Spruzza acquasanta su alcuni blocchi";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Diffonde la corruzione su alcuni blocchi";
					case EntityID.ItemID.FAIRY_BELL:
						return "Evoca una fata magica";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Tre raffiche";
					case EntityID.ItemID.MOON_CHARM:
						return "Durante la luna piena trasforma il portatore in un lupo mannaro";
					case EntityID.ItemID.RULER:
						return "Crea una griglia sullo schermo per posizionare i blocchi";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Danno magico aumentato del 15%";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Danno da mischia aumentato del 15%";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Danno boomerang aumentato del 15%";
					case EntityID.ItemID.DEMON_WINGS:
					case EntityID.ItemID.ANGEL_WINGS:
#if VERSION_101
					case EntityID.ItemID.SPARKLY_WINGS:
#endif
						return "Permettono il volo e la caduta lenta";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Genera un arcobaleno guidato";
					case EntityID.ItemID.ICE_ROD:
						return "Evoca un blocco di ghiaccio";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Trasforma il portatore in Tritone quando entra in acqua";
					case EntityID.ItemID.FLAMETHROWER:
						return "Utilizza la gelatina come munizione";
					case EntityID.ItemID.WRENCH:
						return "Posiziona i cavi";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Rimuove i cavi";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Crea svariati frammenti di cristallo all'impatto";
					case EntityID.ItemID.HOLY_ARROW:
						return "Evoca stelle cadenti all'impatto";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Un pugnale magico che ritorna";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Evoca veloci frammenti di cristallo infuocati";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Evoca sfere di fuoco profane";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "'L'essenza delle creature della luce'";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "'L'essenza delle creature oscure'";
					case EntityID.ItemID.CURSED_FLAME:
						return "'Neanche l'acqua può spegnere la fiamma'";
					case EntityID.ItemID.CURSED_TORCH:
						return "Può essere messa in acqua";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Utilizzata per fondere il minerale adamantio";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Utilizzata per creare oggetti da barre di mitrilio e adamantio";
					case EntityID.ItemID.UNICORN_HORN:
						return "'Appuntito e magico!'";
					case EntityID.ItemID.DARK_SHARD:
						return "'A volte portato dalle creature nei deserti corrotti'";
					case EntityID.ItemID.LIGHT_SHARD:
						return "'A volte portato dalle creature nei deserti di luce'";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Si attiva quando calpestata";
					case EntityID.ItemID.SPELL_TOME:
						return "Può essere incantato";
					case EntityID.ItemID.STAR_CLOAK:
						return "Causa la caduta delle stelle quando colpito";
					case EntityID.ItemID.MEGASHARK:
						return "50% di possibilità di non consumare munizioni";
					case EntityID.ItemID.SHOTGUN:
						return "Spara una rosa di proiettili";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Riduce la ricarica della pozione curativa";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Aumenta lo spintone nel corpo a corpo";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Si attiva quando calpestata";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Si attiva quando calpestata";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Si attiva quando calpestata";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Evoca i Gemelli";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "'L'essenza del terrore puro'";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "'L'essenza del distruttore'";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "'L'essenza degli osservatori onniscienti'";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Possibilità di colpo critico aumentata del 7%";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Danno aumentato del 7%";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Danno boomerang aumentato del 15%";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Aumenta la durata dell'invincibilità dopo aver subito danni";
					case EntityID.ItemID.MANA_FLOWER:
						return "Consumo mana ridotto del 8%";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Evoca il Distruttore";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Evoca lo Skeletron primario";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Aumenta il mana massimo di 100";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Possibilità di danno da mischia critico aumentate del 10%";
					case EntityID.ItemID.SLIME_CROWN:
						return "Evoca lo Slime re";
					case EntityID.ItemID.LIGHT_DISC:
						return "Raccoglie fino a 5";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "'L'essenza delle potenti creature volanti'";
					case EntityID.ItemID.MUSIC_BOX:
						return "Ha una possibilità di registrare canzoni";
					case EntityID.ItemID.HAMDRAX:
						return "'Da non confondere con il Segartello'";
					case EntityID.ItemID.EXPLOSIVES:
						return "Esplodono quando attivati";
					case EntityID.ItemID.INLET_PUMP:
						return "Invia acqua alle pompe esterne";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Riceve acqua dalle pompe interne";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "Si attiva ogni secondo";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "Si attiva ogni 3 secondi";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "Si attiva ogni 5 secondi";
					case EntityID.ItemID.BLUE_PRESENT:
					case EntityID.ItemID.GREEN_PRESENT:
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Premi " + RightTrigger + " per aprire";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Evoca la Legione gelo";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Evoca un porcellino d'India ";
					case EntityID.ItemID.DRAGON_MASK:
						return "Danno da mischia e possibilità di colpo critico aumentati del 15%";
					case EntityID.ItemID.TITAN_HELMET:
						return "Danno boomerang aumentato del 15%, 5% di possibilità di non consumare munizioni";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Aumenta il mana massimo di 120";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Possibilità di colpo critico aumentata del 10%";
					case EntityID.ItemID.TITAN_MAIL:
						return "Danno boomerang aumentato del 5%, 5% di possibilità di non consumare munizioni";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Danno magico aumentato del 5%, consumo del mana ridotto del 10%";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Velocità di movimento aumentata del 12%";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Velocità di movimento e danno boomerang aumentati del 10%";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Velocità di movimento e danno magico aumentati del 10%";
					case EntityID.ItemID.TIZONA:
						return "Ha la possibilità di provocare un sanguinamento";
					case EntityID.ItemID.TONBOGIRI:
						return "Una leggendaria lancia giapponese ricoperta di veleno";
					case EntityID.ItemID.SHARANGA:
						return "Trasforma qualsiasi munizione adatta in Frecce spettrali";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Trasforma qualsiasi munizione adatta in Balestre vulcaniche";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Evoca Ocram";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "'L'essenza delle creature contaminate'";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Evoca uno slime";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Evoca una vespa";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Evoca un pipistrello";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Evoca un lupo mannaro";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Evoca uno zombie";
#if VERSION_101
					case EntityID.ItemID.GEORGES_HAT:
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Divino!";
					case EntityID.ItemID.CAMPFIRE:
						return "La rigenerazione vita aumenta vicino a un fuoco di bivacco";
#endif
				}
			}
			else if (LangOption == (int)ID.FRENCH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Permet d'extraire la météorite";
					case EntityID.ItemID.TORCH:
						return "Procure de la lumière";
					case EntityID.ItemID.COPPER_WATCH:
						return "Donne l'heure";
					case EntityID.ItemID.SILVER_WATCH:
						return "Donne l'heure";
					case EntityID.ItemID.GOLD_WATCH:
						return "Donne l'heure";
					case EntityID.ItemID.DEPTH_METER:
						return "Indique la profondeur";
					case EntityID.ItemID.GEL:
						return "'À la fois savoureux et inflammable'";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Augmente le maximum de vie de 20 de façon permanente";
					case EntityID.ItemID.FURNACE:
						return "Utilisé pour fondre le minerai";
					case EntityID.ItemID.IRON_ANVIL:
						return "Permet de forger des objets à partir de métal";
					case EntityID.ItemID.WORK_BENCH:
						return "Utilisé pour l'artisanat de base";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Invoque l'œil de Cthulhu";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Régénère lentement la vie";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Fixer le miroir pour regagner son foyer";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Permet de faire un double saut";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Le porteur peur courir super vite";
					case EntityID.ItemID.DEMONITE_ORE:
						return "'Vibre d'une énergie sombre'";
					case EntityID.ItemID.DEMONITE_BAR:
						return "'Vibre d'une énergie sombre'";
					case EntityID.ItemID.VILETHORN:
						return "Invoque une vileronce";
					case EntityID.ItemID.STARFURY:
						return "Provoque une pluie d'étoiles";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Purifie la corruption";
					case EntityID.ItemID.VILE_POWDER:
						return "Corrompt la sainteté";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "'Ça a l'air bon !'";
					case EntityID.ItemID.WORM_FOOD:
						return "Invoque le dévoreur de mondes";
					case EntityID.ItemID.FALLEN_STAR:
						return "Disparaît au coucher du soleil";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "«\u00a0Viens ici\u00a0!\u00a0»";
					case EntityID.ItemID.MINING_HELMET:
						return "Procure de la lumière lorsqu'il est porté";
					case EntityID.ItemID.MINISHARK:
						return "33 % de chance de n'utiliser aucune munition";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Vitesse de mêlée augmentée de 7 %";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Vitesse de mêlée augmentée de 7 %";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Vitesse de mêlée augmentée de 7 %";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Permet d'extraire de la pierre de l'enfer";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Augmente le maximum de mana de 20 de façon permanente";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Augmente le maximum de mana de 20";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Lance des boules de feu";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Lance un missile contrôlable";
					case EntityID.ItemID.DIRT_ROD:
						return "Déplace la terre par magie";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Crée un orbe magique de lumière";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Crée un orbe d'ombre magique";
#endif
					case EntityID.ItemID.METEORITE_BAR:
						return "'Chaude au toucher'";
					case EntityID.ItemID.HOOK:
						return "Trouvé parfois sur les squelettes et les piranhas";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Transforme les flèches en bois tirées en flèches enflammées";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "'Elle pète le feu !'";
					case EntityID.ItemID.METEOR_HELMET:
						return "Dégâts magiques augmentés de 5\u00a0%";
					case EntityID.ItemID.METEOR_SUIT:
						return "Dégâts magiques augmentés de 5\u00a0%";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Dégâts magiques augmentés de 5\u00a0%";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Permet de voler";
					case EntityID.ItemID.WATER_CANDLE:
						return "Cet objet peut attirer une attention non désirée";
					case EntityID.ItemID.BOOK:
						return "«\u00a0Il contient d'étranges symboles\u00a0»";
					case EntityID.ItemID.NECRO_HELMET:
						return "Dégâts à distance augmentés de 4 %";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Dégâts à distance augmentés de 4 %";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Dégâts à distance augmentés de 4 %";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Annule tout effet de recul";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Lance de l'eau en continu";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Annule les dégâts de chute";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Augmente la hauteur des sauts";
					case EntityID.ItemID.WATER_BOLT:
						return "Invoque une boule d'eau se déplaçant lentement";
					case EntityID.ItemID.BOMB:
						return "Une petite explosion détruisant quelques blocs";
					case EntityID.ItemID.DYNAMITE:
						return "Une grosse explosion détruisant la plupart des blocs";
					case EntityID.ItemID.GRENADE:
						return "Une petite explosion ne détruisant pas de blocs";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "'Chaude au toucher'";
					case EntityID.ItemID.BREATHING_REED:
						return "'Ne pas se noyer, c'est quand même cool !'";
					case EntityID.ItemID.FLIPPER:
						return "Permet de nager";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Permet de résister aux blocs de feu";
					case EntityID.ItemID.STAR_CANNON:
						return "Tire des étoiles filantes";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "'Comme c'est joli !'";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Vitesse de mêlée augmentée de 12\u00a0%";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Vitesse de déplacement augmentée de 10\u00a0%";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Fait pousser de l'herbe sur la terre";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "'Peut être incommodant'";
					case EntityID.ItemID.FLAMELASH:
						return "Invoque une boule de feu contrôlable";
					case EntityID.ItemID.CLAY_POT:
						return "Fait pousser les plantes";
					case EntityID.ItemID.NATURES_GIFT:
						return "Réduit le coût de mana de 6\u00a0%";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Augmente le maximum de mana de 20";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Augmente le maximum de mana de 20";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Augmente le maximum de mana de 20";
					case EntityID.ItemID.STICKY_BOMB:
						return "'Peut s'avérer difficile à lancer'";
					case EntityID.ItemID.SUNGLASSES:
						return "'Pour un look de star !'";
					case EntityID.ItemID.WIZARD_HAT:
						return "Dégâts magiques augmentés de 15\u00a0%";
					case EntityID.ItemID.GOLDFISH:
						return "'Il sourit, ça ferait un casse-croûte sympa.'";
					case EntityID.ItemID.SANDGUN:
						return "'Super idée !'";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "'Vous êtes vraiment terrible.'";
					case EntityID.ItemID.DIVING_HELMET:
						return "Améliore grandement la respiration sous l'eau";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Lance une faux de démon";
					case EntityID.ItemID.BLOWPIPE:
						return "Permet de récupérer des graines comme munitions";
					case EntityID.ItemID.GLOWSTICK:
						return "Fonctionne même humide";
					case EntityID.ItemID.SEED:
						return "Utilisable avec la sarbacane";
					case EntityID.ItemID.AGLET:
						return "La vitesse de déplacement est augmentée de 5 %";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Procure l'immunité à la lave";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Régénère la vie";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Augmente la vitesse de déplacement de 25 %";
					case EntityID.ItemID.GILLS_POTION:
						return "Permet de respirer sous l'eau comme dans l'air";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Augmente la défense de 8";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Régénération de mana augmentée";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Dégâts magiques augmentés de 20\u00a0%";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Réduit la vitesse de chute";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Indique l'emplacement des trésors et du minerai";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Procure l'invisibilité";
					case EntityID.ItemID.SHINE_POTION:
						return "Émet une aura de lumière";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Augmente la vision nocturne";
					case EntityID.ItemID.BATTLE_POTION:
						return "Augmente la fréquence d'apparition des ennemis";
					case EntityID.ItemID.THORNS_POTION:
						return "Les attaquants subissent aussi des dégâts";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Permet de marcher sur l'eau";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Vitesse des flèches et leurs dégâts augmentés de 20\u00a0%";
					case EntityID.ItemID.HUNTER_POTION:
						return "Indique l'emplacement des ennemis";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Permet de contrôler la gravité";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "'Interdit quasiment partout'";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Ouvre un coffre d'or";
					case EntityID.ItemID.SHADOW_KEY:
						return "Ouvre tous les coffres sombres";
					case EntityID.ItemID.LOOM:
						return "Utilisé pour la fabrication de vêtements";
					case EntityID.ItemID.KEG:
						return "Utilisé pour brasser la bière.";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Amélioration mineure de toutes les stats.";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Invoque une armée de gobelins";
					case EntityID.ItemID.SAWMILL:
						return "Permet un travail avancé du bois";
					case EntityID.ItemID.PWNHAMMER:
						return "Suffisamment puissant pour détruire les autels de démon";
					case EntityID.ItemID.COBALT_HAT:
						return "Augmente le maximum de mana de 40";
					case EntityID.ItemID.COBALT_HELMET:
						return "Vitesse de déplacement augmentée de 7\u00a0%";
					case EntityID.ItemID.COBALT_MASK:
						return "Dégâts à distance augmentés de 10\u00a0%";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Augmente le maximum de mana de 60";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Chance de coup critique de mêlée augmentée de 5\u00a0%";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Dégâts à distance augmentés de 12\u00a0%";
					case EntityID.ItemID.COBALT_DRILL:
						return "Permet d'extraire du mythril";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Permet d'extraire de l'adamantine";
					case EntityID.ItemID.DAO_OF_POW:
						return "Peut étourdir les ennemis";
					case EntityID.ItemID.COMPASS:
						return "Indique la position horizontale";
					case EntityID.ItemID.DIVING_GEAR:
						return "Permet de nager";
					case EntityID.ItemID.GPS:
						return "Indique la position";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Annule les dégâts de chute";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Annule tout effet de recul";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Permet de combiner certains accessoires";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Permet de faire un double saut";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Augmente le maximum de mana de 80";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Chance de coup critique de mêlée augmentée de 7\u00a0%";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Dégâts à distance augmentés de 14\u00a0%";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Dégâts augmentés de 6\u00a0%";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Chance de coup critique augmentée de 4\u00a0%";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Permet de voler";
					case EntityID.ItemID.TOOLBELT:
						return "Permet de construire un bloc plus loin";
					case EntityID.ItemID.HOLY_WATER:
						return "Purifie certains blocs";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Corrompt certains blocs";
					case EntityID.ItemID.FAIRY_BELL:
						return "Invoque une fée magique";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Tire des rafales de trois coups";
					case EntityID.ItemID.MOON_CHARM:
						return "Transforme le porteur en loup-garou à la pleine lune";
					case EntityID.ItemID.RULER:
						return "Crée une grille à l'écran pour le placement des blocs";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Dégâts magiques augmentés de 15\u00a0%";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Dégâts de mêlée augmentés de 15\u00a0%";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Dégâts à distance augmentés de 15 %";
					case EntityID.ItemID.DEMON_WINGS:
					case EntityID.ItemID.ANGEL_WINGS:
#if VERSION_101
					case EntityID.ItemID.SPARKLY_WINGS:
#endif
						return "Permet de voler et de ralentir la chute";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Lance un arc-en-ciel contrôlable";
					case EntityID.ItemID.ICE_ROD:
						return "Invoque un bloc de glace";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Transforme le porteur en sirène lorsqu'il entre dans l'eau";
					case EntityID.ItemID.FLAMETHROWER:
						return "Utilise du gel comme carburant";
					case EntityID.ItemID.WRENCH:
						return "Joint les câbles";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Coupe les câbles";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Crée plusieurs éclats de cristal à l'impact";
					case EntityID.ItemID.HOLY_ARROW:
						return "Invoque des étoiles déchues à l'impact";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Une dague qui revient magiquement à son possesseur";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Invoque des éclats rapides de cristal de feu";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Invoque des boules de feu maudites";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "«\u00a0L'essence des créatures de lumière\u00a0»";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "«\u00a0L'essence des créatures sombres\u00a0»";
					case EntityID.ItemID.CURSED_FLAME:
						return "«\u00a0Même l'eau ne peut l'éteindre\u00a0»";
					case EntityID.ItemID.CURSED_TORCH:
						return "Peut être placée dans l'eau";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Utilisée pour fondre le minerai d'adamantine";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Utilisée pour forger des objets avec du mythril et de l'adamantite";
					case EntityID.ItemID.UNICORN_HORN:
						return "«\u00a0Magique et coupante\u00a0»";
					case EntityID.ItemID.DARK_SHARD:
						return "«\u00a0Porté parfois par les créatures dans le désert corrompu\u00a0»";
					case EntityID.ItemID.LIGHT_SHARD:
						return "«\u00a0Porté parfois par les créatures dans le désert de lumière\u00a0»";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "S'active en marchant dessus";
					case EntityID.ItemID.SPELL_TOME:
						return "Peut être enchanté";
					case EntityID.ItemID.STAR_CLOAK:
						return "Des étoiles tombent lorsque le porteur est blessé";
					case EntityID.ItemID.MEGASHARK:
						return "50 % de chance de n'utiliser aucune munition";
					case EntityID.ItemID.SHOTGUN:
						return "Disperse une salve de balles";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Réduit le temps d'utilisation entre les potions de soin";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Accroît le recul en mêlée";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "S'active en marchant dessus";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "S'active en marchant dessus";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "S'active en marchant dessus";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Invoque les Jumeaux";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "«\u00a0L'essence de la terreur pure\u00a0»";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "«\u00a0L'essence du destructeur\u00a0»";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "«\u00a0L'essence des observateurs omniscients\u00a0»";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Chance de coup critique augmentée de 7\u00a0%";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Dégâts augmentés de 7 %";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Dégâts à distance augmentés de 15 %";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Augmente la durée d'invincibilité après avoir subi des dégâts";
					case EntityID.ItemID.MANA_FLOWER:
						return "Utilisation de mana réduite de 8 %";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Invoque le destructeur";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Invoque le Skeletron Prime";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Augmente le maximum de mana de 100";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Chance de coup critique et dégâts de mêlée augmentés de 10\u00a0%";
					case EntityID.ItemID.SLIME_CROWN:
						return "Invoque le roi slime";
					case EntityID.ItemID.LIGHT_DISC:
						return "Possibilité d'en empiler jusqu'à 5";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "«\u00a0L'essence des puissantes créatures volantes\u00a0»";
					case EntityID.ItemID.MUSIC_BOX:
						return "A une chance d'enregistrer un morceau";
					case EntityID.ItemID.HAMDRAX:
						return "«\u00a0À ne pas confondre avec le marteau-scie\u00a0»";
					case EntityID.ItemID.EXPLOSIVES:
						return "Explosent lorsqu'ils sont activés";
					case EntityID.ItemID.INLET_PUMP:
						return "Envoie de l'eau aux sorties de pompage";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Reçoit de l'eau des postes de pompage";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "S'active chaque seconde";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "S'active toutes les 3 secondes";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "S'active toutes les 5 secondes";
					case EntityID.ItemID.BLUE_PRESENT:
					case EntityID.ItemID.GREEN_PRESENT:
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Appuyez sur" + RightTrigger + "pour ouvrir";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Invoque la Légion gel";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Invoque un cochon d'Inde de compagnie";
					case EntityID.ItemID.DRAGON_MASK:
						return "Dégâts de mêlée et chance de coup critique, augmentés de 15\u00a0%";
					case EntityID.ItemID.TITAN_HELMET:
						return "Dégâts à distance augmentés de 15\u00a0%, 5\u00a0% de chance de n'utiliser aucune munition";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Maximum de mana augmenté de 120";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Chance de coup critique augmentée de 10\u00a0%";
					case EntityID.ItemID.TITAN_MAIL:
						return "Dégâts à distance augmentés de 5\u00a0%, 5\u00a0% de chance de n'utiliser aucune munition";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Dégâts magiques augmentés de 5\u00a0%, utilisation du mana réduite de 10\u00a0%";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Vitesse de déplacement augmentée de 12\u00a0%";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Vitesse de déplacement et dégâts à distance augmentés de 10\u00a0%";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Vitesse de déplacement et dégâts magiques augmentés de 10\u00a0%";
					case EntityID.ItemID.TIZONA:
						return "A une chance de provoquer des saignements";
					case EntityID.ItemID.TONBOGIRI:
						return "Une lance japonaise légendaire couverte de venin";
					case EntityID.ItemID.SHARANGA:
						return "Transforme toute munition appropriée en flèches spectrales";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Transforme toute munition appropriée en traits de Vulcain";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Invoque Ocram";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "L'essence de créatures infectes";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Invoque un slime de compagnie";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Invoque un tiphia de compagnie";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Invoque une chauve-souris de compagnie";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Invoque un loup-garou de compagnie";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Invoque un zombie de compagnie";
#if VERSION_101
					case EntityID.ItemID.GEORGES_HAT:
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Ouh la la"; // Wait, really?
					case EntityID.ItemID.CAMPFIRE:
						return "La régénération augmente à proximité des feux de camp";
#endif
				}
			}
			else if (LangOption == (int)ID.SPANISH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Permite excavar meteoritos";
					case EntityID.ItemID.TORCH:
						return "Da luz";
					case EntityID.ItemID.COPPER_WATCH:
						return "Da la hora";
					case EntityID.ItemID.SILVER_WATCH:
						return "Da la hora";
					case EntityID.ItemID.GOLD_WATCH:
						return "Da la hora";
					case EntityID.ItemID.DEPTH_METER:
						return "Indica la profundidad";
					case EntityID.ItemID.GEL:
						return "Sabroso a la par que inflamable";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Aumenta el nivel máximo de vida en 20 de forma permanente";
					case EntityID.ItemID.FURNACE:
						return "Se usa para fundir mineral";
					case EntityID.ItemID.IRON_ANVIL:
						return "Se usa para fabricar objetos con lingotes de metal";
					case EntityID.ItemID.WORK_BENCH:
						return "Se usa para creaciones básicas";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Invoca al Ojo de Cthulhu";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Regenera la vida poco a poco";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Al mirarte en él regresarás a tu hogar";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Su portador puede realizar dobles saltos";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Permite correr superrápido";
					case EntityID.ItemID.DEMONITE_ORE:
						return "La energía oscura fluye en su interior";
					case EntityID.ItemID.DEMONITE_BAR:
						return "La energía oscura fluye en su interior";
					case EntityID.ItemID.VILETHORN:
						return "Lanza una espina vil";
					case EntityID.ItemID.STARFURY:
						return "Hace que lluevan estrellas del cielo";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Limpia la corrupción";
					case EntityID.ItemID.VILE_POWDER:
						return "Devuelve el territorio sagrado a la normalidad";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "¡Qué delicia!";
					case EntityID.ItemID.WORM_FOOD:
						return "Invoca al Devoramundos";
					case EntityID.ItemID.FALLEN_STAR:
						return "Desaparece al amanecer";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "'¡Te atrapé!'";
					case EntityID.ItemID.MINING_HELMET:
						return "Da luz a su portador";
					case EntityID.ItemID.MINISHARK:
						return "Probabilidad del 33% de no gastar munición";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Aumenta un 7% la velocidad de los ataques cuerpo a cuerpo";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Aumenta un 7% la velocidad de los ataques cuerpo a cuerpo";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Aumenta un 7% la velocidad de los ataques cuerpo a cuerpo";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Permite excavar la piedra infernal";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Aumenta el maná máximo en 20 de forma permanente";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Aumenta el maná máximo en 20";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Arroja bolas de fuego";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Lanza un proyectil dirigido";
					case EntityID.ItemID.DIRT_ROD:
						return "Desplaza la tierra por arte de magia";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Crea un orbe mágico de luz";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Crea un orbe sombrío mágico";
#endif
					case EntityID.ItemID.METEORITE_BAR:
						return "Caliente al tacto";
					case EntityID.ItemID.HOOK:
						return "A veces lo sueltan esqueletos y pirañas";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Enciende las flechas de madera";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "'¡Hecha de fuego!'";
					case EntityID.ItemID.METEOR_HELMET:
						return "Aumenta el daño de los ataques mágicos en un 5%";
					case EntityID.ItemID.METEOR_SUIT:
						return "Aumenta el daño de los ataques mágicos en un 5%";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Aumenta el daño de los ataques mágicos en un 5%";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Permite volar";
					case EntityID.ItemID.WATER_CANDLE:
						return "Su portador llamará la atención de los indeseables";
					case EntityID.ItemID.BOOK:
						return "'Contiene extraños símbolos'";
					case EntityID.ItemID.NECRO_HELMET:
						return "Aumenta el daño de los ataques a distancia en un 4%";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Aumenta el daño de los ataques a distancia en un 4%";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Aumenta el daño de los ataques a distancia en un 4%";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Anula el retroceso";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Lanza un chorro de agua";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Anula el daño al caer";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Aumenta la altura de los saltos";
					case EntityID.ItemID.WATER_BOLT:
						return "Lanza un proyectil de agua a baja velocidad";
					case EntityID.ItemID.BOMB:
						return "Pequeña explosión capaz de romper varios ladrillos";
					case EntityID.ItemID.DYNAMITE:
						return "Gran explosión capaz de romper casi todos los ladrillos";
					case EntityID.ItemID.GRENADE:
						return "Pequeña explosión que no rompe ningún ladrillo";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "Caliente al tacto";
					case EntityID.ItemID.BREATHING_REED:
						return "'Está bien eso de no ahogarse'";
					case EntityID.ItemID.FLIPPER:
						return "Permite nadar";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Ofrece inmunidad ante los bloques de fuego";
					case EntityID.ItemID.STAR_CANNON:
						return "Dispara estrellas fugaces";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "'Hermosa, muy hermosa'";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Aumenta un 12% la velocidad en el cuerpo a cuerpo";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Aumenta en un 10% la velocidad de movimiento";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Genera césped sobre la tierra";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "'Una molestia para los demás'";
					case EntityID.ItemID.FLAMELASH:
						return "Lanza una bola de fuego dirigida";
					case EntityID.ItemID.CLAY_POT:
						return "Cultiva plantas";
					case EntityID.ItemID.NATURES_GIFT:
						return "Reduce el uso de maná en un 6%";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Aumenta el maná máximo en 20";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Aumenta el maná máximo en 20";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Aumenta el maná máximo en 20";
					case EntityID.ItemID.STICKY_BOMB:
						return "'Puede costar lanzarla'";
					case EntityID.ItemID.SUNGLASSES:
						return "'¡Te quedan muy bien!'";
					case EntityID.ItemID.WIZARD_HAT:
						return "Aumenta el daño de los ataques mágicos en un 15%";
					case EntityID.ItemID.GOLDFISH:
						return "Sonríe y además es un buen aperitivo";
					case EntityID.ItemID.SANDGUN:
						return "'¡Una buena idea!'";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "'Eres mala persona'";
					case EntityID.ItemID.DIVING_HELMET:
						return "Permite respirar bajo el agua mucho más tiempo";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Lanza una guadaña demoníaca";
					case EntityID.ItemID.BLOWPIPE:
						return "Permite recoger semillas como munición";
					case EntityID.ItemID.GLOWSTICK:
						return "Funciona con humedad";
					case EntityID.ItemID.SEED:
						return "Para la cerbatana";
					case EntityID.ItemID.AGLET:
						return "Aumenta en un 5% la velocidad de movimiento";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Ofrece inmunidad ante la lava";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Regenera la vida";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Aumenta en un 25% la velocidad de movimiento";
					case EntityID.ItemID.GILLS_POTION:
						return "Permite respirar agua en lugar de aire";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Aumenta la defensa en 8";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Aumenta la regeneración de maná";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Aumenta el daño de los ataques mágicos en un 20%";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Disminuye la velocidad de caída";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Muestra la ubicación de tesoros y minerales";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Proporciona invisibilidad";
					case EntityID.ItemID.SHINE_POTION:
						return "Emite un aura de luz";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Mejora la visión nocturna";
					case EntityID.ItemID.BATTLE_POTION:
						return "Aumenta la velocidad de regeneración del enemigo";
					case EntityID.ItemID.THORNS_POTION:
						return "Los atacantes también sufren daños";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Permite caminar sobre el agua";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Aumenta en un 20% la velocidad de las flechas y el daño que causan";
					case EntityID.ItemID.HUNTER_POTION:
						return "Muestra la ubicación de los enemigos";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Permite controlar la gravedad";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "'Prohibidos en casi todas partes'";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Abre un cofre de oro";
					case EntityID.ItemID.SHADOW_KEY:
						return "Abre todos los cofres de las sombras";
					case EntityID.ItemID.LOOM:
						return "Se usa para confeccionar ropa";
					case EntityID.ItemID.KEG:
						return "Se usa para elaborar cerveza";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Proporciona pequeñas mejoras a todas las estadísticas";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Invoca a un ejército de duendes";
					case EntityID.ItemID.SAWMILL:
						return "Se usa para fabricar artículos de madera avanzados";
					case EntityID.ItemID.PWNHAMMER:
						return "Lo bastante sólido para destruir los altares demoníacos";
					case EntityID.ItemID.COBALT_HAT:
						return "Aumenta el maná máximo en 40";
					case EntityID.ItemID.COBALT_HELMET:
						return "Aumenta en un 7% la velocidad de movimiento";
					case EntityID.ItemID.COBALT_MASK:
						return "Aumenta el daño de los ataques a distancia en un 10%";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Aumenta el maná máximo en 60";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Aumenta un 5% la probabilidad de ataque crítico en el cuerpo a cuerpo";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Aumenta el daño de los ataques a distancia en un 12%";
					case EntityID.ItemID.COBALT_DRILL:
						return "Permite extraer mithril";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Permite extraer adamantita";
					case EntityID.ItemID.DAO_OF_POW:
						return "Puede llegar a confundir";
					case EntityID.ItemID.COMPASS:
						return "Indica el horizonte";
					case EntityID.ItemID.DIVING_GEAR:
						return "Permite nadar";
					case EntityID.ItemID.GPS:
						return "Indica la posición";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Anula el daño al caer";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Anula el retroceso";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Permite combinar varios accesorios";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Su portador puede realizar dobles saltos";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Aumenta el maná máximo en 80";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Aumenta un 7% la probabilidad de ataque crítico en el cuerpo a cuerpo";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Aumenta el daño de los ataques a distancia en un 14%";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Aumenta el daño de los ataques en un 6%";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Aumenta la probabilidad de conseguir ataques críticos en un 4%";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Permite volar";
					case EntityID.ItemID.TOOLBELT:
						return "Aumenta la distancia de colocación de bloques";
					case EntityID.ItemID.HOLY_WATER:
						return "Convierte los bloques cercanos en bloques sagrados";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Extiende la corrupción a algunos bloques";
					case EntityID.ItemID.FAIRY_BELL:
						return "Invoca a una hada mágica";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Dispara tres ráfagas";
					case EntityID.ItemID.MOON_CHARM:
						return "Convierte a su portador en hombre lobo durante la luna llena";
					case EntityID.ItemID.RULER:
						return "Dibuja una rejilla en pantalla para colocar los bloques";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Aumenta el daño de los ataques mágicos en un 15%";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Aumenta el daño de los ataques cuerpo a cuerpo en un 15%";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Aumenta el daño de los ataques a distancia en un 15%";
					case EntityID.ItemID.DEMON_WINGS:
					case EntityID.ItemID.ANGEL_WINGS:
#if VERSION_101
					case EntityID.ItemID.SPARKLY_WINGS:
#endif
						return "Permite volar y caer lentamente";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Lanza un arco iris dirigido";
					case EntityID.ItemID.ICE_ROD:
						return "Invoca un bloque de hielo";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Transforma a su portador en un tritón al sumergirse en el agua";
					case EntityID.ItemID.FLAMETHROWER:
						return "Utiliza gel como munición";
					case EntityID.ItemID.WRENCH:
						return "Permite colocar alambre";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Permite cortar alambre";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Crea varios fragmentos de cristal al impactar";
					case EntityID.ItemID.HOLY_ARROW:
						return "Invoca estrellas fugaces al impactar";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Una daga mágica que vuelve al arrojarse";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Lanza fragmentos de cristal a toda velocidad";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Lanza bolas de fuego impuras";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "La esencia de las criaturas de la luz";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "La esencia de las criaturas de la oscuridad";
					case EntityID.ItemID.CURSED_FLAME:
						return "Ni siquiera el agua puede apagarla";
					case EntityID.ItemID.CURSED_TORCH:
						return "Se puede meter en el agua";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Se usa para fundir mineral de adamantita";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Se usa para fabricar objetos con lingotes de mithril y adamantita";
					case EntityID.ItemID.UNICORN_HORN:
						return "'¡Puntiagudo y mágico!'";
					case EntityID.ItemID.DARK_SHARD:
						return "A veces lo llevan las criaturas de los desiertos corrompidos";
					case EntityID.ItemID.LIGHT_SHARD:
						return "A veces lo llevan las criaturas de los desiertos de luz";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Se activa al pisarla";
					case EntityID.ItemID.SPELL_TOME:
						return "Se puede hechizar";
					case EntityID.ItemID.STAR_CLOAK:
						return "Hace que las estrellas caigan al recibir heridas";
					case EntityID.ItemID.MEGASHARK:
						return "Probabilidad del 50% de no gastar munición";
					case EntityID.ItemID.SHOTGUN:
						return "Dispara una ráfaga dispersa de balas";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Reduce el tiempo de espera para usar pociones curativas";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Aumenta el retroceso en el cuerpo a cuerpo";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Se activa al pisarla";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Se activa al pisarla";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Se activa al pisarla";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Invoca a los Gemelos";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "La esencia del terror en estado puro";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "La esencia del Destructor";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "La esencia de los observadores omniscientes";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Aumenta la probabilidad de conseguir ataques críticos en un 7%";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Aumenta el daño de los ataques en un 7%";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Aumenta el daño a de los ataques a distancia en un 15%";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Aumenta el tiempo de invencibilidad tras recibir daños";
					case EntityID.ItemID.MANA_FLOWER:
						return "Reduce el uso de maná en un 8%";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Invoca al Destructor";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Invoca al Esqueletrón mayor";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Aumenta el maná máximo en 100";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Aumenta en un 10% el daño de los ataques cuerpo a cuerpo y la posibilidad de causar ataques críticos";
					case EntityID.ItemID.SLIME_CROWN:
						return "Invoca al rey slime";
					case EntityID.ItemID.LIGHT_DISC:
						return "No apilar más de 5";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "La esencia de poderosas criaturas que vuelan";
					case EntityID.ItemID.MUSIC_BOX:
						return "Permite grabar canciones";
					case EntityID.ItemID.HAMDRAX:
						return "No confundir con un cuchillo jamonero";
					case EntityID.ItemID.EXPLOSIVES:
						return "Explota al activarse";
					case EntityID.ItemID.INLET_PUMP:
						return "Envía agua a los colectores de salida";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Recibe agua de los colectores de entrada";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "Se activa cada segundo";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "Se activa cada 3 segundos";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "Se activa cada 5 segundos";
					case EntityID.ItemID.BLUE_PRESENT:
					case EntityID.ItemID.GREEN_PRESENT:
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Pulsa " + RightTrigger + " para abrir";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Convoca a la Legión del hielo";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Invoca a un conejillo de Indias de mascota";
					case EntityID.ItemID.DRAGON_MASK:
						return "15% de aumento en daño por ataque en grupo y posibilidad de ataque mortal";
					case EntityID.ItemID.TITAN_HELMET:
						return "15% de aumento de daño a distancia, 5% de posibilidad de no gastar munición";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Aumenta el maná máximo en 120";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "10% de aumento en posibilidad de ataque mortal";
					case EntityID.ItemID.TITAN_MAIL:
						return "5% de aumento de daño a distancia, 5% de posibilidad de no gastar munición";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "5% de aumento en daño por magia, 10% de reducción en uso de maná";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "12% de aumento en la velocidad de movimiento";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "10% de aumento en la velocidad de movimiento y el daño a distancia";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "10% de aumento en la velocidad de movimiento y el daño por magia";
					case EntityID.ItemID.TIZONA:
						return "Tiene la posibilidad de causar hemorragia";
					case EntityID.ItemID.TONBOGIRI:
						return "Una legendaria lanza japonesa empapada de veneno";
					case EntityID.ItemID.SHARANGA:
						return "Transforma cualquier munición adecuada en flechas espectrales";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Transforma cualquier munición adecuada en relámpagos volcánicos";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Invoca a Ocram";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "'La esencia de las criaturas infectadas'";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Invoca a un slime mascota";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Invoca a una avispa mascota";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Invoca a un murciélago mascota";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Invoca a un hombre lobo mascota";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Invoca a un zombi mascota";
#if VERSION_101
					case EntityID.ItemID.GEORGES_HAT:
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "La repera";
					case EntityID.ItemID.CAMPFIRE:
						return "La regeneración de vida es mayor junto a una hoguera";
#endif
				}
			}
			return null;
		}

		public static string ToolTip2(int l)
		{
			if (LangOption <= (int)ID.ENGLISH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.STARFURY:
						return "'Forged with the fury of heaven'";
					case EntityID.ItemID.MINISHARK:
						return "'Half shark, half gun, completely awesome.'";
					case EntityID.ItemID.JUNGLE_HAT:
						return "3% increased magic critical strike chance";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "3% increased magic critical strike chance";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "3% increased magic critical strike chance";
					case EntityID.ItemID.COBALT_HAT:
						return "9% increased magic critical strike chance";
					case EntityID.ItemID.COBALT_HELMET:
						return "12% increased melee speed";
					case EntityID.ItemID.COBALT_MASK:
						return "6% increased ranged critical strike chance";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "3% increased critical strike chance";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "10% increased movement speed";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "15% increased magic damage";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "10% increased melee damage";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "7% increased ranged critical strike chance";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "5% increased damage";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "3% increased critical strike chance";
					case EntityID.ItemID.DAO_OF_POW:
						return "'Find your inner pieces'";
					case EntityID.ItemID.DIVING_GEAR:
						return "Greatly extends underwater breathing";
					case EntityID.ItemID.GPS:
						return "Tells the time";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Grants immunity to fire blocks";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Grants immunity to fire blocks";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Increases jump height";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "11% increased magic damage and critical strike chance";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "14% increased melee damage";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "8% increased ranged critical strike chance";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "5% increased movement speed";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "The wearer can run super fast";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Only the first shot consumes ammo";
					case EntityID.ItemID.MEGASHARK:
						return "'Minishark's older brother'";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "8% increased movement speed";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "8% increased ranged critical strike chance";
					case EntityID.ItemID.MANA_FLOWER:
						return "Automatically use mana potions when needed";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "12% increased magic damage and critical strike chance";
					case EntityID.ItemID.HALLOWED_MASK:
						return "10% increased melee speed";
					case EntityID.ItemID.DRAGON_MASK:
						return "15% increased critical strike chance";
					case EntityID.ItemID.TITAN_HELMET:
						return "10% increased ranged critical strike chance";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "15% increased magic damage and critical strike chance";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "5% increased melee damage";
					case EntityID.ItemID.TITAN_MAIL:
						return "10% increased ranged critical strike chance";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "10% increased magic critical strike chance";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "2% increased melee speed";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "10% chance to not consume ammo";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Increases maximum mana by 30";
				}
			}
			else if (LangOption == (int)ID.GERMAN)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.STARFURY:
						return "'Geschmiedet mit Himmelswut'";
					case EntityID.ItemID.MINISHARK:
						return "'Halb Hai, halb Pistole - einfach toll!'";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Um 3% erhöhte kritische Magietrefferchance";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Um 3% erhöhte kritische Magietrefferchance";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Um 3% erhöhte kritische Magietrefferchance";
					case EntityID.ItemID.COBALT_HAT:
						return "Um 9% erhöhte kritische Magietrefferchance";
					case EntityID.ItemID.COBALT_HELMET:
						return "Um 12% erhöhtes Nahkampftempo";
					case EntityID.ItemID.COBALT_MASK:
						return "Um 6% erhöhte kritische Fernkampf-Trefferchance";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Um 3% erhöhte kritische Trefferchance";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Um 10% erhöhtes Bewegungstempo";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Um 15% erhöhter magischer Schaden";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Um 10% erhöhter Nahkampfschaden";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Um 7% erhöhte kritische Fernkampf-Trefferchance";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Um 5% erhöhter Schaden";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Um 3% erhöhte kritische Trefferchance";
					case EntityID.ItemID.DAO_OF_POW:
						return "'Sammle dich!'";
					case EntityID.ItemID.DIVING_GEAR:
						return "Verleiht deutlich mehr Atemluft unter Wasser";
					case EntityID.ItemID.GPS:
						return "Zeigt die Zeit an";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Macht immun gegen Feuer-Blöcke";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Macht immun gegen Feuer-Blöcke";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Vergrössert die Sprunghöhe";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Magischer Schaden und kritische Trefferchance um 11% erhöht";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Um 14% erhöhter Nahkampfschaden";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Um 8% erhöhte kritische Fernkampf-Trefferchance";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Um 5% erhöhtes Bewegungstempo";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Der Träger kann superschnell rennen";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Nur der erste Schuss verbraucht Munition ";
					case EntityID.ItemID.MEGASHARK:
						return "'Minihais großer Bruder'";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Um 8% erhöhtes Bewegungstempo";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Um 8% erhöhte kritische Fernkampf-Trefferchance";
					case EntityID.ItemID.MANA_FLOWER:
						return "Bei Bedarf automatisch Manatränke verwenden";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Magischer Schaden und kritische Trefferchance um 12% erhöht";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Um 10% erhöhtes Nahkampftempo";
					case EntityID.ItemID.DRAGON_MASK:
						return "Kritische Trefferchance um 15% erhöht";
					case EntityID.ItemID.TITAN_HELMET:
						return "Um 10% erhöhte kritische Fernkampf-Trefferchance";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Magieschaden und kritische Trefferchance um 15% erhöht";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Um 5% erhöhter Nahkampfschaden";
					case EntityID.ItemID.TITAN_MAIL:
						return "Um 10% erhöhte kritische Fernkampf-Trefferchance";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "10% erhöhte Chance auf kritischen Magietreffer";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Um 2% erhöhtes Nahkampftempo";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "10%ige Chance, keine Munition zu verbrauchen";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Erhöht maximales Mana um 30";
				}
			}
			else if (LangOption == (int)ID.ITALIAN)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.STARFURY:
						return "'Forgiato con la furia del cielo'";
					case EntityID.ItemID.MINISHARK:
						return "'Mezzo squalo, mezza arma, assolutamente terrificante.'";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Aumenta la possibilità di colpo critico magico del 3%";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Aumenta la possibilità di colpo critico magico del 3%";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Aumenta la possibilità di colpo critico magico del 3%";
					case EntityID.ItemID.COBALT_HAT:
						return "Possibilità colpo critico magico aumentate del 9%";
					case EntityID.ItemID.COBALT_HELMET:
						return "Velocità del corpo a corpo aumentata del 12%";
					case EntityID.ItemID.COBALT_MASK:
						return "Possibilità di colpo critico magico aumentata del 6%";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Possibilità di colpo critico aumentata del 3%";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Velocità di movimento aumentata del 10%";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Danno magico aumentato del 15%";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Danno da mischia aumentato del 10%";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Possibilità di colpo critico a distanza aumentata del 7%";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Danno aumentato del 5%";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Possibilità di colpo critico aumentata del 3%";
					case EntityID.ItemID.DAO_OF_POW:
						return "'Trova i pezzi interni'";
					case EntityID.ItemID.DIVING_GEAR:
						return "Aumenta moltissimo il respiro sott'acqua";
					case EntityID.ItemID.GPS:
						return "Indica il tempo";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Permette immunità ai blocchi di fuoco";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Permette immunità ai blocchi di fuoco";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Aumenta l'altezza del salto";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Possibilità di colpo critico e danno magico aumentate del 11%";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Danno da mischia aumentato del 14%";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Possibilità di colpo critico a distanza aumentata dell'8%";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Velocità di movimento aumentata del 5%";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Colui che li indossa può correre velocissimo";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Solo il primo colpo consuma munizioni";
					case EntityID.ItemID.MEGASHARK:
						return "'Fratello maggiore del Minishark'";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Velocità di movimento aumentata del 8%";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Possibilità di colpo critico a distanza aumentata dell'8%";
					case EntityID.ItemID.MANA_FLOWER:
						return "Utilizza le pozioni mana automaticamente in caso di bisogno";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Possibilità di danno magico e colpo critico aumentate del 12%";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Velocità del corpo a corpo aumentata del 10%";
					case EntityID.ItemID.DRAGON_MASK:
						return "Possibilità di colpo critico aumentata del 15%";
					case EntityID.ItemID.TITAN_HELMET:
						return "Possibilità di colpo critico boomerang aumentata del 10%";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Possibilità di colpo critico e del danno magico aumentati del 15%";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Danno da mischia aumentato del 5%";
					case EntityID.ItemID.TITAN_MAIL:
						return "Possibilità di colpo critico boomerang aumentata del 10%";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Possibilità di colpo critico magico aumentata del 10%";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Velocità del corpo a corpo aumentata del 2%";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "10% di possibilità di non consumare munizioni";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Aumenta il mana massimo di 30";
				}
			}
			else if (LangOption == (int)ID.FRENCH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.STARFURY:
						return "'Forgée dans la furie du ciel'";
					case EntityID.ItemID.MINISHARK:
						return "'Moitié requin, moitié fusil, c'est de la balle !'";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Chance de coup critique magique augmentée de 3\u00a0%";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Chance de coup critique magique augmentée de 3\u00a0%";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Chance de coup critique magique augmentée de 3\u00a0%";
					case EntityID.ItemID.COBALT_HAT:
						return "Chance de coup critique magique augmentée de 9\u00a0%";
					case EntityID.ItemID.COBALT_HELMET:
						return "Vitesse de mêlée augmentée de 12\u00a0%";
					case EntityID.ItemID.COBALT_MASK:
						return "Chance de coup critique à distance augmentée de 6\u00a0%";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Chance de coup critique augmentée de 3\u00a0%";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Vitesse de déplacement augmentée de 10\u00a0%";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Dégâts magiques augmentés de 15\u00a0%";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Dégâts de mêlée  augmentés de 10\u00a0%";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Chance de coup critique à distance augmentée de 7\u00a0%";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Dégâts augmentés de 5\u00a0%";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Chance de coup critique augmentée de 3\u00a0%";
					case EntityID.ItemID.DAO_OF_POW:
						return "«\u00a0Pour trouver la paix intérieure\u00a0»";
					case EntityID.ItemID.DIVING_GEAR:
						return "Améliore grandement la respiration sous l'eau";
					case EntityID.ItemID.GPS:
						return "Donne l'heure";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Permet de résister aux blocs de feu";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Permet de résister aux blocs de feu";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Augmente la hauteur des sauts";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Dégâts magiques et chance de coup critique augmentés de 11\u00a0%";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Dégâts de mêlée augmentés de 14\u00a0%";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Chance de coup critique à distance augmentée de 8\u00a0%";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Vitesse de déplacement augmentée de 5\u00a0%";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Le porteur peur courir super vite";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Seul le premier tir utilise des munitions";
					case EntityID.ItemID.MEGASHARK:
						return "'La version améliorée du minishark'";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Vitesse de mouvement augmentée de 8 %";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Chance de coup critique à distance augmentée de 8\u00a0%";
					case EntityID.ItemID.MANA_FLOWER:
						return "Utilise des potions de mana automatiquement si besoin";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Chance de coup critique et dégâts magiques augmentés de 12\u00a0%";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Vitesse de mêlée augmentée de 10 %";
					case EntityID.ItemID.DRAGON_MASK:
						return "Chance de coup critique augmentée de 15\u00a0%";
					case EntityID.ItemID.TITAN_HELMET:
						return "Chance de coup critique à distance augmentée de 10\u00a0%";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Dégâts magiques et chance de coup critique augmentés de 15\u00a0%";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Dégâts de mêlée augmentés de 5\u00a0%";
					case EntityID.ItemID.TITAN_MAIL:
						return "Chance de coup critique à distance augmentée de 10\u00a0%";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Chance de coup critique magique augmentée de 10\u00a0%";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Vitesse de mêlée augmentée de 2\u00a0%";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "10\u00a0% de chance de n'utiliser aucune munition";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Maximum de mana augmenté de 30";
				}
			}
			else if (LangOption == (int)ID.SPANISH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.STARFURY:
						return "'Forjada por la furia del cielo'";
					case EntityID.ItemID.MINISHARK:
						return "'Mitad tiburón, mitad arma; realmente asombroso'";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Aumenta la probabilidad de ataque mágico crítico en un 3%";
					case EntityID.ItemID.COBALT_HAT:
						return "Aumenta la probabilidad de ataque mágico crítico en un 9%";
					case EntityID.ItemID.COBALT_HELMET:
						return "Aumenta un 12% la velocidad de los ataques cuerpo a cuerpo";
					case EntityID.ItemID.COBALT_MASK:
						return "Aumenta la probabilidad de ataque a distancia crítico en un 6%";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Aumenta la probabilidad de conseguir ataques críticos en un 3%";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Aumenta en un 10% la velocidad de movimiento";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Aumenta el daño de los ataques mágicos en un 15%";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Aumenta el daño de los ataques cuerpo a cuerpo en un 10%";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Aumenta la probabilidad de ataque a distancia crítico en un 7%";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Aumenta el daño en un 5%";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Aumenta la probabilidad de conseguir ataques críticos en un 3%";
					case EntityID.ItemID.DAO_OF_POW:
						return "Busca en tu interior";
					case EntityID.ItemID.DIVING_GEAR:
						return "Permite respirar bajo el agua mucho más tiempo";
					case EntityID.ItemID.GPS:
						return "Da la hora";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Ofrece inmunidad ante los bloques de fuego";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Ofrece inmunidad ante los bloques de fuego";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Aumenta la altura de los saltos";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Aumenta en un 11% el daño de los ataques mágicos y la posibilidad de causar ataques críticos";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Aumenta el daño de los ataques cuerpo a cuerpo en un 14%";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Aumenta la probabilidad de ataque a distancia crítico en un 8%";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Aumenta en un 5% la velocidad de movimiento";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Permite correr superrápido";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Solo gasta munición el primer disparo";
					case EntityID.ItemID.MEGASHARK:
						return "'El hermano mayor del minitiburón'";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Aumenta en un 8% la velocidad de movimiento";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Aumenta la probabilidad de ataque a distancia crítico en un 8%";
					case EntityID.ItemID.MANA_FLOWER:
						return "Usa de forma automática pociones de maná cuando se necesitan";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Aumenta en un 12% el daño de los ataques mágicos y la posibilidad de causar ataques críticos";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Aumenta en un 10% la velocidad de los ataques cuerpo a cuerpo";
					case EntityID.ItemID.DRAGON_MASK:
						return "15% de aumento en posibilidad de ataque mortal";
					case EntityID.ItemID.TITAN_HELMET:
						return "10% de aumento en posibilidad de ataque mortal a distancia";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "15% de aumento en daño por magia y posibilidad de ataque mortal";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "5% de aumento en daño por ataque en grupo";
					case EntityID.ItemID.TITAN_MAIL:
						return "10% de aumento en posibilidad de ataque mortal a distancia";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "10% de aumento en posibilidad de ataque mágico mortal";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "2% de aumento en la velocidad de ataque en grupo";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "10% de posibilidad de no gastar munición";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Aumenta el maná máximo en 30";
				}
			}
			return null;
		}

		public static string ItemName(int l)
		{
			if (LangOption <= (int)ID.ENGLISH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Gold Pickaxe";
					case EntityID.ItemID.GOLD_BROADSWORD:
						return "Gold Broadsword";
					case EntityID.ItemID.GOLD_SHORTSWORD:
						return "Gold Shortsword";
					case EntityID.ItemID.GOLD_AXE:
						return "Gold Axe";
					case EntityID.ItemID.GOLD_HAMMER:
						return "Gold Hammer";
					case EntityID.ItemID.GOLD_BOW:
						return "Gold Bow";
					case EntityID.ItemID.SILVER_PICKAXE:
						return "Silver Pickaxe";
					case EntityID.ItemID.SILVER_BROADSWORD:
						return "Silver Broadsword";
					case EntityID.ItemID.SILVER_SHORTSWORD:
						return "Silver Shortsword";
					case EntityID.ItemID.SILVER_AXE:
						return "Silver Axe";
					case EntityID.ItemID.SILVER_HAMMER:
						return "Silver Hammer";
					case EntityID.ItemID.SILVER_BOW:
						return "Silver Bow";
					case EntityID.ItemID.COPPER_PICKAXE:
						return "Copper Pickaxe";
					case EntityID.ItemID.COPPER_BROADSWORD:
						return "Copper Broadsword";
					case EntityID.ItemID.COPPER_SHORTSWORD:
						return "Copper Shortsword";
					case EntityID.ItemID.COPPER_AXE:
						return "Copper Axe";
					case EntityID.ItemID.COPPER_HAMMER:
						return "Copper Hammer";
					case EntityID.ItemID.COPPER_BOW:
						return "Copper Bow";
					case EntityID.ItemID.BLUE_PHASESABER:
						return "Blue Phasesaber";
					case EntityID.ItemID.RED_PHASESABER:
						return "Red Phasesaber";
					case EntityID.ItemID.GREEN_PHASESABER:
						return "Green Phasesaber";
					case EntityID.ItemID.PURPLE_PHASESABER:
						return "Purple Phasesaber";
					case EntityID.ItemID.WHITE_PHASESABER:
						return "White Phasesaber";
					case EntityID.ItemID.YELLOW_PHASESABER:
						return "Yellow Phasesaber";
					case EntityID.ItemID.IRON_PICKAXE:
						return "Iron Pickaxe";
					case EntityID.ItemID.DIRT_BLOCK:
						return "Dirt Block";
					case EntityID.ItemID.STONE_BLOCK:
						return "Stone Block";
					case EntityID.ItemID.IRON_BROADSWORD:
						return "Iron Broadsword";
					case EntityID.ItemID.MUSHROOM:
						return "Mushroom";
					case EntityID.ItemID.IRON_SHORTSWORD:
						return "Iron Shortsword";
					case EntityID.ItemID.IRON_HAMMER:
						return "Iron Hammer";
					case EntityID.ItemID.TORCH:
						return "Torch";
					case EntityID.ItemID.WOOD:
						return "Wood";
					case EntityID.ItemID.IRON_AXE:
						return "Iron Axe";
					case EntityID.ItemID.IRON_ORE:
						return "Iron Ore";
					case EntityID.ItemID.COPPER_ORE:
						return "Copper Ore";
					case EntityID.ItemID.GOLD_ORE:
						return "Gold Ore";
					case EntityID.ItemID.SILVER_ORE:
						return "Silver Ore";
					case EntityID.ItemID.COPPER_WATCH:
						return "Copper Watch";
					case EntityID.ItemID.SILVER_WATCH:
						return "Silver Watch";
					case EntityID.ItemID.GOLD_WATCH:
						return "Gold Watch";
					case EntityID.ItemID.DEPTH_METER:
						return "Depth Meter";
					case EntityID.ItemID.GOLD_BAR:
						return "Gold Bar";
					case EntityID.ItemID.COPPER_BAR:
						return "Copper Bar";
					case EntityID.ItemID.SILVER_BAR:
						return "Silver Bar";
					case EntityID.ItemID.IRON_BAR:
						return "Iron Bar";
					case EntityID.ItemID.GEL:
						return "Gel";
					case EntityID.ItemID.WOODEN_SWORD:
						return "Wooden Sword";
					case EntityID.ItemID.WOODEN_DOOR:
						return "Wooden Door";
					case EntityID.ItemID.STONE_WALL:
						return "Stone Wall";
					case EntityID.ItemID.ACORN:
						return "Acorn";
					case EntityID.ItemID.LESSER_HEALING_POTION:
						return "Lesser Healing Potion";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Life Crystal";
					case EntityID.ItemID.DIRT_WALL:
						return "Dirt Wall";
					case EntityID.ItemID.BOTTLE:
						return "Bottle";
					case EntityID.ItemID.WOODEN_TABLE:
						return "Wooden Table";
					case EntityID.ItemID.FURNACE:
						return "Furnace";
					case EntityID.ItemID.WOODEN_CHAIR:
						return "Wooden Chair";
					case EntityID.ItemID.IRON_ANVIL:
						return "Iron Anvil";
					case EntityID.ItemID.WORK_BENCH:
						return "Work Bench";
					case EntityID.ItemID.GOGGLES:
						return "Goggles";
					case EntityID.ItemID.LENS:
						return "Lens";
					case EntityID.ItemID.WOODEN_BOW:
						return "Wooden Bow";
					case EntityID.ItemID.WOODEN_ARROW:
						return "Wooden Arrow";
					case EntityID.ItemID.FLAMING_ARROW:
						return "Flaming Arrow";
					case EntityID.ItemID.SHURIKEN:
						return "Shuriken";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Suspicious Looking Eye";
					case EntityID.ItemID.DEMON_BOW:
						return "Demon Bow";
					case EntityID.ItemID.WAR_AXE_OF_THE_NIGHT:
						return "War Axe of the Night";
					case EntityID.ItemID.LIGHTS_BANE:
						return "Light's Bane";
					case EntityID.ItemID.UNHOLY_ARROW:
						return "Unholy Arrow";
					case EntityID.ItemID.CHEST:
						return "Chest";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Band of Regeneration";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Magic Mirror";
					case EntityID.ItemID.JESTERS_ARROW:
						return "Jester's Arrow";
					case EntityID.ItemID.ANGEL_STATUE:
						return "Angel Statue";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Cloud in a Bottle";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Hermes Boots";
					case EntityID.ItemID.ENCHANTED_BOOMERANG:
						return "Enchanted Boomerang";
					case EntityID.ItemID.DEMONITE_ORE:
						return "Demonite Ore";
					case EntityID.ItemID.DEMONITE_BAR:
						return "Demonite Bar";
					case EntityID.ItemID.HEART:
						return "Heart";
					case EntityID.ItemID.CORRUPT_SEEDS:
						return "Corrupt Seeds";
					case EntityID.ItemID.VILE_MUSHROOM:
						return "Vile Mushroom";
					case EntityID.ItemID.EBONSTONE_BLOCK:
						return "Ebonstone Block";
					case EntityID.ItemID.GRASS_SEEDS:
						return "Grass Seeds";
					case EntityID.ItemID.SUNFLOWER:
						return "Sunflower";
					case EntityID.ItemID.VILETHORN:
						return "Vilethorn";
					case EntityID.ItemID.STARFURY:
						return "Starfury";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Purification Powder";
					case EntityID.ItemID.VILE_POWDER:
						return "Vile Powder";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "Rotten Chunk";
					case EntityID.ItemID.WORM_TOOTH:
						return "Worm Tooth";
					case EntityID.ItemID.WORM_FOOD:
						return "Worm Food";
					case EntityID.ItemID.COPPER_COIN:
						return "Copper Coin";
					case EntityID.ItemID.SILVER_COIN:
						return "Silver Coin";
					case EntityID.ItemID.GOLD_COIN:
						return "Gold Coin";
					case EntityID.ItemID.PLATINUM_COIN:
						return "Platinum Coin";
					case EntityID.ItemID.FALLEN_STAR:
						return "Fallen Star";
					case EntityID.ItemID.COPPER_GREAVES:
						return "Copper Greaves";
					case EntityID.ItemID.IRON_GREAVES:
						return "Iron Greaves";
					case EntityID.ItemID.SILVER_GREAVES:
						return "Silver Greaves";
					case EntityID.ItemID.GOLD_GREAVES:
						return "Gold Greaves";
					case EntityID.ItemID.COPPER_CHAINMAIL:
						return "Copper Chainmail";
					case EntityID.ItemID.IRON_CHAINMAIL:
						return "Iron Chainmail";
					case EntityID.ItemID.SILVER_CHAINMAIL:
						return "Silver Chainmail";
					case EntityID.ItemID.GOLD_CHAINMAIL:
						return "Gold Chainmail";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "Grappling Hook";
					case EntityID.ItemID.CHAIN:
						return "Iron Chain";
					case EntityID.ItemID.SHADOW_SCALE:
						return "Shadow Scale";
					case EntityID.ItemID.PIGGY_BANK:
						return "Piggy Bank";
					case EntityID.ItemID.MINING_HELMET:
						return "Mining Helmet";
					case EntityID.ItemID.COPPER_HELMET:
						return "Copper Helmet";
					case EntityID.ItemID.IRON_HELMET:
						return "Iron Helmet";
					case EntityID.ItemID.SILVER_HELMET:
						return "Silver Helmet";
					case EntityID.ItemID.GOLD_HELMET:
						return "Gold Helmet";
					case EntityID.ItemID.WOOD_WALL:
						return "Wood Wall";
					case EntityID.ItemID.WOOD_PLATFORM:
						return "Wood Platform";
					case EntityID.ItemID.FLINTLOCK_PISTOL:
						return "Flintlock Pistol";
					case EntityID.ItemID.MUSKET:
						return "Musket";
					case EntityID.ItemID.MUSKET_BALL:
						return "Musket Ball";
					case EntityID.ItemID.MINISHARK:
						return "Minishark";
					case EntityID.ItemID.IRON_BOW:
						return "Iron Bow";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Shadow Greaves";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Shadow Scalemail";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Shadow Helmet";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Nightmare Pickaxe";
					case EntityID.ItemID.THE_BREAKER:
						return "The Breaker";
					case EntityID.ItemID.CANDLE:
						return "Candle";
					case EntityID.ItemID.COPPER_CHANDELIER:
						return "Copper Chandelier";
					case EntityID.ItemID.SILVER_CHANDELIER:
						return "Silver Chandelier";
					case EntityID.ItemID.GOLD_CHANDELIER:
						return "Gold Chandelier";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Mana Crystal";
					case EntityID.ItemID.LESSER_MANA_POTION:
						return "Lesser Mana Potion";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Band of Starpower";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Flower of Fire";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Magic Missile";
					case EntityID.ItemID.DIRT_ROD:
						return "Dirt Rod";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Orb of Light"; // Funny part about this is that only the item name and tooltip are changed. Buff icon, name, and the actual orb that follows you is still for the Orb of Light.
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Shadow Orb";
#endif
					case EntityID.ItemID.METEORITE:
						return "Meteorite";
					case EntityID.ItemID.METEORITE_BAR:
						return "Meteorite Bar";
					case EntityID.ItemID.HOOK:
						return "Hook";
					case EntityID.ItemID.FLAMARANG:
						return "Flamarang";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Molten Fury";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "Fiery Greatsword";
					case EntityID.ItemID.MOLTEN_PICKAXE:
						return "Molten Pickaxe";
					case EntityID.ItemID.METEOR_HELMET:
						return "Meteor Helmet";
					case EntityID.ItemID.METEOR_SUIT:
						return "Meteor Suit";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Meteor Leggings";
					case EntityID.ItemID.BOTTLED_WATER:
						return "Bottled Water";
					case EntityID.ItemID.SPACE_GUN:
						return "Space Gun";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Rocket Boots";
					case EntityID.ItemID.GRAY_BRICK:
						return "Gray Brick";
					case EntityID.ItemID.GRAY_BRICK_WALL:
						return "Gray Brick Wall";
					case EntityID.ItemID.RED_BRICK:
						return "Red Brick";
					case EntityID.ItemID.RED_BRICK_WALL:
						return "Red Brick Wall";
					case EntityID.ItemID.CLAY_BLOCK:
						return "Clay Block";
					case EntityID.ItemID.BLUE_BRICK:
						return "Blue Brick";
					case EntityID.ItemID.BLUE_BRICK_WALL:
						return "Blue Brick Wall";
					case EntityID.ItemID.CHAIN_LANTERN:
						return "Chain Lantern";
					case EntityID.ItemID.GREEN_BRICK:
						return "Green Brick";
					case EntityID.ItemID.GREEN_BRICK_WALL:
						return "Green Brick Wall";
					case EntityID.ItemID.PINK_BRICK:
						return "Pink Brick";
					case EntityID.ItemID.PINK_BRICK_WALL:
						return "Pink Brick Wall";
					case EntityID.ItemID.GOLD_BRICK:
						return "Gold Brick";
					case EntityID.ItemID.GOLD_BRICK_WALL:
						return "Gold Brick Wall";
					case EntityID.ItemID.SILVER_BRICK:
						return "Silver Brick";
					case EntityID.ItemID.SILVER_BRICK_WALL:
						return "Silver Brick Wall";
					case EntityID.ItemID.COPPER_BRICK:
						return "Copper Brick";
					case EntityID.ItemID.COPPER_BRICK_WALL:
						return "Copper Brick Wall";
					case EntityID.ItemID.SPIKE:
						return "Spike";
					case EntityID.ItemID.WATER_CANDLE:
						return "Water Candle";
					case EntityID.ItemID.BOOK:
						return "Book";
					case EntityID.ItemID.COBWEB:
						return "Cobweb";
					case EntityID.ItemID.NECRO_HELMET:
						return "Necro Helmet";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Necro Breastplate";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Necro Greaves";
					case EntityID.ItemID.BONE:
						return "Bone";
					case EntityID.ItemID.MURAMASA:
						return "Muramasa";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Cobalt Shield";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Aqua Scepter";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Lucky Horseshoe";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Shiny Red Balloon";
					case EntityID.ItemID.HARPOON:
						return "Harpoon";
					case EntityID.ItemID.SPIKY_BALL:
						return "Spiky Ball";
					case EntityID.ItemID.BALL_O_HURT:
						return "Ball O' Hurt";
					case EntityID.ItemID.BLUE_MOON:
						return "Blue Moon";
					case EntityID.ItemID.HANDGUN:
						return "Handgun";
					case EntityID.ItemID.WATER_BOLT:
						return "Water Bolt";
					case EntityID.ItemID.BOMB:
						return "Bomb";
					case EntityID.ItemID.DYNAMITE:
						return "Dynamite";
					case EntityID.ItemID.GRENADE:
						return "Grenade";
					case EntityID.ItemID.SAND_BLOCK:
						return "Sand Block";
					case EntityID.ItemID.GLASS:
						return "Glass";
					case EntityID.ItemID.SIGN:
						return "Sign";
					case EntityID.ItemID.ASH_BLOCK:
						return "Ash Block";
					case EntityID.ItemID.OBSIDIAN:
						return "Obsidian";
					case EntityID.ItemID.HELLSTONE:
						return "Hellstone";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "Hellstone Bar";
					case EntityID.ItemID.MUD_BLOCK:
						return "Mud Block";
					case EntityID.ItemID.SAPPHIRE:
						return "Sapphire";
					case EntityID.ItemID.RUBY:
						return "Ruby";
					case EntityID.ItemID.EMERALD:
						return "Emerald";
					case EntityID.ItemID.TOPAZ:
						return "Topaz";
					case EntityID.ItemID.AMETHYST:
						return "Amethyst";
					case EntityID.ItemID.DIAMOND:
						return "Diamond";
					case EntityID.ItemID.GLOWING_MUSHROOM:
						return "Glowing Mushroom";
					case EntityID.ItemID.STAR:
						return "Star";
					case EntityID.ItemID.IVY_WHIP:
						return "Ivy Whip";
					case EntityID.ItemID.BREATHING_REED:
						return "Breathing Reed";
					case EntityID.ItemID.FLIPPER:
						return "Flipper";
					case EntityID.ItemID.HEALING_POTION:
						return "Healing Potion";
					case EntityID.ItemID.MANA_POTION:
						return "Mana Potion";
					case EntityID.ItemID.BLADE_OF_GRASS:
						return "Blade of Grass";
					case EntityID.ItemID.THORN_CHAKRAM:
						return "Thorn Chakram";
					case EntityID.ItemID.OBSIDIAN_BRICK:
						return "Obsidian Brick";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Obsidian Skull";
					case EntityID.ItemID.MUSHROOM_GRASS_SEEDS:
						return "Mushroom Grass Seeds";
					case EntityID.ItemID.JUNGLE_GRASS_SEEDS:
						return "Jungle Grass Seeds";
					case EntityID.ItemID.WOODEN_HAMMER:
						return "Wooden Hammer";
					case EntityID.ItemID.STAR_CANNON:
						return "Star Cannon";
					case EntityID.ItemID.BLUE_PHASEBLADE:
						return "Blue Phaseblade";
					case EntityID.ItemID.RED_PHASEBLADE:
						return "Red Phaseblade";
					case EntityID.ItemID.GREEN_PHASEBLADE:
						return "Green Phaseblade";
					case EntityID.ItemID.PURPLE_PHASEBLADE:
						return "Purple Phaseblade";
					case EntityID.ItemID.WHITE_PHASEBLADE:
						return "White Phaseblade";
					case EntityID.ItemID.YELLOW_PHASEBLADE:
						return "Yellow Phaseblade";
					case EntityID.ItemID.METEOR_HAMAXE:
						return "Meteor Hamaxe";
					case EntityID.ItemID.EMPTY_BUCKET:
						return "Empty Bucket";
					case EntityID.ItemID.WATER_BUCKET:
						return "Water Bucket";
					case EntityID.ItemID.LAVA_BUCKET:
						return "Lava Bucket";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "Jungle Rose";
					case EntityID.ItemID.STINGER:
						return "Stinger";
					case EntityID.ItemID.VINE:
						return "Vine";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Feral Claws";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Anklet of the Wind";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Staff of Regrowth";
					case EntityID.ItemID.HELLSTONE_BRICK:
						return "Hellstone Brick";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "Whoopie Cushion";
					case EntityID.ItemID.SHACKLE:
						return "Shackle";
					case EntityID.ItemID.MOLTEN_HAMAXE:
						return "Molten Hamaxe";
					case EntityID.ItemID.FLAMELASH:
						return "Flamelash";
					case EntityID.ItemID.PHOENIX_BLASTER:
						return "Phoenix Blaster";
					case EntityID.ItemID.SUNFURY:
						return "Sunfury";
					case EntityID.ItemID.HELLFORGE:
						return "Hellforge";
					case EntityID.ItemID.CLAY_POT:
						return "Clay Pot";
					case EntityID.ItemID.NATURES_GIFT:
						return "Nature's Gift";
					case EntityID.ItemID.BED:
						return "Bed";
					case EntityID.ItemID.SILK:
						return "Silk";
					case EntityID.ItemID.LESSER_RESTORATION_POTION:
						return "Lesser Restoration Potion";
					case EntityID.ItemID.RESTORATION_POTION:
						return "Restoration Potion";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Jungle Hat";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Jungle Shirt";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Jungle Pants";
					case EntityID.ItemID.MOLTEN_HELMET:
						return "Molten Helmet";
					case EntityID.ItemID.MOLTEN_BREASTPLATE:
						return "Molten Breastplate";
					case EntityID.ItemID.MOLTEN_GREAVES:
						return "Molten Greaves";
					case EntityID.ItemID.METEOR_SHOT:
						return "Meteor Shot";
					case EntityID.ItemID.STICKY_BOMB:
						return "Sticky Bomb";
					case EntityID.ItemID.BLACK_LENS:
						return "Black Lens";
					case EntityID.ItemID.SUNGLASSES:
						return "Sunglasses";
					case EntityID.ItemID.WIZARD_HAT:
						return "Wizard Hat";
					case EntityID.ItemID.TOP_HAT:
						return "Top Hat";
					case EntityID.ItemID.TUXEDO_SHIRT:
						return "Tuxedo Shirt";
					case EntityID.ItemID.TUXEDO_PANTS:
						return "Tuxedo Pants";
					case EntityID.ItemID.SUMMER_HAT:
						return "Summer Hat";
					case EntityID.ItemID.BUNNY_HOOD:
						return "Bunny Hood";
					case EntityID.ItemID.PLUMBERS_HAT:
						return "Plumber's Hat";
					case EntityID.ItemID.PLUMBERS_SHIRT:
						return "Plumber's Shirt";
					case EntityID.ItemID.PLUMBERS_PANTS:
						return "Plumber's Pants";
					case EntityID.ItemID.HEROS_HAT:
						return "Hero's Hat";
					case EntityID.ItemID.HEROS_SHIRT:
						return "Hero's Shirt";
					case EntityID.ItemID.HEROS_PANTS:
						return "Hero's Pants";
					case EntityID.ItemID.FISH_BOWL:
						return "Fish Bowl";
					case EntityID.ItemID.ARCHAEOLOGISTS_HAT:
						return "Archaeologist's Hat";
					case EntityID.ItemID.ARCHAEOLOGISTS_JACKET:
						return "Archaeologist's Jacket";
					case EntityID.ItemID.ARCHAEOLOGISTS_PANTS:
						return "Archaeologist's Pants";
#if VERSION_INITIAL
					case EntityID.ItemID.BLACK_THREAD:
						return "Black Dye";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Purple Dye";
#else
					case EntityID.ItemID.BLACK_THREAD:
						return "Black Thread";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Purple Thread";
#endif

					case EntityID.ItemID.NINJA_HOOD:
						return "Ninja Hood";
					case EntityID.ItemID.NINJA_SHIRT:
						return "Ninja Shirt";
					case EntityID.ItemID.NINJA_PANTS:
						return "Ninja Pants";
					case EntityID.ItemID.LEATHER:
						return "Leather";
					case EntityID.ItemID.RED_HAT:
						return "Red Hat";
					case EntityID.ItemID.GOLDFISH:
						return "Goldfish";
					case EntityID.ItemID.ROBE:
						return "Robe";
					case EntityID.ItemID.ROBOT_HAT:
						return "Robot Hat";
					case EntityID.ItemID.GOLD_CROWN:
						return "Gold Crown";
					case EntityID.ItemID.HELLFIRE_ARROW:
						return "Hellfire Arrow";
					case EntityID.ItemID.SANDGUN:
						return "Sandgun";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "Guide Voodoo Doll";
					case EntityID.ItemID.DIVING_HELMET:
						return "Diving Helmet";
					case EntityID.ItemID.FAMILIAR_SHIRT:
						return "Familiar Shirt";
					case EntityID.ItemID.FAMILIAR_PANTS:
						return "Familiar Pants";
					case EntityID.ItemID.FAMILIAR_WIG:
						return "Familiar Wig";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Demon Scythe";
					case EntityID.ItemID.NIGHTS_EDGE:
						return "Night's Edge";
					case EntityID.ItemID.DARK_LANCE:
						return "Dark Lance";
					case EntityID.ItemID.CORAL:
						return "Coral";
					case EntityID.ItemID.CACTUS:
						return "Cactus";
					case EntityID.ItemID.TRIDENT:
						return "Trident";
					case EntityID.ItemID.SILVER_BULLET:
						return "Silver Bullet";
					case EntityID.ItemID.THROWING_KNIFE:
						return "Throwing Knife";
					case EntityID.ItemID.SPEAR:
						return "Spear";
					case EntityID.ItemID.BLOWPIPE:
						return "Blowpipe";
					case EntityID.ItemID.GLOWSTICK:
						return "Glowstick";
					case EntityID.ItemID.SEED:
						return "Seed";
					case EntityID.ItemID.WOODEN_BOOMERANG:
						return "Wooden Boomerang";
					case EntityID.ItemID.AGLET:
						return "Aglet";
					case EntityID.ItemID.STICKY_GLOWSTICK:
						return "Sticky Glowstick";
					case EntityID.ItemID.POISONED_KNIFE:
						return "Poisoned Knife";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Obsidian Skin Potion";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Regeneration Potion";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Swiftness Potion";
					case EntityID.ItemID.GILLS_POTION:
						return "Gills Potion";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Ironskin Potion";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Mana Regeneration Potion";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Magic Power Potion";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Featherfall Potion";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Spelunker Potion";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Invisibility Potion";
					case EntityID.ItemID.SHINE_POTION:
						return "Shine Potion";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Night Owl Potion";
					case EntityID.ItemID.BATTLE_POTION:
						return "Battle Potion";
					case EntityID.ItemID.THORNS_POTION:
						return "Thorns Potion";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Water Walking Potion";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Archery Potion";
					case EntityID.ItemID.HUNTER_POTION:
						return "Hunter Potion";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Gravitation Potion";
					case EntityID.ItemID.GOLD_CHEST:
						return "Gold Chest";
					case EntityID.ItemID.DAYBLOOM_SEEDS:
						return "Daybloom Seeds";
					case EntityID.ItemID.MOONGLOW_SEEDS:
						return "Moonglow Seeds";
					case EntityID.ItemID.BLINKROOT_SEEDS:
						return "Blinkroot Seeds";
					case EntityID.ItemID.DEATHWEED_SEEDS:
						return "Deathweed Seeds";
					case EntityID.ItemID.WATERLEAF_SEEDS:
						return "Waterleaf Seeds";
					case EntityID.ItemID.FIREBLOSSOM_SEEDS:
						return "Fireblossom Seeds";
					case EntityID.ItemID.DAYBLOOM:
						return "Daybloom";
					case EntityID.ItemID.MOONGLOW:
						return "Moonglow";
					case EntityID.ItemID.BLINKROOT:
						return "Blinkroot";
					case EntityID.ItemID.DEATHWEED:
						return "Deathweed";
					case EntityID.ItemID.WATERLEAF:
						return "Waterleaf";
					case EntityID.ItemID.FIREBLOSSOM:
						return "Fireblossom";
					case EntityID.ItemID.SHARK_FIN:
						return "Shark Fin";
					case EntityID.ItemID.FEATHER:
						return "Feather";
					case EntityID.ItemID.TOMBSTONE:
						return "Tombstone";
					case EntityID.ItemID.MIME_MASK:
						return "Mime Mask";
					case EntityID.ItemID.ANTLION_MANDIBLE:
						return "Antlion Mandible";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "Illegal Gun Parts";
					case EntityID.ItemID.THE_DOCTORS_SHIRT:
						return "The Doctor's Shirt";
					case EntityID.ItemID.THE_DOCTORS_PANTS:
						return "The Doctor's Pants";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Golden Key";
					case EntityID.ItemID.SHADOW_CHEST:
						return "Shadow Chest";
					case EntityID.ItemID.SHADOW_KEY:
						return "Shadow Key";
					case EntityID.ItemID.OBSIDIAN_BRICK_WALL:
						return "Obsidian Brick Wall";
					case EntityID.ItemID.JUNGLE_SPORES:
						return "Jungle Spores";
					case EntityID.ItemID.LOOM:
						return "Loom";
					case EntityID.ItemID.PIANO:
						return "Piano";
					case EntityID.ItemID.DRESSER:
						return "Dresser";
					case EntityID.ItemID.BENCH:
						return "Bench";
					case EntityID.ItemID.BATHTUB:
						return "Bathtub";
					case EntityID.ItemID.RED_BANNER:
						return "Red Banner";
					case EntityID.ItemID.GREEN_BANNER:
						return "Green Banner";
					case EntityID.ItemID.BLUE_BANNER:
						return "Blue Banner";
					case EntityID.ItemID.YELLOW_BANNER:
						return "Yellow Banner";
					case EntityID.ItemID.LAMP_POST:
						return "Lamp Post";
					case EntityID.ItemID.TIKI_TORCH:
						return "Tiki Torch";
					case EntityID.ItemID.BARREL:
						return "Barrel";
					case EntityID.ItemID.CHINESE_LANTERN:
						return "Chinese Lantern";
					case EntityID.ItemID.COOKING_POT:
						return "Cooking Pot";
					case EntityID.ItemID.SAFE:
						return "Safe";
					case EntityID.ItemID.SKULL_LANTERN:
						return "Skull Lantern";
					case EntityID.ItemID.TRASH_CAN:
						return "Trash Can";
					case EntityID.ItemID.CANDELABRA:
						return "Candelabra";
					case EntityID.ItemID.PINK_VASE:
						return "Pink Vase";
					case EntityID.ItemID.MUG:
						return "Mug";
					case EntityID.ItemID.KEG:
						return "Keg";
					case EntityID.ItemID.ALE:
						return "Ale";
					case EntityID.ItemID.BOOKCASE:
						return "Bookcase";
					case EntityID.ItemID.THRONE:
						return "Throne";
					case EntityID.ItemID.BOWL:
						return "Bowl";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Bowl of Soup";
					case EntityID.ItemID.TOILET:
						return "Toilet";
					case EntityID.ItemID.GRANDFATHER_CLOCK:
						return "Grandfather Clock";
					case EntityID.ItemID.STATUE:
						return "Armor Statue";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Goblin Battle Standard";
					case EntityID.ItemID.TATTERED_CLOTH:
						return "Tattered Cloth";
					case EntityID.ItemID.SAWMILL:
						return "Sawmill";
					case EntityID.ItemID.COBALT_ORE:
						return "Cobalt Ore";
					case EntityID.ItemID.MYTHRIL_ORE:
						return "Mythril Ore";
					case EntityID.ItemID.ADAMANTITE_ORE:
						return "Adamantite Ore";
					case EntityID.ItemID.PWNHAMMER:
						return "Pwnhammer";
					case EntityID.ItemID.EXCALIBUR:
						return "Excalibur";
					case EntityID.ItemID.HALLOWED_SEEDS:
						return "Hallowed Seeds";
					case EntityID.ItemID.EBONSAND_BLOCK:
						return "Ebonsand Block";
					case EntityID.ItemID.COBALT_HAT:
						return "Cobalt Hat";
					case EntityID.ItemID.COBALT_HELMET:
						return "Cobalt Helmet";
					case EntityID.ItemID.COBALT_MASK:
						return "Cobalt Mask";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Cobalt Breastplate";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Cobalt Leggings";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Mythril Hood";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Mythril Helmet";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Mythril Hat";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Mythril Chainmail";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Mythril Greaves";
					case EntityID.ItemID.COBALT_BAR:
						return "Cobalt Bar";
					case EntityID.ItemID.MYTHRIL_BAR:
						return "Mythril Bar";
					case EntityID.ItemID.COBALT_CHAINSAW:
						return "Cobalt Chainsaw";
					case EntityID.ItemID.MYTHRIL_CHAINSAW:
						return "Mythril Chainsaw";
					case EntityID.ItemID.COBALT_DRILL:
						return "Cobalt Drill";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Mythril Drill";
					case EntityID.ItemID.ADAMANTITE_CHAINSAW:
						return "Adamantite Chainsaw";
					case EntityID.ItemID.ADAMANTITE_DRILL:
						return "Adamantite Drill";
					case EntityID.ItemID.DAO_OF_POW:
						return "Dao of Pow";
					case EntityID.ItemID.MYTHRIL_HALBERD:
						return "Mythril Halberd";
					case EntityID.ItemID.ADAMANTITE_BAR:
						return "Adamantite Bar";
					case EntityID.ItemID.GLASS_WALL:
						return "Glass Wall";
					case EntityID.ItemID.COMPASS:
						return "Compass";
					case EntityID.ItemID.DIVING_GEAR:
						return "Diving Gear";
					case EntityID.ItemID.GPS:
						return "GPS";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Obsidian Horseshoe";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Obsidian Shield";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Tinkerer's Workshop";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Cloud in a Balloon";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Adamantite Headgear";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Adamantite Helmet";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Adamantite Mask";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Adamantite Breastplate";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Adamantite Leggings";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Spectre Boots";
					case EntityID.ItemID.ADAMANTITE_GLAIVE:
						return "Adamantite Glaive";
					case EntityID.ItemID.TOOLBELT:
						return "Toolbelt";
					case EntityID.ItemID.PEARLSAND_BLOCK:
						return "Pearlsand Block";
					case EntityID.ItemID.PEARLSTONE_BLOCK:
						return "Pearlstone Block";
					case EntityID.ItemID.MINING_SHIRT:
						return "Mining Shirt";
					case EntityID.ItemID.MINING_PANTS:
						return "Mining Pants";
					case EntityID.ItemID.PEARLSTONE_BRICK:
						return "Pearlstone Brick";
					case EntityID.ItemID.IRIDESCENT_BRICK:
						return "Iridescent Brick";
					case EntityID.ItemID.MUDSTONE_BRICK:
						return "Mudstone Brick";
					case EntityID.ItemID.COBALT_BRICK:
						return "Cobalt Brick";
					case EntityID.ItemID.MYTHRIL_BRICK:
						return "Mythril Brick";
					case EntityID.ItemID.PEARLSTONE_BRICK_WALL:
						return "Pearlstone Brick Wall";
					case EntityID.ItemID.IRIDESCENT_BRICK_WALL:
						return "Iridescent Brick Wall";
					case EntityID.ItemID.MUDSTONE_BRICK_WALL:
						return "Mudstone Brick Wall";
					case EntityID.ItemID.COBALT_BRICK_WALL:
						return "Cobalt Brick Wall";
					case EntityID.ItemID.MYTHRIL_BRICK_WALL:
						return "Mythril Brick Wall";
					case EntityID.ItemID.HOLY_WATER:
						return "Holy Water";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Unholy Water";
					case EntityID.ItemID.SILT_BLOCK:
						return "Silt Block";
					case EntityID.ItemID.FAIRY_BELL:
						return "Fairy Bell";
					case EntityID.ItemID.BREAKER_BLADE:
						return "Breaker Blade";
					case EntityID.ItemID.BLUE_TORCH:
						return "Blue Torch";
					case EntityID.ItemID.RED_TORCH:
						return "Red Torch";
					case EntityID.ItemID.GREEN_TORCH:
						return "Green Torch";
					case EntityID.ItemID.PURPLE_TORCH:
						return "Purple Torch";
					case EntityID.ItemID.WHITE_TORCH:
						return "White Torch";
					case EntityID.ItemID.YELLOW_TORCH:
						return "Yellow Torch";
					case EntityID.ItemID.DEMON_TORCH:
						return "Demon Torch";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Clockwork Assault Rifle";
					case EntityID.ItemID.COBALT_REPEATER:
						return "Cobalt Repeater";
					case EntityID.ItemID.MYTHRIL_REPEATER:
						return "Mythril Repeater";
					case EntityID.ItemID.DUAL_HOOK:
						return "Dual Hook";
					case EntityID.ItemID.STAR_STATUE:
						return "Star Statue";
					case EntityID.ItemID.SWORD_STATUE:
						return "Sword Statue";
					case EntityID.ItemID.SLIME_STATUE:
						return "Slime Statue";
					case EntityID.ItemID.GOBLIN_STATUE:
						return "Goblin Statue";
					case EntityID.ItemID.SHIELD_STATUE:
						return "Shield Statue";
					case EntityID.ItemID.BAT_STATUE:
						return "Bat Statue";
					case EntityID.ItemID.FISH_STATUE:
						return "Fish Statue";
					case EntityID.ItemID.BUNNY_STATUE:
						return "Bunny Statue";
					case EntityID.ItemID.SKELETON_STATUE:
						return "Skeleton Statue";
					case EntityID.ItemID.REAPER_STATUE:
						return "Reaper Statue";
					case EntityID.ItemID.WOMAN_STATUE:
						return "Woman Statue";
					case EntityID.ItemID.IMP_STATUE:
						return "Imp Statue";
					case EntityID.ItemID.GARGOYLE_STATUE:
						return "Gargoyle Statue";
					case EntityID.ItemID.GLOOM_STATUE:
						return "Gloom Statue";
					case EntityID.ItemID.HORNET_STATUE:
						return "Hornet Statue";
					case EntityID.ItemID.BOMB_STATUE:
						return "Bomb Statue";
					case EntityID.ItemID.CRAB_STATUE:
						return "Crab Statue";
					case EntityID.ItemID.HAMMER_STATUE:
						return "Hammer Statue";
					case EntityID.ItemID.POTION_STATUE:
						return "Potion Statue";
					case EntityID.ItemID.SPEAR_STATUE:
						return "Spear Statue";
					case EntityID.ItemID.CROSS_STATUE:
						return "Cross Statue";
					case EntityID.ItemID.JELLYFISH_STATUE:
						return "Jellyfish Statue";
					case EntityID.ItemID.BOW_STATUE:
						return "Bow Statue";
					case EntityID.ItemID.BOOMERANG_STATUE:
						return "Boomerang Statue";
					case EntityID.ItemID.BOOT_STATUE:
						return "Boot Statue";
					case EntityID.ItemID.CHEST_STATUE:
						return "Chest Statue";
					case EntityID.ItemID.BIRD_STATUE:
						return "Bird Statue";
					case EntityID.ItemID.AXE_STATUE:
						return "Axe Statue";
					case EntityID.ItemID.CORRUPT_STATUE:
						return "Corrupt Statue";
					case EntityID.ItemID.TREE_STATUE:
						return "Tree Statue";
					case EntityID.ItemID.ANVIL_STATUE:
						return "Anvil Statue";
					case EntityID.ItemID.PICKAXE_STATUE:
						return "Pickaxe Statue";
					case EntityID.ItemID.MUSHROOM_STATUE:
						return "Mushroom Statue";
					case EntityID.ItemID.EYEBALL_STATUE:
						return "Eyeball Statue";
					case EntityID.ItemID.PILLAR_STATUE:
						return "Pillar Statue";
					case EntityID.ItemID.HEART_STATUE:
						return "Heart Statue";
					case EntityID.ItemID.POT_STATUE:
						return "Pot Statue";
					case EntityID.ItemID.SUNFLOWER_STATUE:
						return "Sunflower Statue";
					case EntityID.ItemID.KING_STATUE:
						return "King Statue";
					case EntityID.ItemID.QUEEN_STATUE:
						return "Queen Statue";
					case EntityID.ItemID.PIRANHA_STATUE:
						return "Piranha Statue";
					case EntityID.ItemID.PLANKED_WALL:
						return "Planked Wall";
					case EntityID.ItemID.WOODEN_BEAM:
						return "Wooden Beam";
					case EntityID.ItemID.ADAMANTITE_REPEATER:
						return "Adamantite Repeater";
					case EntityID.ItemID.ADAMANTITE_SWORD:
						return "Adamantite Sword";
					case EntityID.ItemID.COBALT_SWORD:
						return "Cobalt Sword";
					case EntityID.ItemID.MYTHRIL_SWORD:
						return "Mythril Sword";
					case EntityID.ItemID.MOON_CHARM:
						return "Moon Charm";
					case EntityID.ItemID.RULER:
						return "Ruler";
					case EntityID.ItemID.CRYSTAL_BALL:
						return "Crystal Ball";
					case EntityID.ItemID.DISCO_BALL:
						return "Disco Ball";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Sorcerer Emblem";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Warrior Emblem";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Ranger Emblem";
					case EntityID.ItemID.DEMON_WINGS:
						return "Demon Wings";
					case EntityID.ItemID.ANGEL_WINGS:
						return "Angel Wings";
					case EntityID.ItemID.MAGICAL_HARP:
						return "Magical Harp";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Rainbow Rod";
					case EntityID.ItemID.ICE_ROD:
						return "Ice Rod";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Neptune's Shell";
					case EntityID.ItemID.MANNEQUIN:
						return "Mannequin";
					case EntityID.ItemID.GREATER_HEALING_POTION:
						return "Greater Healing Potion";
					case EntityID.ItemID.GREATER_MANA_POTION:
						return "Greater Mana Potion";
					case EntityID.ItemID.PIXIE_DUST:
						return "Pixie Dust";
					case EntityID.ItemID.CRYSTAL_SHARD:
						return "Crystal Shard";
					case EntityID.ItemID.CLOWN_HAT:
						return "Clown Hat";
					case EntityID.ItemID.CLOWN_SHIRT:
						return "Clown Shirt";
					case EntityID.ItemID.CLOWN_PANTS:
						return "Clown Pants";
					case EntityID.ItemID.FLAMETHROWER:
						return "Flamethrower";
					case EntityID.ItemID.BELL:
						return "Bell";
					case EntityID.ItemID.HARP:
						return "Harp";
					case EntityID.ItemID.WRENCH:
						return "Wrench";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Wire Cutter";
					case EntityID.ItemID.ACTIVE_STONE_BLOCK:
						return "Active Stone Block";
					case EntityID.ItemID.INACTIVE_STONE_BLOCK:
						return "Inactive Stone Block";
					case EntityID.ItemID.LEVER:
						return "Lever";
					case EntityID.ItemID.LASER_RIFLE:
						return "Laser Rifle";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Crystal Bullet";
					case EntityID.ItemID.HOLY_ARROW:
						return "Holy Arrow";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Magic Dagger";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Crystal Storm";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Cursed Flames";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "Soul of Light";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "Soul of Night";
					case EntityID.ItemID.CURSED_FLAME:
						return "Cursed Flame";
					case EntityID.ItemID.CURSED_TORCH:
						return "Cursed Torch";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Adamantite Forge";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Mythril Anvil";
					case EntityID.ItemID.UNICORN_HORN:
						return "Unicorn Horn";
					case EntityID.ItemID.DARK_SHARD:
						return "Dark Shard";
					case EntityID.ItemID.LIGHT_SHARD:
						return "Light Shard";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Red Pressure Plate";
					case EntityID.ItemID.WIRE:
						return "Wire";
					case EntityID.ItemID.SPELL_TOME:
						return "Spell Tome";
					case EntityID.ItemID.STAR_CLOAK:
						return "Star Cloak";
					case EntityID.ItemID.MEGASHARK:
						return "Megashark";
					case EntityID.ItemID.SHOTGUN:
						return "Shotgun";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Philosopher's Stone";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Titan Glove";
					case EntityID.ItemID.COBALT_NAGINATA:
						return "Cobalt Naginata";
					case EntityID.ItemID.SWITCH:
						return "Switch";
					case EntityID.ItemID.DART_TRAP:
						return "Dart Trap";
					case EntityID.ItemID.BOULDER:
						return "Boulder";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Green Pressure Plate";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Gray Pressure Plate";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Brown Pressure Plate";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Mechanical Eye";
					case EntityID.ItemID.CURSED_ARROW:
						return "Cursed Arrow";
					case EntityID.ItemID.CURSED_BULLET:
						return "Cursed Bullet";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "Soul of Fright";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "Soul of Might";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "Soul of Sight";
					case EntityID.ItemID.GUNGNIR:
						return "Gungnir";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Hallowed Plate Mail";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Hallowed Greaves";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Hallowed Helmet";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Cross Necklace";
					case EntityID.ItemID.MANA_FLOWER:
						return "Mana Flower";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Mechanical Worm";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Mechanical Skull";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Hallowed Headgear";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Hallowed Mask";
					case EntityID.ItemID.SLIME_CROWN:
						return "Slime Crown";
					case EntityID.ItemID.LIGHT_DISC:
						return "Light Disc";
					case EntityID.ItemID.MUSIC_BOX_OVERWORLD_DAY:
						return "Music Box (Overworld Day)";
					case EntityID.ItemID.MUSIC_BOX_EERIE:
						return "Music Box (Eerie)";
					case EntityID.ItemID.MUSIC_BOX_NIGHT:
						return "Music Box (Night)";
					case EntityID.ItemID.MUSIC_BOX_TITLE:
						return "Music Box (Title)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND:
						return "Music Box (Underground)";
					case EntityID.ItemID.MUSIC_BOX_BOSS1:
						return "Music Box (Boss 1)";
					case EntityID.ItemID.MUSIC_BOX_JUNGLE:
						return "Music Box (Jungle)";
					case EntityID.ItemID.MUSIC_BOX_CORRUPTION:
						return "Music Box (Corruption)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_CORRUPTION:
						return "Music Box (Underground Corruption)";
					case EntityID.ItemID.MUSIC_BOX_THE_HALLOW:
						return "Music Box (The Hallow)";
					case EntityID.ItemID.MUSIC_BOX_BOSS2:
						return "Music Box (Boss 2)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_HALLOW:
						return "Music Box (Underground Hallow)";
					case EntityID.ItemID.MUSIC_BOX_BOSS3:
						return "Music Box (Boss 3)";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "Soul of Flight";
					case EntityID.ItemID.MUSIC_BOX:
						return "Music Box";
					case EntityID.ItemID.DEMONITE_BRICK:
						return "Demonite Brick";
					case EntityID.ItemID.HALLOWED_REPEATER:
						return "Hallowed Repeater";
					case EntityID.ItemID.HAMDRAX:
						return "Hamdrax";
					case EntityID.ItemID.EXPLOSIVES:
						return "Explosives";
					case EntityID.ItemID.INLET_PUMP:
						return "Inlet Pump";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Outlet Pump";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "1 Second Timer";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "3 Second Timer";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "5 Second Timer";
					case EntityID.ItemID.CANDY_CANE_BLOCK:
						return "Candy Cane Block";
					case EntityID.ItemID.CANDY_CANE_WALL:
						return "Candy Cane Wall";
					case EntityID.ItemID.SANTA_HAT:
						return "Santa Hat";
					case EntityID.ItemID.SANTA_SHIRT:
						return "Santa Shirt";
					case EntityID.ItemID.SANTA_PANTS:
						return "Santa Pants";
					case EntityID.ItemID.GREEN_CANDY_CANE_BLOCK:
						return "Green Candy Cane Block";
					case EntityID.ItemID.GREEN_CANDY_CANE_WALL:
						return "Green Candy Cane Wall";
					case EntityID.ItemID.SNOW_BLOCK:
						return "Snow Block";
					case EntityID.ItemID.SNOW_BRICK:
						return "Snow Brick";
					case EntityID.ItemID.SNOW_BRICK_WALL:
						return "Snow Brick Wall";
					case EntityID.ItemID.BLUE_LIGHT:
						return "Blue Light";
					case EntityID.ItemID.RED_LIGHT:
						return "Red Light";
					case EntityID.ItemID.GREEN_LIGHT:
						return "Green Light";
					case EntityID.ItemID.BLUE_PRESENT:
						return "Blue Present";
					case EntityID.ItemID.GREEN_PRESENT:
						return "Green Present";
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Yellow Present";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Snow Globe";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Cabbage";
					case EntityID.ItemID.DRAGON_MASK:
						return "Dragon Mask";
					case EntityID.ItemID.TITAN_HELMET:
						return "Titan Helmet";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Spectral Headgear";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Dragon Breastplate";
					case EntityID.ItemID.TITAN_MAIL:
						return "Titan Mail";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Spectral Armor";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Dragon Greaves";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Titan Leggings";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Spectral Subligar";
					case EntityID.ItemID.TIZONA:
						return "Tizona";
					case EntityID.ItemID.TONBOGIRI:
						return "Tonbogiri";
					case EntityID.ItemID.SHARANGA:
						return "Sharanga";
					case EntityID.ItemID.SPECTRAL_ARROW:
						return "Spectral Arrow";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Vulcan Repeater";
					case EntityID.ItemID.VULCAN_BOLT:
						return "Vulcan Bolt";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Suspicious Looking Skull";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "Soul of Blight";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Petri Dish";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Honeycomb";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Vial of Blood";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Wolf Fang";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Brain";
					case EntityID.ItemID.MUSIC_BOX_DESERT:
						return "Music Box (Desert)";
					case EntityID.ItemID.MUSIC_BOX_SPACE:
						return "Music Box (Space)";
					case EntityID.ItemID.MUSIC_BOX_TUTORIAL:
						return "Music Box (Tutorial)";
					case EntityID.ItemID.MUSIC_BOX_BOSS4:
						return "Music Box (Boss 4)";
					case EntityID.ItemID.MUSIC_BOX_OCEAN:
						return "Music Box (Ocean)";
					case EntityID.ItemID.MUSIC_BOX_SNOW:
						return "Music Box (Snow)";
#if VERSION_101
					case EntityID.ItemID.FABULOUS_RIBBON:
						return "Fabulous Ribbon";
					case EntityID.ItemID.GEORGES_HAT:
						return "George's Hat";
					case EntityID.ItemID.FABULOUS_TUTU:
						return "Fabulous Tutu";
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
						return "George's Tuxedo Shirt";
					case EntityID.ItemID.FABULOUS_SLIPPERS:
						return "Fabulous Slippers";
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "George's Tuxedo Pants";
					case EntityID.ItemID.SPARKLY_WINGS:
						return "Sparkly Wings";
					case EntityID.ItemID.CAMPFIRE:
						return "Campfire";
					case EntityID.ItemID.WOOD_HELMET:
						return "Wood Helmet";
					case EntityID.ItemID.WOOD_BREASTPLATE:
						return "Wood Breastplate";
					case EntityID.ItemID.WOOD_GREAVES:
						return "Wood Greaves";
					case EntityID.ItemID.CACTUS_SWORD:
						return "Cactus Sword";
					case EntityID.ItemID.CACTUS_PICKAXE:
						return "Cactus Pickaxe";
					case EntityID.ItemID.CACTUS_HELMET:
						return "Cactus Helmet";
					case EntityID.ItemID.CACTUS_BREASTPLATE:
						return "Cactus Breastplate";
					case EntityID.ItemID.CACTUS_LEGGINGS:
						return "Cactus Leggings";
					case EntityID.ItemID.PURPLE_STAINED_GLASS_WALL:
						return "Purple Stained Glass";
					case EntityID.ItemID.YELLOW_STAINED_GLASS_WALL:
						return "Yellow Stained Glass";
					case EntityID.ItemID.BLUE_STAINED_GLASS_WALL:
						return "Blue Stained Glass";
					case EntityID.ItemID.GREEN_STAINED_GLASS_WALL:
						return "Green Stained Glass";
					case EntityID.ItemID.RED_STAINED_GLASS_WALL:
						return "Red Stained Glass";
					case EntityID.ItemID.MULTICOLORED_STAINED_GLASS_WALL:
						return "Multicolored Stained Glass";
#endif
				}
			}
			else if (LangOption == (int)ID.GERMAN)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Goldspitzhacke";
					case EntityID.ItemID.GOLD_BROADSWORD:
						return "Goldbreitschwert";
					case EntityID.ItemID.GOLD_SHORTSWORD:
						return "Goldkurzschwert";
					case EntityID.ItemID.GOLD_AXE:
						return "Goldaxt";
					case EntityID.ItemID.GOLD_HAMMER:
						return "Goldhammer";
					case EntityID.ItemID.GOLD_BOW:
						return "Goldbogen";
					case EntityID.ItemID.SILVER_PICKAXE:
						return "Silberspitzhacke";
					case EntityID.ItemID.SILVER_BROADSWORD:
						return "Silberbreitschwert";
					case EntityID.ItemID.SILVER_SHORTSWORD:
						return "Silberkurzschwert";
					case EntityID.ItemID.SILVER_AXE:
						return "Silberaxt";
					case EntityID.ItemID.SILVER_HAMMER:
						return "Silberhammer";
					case EntityID.ItemID.SILVER_BOW:
						return "Silberbogen";
					case EntityID.ItemID.COPPER_PICKAXE:
						return "Kupferspitzhacke";
					case EntityID.ItemID.COPPER_BROADSWORD:
						return "Kupferbreitschwert";
					case EntityID.ItemID.COPPER_SHORTSWORD:
						return "Kupferkurzschwert";
					case EntityID.ItemID.COPPER_AXE:
						return "Kupferaxt";
					case EntityID.ItemID.COPPER_HAMMER:
						return "Kupferhammer";
					case EntityID.ItemID.COPPER_BOW:
						return "Kupferbogen";
					case EntityID.ItemID.BLUE_PHASESABER:
						return "Blaues Laserschwert";
					case EntityID.ItemID.RED_PHASESABER:
						return "Rotes Laserschwert";
					case EntityID.ItemID.GREEN_PHASESABER:
						return "Grünes Laserschwert";
					case EntityID.ItemID.PURPLE_PHASESABER:
						return "Lila Laserschwert";
					case EntityID.ItemID.WHITE_PHASESABER:
						return "Weißes Laserschwert";
					case EntityID.ItemID.YELLOW_PHASESABER:
						return "Gelbes Laserschwert";
					case EntityID.ItemID.IRON_PICKAXE:
						return "Eisenspitzhacke";
					case EntityID.ItemID.DIRT_BLOCK:
						return "Dreckblock";
					case EntityID.ItemID.STONE_BLOCK:
						return "Steinblock";
					case EntityID.ItemID.IRON_BROADSWORD:
						return "Eisenbreitschwert";
					case EntityID.ItemID.MUSHROOM:
						return "Pilz";
					case EntityID.ItemID.IRON_SHORTSWORD:
						return "Eisenkurzschwert";
					case EntityID.ItemID.IRON_HAMMER:
						return "Eisenhammer";
					case EntityID.ItemID.TORCH:
						return "Fackel";
					case EntityID.ItemID.WOOD:
						return "Holz";
					case EntityID.ItemID.IRON_AXE:
						return "Eisenaxt";
					case EntityID.ItemID.IRON_ORE:
						return "Eisenerz";
					case EntityID.ItemID.COPPER_ORE:
						return "Kupfererz";
					case EntityID.ItemID.GOLD_ORE:
						return "Golderz";
					case EntityID.ItemID.SILVER_ORE:
						return "Silbererz";
					case EntityID.ItemID.COPPER_WATCH:
						return "Kupferuhr";
					case EntityID.ItemID.SILVER_WATCH:
						return "Silberuhr";
					case EntityID.ItemID.GOLD_WATCH:
						return "Golduhr";
					case EntityID.ItemID.DEPTH_METER:
						return "Taucheruhr";
					case EntityID.ItemID.GOLD_BAR:
						return "Goldbarren";
					case EntityID.ItemID.COPPER_BAR:
						return "Kupferbarren";
					case EntityID.ItemID.SILVER_BAR:
						return "Silberbarren";
					case EntityID.ItemID.IRON_BAR:
						return "Eisenbarren";
					case EntityID.ItemID.GEL:
						return "Glibber";
					case EntityID.ItemID.WOODEN_SWORD:
						return "Holzschwert";
					case EntityID.ItemID.WOODEN_DOOR:
						return "Holztür";
					case EntityID.ItemID.STONE_WALL:
						return "Steinwand";
					case EntityID.ItemID.ACORN:
						return "Eichel";
					case EntityID.ItemID.LESSER_HEALING_POTION:
						return "Schwacher Heiltrank";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Lebenskristall";
					case EntityID.ItemID.DIRT_WALL:
						return "Dreckwand";
					case EntityID.ItemID.BOTTLE:
						return "Flasche";
					case EntityID.ItemID.WOODEN_TABLE:
						return "Holztisch";
					case EntityID.ItemID.FURNACE:
						return "Schmelzofen";
					case EntityID.ItemID.WOODEN_CHAIR:
						return "Holzstuhl";
					case EntityID.ItemID.IRON_ANVIL:
						return "Eisenamboss";
					case EntityID.ItemID.WORK_BENCH:
						return "Werkbank";
					case EntityID.ItemID.GOGGLES:
						return "Schutzbrille";
					case EntityID.ItemID.LENS:
						return "Linse";
					case EntityID.ItemID.WOODEN_BOW:
						return "Holzbogen";
					case EntityID.ItemID.WOODEN_ARROW:
						return "Holzpfeil";
					case EntityID.ItemID.FLAMING_ARROW:
						return "Flammenpfeil";
					case EntityID.ItemID.SHURIKEN:
						return "Shuriken";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Verdächtig aussehendes Auge";
					case EntityID.ItemID.DEMON_BOW:
						return "Dämonenbogen";
					case EntityID.ItemID.WAR_AXE_OF_THE_NIGHT:
						return "Kriegsaxt der Nacht";
					case EntityID.ItemID.LIGHTS_BANE:
						return "Schrecken des Tages";
					case EntityID.ItemID.UNHOLY_ARROW:
						return "Unheiliger Pfeil";
					case EntityID.ItemID.CHEST:
						return "Truhe";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Wiederbelebungsband";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Magischer Spiegel";
					case EntityID.ItemID.JESTERS_ARROW:
						return "Jester's Pfeil";
					case EntityID.ItemID.ANGEL_STATUE:
						return "Engelsstatue";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Wolke in einer Flasche";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Hermes-Stiefel";
					case EntityID.ItemID.ENCHANTED_BOOMERANG:
						return "Verzauberter Bumerang";
					case EntityID.ItemID.DEMONITE_ORE:
						return "Dämoniterz";
					case EntityID.ItemID.DEMONITE_BAR:
						return "Dämonitbarren";
					case EntityID.ItemID.HEART:
						return "Herz";
					case EntityID.ItemID.CORRUPT_SEEDS:
						return "Verderbte Saat";
					case EntityID.ItemID.VILE_MUSHROOM:
						return "Ekelpilz";
					case EntityID.ItemID.EBONSTONE_BLOCK:
						return "Ebensteinblock";
					case EntityID.ItemID.GRASS_SEEDS:
						return "Grassaat";
					case EntityID.ItemID.SUNFLOWER:
						return "Sonnenblume";
					case EntityID.ItemID.VILETHORN:
						return "Ekeldorn";
					case EntityID.ItemID.STARFURY:
						return "Sternenwut";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Reinigungspulver";
					case EntityID.ItemID.VILE_POWDER:
						return "Ekelpulver";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "Verfaulter Fleischbrocken";
					case EntityID.ItemID.WORM_TOOTH:
						return "Wurmzahn";
					case EntityID.ItemID.WORM_FOOD:
						return "Wurmköder";
					case EntityID.ItemID.COPPER_COIN:
						return "Kupfermünze";
					case EntityID.ItemID.SILVER_COIN:
						return "Silbermünze";
					case EntityID.ItemID.GOLD_COIN:
						return "Goldmünze";
					case EntityID.ItemID.PLATINUM_COIN:
						return "Platinmünze";
					case EntityID.ItemID.FALLEN_STAR:
						return "Sternschnuppe";
					case EntityID.ItemID.COPPER_GREAVES:
						return "Kupferbeinschützer";
					case EntityID.ItemID.IRON_GREAVES:
						return "Eisenbeinschützer";
					case EntityID.ItemID.SILVER_GREAVES:
						return "Silberbeinschützer";
					case EntityID.ItemID.GOLD_GREAVES:
						return "Goldbeinschützer";
					case EntityID.ItemID.COPPER_CHAINMAIL:
						return "Kupferkettenhemd";
					case EntityID.ItemID.IRON_CHAINMAIL:
						return "Eisenkettenhemd";
					case EntityID.ItemID.SILVER_CHAINMAIL:
						return "Silberkettenhemd";
					case EntityID.ItemID.GOLD_CHAINMAIL:
						return "Goldkettenhemd";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "Greifhaken ";
					case EntityID.ItemID.CHAIN:
						return "Eisenkette";
					case EntityID.ItemID.SHADOW_SCALE:
						return "Schattenschuppe";
					case EntityID.ItemID.PIGGY_BANK:
						return "Sparschwein";
					case EntityID.ItemID.MINING_HELMET:
						return "Bergmannshelm";
					case EntityID.ItemID.COPPER_HELMET:
						return "Kupferhelm";
					case EntityID.ItemID.IRON_HELMET:
						return "Eisenhelm";
					case EntityID.ItemID.SILVER_HELMET:
						return "Silberhelm";
					case EntityID.ItemID.GOLD_HELMET:
						return "Goldhelm";
					case EntityID.ItemID.WOOD_WALL:
						return "Holzwand";
					case EntityID.ItemID.WOOD_PLATFORM:
						return "Holzklappe";
					case EntityID.ItemID.FLINTLOCK_PISTOL:
						return "Steinschlosspistole";
					case EntityID.ItemID.MUSKET:
						return "Muskete";
					case EntityID.ItemID.MUSKET_BALL:
						return "Musketenkugel";
					case EntityID.ItemID.MINISHARK:
						return "Minihai";
					case EntityID.ItemID.IRON_BOW:
						return "Eisenbogen";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Schattenbeinschützer";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Schattenschuppenhemd";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Schattenhelm";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Albtraum-Spitzhacke";
					case EntityID.ItemID.THE_BREAKER:
						return "Zerschmetterer";
					case EntityID.ItemID.CANDLE:
						return "Kerze";
					case EntityID.ItemID.COPPER_CHANDELIER:
						return "Kupferkronleuchter";
					case EntityID.ItemID.SILVER_CHANDELIER:
						return "Silberkronleuchter";
					case EntityID.ItemID.GOLD_CHANDELIER:
						return "Goldkronleuchter";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Mana-Kristall";
					case EntityID.ItemID.LESSER_MANA_POTION:
						return "Schwacher Manatrank";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Sternenkraftband";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Feuerblume";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Magische Rakete";
					case EntityID.ItemID.DIRT_ROD:
						return "Dreckrute";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Lichtkugel";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Schattenkugel";
#endif
					case EntityID.ItemID.METEORITE:
						return "Meteorit";
					case EntityID.ItemID.METEORITE_BAR:
						return "Meteoritenbarren";
					case EntityID.ItemID.HOOK:
						return "Haken";
					case EntityID.ItemID.FLAMARANG:
						return "Flamarang";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Geschmolzene Wut";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "Feuriges Großschwert";
					case EntityID.ItemID.MOLTEN_PICKAXE:
						return "Geschmolzene Spitzhacke";
					case EntityID.ItemID.METEOR_HELMET:
						return "Meteorhelm";
					case EntityID.ItemID.METEOR_SUIT:
						return "Meteoranzug";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Meteor Leggings";
					case EntityID.ItemID.BOTTLED_WATER:
						return "Flaschenwasser";
					case EntityID.ItemID.SPACE_GUN:
						return "Weltraumpistole";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Raketenstiefel";
					case EntityID.ItemID.GRAY_BRICK:
						return "Grauer Ziegel";
					case EntityID.ItemID.GRAY_BRICK_WALL:
						return "Graue Ziegelwand";
					case EntityID.ItemID.RED_BRICK:
						return "Roter Ziegel";
					case EntityID.ItemID.RED_BRICK_WALL:
						return "Rote Ziegelwand";
					case EntityID.ItemID.CLAY_BLOCK:
						return "Lehmblock";
					case EntityID.ItemID.BLUE_BRICK:
						return "Blauer Ziegel";
					case EntityID.ItemID.BLUE_BRICK_WALL:
						return "Blaue Ziegelwand";
					case EntityID.ItemID.CHAIN_LANTERN:
						return "Kettenlaterne";
					case EntityID.ItemID.GREEN_BRICK:
						return "Grüner Ziegel";
					case EntityID.ItemID.GREEN_BRICK_WALL:
						return "Grüne Ziegelwand";
					case EntityID.ItemID.PINK_BRICK:
						return "Rosa Ziegel";
					case EntityID.ItemID.PINK_BRICK_WALL:
						return "Rosa Ziegelwand";
					case EntityID.ItemID.GOLD_BRICK:
						return "Goldziegel";
					case EntityID.ItemID.GOLD_BRICK_WALL:
						return "Goldene Ziegelwand";
					case EntityID.ItemID.SILVER_BRICK:
						return "Silberziegel";
					case EntityID.ItemID.SILVER_BRICK_WALL:
						return "Silberne Ziegelwand";
					case EntityID.ItemID.COPPER_BRICK:
						return "Kupferziegel";
					case EntityID.ItemID.COPPER_BRICK_WALL:
						return "Kupferne Ziegelwand";
					case EntityID.ItemID.SPIKE:
						return "Stachel";
					case EntityID.ItemID.WATER_CANDLE:
						return "Wasserkerze";
					case EntityID.ItemID.BOOK:
						return "Buch";
					case EntityID.ItemID.COBWEB:
						return "Spinnennetz";
					case EntityID.ItemID.NECRO_HELMET:
						return "Nekrohelm";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Nekro-Brustplatte";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Nekro-Beinschützer";
					case EntityID.ItemID.BONE:
						return "Knochen";
					case EntityID.ItemID.MURAMASA:
						return "Muramasa";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Kobaltschild";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Aqua-Zepter";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Glückshufeisen";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Leuchtend roter Ballon";
					case EntityID.ItemID.HARPOON:
						return "Harpune";
					case EntityID.ItemID.SPIKY_BALL:
						return "Stachelball";
					case EntityID.ItemID.BALL_O_HURT:
						return "Ball des Schmerzes";
					case EntityID.ItemID.BLUE_MOON:
						return "Blauer Mond";
					case EntityID.ItemID.HANDGUN:
						return "Pistole";
					case EntityID.ItemID.WATER_BOLT:
						return "Wasserbolzen";
					case EntityID.ItemID.BOMB:
						return "Bombe";
					case EntityID.ItemID.DYNAMITE:
						return "Dynamit";
					case EntityID.ItemID.GRENADE:
						return "Granate";
					case EntityID.ItemID.SAND_BLOCK:
						return "Sandblock";
					case EntityID.ItemID.GLASS:
						return "Glas";
					case EntityID.ItemID.SIGN:
						return "Spruchschild";
					case EntityID.ItemID.ASH_BLOCK:
						return "Aschenblock";
					case EntityID.ItemID.OBSIDIAN:
						return "Obsidian";
					case EntityID.ItemID.HELLSTONE:
						return "Höllenstein";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "Höllenstein-Barren";
					case EntityID.ItemID.MUD_BLOCK:
						return "Schlammblock";
					case EntityID.ItemID.SAPPHIRE:
						return "Saphir";
					case EntityID.ItemID.RUBY:
						return "Rubin";
					case EntityID.ItemID.EMERALD:
						return "Smaragd";
					case EntityID.ItemID.TOPAZ:
						return "Topas";
					case EntityID.ItemID.AMETHYST:
						return "Amethyst";
					case EntityID.ItemID.DIAMOND:
						return "Diamant";
					case EntityID.ItemID.GLOWING_MUSHROOM:
						return "Glühender Pilz";
					case EntityID.ItemID.STAR:
						return "Stern";
					case EntityID.ItemID.IVY_WHIP:
						return "Efeupeitsche";
					case EntityID.ItemID.BREATHING_REED:
						return "Schilfrohr";
					case EntityID.ItemID.FLIPPER:
						return "Flosse";
					case EntityID.ItemID.HEALING_POTION:
						return "Heiltrank";
					case EntityID.ItemID.MANA_POTION:
						return "Manatrank";
					case EntityID.ItemID.BLADE_OF_GRASS:
						return "Grasklinge";
					case EntityID.ItemID.THORN_CHAKRAM:
						return "Dornen-Chakram";
					case EntityID.ItemID.OBSIDIAN_BRICK:
						return "Obsidianziegel";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Obsidianschädel";
					case EntityID.ItemID.MUSHROOM_GRASS_SEEDS:
						return "Pilzgras-Saat";
					case EntityID.ItemID.JUNGLE_GRASS_SEEDS:
						return "Dschungelgras-Saat";
					case EntityID.ItemID.WOODEN_HAMMER:
						return "Holzhammer";
					case EntityID.ItemID.STAR_CANNON:
						return "Sternenkanone";
					case EntityID.ItemID.BLUE_PHASEBLADE:
						return "Blaue Laserklinge";
					case EntityID.ItemID.RED_PHASEBLADE:
						return "Rote Laserklinge";
					case EntityID.ItemID.GREEN_PHASEBLADE:
						return "Grüne Laserklinge";
					case EntityID.ItemID.PURPLE_PHASEBLADE:
						return "Lila Laserklinge";
					case EntityID.ItemID.WHITE_PHASEBLADE:
						return "Weiße Laserklinge";
					case EntityID.ItemID.YELLOW_PHASEBLADE:
						return "Gelbe Laserklinge";
					case EntityID.ItemID.METEOR_HAMAXE:
						return "Meteor-Hamaxt";
					case EntityID.ItemID.EMPTY_BUCKET:
						return "Leerer Eimer";
					case EntityID.ItemID.WATER_BUCKET:
						return "Wassereimer";
					case EntityID.ItemID.LAVA_BUCKET:
						return "Lavaeimer";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "Dschungelrose";
					case EntityID.ItemID.STINGER:
						return "Hornissenstachel";
					case EntityID.ItemID.VINE:
						return "Weinrebe";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Wilde Klauen";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Fusskette des Windes";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Stab des Nachwachsens";
					case EntityID.ItemID.HELLSTONE_BRICK:
						return "Höllensteinziegel";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "Furzkissen";
					case EntityID.ItemID.SHACKLE:
						return "Fessel";
					case EntityID.ItemID.MOLTEN_HAMAXE:
						return "Geschmolzene Hamaxt";
					case EntityID.ItemID.FLAMELASH:
						return "Flammenpeitsche";
					case EntityID.ItemID.PHOENIX_BLASTER:
						return "Phoenix-Blaster";
					case EntityID.ItemID.SUNFURY:
						return "Sonnenwut";
					case EntityID.ItemID.HELLFORGE:
						return "Höllenschmiede";
					case EntityID.ItemID.CLAY_POT:
						return "Tontopf";
					case EntityID.ItemID.NATURES_GIFT:
						return "Geschenk der Natur";
					case EntityID.ItemID.BED:
						return "Bett";
					case EntityID.ItemID.SILK:
						return "Seide";
					case EntityID.ItemID.LESSER_RESTORATION_POTION:
						return "Schwacher Wiederherstellungstrank";
					case EntityID.ItemID.RESTORATION_POTION:
						return "Wiederherstellungstrank";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Dschungelhut";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Dschungelhemd";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Dschungelhosen";
					case EntityID.ItemID.MOLTEN_HELMET:
						return "Geschmolzener Helm";
					case EntityID.ItemID.MOLTEN_BREASTPLATE:
						return "Geschmolzene Brustplatte";
					case EntityID.ItemID.MOLTEN_GREAVES:
						return "Geschmolzene Beinschützer";
					case EntityID.ItemID.METEOR_SHOT:
						return "Meteorenschuss";
					case EntityID.ItemID.STICKY_BOMB:
						return "Haftbombe";
					case EntityID.ItemID.BLACK_LENS:
						return "Schwarze Linsen";
					case EntityID.ItemID.SUNGLASSES:
						return "Sonnenbrille";
					case EntityID.ItemID.WIZARD_HAT:
						return "Zaubererhut";
					case EntityID.ItemID.TOP_HAT:
						return "Zylinderhut";
					case EntityID.ItemID.TUXEDO_SHIRT:
						return "Smokinghemd";
					case EntityID.ItemID.TUXEDO_PANTS:
						return "Smokinghosen";
					case EntityID.ItemID.SUMMER_HAT:
						return "Sommerhut";
					case EntityID.ItemID.BUNNY_HOOD:
						return "Hasenkapuze";
					case EntityID.ItemID.PLUMBERS_HAT:
						return "Klempnerhut";
					case EntityID.ItemID.PLUMBERS_SHIRT:
						return "Klempnerhemd";
					case EntityID.ItemID.PLUMBERS_PANTS:
						return "Klempnerhosen";
					case EntityID.ItemID.HEROS_HAT:
						return "Heldenhut";
					case EntityID.ItemID.HEROS_SHIRT:
						return "Heldenhemd";
					case EntityID.ItemID.HEROS_PANTS:
						return "Heldenhosen";
					case EntityID.ItemID.FISH_BOWL:
						return "Fischglas";
					case EntityID.ItemID.ARCHAEOLOGISTS_HAT:
						return "Archäologenhut";
					case EntityID.ItemID.ARCHAEOLOGISTS_JACKET:
						return "Archäologenjacke";
					case EntityID.ItemID.ARCHAEOLOGISTS_PANTS:
						return "Archäologenhosen";

#if VERSION_INITIAL
					case EntityID.ItemID.BLACK_THREAD:
						return "Schwarzer Farbstoff";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Violetter Farbstoff";
#else
					case EntityID.ItemID.BLACK_THREAD:
						return "Schwarzer Faden";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Lila Faden";
#endif

					case EntityID.ItemID.NINJA_HOOD:
						return "Ninja-Kapuze";
					case EntityID.ItemID.NINJA_SHIRT:
						return "Ninjahemd";
					case EntityID.ItemID.NINJA_PANTS:
						return "Ninjahosen";
					case EntityID.ItemID.LEATHER:
						return "Leder";
					case EntityID.ItemID.RED_HAT:
						return "Roter Hut";
					case EntityID.ItemID.GOLDFISH:
						return "Goldfisch";
					case EntityID.ItemID.ROBE:
						return "Robe";
					case EntityID.ItemID.ROBOT_HAT:
						return "Roboterhut";
					case EntityID.ItemID.GOLD_CROWN:
						return "Goldkrone";
					case EntityID.ItemID.HELLFIRE_ARROW:
						return "Höllenfeuer-Pfeil";
					case EntityID.ItemID.SANDGUN:
						return "Sandgewehr";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "Guide-Voodoopuppe";
					case EntityID.ItemID.DIVING_HELMET:
						return "Taucherhelm";
					case EntityID.ItemID.FAMILIAR_SHIRT:
						return "Vertrautes Hemd";
					case EntityID.ItemID.FAMILIAR_PANTS:
						return "Vertraute Hosen";
					case EntityID.ItemID.FAMILIAR_WIG:
						return "Vertraute Frisur";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Dämonensense";
					case EntityID.ItemID.NIGHTS_EDGE:
						return "Klinge der Nacht";
					case EntityID.ItemID.DARK_LANCE:
						return "Dunkle Lanze";
					case EntityID.ItemID.CORAL:
						return "Koralle";
					case EntityID.ItemID.CACTUS:
						return "Kaktus";
					case EntityID.ItemID.TRIDENT:
						return "Dreizack";
					case EntityID.ItemID.SILVER_BULLET:
						return "Silbergeschoss";
					case EntityID.ItemID.THROWING_KNIFE:
						return "Wurfmesser";
					case EntityID.ItemID.SPEAR:
						return "Speer";
					case EntityID.ItemID.BLOWPIPE:
						return "Blasrohr";
					case EntityID.ItemID.GLOWSTICK:
						return "Leuchtstab";
					case EntityID.ItemID.SEED:
						return "Saat";
					case EntityID.ItemID.WOODEN_BOOMERANG:
						return "Holzbumerang";
					case EntityID.ItemID.AGLET:
						return "Schnürsenkelkappe";
					case EntityID.ItemID.STICKY_GLOWSTICK:
						return "Klebriger Leuchtstab";
					case EntityID.ItemID.POISONED_KNIFE:
						return "Giftmesser";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Obsidianhaut-Trank";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Wiederbelebungstrank";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Flinkheitstrank";
					case EntityID.ItemID.GILLS_POTION:
						return "Kiementrank";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Eisenhaut-Trank";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Mana-Wiederherstellungstrank";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Magiekraft-Trank";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Federsturz-Trank";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Höhlenforschertrank";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Unsichtbarkeitstrank";
					case EntityID.ItemID.SHINE_POTION:
						return "Strahlentrank";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Nachteulentrank";
					case EntityID.ItemID.BATTLE_POTION:
						return "Kampftrank";
					case EntityID.ItemID.THORNS_POTION:
						return "Dornentrank";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Wasserlauftrank";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Bogenschießtrank";
					case EntityID.ItemID.HUNTER_POTION:
						return "Jägertrank";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Gravitationstrank";
					case EntityID.ItemID.GOLD_CHEST:
						return "Goldtruhe";
					case EntityID.ItemID.DAYBLOOM_SEEDS:
						return "Tagesblumensaat";
					case EntityID.ItemID.MOONGLOW_SEEDS:
						return "Mondscheinsaat";
					case EntityID.ItemID.BLINKROOT_SEEDS:
						return "Leuchtwurzel-Saat";
					case EntityID.ItemID.DEATHWEED_SEEDS:
						return "Todeskraut-Saat";
					case EntityID.ItemID.WATERLEAF_SEEDS:
						return "Wasserblatt-Saat";
					case EntityID.ItemID.FIREBLOSSOM_SEEDS:
						return "Feuerblüten-Saat";
					case EntityID.ItemID.DAYBLOOM:
						return "Tagesblume";
					case EntityID.ItemID.MOONGLOW:
						return "Mondglanz";
					case EntityID.ItemID.BLINKROOT:
						return "Leuchtwurzel";
					case EntityID.ItemID.DEATHWEED:
						return "Todeskraut";
					case EntityID.ItemID.WATERLEAF:
						return "Wasserblatt";
					case EntityID.ItemID.FIREBLOSSOM:
						return "Feuerblüte";
					case EntityID.ItemID.SHARK_FIN:
						return "Haifinne";
					case EntityID.ItemID.FEATHER:
						return "Feder";
					case EntityID.ItemID.TOMBSTONE:
						return "Grabstein";
					case EntityID.ItemID.MIME_MASK:
						return "Pantomimen-Maske";
					case EntityID.ItemID.ANTLION_MANDIBLE:
						return "Ameisenlöwenkiefer";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "Illegale Gewehrteile";
					case EntityID.ItemID.THE_DOCTORS_SHIRT:
						return "Hemd des Arztes";
					case EntityID.ItemID.THE_DOCTORS_PANTS:
						return "Hosen des Arztes";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Goldener Schlüssel";
					case EntityID.ItemID.SHADOW_CHEST:
						return "Schattentruhe";
					case EntityID.ItemID.SHADOW_KEY:
						return "Schattenschlüssel";
					case EntityID.ItemID.OBSIDIAN_BRICK_WALL:
						return "Obsidianziegelwand";
					case EntityID.ItemID.JUNGLE_SPORES:
						return "Dschungelsporen";
					case EntityID.ItemID.LOOM:
						return "Webstuhl";
					case EntityID.ItemID.PIANO:
						return "Piano";
					case EntityID.ItemID.DRESSER:
						return "Kommode";
					case EntityID.ItemID.BENCH:
						return "Sitzbank";
					case EntityID.ItemID.BATHTUB:
						return "Badewanne";
					case EntityID.ItemID.RED_BANNER:
						return "Rotes Banner";
					case EntityID.ItemID.GREEN_BANNER:
						return "Grünes Banner";
					case EntityID.ItemID.BLUE_BANNER:
						return "Blaues Banner";
					case EntityID.ItemID.YELLOW_BANNER:
						return "Gelbes Banner";
					case EntityID.ItemID.LAMP_POST:
						return "Laternenpfahl";
					case EntityID.ItemID.TIKI_TORCH:
						return "Petroleumfackel";
					case EntityID.ItemID.BARREL:
						return "Fass";
					case EntityID.ItemID.CHINESE_LANTERN:
						return "Chinesische Laterne";
					case EntityID.ItemID.COOKING_POT:
						return "Kochtopf";
					case EntityID.ItemID.SAFE:
						return "Tresor";
					case EntityID.ItemID.SKULL_LANTERN:
						return "Schädellaterne";
					case EntityID.ItemID.TRASH_CAN:
						return "Mülleimer";
					case EntityID.ItemID.CANDELABRA:
						return "Kandelaber";
					case EntityID.ItemID.PINK_VASE:
						return "Rosa Vase";
					case EntityID.ItemID.MUG:
						return "Krug";
					case EntityID.ItemID.KEG:
						return "Gärbottich";
					case EntityID.ItemID.ALE:
						return "Bier";
					case EntityID.ItemID.BOOKCASE:
						return "Bücherregal";
					case EntityID.ItemID.THRONE:
						return "Thron";
					case EntityID.ItemID.BOWL:
						return "Schüssel";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Schüssel mit Suppe";
					case EntityID.ItemID.TOILET:
						return "Toilette";
					case EntityID.ItemID.GRANDFATHER_CLOCK:
						return "Standuhr";
					case EntityID.ItemID.STATUE:
						return "Rüstungsstatue";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Goblin-Kampfstandarte";
					case EntityID.ItemID.TATTERED_CLOTH:
						return "Zerfetzter Stoff";
					case EntityID.ItemID.SAWMILL:
						return "Sägewerk";
					case EntityID.ItemID.COBALT_ORE:
						return "Kobalterz";
					case EntityID.ItemID.MYTHRIL_ORE:
						return "Mithrilerz";
					case EntityID.ItemID.ADAMANTITE_ORE:
						return "Adamantiterz";
					case EntityID.ItemID.PWNHAMMER:
						return "Pwnhammer";
					case EntityID.ItemID.EXCALIBUR:
						return "Excalibur";
					case EntityID.ItemID.HALLOWED_SEEDS:
						return "Heilige Saat";
					case EntityID.ItemID.EBONSAND_BLOCK:
						return "Ebensandblock";
					case EntityID.ItemID.COBALT_HAT:
						return "Kobalthut";
					case EntityID.ItemID.COBALT_HELMET:
						return "Kobalthelm";
					case EntityID.ItemID.COBALT_MASK:
						return "Kobalt-Maske";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Kobalt-Brustplatte";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Kobalt-Gamaschen";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Mithril-Kapuze";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Mithril-Helm";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Mithrilhut";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Mithril-Kettenhemd";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Mithril-Beinschützer";
					case EntityID.ItemID.COBALT_BAR:
						return "Kobaltbarren";
					case EntityID.ItemID.MYTHRIL_BAR:
						return "Mithrilbarren";
					case EntityID.ItemID.COBALT_CHAINSAW:
						return "Kobalt-Kettensäge";
					case EntityID.ItemID.MYTHRIL_CHAINSAW:
						return "Mithril-Kettensäge";
					case EntityID.ItemID.COBALT_DRILL:
						return "Kobaltbohrer";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Mithrilbohrer";
					case EntityID.ItemID.ADAMANTITE_CHAINSAW:
						return "Adamantit-Kettensäge";
					case EntityID.ItemID.ADAMANTITE_DRILL:
						return "Adamantitbohrer";
					case EntityID.ItemID.DAO_OF_POW:
						return "Dao von Pow";
					case EntityID.ItemID.MYTHRIL_HALBERD:
						return "Mithril-Hellebarde";
					case EntityID.ItemID.ADAMANTITE_BAR:
						return "Adamantitbarren";
					case EntityID.ItemID.GLASS_WALL:
						return "Glaswand";
					case EntityID.ItemID.COMPASS:
						return "Kompass";
					case EntityID.ItemID.DIVING_GEAR:
						return "Tauchausrüstung";
					case EntityID.ItemID.GPS:
						return "GPS";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Obsidian-Hufeisen";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Obsidianschild";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Tüftler-Werkstatt";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Wolke in einem Ballon";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Adamantit-Kopfschutz";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Adamantit-Helm";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Adamantit-Maske";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Adamantit-Brustplatte";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Adamantit-Gamaschen";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Geisterstiefel";
					case EntityID.ItemID.ADAMANTITE_GLAIVE:
						return "Adamantit-Gleve";
					case EntityID.ItemID.TOOLBELT:
						return "Werkzeuggürtel";
					case EntityID.ItemID.PEARLSAND_BLOCK:
						return "Perlsandblock";
					case EntityID.ItemID.PEARLSTONE_BLOCK:
						return "Perlsteinblock";
					case EntityID.ItemID.MINING_SHIRT:
						return "Bergbauhemd";
					case EntityID.ItemID.MINING_PANTS:
						return "Bergbauhosen";
					case EntityID.ItemID.PEARLSTONE_BRICK:
						return "Perlsteinziegel";
					case EntityID.ItemID.IRIDESCENT_BRICK:
						return "Schillernder Ziegel";
					case EntityID.ItemID.MUDSTONE_BRICK:
						return "Schlammsteinziegel";
					case EntityID.ItemID.COBALT_BRICK:
						return "Kobaltziegel";
					case EntityID.ItemID.MYTHRIL_BRICK:
						return "Mithrilziegel";
					case EntityID.ItemID.PEARLSTONE_BRICK_WALL:
						return "Perlstein-Ziegelwand";
					case EntityID.ItemID.IRIDESCENT_BRICK_WALL:
						return "Schillernde Ziegelwand";
					case EntityID.ItemID.MUDSTONE_BRICK_WALL:
						return "Schlammstein-Ziegelwand";
					case EntityID.ItemID.COBALT_BRICK_WALL:
						return "Kobalt-Ziegelwand";
					case EntityID.ItemID.MYTHRIL_BRICK_WALL:
						return "Mithril-Ziegelwand";
					case EntityID.ItemID.HOLY_WATER:
						return "Heiliges Wasser";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Unheiliges Wasser";
					case EntityID.ItemID.SILT_BLOCK:
						return "Schlickblock";
					case EntityID.ItemID.FAIRY_BELL:
						return "Feenglocke";
					case EntityID.ItemID.BREAKER_BLADE:
						return "Schmetterklinge";
					case EntityID.ItemID.BLUE_TORCH:
						return "Blaue Fackel";
					case EntityID.ItemID.RED_TORCH:
						return "Rote Fackel";
					case EntityID.ItemID.GREEN_TORCH:
						return "Grüne Fackel";
					case EntityID.ItemID.PURPLE_TORCH:
						return "Lila Fackel";
					case EntityID.ItemID.WHITE_TORCH:
						return "Weiße Fackel";
					case EntityID.ItemID.YELLOW_TORCH:
						return "Gelbe Fackel";
					case EntityID.ItemID.DEMON_TORCH:
						return "Dämonenfackel";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Automatiksturmwaffe";
					case EntityID.ItemID.COBALT_REPEATER:
						return "Kobaltrepetierer";
					case EntityID.ItemID.MYTHRIL_REPEATER:
						return "Mithrilrepetierer";
					case EntityID.ItemID.DUAL_HOOK:
						return "Doppel-Greifhaken";
					case EntityID.ItemID.STAR_STATUE:
						return "Sternstatue";
					case EntityID.ItemID.SWORD_STATUE:
						return "Schwertstatue";
					case EntityID.ItemID.SLIME_STATUE:
						return "Schleimstatue";
					case EntityID.ItemID.GOBLIN_STATUE:
						return "Goblinstatue";
					case EntityID.ItemID.SHIELD_STATUE:
						return "Schildstatue";
					case EntityID.ItemID.BAT_STATUE:
						return "Fledermausstatue";
					case EntityID.ItemID.FISH_STATUE:
						return "Fischstatue";
					case EntityID.ItemID.BUNNY_STATUE:
						return "Hasenstatue";
					case EntityID.ItemID.SKELETON_STATUE:
						return "Skelettstatue";
					case EntityID.ItemID.REAPER_STATUE:
						return "Sensenmannstatue";
					case EntityID.ItemID.WOMAN_STATUE:
						return "Frauenstatue";
					case EntityID.ItemID.IMP_STATUE:
						return "Impstatue";
					case EntityID.ItemID.GARGOYLE_STATUE:
						return "Wasserspeier-Statue";
					case EntityID.ItemID.GLOOM_STATUE:
						return "Vanitasstatue";
					case EntityID.ItemID.HORNET_STATUE:
						return "Hornissenstatue";
					case EntityID.ItemID.BOMB_STATUE:
						return "Bombenstatue";
					case EntityID.ItemID.CRAB_STATUE:
						return "Krabbenstatue";
					case EntityID.ItemID.HAMMER_STATUE:
						return "Hammerstatue";
					case EntityID.ItemID.POTION_STATUE:
						return "Trankstatue";
					case EntityID.ItemID.SPEAR_STATUE:
						return "Speerstatue";
					case EntityID.ItemID.CROSS_STATUE:
						return "Kreuzstatue";
					case EntityID.ItemID.JELLYFISH_STATUE:
						return "Quallenstatue";
					case EntityID.ItemID.BOW_STATUE:
						return "Bogenstatue";
					case EntityID.ItemID.BOOMERANG_STATUE:
						return "Bumerangstatue";
					case EntityID.ItemID.BOOT_STATUE:
						return "Stiefelstatue";
					case EntityID.ItemID.CHEST_STATUE:
						return "Truhenstatue";
					case EntityID.ItemID.BIRD_STATUE:
						return "Vogelstatue";
					case EntityID.ItemID.AXE_STATUE:
						return "Axtstatue";
					case EntityID.ItemID.CORRUPT_STATUE:
						return "Verderbnisstatue";
					case EntityID.ItemID.TREE_STATUE:
						return "Baumstatue";
					case EntityID.ItemID.ANVIL_STATUE:
						return "Amboss-Statue";
					case EntityID.ItemID.PICKAXE_STATUE:
						return "Spitzhackenstatue";
					case EntityID.ItemID.MUSHROOM_STATUE:
						return "Pilzstatue";
					case EntityID.ItemID.EYEBALL_STATUE:
						return "Augapfelstatue";
					case EntityID.ItemID.PILLAR_STATUE:
						return "Säulenstatue";
					case EntityID.ItemID.HEART_STATUE:
						return "Herzstatue";
					case EntityID.ItemID.POT_STATUE:
						return "Topfstatue";
					case EntityID.ItemID.SUNFLOWER_STATUE:
						return "Sonnenblumenstatue";
					case EntityID.ItemID.KING_STATUE:
						return "Königstatue";
					case EntityID.ItemID.QUEEN_STATUE:
						return "Königinstatue";
					case EntityID.ItemID.PIRANHA_STATUE:
						return "Piranhastatue";
					case EntityID.ItemID.PLANKED_WALL:
						return "Plankenwand";
					case EntityID.ItemID.WOODEN_BEAM:
						return "Holzbalken";
					case EntityID.ItemID.ADAMANTITE_REPEATER:
						return "Adamantitrepetierer";
					case EntityID.ItemID.ADAMANTITE_SWORD:
						return "Adamantitschwert";
					case EntityID.ItemID.COBALT_SWORD:
						return "Kobaltschwert";
					case EntityID.ItemID.MYTHRIL_SWORD:
						return "Mithrilschwert";
					case EntityID.ItemID.MOON_CHARM:
						return "Mondzauber";
					case EntityID.ItemID.RULER:
						return "Lineal";
					case EntityID.ItemID.CRYSTAL_BALL:
						return "Kristallkugel";
					case EntityID.ItemID.DISCO_BALL:
						return "Diskokugel";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Siegel des Magiers";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Siegel des Kriegers";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Siegel des Bogenschützen";
					case EntityID.ItemID.DEMON_WINGS:
						return "Dämonenflügel";
					case EntityID.ItemID.ANGEL_WINGS:
						return "Engelsflügel";
					case EntityID.ItemID.MAGICAL_HARP:
						return "Magische Harfe";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Regenbogenrute";
					case EntityID.ItemID.ICE_ROD:
						return "Eisrute";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Neptuns Muschel";
					case EntityID.ItemID.MANNEQUIN:
						return "Schaufensterpuppe";
					case EntityID.ItemID.GREATER_HEALING_POTION:
						return "Großer Heiltrank";
					case EntityID.ItemID.GREATER_MANA_POTION:
						return "Großer Manatrank";
					case EntityID.ItemID.PIXIE_DUST:
						return "Pixie-Staub";
					case EntityID.ItemID.CRYSTAL_SHARD:
						return "Kristallscherbe";
					case EntityID.ItemID.CLOWN_HAT:
						return "Clownshut";
					case EntityID.ItemID.CLOWN_SHIRT:
						return "Clownshemd";
					case EntityID.ItemID.CLOWN_PANTS:
						return "Clownshosen";
					case EntityID.ItemID.FLAMETHROWER:
						return "Flammenwerfer";
					case EntityID.ItemID.BELL:
						return "Glocke";
					case EntityID.ItemID.HARP:
						return "Harfe";
					case EntityID.ItemID.WRENCH:
						return "Schraubenschlüssel";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Kabelcutter";
					case EntityID.ItemID.ACTIVE_STONE_BLOCK:
						return "Aktiver Steinblock";
					case EntityID.ItemID.INACTIVE_STONE_BLOCK:
						return "Inaktiver Steinblock";
					case EntityID.ItemID.LEVER:
						return "Hebel";
					case EntityID.ItemID.LASER_RIFLE:
						return "Lasergewehr";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Kristallgeschoss";
					case EntityID.ItemID.HOLY_ARROW:
						return "Heiliger Pfeil";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Magischer Dolch";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Kristallsturm";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Verfluchte Flammen";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "Seele des Lichts";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "Seele der Nacht";
					case EntityID.ItemID.CURSED_FLAME:
						return "Verfluchte Flamme";
					case EntityID.ItemID.CURSED_TORCH:
						return "Verfluchte Fackel";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Adamantitschmiede";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Mithrilamboss";
					case EntityID.ItemID.UNICORN_HORN:
						return "Horn des Einhorns";
					case EntityID.ItemID.DARK_SHARD:
						return "Dunkle Scherbe";
					case EntityID.ItemID.LIGHT_SHARD:
						return "Lichtscherbe";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Rote Druckplatte";
					case EntityID.ItemID.WIRE:
						return "Kabel";
					case EntityID.ItemID.SPELL_TOME:
						return "Buch der Flüche";
					case EntityID.ItemID.STAR_CLOAK:
						return "Sternenumhang";
					case EntityID.ItemID.MEGASHARK:
						return "Maxihai";
					case EntityID.ItemID.SHOTGUN:
						return "Schrotflinte";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Stein der Weisen";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Titanhandschuh";
					case EntityID.ItemID.COBALT_NAGINATA:
						return "Kobalt-Naginata";
					case EntityID.ItemID.SWITCH:
						return "Schalter";
					case EntityID.ItemID.DART_TRAP:
						return "Pfeilfalle";
					case EntityID.ItemID.BOULDER:
						return "Felsbrocken";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Grüne Druckplatte";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Graue Druckplatte";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Braune Druckplatte";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Mechanisches Auge";
					case EntityID.ItemID.CURSED_ARROW:
						return "Verfluchter Pfeil";
					case EntityID.ItemID.CURSED_BULLET:
						return "Verfluchtes Geschoss";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "Seele des Schreckens";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "Seele der Macht";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "Seele der Einsicht";
					case EntityID.ItemID.GUNGNIR:
						return "Gungnir";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Heiliger Plattenpanzer";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Heilige Beinschützer";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Heiliger Helm";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Kreuzhalskette";
					case EntityID.ItemID.MANA_FLOWER:
						return "Mana-Blume";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Mechanischer Wurm";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Mechanischer Schaedel";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Heiliger Kopfschutz";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Heilige Maske";
					case EntityID.ItemID.SLIME_CROWN:
						return "Schleimkrone";
					case EntityID.ItemID.LIGHT_DISC:
						return "Lichtscheibe";
					case EntityID.ItemID.MUSIC_BOX_OVERWORLD_DAY:
						return "Musikbox (Tag in der Oberwelt)";
					case EntityID.ItemID.MUSIC_BOX_EERIE:
						return "Musikbox (Gespenstisch)";
					case EntityID.ItemID.MUSIC_BOX_NIGHT:
						return "Musikbox (Nacht)";
					case EntityID.ItemID.MUSIC_BOX_TITLE:
						return "Musikbox (Titel)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND:
						return "Musikbox (Unterirdisch)";
					case EntityID.ItemID.MUSIC_BOX_BOSS1:
						return "Musikbox (Boss 1)";
					case EntityID.ItemID.MUSIC_BOX_JUNGLE:
						return "Musikbox (Dschungel)";
					case EntityID.ItemID.MUSIC_BOX_CORRUPTION:
						return "Musikbox (Verderben)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_CORRUPTION:
						return "Musikbox (Unterirdisches Verderben)";
					case EntityID.ItemID.MUSIC_BOX_THE_HALLOW:
						return "Musikbox (Das Heilige)";
					case EntityID.ItemID.MUSIC_BOX_BOSS2:
						return "Musikbox (Boss 2)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_HALLOW:
						return "Musikbox (Unterirdisches Heiliges)";
					case EntityID.ItemID.MUSIC_BOX_BOSS3:
						return "Musikbox (Boss 3)";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "Seele des Flugs";
					case EntityID.ItemID.MUSIC_BOX:
						return "Musikbox";
					case EntityID.ItemID.DEMONITE_BRICK:
						return "Dämonitziegel";
					case EntityID.ItemID.HALLOWED_REPEATER:
						return "Heiliger Repetierer";
					case EntityID.ItemID.HAMDRAX:
						return "Hamdrax";
					case EntityID.ItemID.EXPLOSIVES:
						return "Sprengstoffe";
					case EntityID.ItemID.INLET_PUMP:
						return "Einlasspumpe";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Auslasspumpe";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "1-Sekunden-Timer";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "3-Sekunden-Timer";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "5-Sekunden-Timer";
					case EntityID.ItemID.CANDY_CANE_BLOCK:
						return "Candy Cane-Block";
					case EntityID.ItemID.CANDY_CANE_WALL:
						return "Candy Cane-Wand";
					case EntityID.ItemID.SANTA_HAT:
						return "Weihnachtsmütze";
					case EntityID.ItemID.SANTA_SHIRT:
						return "Santa Shirt";
					case EntityID.ItemID.SANTA_PANTS:
						return "von Santa Pants";
					case EntityID.ItemID.GREEN_CANDY_CANE_BLOCK:
						return "Grüner Candy Cane-Block";
					case EntityID.ItemID.GREEN_CANDY_CANE_WALL:
						return "Grüne Candy Cane-Wand";
					case EntityID.ItemID.SNOW_BLOCK:
						return "Schnee-Block";
					case EntityID.ItemID.SNOW_BRICK:
						return "Schneeziegel";
					case EntityID.ItemID.SNOW_BRICK_WALL:
						return "Schnee-Ziegelwand";
					case EntityID.ItemID.BLUE_LIGHT:
						return "Blaues Licht";
					case EntityID.ItemID.RED_LIGHT:
						return "Rotes Licht";
					case EntityID.ItemID.GREEN_LIGHT:
						return "Grünes Licht";
					case EntityID.ItemID.BLUE_PRESENT:
						return "Blaue Gegenwart";
					case EntityID.ItemID.GREEN_PRESENT:
						return "Grüne Gegenwart";
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Gelbe Gegenwart";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Schneekugel";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Kohl";
					case EntityID.ItemID.DRAGON_MASK:
						return "Drachenmaske";
					case EntityID.ItemID.TITAN_HELMET:
						return "Titanhelm";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Spektral-Kopfbedeckung";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Drachen-Brustpanzer";
					case EntityID.ItemID.TITAN_MAIL:
						return "Titanrüstung";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Spektralrüstung";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Drachen-Beinschienen";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Titanleggings";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Spektralschurz";
					case EntityID.ItemID.TIZONA:
						return "Tizona";
					case EntityID.ItemID.TONBOGIRI:
						return "Tonbogiri";
					case EntityID.ItemID.SHARANGA:
						return "Sharanga";
					case EntityID.ItemID.SPECTRAL_ARROW:
						return "Spektralpfeil";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Vulkan Repeater";
					case EntityID.ItemID.VULCAN_BOLT:
						return "Vulkanbolzen";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Verdächtig aussehender Schädel";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "Seele des Verderbens";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Petrischale";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Bienenwabe";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Phiole mit Blut";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Wolfszahn";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Gehirn";
					case EntityID.ItemID.MUSIC_BOX_DESERT:
						return "Spieluhr (Wüste)";
					case EntityID.ItemID.MUSIC_BOX_SPACE:
						return "Spieluhr (Weltall)";
					case EntityID.ItemID.MUSIC_BOX_TUTORIAL:
						return "Spieluhr (Tutorial)";
					case EntityID.ItemID.MUSIC_BOX_BOSS4:
						return "Spieluhr (Boss 4)";
					case EntityID.ItemID.MUSIC_BOX_OCEAN:
						return "Spieluhr (Ozean)";
					case EntityID.ItemID.MUSIC_BOX_SNOW:
						return "Spieluhr (Schnee)";
#if VERSION_101
					case EntityID.ItemID.FABULOUS_RIBBON:
						return "Fabelhafte Schleife";
					case EntityID.ItemID.GEORGES_HAT:
						return "Georges Hut";
					case EntityID.ItemID.FABULOUS_TUTU:
						return "Fabelhaftes Tutu";
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
						return "Georges Smoking-Hemd";
					case EntityID.ItemID.FABULOUS_SLIPPERS:
						return "Fabelhafte Slipper";
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Georges Smoking-Hose";
					case EntityID.ItemID.SPARKLY_WINGS:
						return "Funkelflügel";
					case EntityID.ItemID.CAMPFIRE:
						return "Lagerfeuer";
					case EntityID.ItemID.WOOD_HELMET:
						return "Holz-Helm";
					case EntityID.ItemID.WOOD_BREASTPLATE:
						return "Holz-Brustpanzer";
					case EntityID.ItemID.WOOD_GREAVES:
						return "Holz-Beinschienen";
					case EntityID.ItemID.CACTUS_SWORD:
						return "Kaktus-Schwert";
					case EntityID.ItemID.CACTUS_PICKAXE:
						return "Kaktus-Spitzhacke";
					case EntityID.ItemID.CACTUS_HELMET:
						return "Kaktus-Helm";
					case EntityID.ItemID.CACTUS_BREASTPLATE:
						return "Kaktus-Brustpanzer";
					case EntityID.ItemID.CACTUS_LEGGINGS:
						return "Kaktus-Leggings";
					case EntityID.ItemID.PURPLE_STAINED_GLASS_WALL:
						return "Lila Buntglas";
					case EntityID.ItemID.YELLOW_STAINED_GLASS_WALL:
						return "Gelbes Buntglas";
					case EntityID.ItemID.BLUE_STAINED_GLASS_WALL:
						return "Blaues Buntglas";
					case EntityID.ItemID.GREEN_STAINED_GLASS_WALL:
						return "Grünes Buntglas";
					case EntityID.ItemID.RED_STAINED_GLASS_WALL:
						return "Rotes Buntglas";
					case EntityID.ItemID.MULTICOLORED_STAINED_GLASS_WALL:
						return "Mehrfarbiges Buntglas";

#endif
				}
			}
			else if (LangOption == (int)ID.ITALIAN)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Piccone d'oro";
					case EntityID.ItemID.GOLD_BROADSWORD:
						return "Spadone d'oro";
					case EntityID.ItemID.GOLD_SHORTSWORD:
						return "Spada corta d'oro";
					case EntityID.ItemID.GOLD_AXE:
						return "Ascia d'oro";
					case EntityID.ItemID.GOLD_HAMMER:
						return "Martello d'oro";
					case EntityID.ItemID.GOLD_BOW:
						return "Arco d'oro";
					case EntityID.ItemID.SILVER_PICKAXE:
						return "Piccone d'argento";
					case EntityID.ItemID.SILVER_BROADSWORD:
						return "Spadone d'argento";
					case EntityID.ItemID.SILVER_SHORTSWORD:
						return "Spada corta d'argento";
					case EntityID.ItemID.SILVER_AXE:
						return "Ascia d'argento";
					case EntityID.ItemID.SILVER_HAMMER:
						return "Martello d'argento";
					case EntityID.ItemID.SILVER_BOW:
						return "Arco d'argento";
					case EntityID.ItemID.COPPER_PICKAXE:
						return "Piccone di rame";
					case EntityID.ItemID.COPPER_BROADSWORD:
						return "Spadone di rame";
					case EntityID.ItemID.COPPER_SHORTSWORD:
						return "Spada corta di rame";
					case EntityID.ItemID.COPPER_AXE:
						return "Ascia di rame";
					case EntityID.ItemID.COPPER_HAMMER:
						return "Martello di rame";
					case EntityID.ItemID.COPPER_BOW:
						return "Arco di rame";
					case EntityID.ItemID.BLUE_PHASESABER:
						return "Spada laser blu";
					case EntityID.ItemID.RED_PHASESABER:
						return "Spada laser rossa";
					case EntityID.ItemID.GREEN_PHASESABER:
						return "Spada laser verde";
					case EntityID.ItemID.PURPLE_PHASESABER:
						return "Spada laser viola";
					case EntityID.ItemID.WHITE_PHASESABER:
						return "Spada laser bianca";
					case EntityID.ItemID.YELLOW_PHASESABER:
						return "Spada laser gialla";
					case EntityID.ItemID.IRON_PICKAXE:
						return "Piccone di ferro";
					case EntityID.ItemID.DIRT_BLOCK:
						return "Blocco di terra";
					case EntityID.ItemID.STONE_BLOCK:
						return "Blocco di pietra";
					case EntityID.ItemID.IRON_BROADSWORD:
						return "Spadone di ferro";
					case EntityID.ItemID.MUSHROOM:
						return "Fungo";
					case EntityID.ItemID.IRON_SHORTSWORD:
						return "Spada corta di ferro";
					case EntityID.ItemID.IRON_HAMMER:
						return "Martello di ferro";
					case EntityID.ItemID.TORCH:
						return "Torcia";
					case EntityID.ItemID.WOOD:
						return "Legno";
					case EntityID.ItemID.IRON_AXE:
						return "Ascia di ferro";
					case EntityID.ItemID.IRON_ORE:
						return "Minerale di ferro";
					case EntityID.ItemID.COPPER_ORE:
						return "Minerale di rame";
					case EntityID.ItemID.GOLD_ORE:
						return "Minerale d'oro";
					case EntityID.ItemID.SILVER_ORE:
						return "Minerale d'argento";
					case EntityID.ItemID.COPPER_WATCH:
						return "Orologio di rame";
					case EntityID.ItemID.SILVER_WATCH:
						return "Orologio d'argento";
					case EntityID.ItemID.GOLD_WATCH:
						return "Orologio d'oro";
					case EntityID.ItemID.DEPTH_METER:
						return "Misuratore di profondità";
					case EntityID.ItemID.GOLD_BAR:
						return "Barra d'oro";
					case EntityID.ItemID.COPPER_BAR:
						return "Barra di rame";
					case EntityID.ItemID.SILVER_BAR:
						return "Barra d'argento";
					case EntityID.ItemID.IRON_BAR:
						return "Barra di ferro";
					case EntityID.ItemID.GEL:
						return "Gelatina";
					case EntityID.ItemID.WOODEN_SWORD:
						return "Spada di legno";
					case EntityID.ItemID.WOODEN_DOOR:
						return "Porta di legno";
					case EntityID.ItemID.STONE_WALL:
						return "Muro di pietra";
					case EntityID.ItemID.ACORN:
						return "Ghianda";
					case EntityID.ItemID.LESSER_HEALING_POTION:
						return "Pozione curativa inferiore";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Cristallo di vita";
					case EntityID.ItemID.DIRT_WALL:
						return "Muro di terra";
					case EntityID.ItemID.BOTTLE:
						return "Bottiglia";
					case EntityID.ItemID.WOODEN_TABLE:
						return "Tavolo di legno";
					case EntityID.ItemID.FURNACE:
						return "Fornace";
					case EntityID.ItemID.WOODEN_CHAIR:
						return "Sedia di legno";
					case EntityID.ItemID.IRON_ANVIL:
						return "Incudine di ferro";
					case EntityID.ItemID.WORK_BENCH:
						return "Banco da lavoro";
					case EntityID.ItemID.GOGGLES:
						return "Occhiali protettivi";
					case EntityID.ItemID.LENS:
						return "Lenti";
					case EntityID.ItemID.WOODEN_BOW:
						return "Arco di legno";
					case EntityID.ItemID.WOODEN_ARROW:
						return "Freccia di legno";
					case EntityID.ItemID.FLAMING_ARROW:
						return "Freccia infuocata";
					case EntityID.ItemID.SHURIKEN:
						return "Shuriken";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Occhio dallo sguardo sospetto";
					case EntityID.ItemID.DEMON_BOW:
						return "Arco demoniaco";
					case EntityID.ItemID.WAR_AXE_OF_THE_NIGHT:
						return "Ascia da guerra della notte";
					case EntityID.ItemID.LIGHTS_BANE:
						return "Flagello di luce";
					case EntityID.ItemID.UNHOLY_ARROW:
						return "Freccia empia";
					case EntityID.ItemID.CHEST:
						return "Cassa";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Benda di rigenerazione";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Specchio magico";
					case EntityID.ItemID.JESTERS_ARROW:
						return "Freccia del giullare";
					case EntityID.ItemID.ANGEL_STATUE:
						return "Statua dell'angelo";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Nuvola in bottiglia";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Stivali di Ermes";
					case EntityID.ItemID.ENCHANTED_BOOMERANG:
						return "Boomerang incantato";
					case EntityID.ItemID.DEMONITE_ORE:
						return "Minerale demoniaco";
					case EntityID.ItemID.DEMONITE_BAR:
						return "Barra demoniaca";
					case EntityID.ItemID.HEART:
						return "Cuore";
					case EntityID.ItemID.CORRUPT_SEEDS:
						return "Semi corrotti";
					case EntityID.ItemID.VILE_MUSHROOM:
						return "Fungo disgustoso";
					case EntityID.ItemID.EBONSTONE_BLOCK:
						return "Blocco pietra d'ebano";
					case EntityID.ItemID.GRASS_SEEDS:
						return "Semi d'erba";
					case EntityID.ItemID.SUNFLOWER:
						return "Girasole";
					case EntityID.ItemID.VILETHORN:
						return "Spina vile";
					case EntityID.ItemID.STARFURY:
						return "Furia stellare";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Polvere purificatrice";
					case EntityID.ItemID.VILE_POWDER:
						return "Polvere disgustosa";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "Ceppo marcio";
					case EntityID.ItemID.WORM_TOOTH:
						return "Dente di verme";
					case EntityID.ItemID.WORM_FOOD:
						return "Esca di verme";
					case EntityID.ItemID.COPPER_COIN:
						return "Moneta di rame";
					case EntityID.ItemID.SILVER_COIN:
						return "Moneta d'argento";
					case EntityID.ItemID.GOLD_COIN:
						return "Moneta d'oro";
					case EntityID.ItemID.PLATINUM_COIN:
						return "Moneta di platino";
					case EntityID.ItemID.FALLEN_STAR:
						return "Stella cadente";
					case EntityID.ItemID.COPPER_GREAVES:
						return "Schiniere di rame ";
					case EntityID.ItemID.IRON_GREAVES:
						return "Schiniere di ferro";
					case EntityID.ItemID.SILVER_GREAVES:
						return "Schiniere d'argento";
					case EntityID.ItemID.GOLD_GREAVES:
						return "Schiniere d'oro";
					case EntityID.ItemID.COPPER_CHAINMAIL:
						return "Maglia metallica di rame";
					case EntityID.ItemID.IRON_CHAINMAIL:
						return "Maglia metallica di ferro";
					case EntityID.ItemID.SILVER_CHAINMAIL:
						return "Maglia metallica d'argento";
					case EntityID.ItemID.GOLD_CHAINMAIL:
						return "Maglia metallica d'oro";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "Rampino";
					case EntityID.ItemID.CHAIN:
						return "Catena di ferro";
					case EntityID.ItemID.SHADOW_SCALE:
						return "Scaglia d'ombra";
					case EntityID.ItemID.PIGGY_BANK:
						return "Salvadanaio";
					case EntityID.ItemID.MINING_HELMET:
						return "Casco da minatore";
					case EntityID.ItemID.COPPER_HELMET:
						return "Casco di rame";
					case EntityID.ItemID.IRON_HELMET:
						return "Casco di ferro";
					case EntityID.ItemID.SILVER_HELMET:
						return "Casco d'argento";
					case EntityID.ItemID.GOLD_HELMET:
						return "Casco d'oro";
					case EntityID.ItemID.WOOD_WALL:
						return "Muro di legno";
					case EntityID.ItemID.WOOD_PLATFORM:
						return "Piattaforma di legno";
					case EntityID.ItemID.FLINTLOCK_PISTOL:
						return "Pistola a pietra focaia";
					case EntityID.ItemID.MUSKET:
						return "Moschetto";
					case EntityID.ItemID.MUSKET_BALL:
						return "Palla di moschetto";
					case EntityID.ItemID.MINISHARK:
						return "Minishark";
					case EntityID.ItemID.IRON_BOW:
						return "Arco di ferro";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Schiniere ombra";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Armatura a scaglie ombra";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Casco ombra";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Piccone dell'incubo";
					case EntityID.ItemID.THE_BREAKER:
						return "Il Distruttore";
					case EntityID.ItemID.CANDLE:
						return "Candela";
					case EntityID.ItemID.COPPER_CHANDELIER:
						return "Lampadario di rame";
					case EntityID.ItemID.SILVER_CHANDELIER:
						return "Lampadario d'argento";
					case EntityID.ItemID.GOLD_CHANDELIER:
						return "Lampadario d'oro";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Cristallo mana";
					case EntityID.ItemID.LESSER_MANA_POTION:
						return "Pozione mana inferiore";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Benda della forza stellare";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Fiore di fuoco";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Missile magico";
					case EntityID.ItemID.DIRT_ROD:
						return "Bastone di terra";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Orbita di luce";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Orbita d'ombra";
#endif
					case EntityID.ItemID.METEORITE:
						return "Meteorite";
					case EntityID.ItemID.METEORITE_BAR:
						return "Barra di meteorite";
					case EntityID.ItemID.HOOK:
						return "Uncino";
					case EntityID.ItemID.FLAMARANG:
						return "Flamarang";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Furia fusa";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "Spadone di fuoco";
					case EntityID.ItemID.MOLTEN_PICKAXE:
						return "Piccone fuso";
					case EntityID.ItemID.METEOR_HELMET:
						return "Casco meteorite";
					case EntityID.ItemID.METEOR_SUIT:
						return "Tunica di meteorite";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Gambali di meteorite";
					case EntityID.ItemID.BOTTLED_WATER:
						return "Acqua imbottigliata";
					case EntityID.ItemID.SPACE_GUN:
						return "Spazio pistola";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Stivali razzo";
					case EntityID.ItemID.GRAY_BRICK:
						return "Mattone grigio";
					case EntityID.ItemID.GRAY_BRICK_WALL:
						return "Muro grigio";
					case EntityID.ItemID.RED_BRICK:
						return "Mattone rosso";
					case EntityID.ItemID.RED_BRICK_WALL:
						return "Muro rosso";
					case EntityID.ItemID.CLAY_BLOCK:
						return "Blocco d'argilla";
					case EntityID.ItemID.BLUE_BRICK:
						return "Mattone blu";
					case EntityID.ItemID.BLUE_BRICK_WALL:
						return "Muro blu";
					case EntityID.ItemID.CHAIN_LANTERN:
						return "Lanterna con catena";
					case EntityID.ItemID.GREEN_BRICK:
						return "Mattone verde";
					case EntityID.ItemID.GREEN_BRICK_WALL:
						return "Muro verde";
					case EntityID.ItemID.PINK_BRICK:
						return "Mattone rosa";
					case EntityID.ItemID.PINK_BRICK_WALL:
						return "Muro rosa";
					case EntityID.ItemID.GOLD_BRICK:
						return "Mattone d'oro";
					case EntityID.ItemID.GOLD_BRICK_WALL:
						return "Muro d'oro";
					case EntityID.ItemID.SILVER_BRICK:
						return "Mattone d'argento";
					case EntityID.ItemID.SILVER_BRICK_WALL:
						return "Muro d'argento";
					case EntityID.ItemID.COPPER_BRICK:
						return "Mattone di rame";
					case EntityID.ItemID.COPPER_BRICK_WALL:
						return "Muro di rame";
					case EntityID.ItemID.SPIKE:
						return "Spina";
					case EntityID.ItemID.WATER_CANDLE:
						return "Candela d'acqua";
					case EntityID.ItemID.BOOK:
						return "Libro";
					case EntityID.ItemID.COBWEB:
						return "Ragnatela";
					case EntityID.ItemID.NECRO_HELMET:
						return "Casco funebre";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Pettorale funebre";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Gambali funebri";
					case EntityID.ItemID.BONE:
						return "Osso";
					case EntityID.ItemID.MURAMASA:
						return "Muramasa";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Scudo di cobalto";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Scettro d'acqua";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Ferro di cavallo fortunato";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Palloncino rosso brillante";
					case EntityID.ItemID.HARPOON:
						return "Arpione";
					case EntityID.ItemID.SPIKY_BALL:
						return "Palla chiodata";
					case EntityID.ItemID.BALL_O_HURT:
						return "Palla del dolore";
					case EntityID.ItemID.BLUE_MOON:
						return "Luna blu";
					case EntityID.ItemID.HANDGUN:
						return "Pistola";
					case EntityID.ItemID.WATER_BOLT:
						return "Dardo d'acqua";
					case EntityID.ItemID.BOMB:
						return "Bomba";
					case EntityID.ItemID.DYNAMITE:
						return "Dinamite";
					case EntityID.ItemID.GRENADE:
						return "Granata";
					case EntityID.ItemID.SAND_BLOCK:
						return "Blocco di sabbia";
					case EntityID.ItemID.GLASS:
						return "Vetro";
					case EntityID.ItemID.SIGN:
						return "Cartello";
					case EntityID.ItemID.ASH_BLOCK:
						return "Blocco di cenere";
					case EntityID.ItemID.OBSIDIAN:
						return "Ossidiana";
					case EntityID.ItemID.HELLSTONE:
						return "Pietra infernale";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "Barra di pietra infernale";
					case EntityID.ItemID.MUD_BLOCK:
						return "Blocco di fango";
					case EntityID.ItemID.SAPPHIRE:
						return "Zaffiro";
					case EntityID.ItemID.RUBY:
						return "Rubino";
					case EntityID.ItemID.EMERALD:
						return "Smeraldo";
					case EntityID.ItemID.TOPAZ:
						return "Topazio";
					case EntityID.ItemID.AMETHYST:
						return "Ametista";
					case EntityID.ItemID.DIAMOND:
						return "Diamante";
					case EntityID.ItemID.GLOWING_MUSHROOM:
						return "Fungo luminoso";
					case EntityID.ItemID.STAR:
						return "Stella";
					case EntityID.ItemID.IVY_WHIP:
						return "Frusta di edera";
					case EntityID.ItemID.BREATHING_REED:
						return "Canna per la respirazione";
					case EntityID.ItemID.FLIPPER:
						return "Pinna";
					case EntityID.ItemID.HEALING_POTION:
						return "Pozione curativa";
					case EntityID.ItemID.MANA_POTION:
						return "Pozione mana";
					case EntityID.ItemID.BLADE_OF_GRASS:
						return "Spada di erba";
					case EntityID.ItemID.THORN_CHAKRAM:
						return "Artiglio di Chakram";
					case EntityID.ItemID.OBSIDIAN_BRICK:
						return "Mattone di ossidiana";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Teschio di ossidiana";
					case EntityID.ItemID.MUSHROOM_GRASS_SEEDS:
						return "Semi di fungo";
					case EntityID.ItemID.JUNGLE_GRASS_SEEDS:
						return "Semi dell'erba della giungla";
					case EntityID.ItemID.WOODEN_HAMMER:
						return "Martello di legno";
					case EntityID.ItemID.STAR_CANNON:
						return "Cannone stellare";
					case EntityID.ItemID.BLUE_PHASEBLADE:
						return "Spada laser blu";
					case EntityID.ItemID.RED_PHASEBLADE:
						return "Spada laser rossa";
					case EntityID.ItemID.GREEN_PHASEBLADE:
						return "Spada laser verde";
					case EntityID.ItemID.PURPLE_PHASEBLADE:
						return "Spada laser viola";
					case EntityID.ItemID.WHITE_PHASEBLADE:
						return "Spada laser bianca";
					case EntityID.ItemID.YELLOW_PHASEBLADE:
						return "Spada laser gialla";
					case EntityID.ItemID.METEOR_HAMAXE:
						return "Maglio di meteorite";
					case EntityID.ItemID.EMPTY_BUCKET:
						return "Secchio vuoto";
					case EntityID.ItemID.WATER_BUCKET:
						return "Secchio d'acqua";
					case EntityID.ItemID.LAVA_BUCKET:
						return "Secchio di lava";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "Rosa della giungla";
					case EntityID.ItemID.STINGER:
						return "Artiglio";
					case EntityID.ItemID.VINE:
						return "Vite";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Artigli bestiali";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Cavigliera del vento";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Bastone della ricrescita";
					case EntityID.ItemID.HELLSTONE_BRICK:
						return "Mattone di pietra infernale";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "Cuscino rumoroso";
					case EntityID.ItemID.SHACKLE:
						return "Grillo";
					case EntityID.ItemID.MOLTEN_HAMAXE:
						return "Maglio fuso";
					case EntityID.ItemID.FLAMELASH:
						return "Lanciatore di fiamma";
					case EntityID.ItemID.PHOENIX_BLASTER:
						return "Blaster della fenice";
					case EntityID.ItemID.SUNFURY:
						return "Furia del sole";
					case EntityID.ItemID.HELLFORGE:
						return "Creazione degli inferi";
					case EntityID.ItemID.CLAY_POT:
						return "Vaso di argilla";
					case EntityID.ItemID.NATURES_GIFT:
						return "Dono della natura";
					case EntityID.ItemID.BED:
						return "Letto";
					case EntityID.ItemID.SILK:
						return "Seta";
					case EntityID.ItemID.LESSER_RESTORATION_POTION:
						return "Pozione di ripristino inferiore";
					case EntityID.ItemID.RESTORATION_POTION:
						return "Pozione di ripristino";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Cappello della giungla";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Camicia della giungla";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Pantaloni della giungla";
					case EntityID.ItemID.MOLTEN_HELMET:
						return "Casco fuso";
					case EntityID.ItemID.MOLTEN_BREASTPLATE:
						return "Pettorale fuso";
					case EntityID.ItemID.MOLTEN_GREAVES:
						return "Schiniere fuso";
					case EntityID.ItemID.METEOR_SHOT:
						return "Sparo di meteorite";
					case EntityID.ItemID.STICKY_BOMB:
						return "Bomba appiccicosa";
					case EntityID.ItemID.BLACK_LENS:
						return "Lenti nere";
					case EntityID.ItemID.SUNGLASSES:
						return "Occhiali da sole";
					case EntityID.ItemID.WIZARD_HAT:
						return "Cappello dello stregone";
					case EntityID.ItemID.TOP_HAT:
						return "Cilindro";
					case EntityID.ItemID.TUXEDO_SHIRT:
						return "Camicia da smoking";
					case EntityID.ItemID.TUXEDO_PANTS:
						return "Pantaloni da smoking";
					case EntityID.ItemID.SUMMER_HAT:
						return "Cappello estivo";
					case EntityID.ItemID.BUNNY_HOOD:
						return "Cappuccio da coniglio";
					case EntityID.ItemID.PLUMBERS_HAT:
						return "Cappello da idraulico";
					case EntityID.ItemID.PLUMBERS_SHIRT:
						return "Camicia da idraulico";
					case EntityID.ItemID.PLUMBERS_PANTS:
						return "Pantaloni da idraulico";
					case EntityID.ItemID.HEROS_HAT:
						return "Cappello da eroe";
					case EntityID.ItemID.HEROS_SHIRT:
						return "Camicia da eroe";
					case EntityID.ItemID.HEROS_PANTS:
						return "Pantaloni da eroe";
					case EntityID.ItemID.FISH_BOWL:
						return "Boccia dei pesci rossi";
					case EntityID.ItemID.ARCHAEOLOGISTS_HAT:
						return "Cappello da archeologo";
					case EntityID.ItemID.ARCHAEOLOGISTS_JACKET:
						return "Giacca da archeologo";
					case EntityID.ItemID.ARCHAEOLOGISTS_PANTS:
						return "Pantaloni da archeologo";

#if VERSION_INITIAL
					case EntityID.ItemID.BLACK_THREAD:
						return "Tintura nera";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Tintura viola";
#else
					case EntityID.ItemID.BLACK_THREAD:
						return "Abito nero";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Abito viola";
#endif

					case EntityID.ItemID.NINJA_HOOD:
						return "Cappuccio ninja";
					case EntityID.ItemID.NINJA_SHIRT:
						return "Camicia ninja";
					case EntityID.ItemID.NINJA_PANTS:
						return "Pantaloni ninja";
					case EntityID.ItemID.LEATHER:
						return "Pelle";
					case EntityID.ItemID.RED_HAT:
						return "Cappello rosso";
					case EntityID.ItemID.GOLDFISH:
						return "Pesce rosso";
					case EntityID.ItemID.ROBE:
						return "Mantello";
					case EntityID.ItemID.ROBOT_HAT:
						return "Cappello da robot";
					case EntityID.ItemID.GOLD_CROWN:
						return "Corona d'oro";
					case EntityID.ItemID.HELLFIRE_ARROW:
						return "Freccia di fuoco infernale";
					case EntityID.ItemID.SANDGUN:
						return "Pistola di sabbia";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "Bambola voodoo della guida";
					case EntityID.ItemID.DIVING_HELMET:
						return "Casco da sommozzatore";
					case EntityID.ItemID.FAMILIAR_SHIRT:
						return "Camicia comune";
					case EntityID.ItemID.FAMILIAR_PANTS:
						return "Pantaloni comuni";
					case EntityID.ItemID.FAMILIAR_WIG:
						return "Parrucca comune";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Falce demoniaca";
					case EntityID.ItemID.NIGHTS_EDGE:
						return "Confine della notte";
					case EntityID.ItemID.DARK_LANCE:
						return "Lancia oscura";
					case EntityID.ItemID.CORAL:
						return "Corallo";
					case EntityID.ItemID.CACTUS:
						return "Cactus";
					case EntityID.ItemID.TRIDENT:
						return "Tridente";
					case EntityID.ItemID.SILVER_BULLET:
						return "Proiettile d'argento";
					case EntityID.ItemID.THROWING_KNIFE:
						return "Coltello da lancio";
					case EntityID.ItemID.SPEAR:
						return "Lancia";
					case EntityID.ItemID.BLOWPIPE:
						return "Cerbottana";
					case EntityID.ItemID.GLOWSTICK:
						return "Bastone luminoso";
					case EntityID.ItemID.SEED:
						return "Seme";
					case EntityID.ItemID.WOODEN_BOOMERANG:
						return "Boomerang di legno";
					case EntityID.ItemID.AGLET:
						return "Aghetto";
					case EntityID.ItemID.STICKY_GLOWSTICK:
						return "Bastone luminoso appiccicoso";
					case EntityID.ItemID.POISONED_KNIFE:
						return "Coltello avvelenato";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Pozione pelle d'ossidiana";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Pozione rigeneratrice";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Pozione della rapidità";
					case EntityID.ItemID.GILLS_POTION:
						return "Pozione branchie";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Pozione pelle di ferro";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Pozione rigenerazione mana";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Pozione potenza magica";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Pozione caduta dolce";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Pozione speleologo";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Pozione invisibilità";
					case EntityID.ItemID.SHINE_POTION:
						return "Pozione splendore";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Pozione civetta";
					case EntityID.ItemID.BATTLE_POTION:
						return "Pozione battaglia";
					case EntityID.ItemID.THORNS_POTION:
						return "Pozione spine";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Pozione per camminare sull'acqua";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Pozione arciere";
					case EntityID.ItemID.HUNTER_POTION:
						return "Pozione cacciatore";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Pozione gravità";
					case EntityID.ItemID.GOLD_CHEST:
						return "Cassa d'oro";
					case EntityID.ItemID.DAYBLOOM_SEEDS:
						return "Semi Fiordigiorno";
					case EntityID.ItemID.MOONGLOW_SEEDS:
						return "Semi Splendiluna";
					case EntityID.ItemID.BLINKROOT_SEEDS:
						return "Semi Lampeggiaradice";
					case EntityID.ItemID.DEATHWEED_SEEDS:
						return "Semi Erbamorte";
					case EntityID.ItemID.WATERLEAF_SEEDS:
						return "Semi Acquafoglia";
					case EntityID.ItemID.FIREBLOSSOM_SEEDS:
						return "Semi Fiordifuoco";
					case EntityID.ItemID.DAYBLOOM:
						return "Fiordigiorno";
					case EntityID.ItemID.MOONGLOW:
						return "Splendiluna";
					case EntityID.ItemID.BLINKROOT:
						return "Lampeggiaradice";
					case EntityID.ItemID.DEATHWEED:
						return "Erbamorte";
					case EntityID.ItemID.WATERLEAF:
						return "Acquafoglia";
					case EntityID.ItemID.FIREBLOSSOM:
						return "Fiordifuoco";
					case EntityID.ItemID.SHARK_FIN:
						return "Pinna di squalo";
					case EntityID.ItemID.FEATHER:
						return "Piuma";
					case EntityID.ItemID.TOMBSTONE:
						return "Lapide";
					case EntityID.ItemID.MIME_MASK:
						return "Maschera sosia";
					case EntityID.ItemID.ANTLION_MANDIBLE:
						return "Mandibola di formicaleone";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "Parti di pistola illegale";
					case EntityID.ItemID.THE_DOCTORS_SHIRT:
						return "Camicia da medico";
					case EntityID.ItemID.THE_DOCTORS_PANTS:
						return "Pantaloni da medico";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Chiave d'oro";
					case EntityID.ItemID.SHADOW_CHEST:
						return "Cassa ombra";
					case EntityID.ItemID.SHADOW_KEY:
						return "Chiave ombra";
					case EntityID.ItemID.OBSIDIAN_BRICK_WALL:
						return "Muro di ossidiana";
					case EntityID.ItemID.JUNGLE_SPORES:
						return "Spore della giungla";
					case EntityID.ItemID.LOOM:
						return "Telaio";
					case EntityID.ItemID.PIANO:
						return "Pianoforte";
					case EntityID.ItemID.DRESSER:
						return "Cassettone";
					case EntityID.ItemID.BENCH:
						return "Panca";
					case EntityID.ItemID.BATHTUB:
						return "Vasca da bagno";
					case EntityID.ItemID.RED_BANNER:
						return "Stendardo rosso";
					case EntityID.ItemID.GREEN_BANNER:
						return "Stendardo verde";
					case EntityID.ItemID.BLUE_BANNER:
						return "Stendardo blu";
					case EntityID.ItemID.YELLOW_BANNER:
						return "Stendardo giallo";
					case EntityID.ItemID.LAMP_POST:
						return "Lampione";
					case EntityID.ItemID.TIKI_TORCH:
						return "Torcia tiki";
					case EntityID.ItemID.BARREL:
						return "Barile";
					case EntityID.ItemID.CHINESE_LANTERN:
						return "Lanterna cinese";
					case EntityID.ItemID.COOKING_POT:
						return "Pentola";
					case EntityID.ItemID.SAFE:
						return "Caveau";
					case EntityID.ItemID.SKULL_LANTERN:
						return "Lanterna-teschio";
					case EntityID.ItemID.TRASH_CAN:
						return "Bidone";
					case EntityID.ItemID.CANDELABRA:
						return "Candelabro";
					case EntityID.ItemID.PINK_VASE:
						return "Vaso rosa";
					case EntityID.ItemID.MUG:
						return "Boccale";
					case EntityID.ItemID.KEG:
						return "Barilotto";
					case EntityID.ItemID.ALE:
						return "Birra";
					case EntityID.ItemID.BOOKCASE:
						return "Scaffale";
					case EntityID.ItemID.THRONE:
						return "Trono";
					case EntityID.ItemID.BOWL:
						return "Ciotola";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Ciotola di zuppa";
					case EntityID.ItemID.TOILET:
						return "Toilette";
					case EntityID.ItemID.GRANDFATHER_CLOCK:
						return "Pendola";
					case EntityID.ItemID.STATUE:
						return "Statua armatura";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Insegna di battaglia dei goblin";
					case EntityID.ItemID.TATTERED_CLOTH:
						return "Abito a brandelli";
					case EntityID.ItemID.SAWMILL:
						return "Segheria";
					case EntityID.ItemID.COBALT_ORE:
						return "Minerale cobalto";
					case EntityID.ItemID.MYTHRIL_ORE:
						return "Minerale mitrilio";
					case EntityID.ItemID.ADAMANTITE_ORE:
						return "Minerale adamantio";
					case EntityID.ItemID.PWNHAMMER:
						return "Martellone";
					case EntityID.ItemID.EXCALIBUR:
						return "Excalibur";
					case EntityID.ItemID.HALLOWED_SEEDS:
						return "Semi consacrati";
					case EntityID.ItemID.EBONSAND_BLOCK:
						return "Blocco sabbia d'ebano";
					case EntityID.ItemID.COBALT_HAT:
						return "Cappello di cobalto";
					case EntityID.ItemID.COBALT_HELMET:
						return "Casco di cobalto";
					case EntityID.ItemID.COBALT_MASK:
						return "Maschera di cobalto";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Corrazza di cobalto";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Gambali di cobalto";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Cappuccio di mitrilio";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Casco di mitrilio";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Cappello di mitrilio";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Maglia metallica di mitrilio";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Schiniere di mitrilio";
					case EntityID.ItemID.COBALT_BAR:
						return "Barra di cobalto";
					case EntityID.ItemID.MYTHRIL_BAR:
						return "Barra di mitrilio";
					case EntityID.ItemID.COBALT_CHAINSAW:
						return "Motosega di cobalto";
					case EntityID.ItemID.MYTHRIL_CHAINSAW:
						return "Motosega di mitrilio";
					case EntityID.ItemID.COBALT_DRILL:
						return "Perforatrice di cobalto";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Perforatrice di mitrilio";
					case EntityID.ItemID.ADAMANTITE_CHAINSAW:
						return "Motosega di adamantio";
					case EntityID.ItemID.ADAMANTITE_DRILL:
						return "Perforatrice di adamantio";
					case EntityID.ItemID.DAO_OF_POW:
						return "Frustona";
					case EntityID.ItemID.MYTHRIL_HALBERD:
						return "Alabarda di mitrilio";
					case EntityID.ItemID.ADAMANTITE_BAR:
						return "Barra di adamantio";
					case EntityID.ItemID.GLASS_WALL:
						return "Muro di vetro";
					case EntityID.ItemID.COMPASS:
						return "Bussola";
					case EntityID.ItemID.DIVING_GEAR:
						return "Muta da sub";
					case EntityID.ItemID.GPS:
						return "GPS";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Ferro di cavallo di ossidiana";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Scudo di ossidiana";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Laboratorio dell'inventore";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Nuvola in un palloncino";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Copricapo di adamantio";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Casco di adamantio";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Maschera di adamantio";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Corrazza di adamantio";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Gambali di adamantio";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Stivali da fantasma";
					case EntityID.ItemID.ADAMANTITE_GLAIVE:
						return "Alabarda di adamantio";
					case EntityID.ItemID.TOOLBELT:
						return "Cintura porta attrezzi";
					case EntityID.ItemID.PEARLSAND_BLOCK:
						return "Blocco sabbiaperla";
					case EntityID.ItemID.PEARLSTONE_BLOCK:
						return "Blocco pietraperla";
					case EntityID.ItemID.MINING_SHIRT:
						return "Camicia da minatore";
					case EntityID.ItemID.MINING_PANTS:
						return "Pantaloni da minatore";
					case EntityID.ItemID.PEARLSTONE_BRICK:
						return "Mattone pietraperla";
					case EntityID.ItemID.IRIDESCENT_BRICK:
						return "Mattone iridescente";
					case EntityID.ItemID.MUDSTONE_BRICK:
						return "Mattone pietrafango";
					case EntityID.ItemID.COBALT_BRICK:
						return "Mattone cobalto";
					case EntityID.ItemID.MYTHRIL_BRICK:
						return "Mattone mitrilio";
					case EntityID.ItemID.PEARLSTONE_BRICK_WALL:
						return "Muro di pietraperla";
					case EntityID.ItemID.IRIDESCENT_BRICK_WALL:
						return "Muro di mattoni iridescenti";
					case EntityID.ItemID.MUDSTONE_BRICK_WALL:
						return "Muro di pietrafango";
					case EntityID.ItemID.COBALT_BRICK_WALL:
						return "Muro di mattoni di cobalto";
					case EntityID.ItemID.MYTHRIL_BRICK_WALL:
						return "Muro di mattoni di mitrilio";
					case EntityID.ItemID.HOLY_WATER:
						return "Acquasanta";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Acqua profana";
					case EntityID.ItemID.SILT_BLOCK:
						return "Blocco insabbiato";
					case EntityID.ItemID.FAIRY_BELL:
						return "Campana della fata";
					case EntityID.ItemID.BREAKER_BLADE:
						return "Lama del distruttore";
					case EntityID.ItemID.BLUE_TORCH:
						return "Torcia blu";
					case EntityID.ItemID.RED_TORCH:
						return "Torcia rossa";
					case EntityID.ItemID.GREEN_TORCH:
						return "Torcia verde";
					case EntityID.ItemID.PURPLE_TORCH:
						return "Torcia viola";
					case EntityID.ItemID.WHITE_TORCH:
						return "Torcia bianca";
					case EntityID.ItemID.YELLOW_TORCH:
						return "Torcia gialla";
					case EntityID.ItemID.DEMON_TORCH:
						return "Torcia demoniaca";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Fucile d'assalto automatico";
					case EntityID.ItemID.COBALT_REPEATER:
						return "Balestra automatica di cobalto";
					case EntityID.ItemID.MYTHRIL_REPEATER:
						return "Balestra automatica di mitrilio";
					case EntityID.ItemID.DUAL_HOOK:
						return "Gancio doppio";
					case EntityID.ItemID.STAR_STATUE:
						return "Statua stella";
					case EntityID.ItemID.SWORD_STATUE:
						return "Statua spada";
					case EntityID.ItemID.SLIME_STATUE:
						return "Statua slime";
					case EntityID.ItemID.GOBLIN_STATUE:
						return "Statua goblin";
					case EntityID.ItemID.SHIELD_STATUE:
						return "Statua scudo";
					case EntityID.ItemID.BAT_STATUE:
						return "Statua pipistrello";
					case EntityID.ItemID.FISH_STATUE:
						return "Statua pesce";
					case EntityID.ItemID.BUNNY_STATUE:
						return "Statua coniglio";
					case EntityID.ItemID.SKELETON_STATUE:
						return "Statua scheletro";
					case EntityID.ItemID.REAPER_STATUE:
						return "Statua mietitore";
					case EntityID.ItemID.WOMAN_STATUE:
						return "Statua donna";
					case EntityID.ItemID.IMP_STATUE:
						return "Statua diavoletto";
					case EntityID.ItemID.GARGOYLE_STATUE:
						return "Statua gargoyle";
					case EntityID.ItemID.GLOOM_STATUE:
						return "Statua tenebre";
					case EntityID.ItemID.HORNET_STATUE:
						return "Statua calabrone";
					case EntityID.ItemID.BOMB_STATUE:
						return "Statua bomba";
					case EntityID.ItemID.CRAB_STATUE:
						return "Statua granchio";
					case EntityID.ItemID.HAMMER_STATUE:
						return "Statua martello";
					case EntityID.ItemID.POTION_STATUE:
						return "Statua pozione";
					case EntityID.ItemID.SPEAR_STATUE:
						return "Statua arpione";
					case EntityID.ItemID.CROSS_STATUE:
						return "Statua croce";
					case EntityID.ItemID.JELLYFISH_STATUE:
						return "Statua medusa";
					case EntityID.ItemID.BOW_STATUE:
						return "Statua arco";
					case EntityID.ItemID.BOOMERANG_STATUE:
						return "Statua boomerang";
					case EntityID.ItemID.BOOT_STATUE:
						return "Statua stivali";
					case EntityID.ItemID.CHEST_STATUE:
						return "Statua cassa";
					case EntityID.ItemID.BIRD_STATUE:
						return "Statua Uccello";
					case EntityID.ItemID.AXE_STATUE:
						return "Statua ascia";
					case EntityID.ItemID.CORRUPT_STATUE:
						return "Statua corruzione";
					case EntityID.ItemID.TREE_STATUE:
						return "Statua albero";
					case EntityID.ItemID.ANVIL_STATUE:
						return "Statua incudine";
					case EntityID.ItemID.PICKAXE_STATUE:
						return "Statua piccone";
					case EntityID.ItemID.MUSHROOM_STATUE:
						return "Statua fungo";
					case EntityID.ItemID.EYEBALL_STATUE:
						return "Statua bulbo oculare";
					case EntityID.ItemID.PILLAR_STATUE:
						return "Statua colonna";
					case EntityID.ItemID.HEART_STATUE:
						return "Statua cuore";
					case EntityID.ItemID.POT_STATUE:
						return "Statua pentola";
					case EntityID.ItemID.SUNFLOWER_STATUE:
						return "Statua girasole";
					case EntityID.ItemID.KING_STATUE:
						return "Statua re";
					case EntityID.ItemID.QUEEN_STATUE:
						return "Statua regina";
					case EntityID.ItemID.PIRANHA_STATUE:
						return "Statua piranha";
					case EntityID.ItemID.PLANKED_WALL:
						return "Muro impalcato";
					case EntityID.ItemID.WOODEN_BEAM:
						return "Trave di legno";
					case EntityID.ItemID.ADAMANTITE_REPEATER:
						return "Mietitore di adamantio";
					case EntityID.ItemID.ADAMANTITE_SWORD:
						return "Spada di adamantio";
					case EntityID.ItemID.COBALT_SWORD:
						return "Spada di cobalto";
					case EntityID.ItemID.MYTHRIL_SWORD:
						return "Spada di mitrilio";
					case EntityID.ItemID.MOON_CHARM:
						return "Amuleto della luna";
					case EntityID.ItemID.RULER:
						return "Righello";
					case EntityID.ItemID.CRYSTAL_BALL:
						return "Sfera di cristallo";
					case EntityID.ItemID.DISCO_BALL:
						return "Palla disco";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Emblema dell'incantatore";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Emblema del guerriero";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Emblema del guardiaboschi";
					case EntityID.ItemID.DEMON_WINGS:
						return "Ali del demone";
					case EntityID.ItemID.ANGEL_WINGS:
						return "Ali dell'angelo";
					case EntityID.ItemID.MAGICAL_HARP:
						return "Arpa magica";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Bastone dell'arcobaleno";
					case EntityID.ItemID.ICE_ROD:
						return "Bastone di ghiaccio";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Conchiglia di Nettuno";
					case EntityID.ItemID.MANNEQUIN:
						return "Manichino";
					case EntityID.ItemID.GREATER_HEALING_POTION:
						return "Pozione curativa superiore";
					case EntityID.ItemID.GREATER_MANA_POTION:
						return "Pozione mana superiore";
					case EntityID.ItemID.PIXIE_DUST:
						return "Polvere di fata";
					case EntityID.ItemID.CRYSTAL_SHARD:
						return "Frammento di cristallo";
					case EntityID.ItemID.CLOWN_HAT:
						return "Cappello da clown";
					case EntityID.ItemID.CLOWN_SHIRT:
						return "Camicia da clown";
					case EntityID.ItemID.CLOWN_PANTS:
						return "Pantaloni da clown";
					case EntityID.ItemID.FLAMETHROWER:
						return "Lanciafiamme";
					case EntityID.ItemID.BELL:
						return "Campana";
					case EntityID.ItemID.HARP:
						return "Arpa";
					case EntityID.ItemID.WRENCH:
						return "Chiave inglese";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Tagliacavi";
					case EntityID.ItemID.ACTIVE_STONE_BLOCK:
						return "Blocco di pietra attivo";
					case EntityID.ItemID.INACTIVE_STONE_BLOCK:
						return "Blocco di pietra non attivo";
					case EntityID.ItemID.LEVER:
						return "Leva";
					case EntityID.ItemID.LASER_RIFLE:
						return "Fucile laser";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Proiettile di cristallo";
					case EntityID.ItemID.HOLY_ARROW:
						return "Freccia sacra";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Pugnale magico";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Tempesta di cristallo";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Fiamme maledette";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "Anima della luce";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "Anima della notte";
					case EntityID.ItemID.CURSED_FLAME:
						return "Fiamma maledetta";
					case EntityID.ItemID.CURSED_TORCH:
						return "Torcia maledetta";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Forgia di adamantio";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Incudine di mitrilio";
					case EntityID.ItemID.UNICORN_HORN:
						return "Corno di unicorno";
					case EntityID.ItemID.DARK_SHARD:
						return "Frammento oscuro";
					case EntityID.ItemID.LIGHT_SHARD:
						return "Frammento di luce";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Piastra a pressione rossa";
					case EntityID.ItemID.WIRE:
						return "Cavo";
					case EntityID.ItemID.SPELL_TOME:
						return "Tomo incantato";
					case EntityID.ItemID.STAR_CLOAK:
						return "Mantello stellato";
					case EntityID.ItemID.MEGASHARK:
						return "Megashark";
					case EntityID.ItemID.SHOTGUN:
						return "Fucile";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Pietra filosofale";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Guanto del Titano";
					case EntityID.ItemID.COBALT_NAGINATA:
						return "Naginata di cobalto";
					case EntityID.ItemID.SWITCH:
						return "Interruttore";
					case EntityID.ItemID.DART_TRAP:
						return "Trappola dardi";
					case EntityID.ItemID.BOULDER:
						return "Masso";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Piastra a pressione verde";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Piastra a pressione grigia";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Piastra a pressione marrone";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Occhio meccanico";
					case EntityID.ItemID.CURSED_ARROW:
						return "Freccia maledetta";
					case EntityID.ItemID.CURSED_BULLET:
						return "Proiettile maledetto";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "Anima del terrore";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "Anima del potere";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "Anima della visione";
					case EntityID.ItemID.GUNGNIR:
						return "Gungnir";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Armatura sacra";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Schiniere sacro";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Casco sacro";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Collana con croce";
					case EntityID.ItemID.MANA_FLOWER:
						return "Fiore di mana";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Verme meccanico";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Teschio meccanico";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Copricapo sacro";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Maschera sacra";
					case EntityID.ItemID.SLIME_CROWN:
						return "Corona slime";
					case EntityID.ItemID.LIGHT_DISC:
						return "Disco di luce";
					case EntityID.ItemID.MUSIC_BOX_OVERWORLD_DAY:
						return "Carillon (Giornata mondiale)";
					case EntityID.ItemID.MUSIC_BOX_EERIE:
						return "Carillon (Mistero)";
					case EntityID.ItemID.MUSIC_BOX_NIGHT:
						return "Carillon (Notte)";
					case EntityID.ItemID.MUSIC_BOX_TITLE:
						return "Carillon (Titolo)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND:
						return "Carillon (Sotterraneo)";
					case EntityID.ItemID.MUSIC_BOX_BOSS1:
						return "Carillon (Boss 1)";
					case EntityID.ItemID.MUSIC_BOX_JUNGLE:
						return "Carillon (Giungla)";
					case EntityID.ItemID.MUSIC_BOX_CORRUPTION:
						return "Carillon (Corruzione)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_CORRUPTION:
						return "Carillon (Corruzione sotterranea)";
					case EntityID.ItemID.MUSIC_BOX_THE_HALLOW:
						return "Carillon (La Consacrazione)";
					case EntityID.ItemID.MUSIC_BOX_BOSS2:
						return "Carillon (Boss 2)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_HALLOW:
						return "Carillon (Consacrazione sotterranea)";
					case EntityID.ItemID.MUSIC_BOX_BOSS3:
						return "Carillon (Boss 3)";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "Anima del volo";
					case EntityID.ItemID.MUSIC_BOX:
						return "Carillon";
					case EntityID.ItemID.DEMONITE_BRICK:
						return "Mattone demoniaco";
					case EntityID.ItemID.HALLOWED_REPEATER:
						return "Balestra automatica consacrata";
					case EntityID.ItemID.HAMDRAX:
						return "Perforascia";
					case EntityID.ItemID.EXPLOSIVES:
						return "Esplosivi";
					case EntityID.ItemID.INLET_PUMP:
						return "Pompa interna";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Pompa esterna";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "Timer 1 secondo";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "Timer 3 secondi";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "Timer 5 secondi";
					case EntityID.ItemID.CANDY_CANE_BLOCK:
						return "Blocco Candy Cane";
					case EntityID.ItemID.CANDY_CANE_WALL:
						return "Muro Candy Cane";
					case EntityID.ItemID.SANTA_HAT:
						return "Cappello di Babbo Natale";
					case EntityID.ItemID.SANTA_SHIRT:
						return "Camicia di Babbo Natale";
					case EntityID.ItemID.SANTA_PANTS:
						return "Pantaloni di Babbo Natale";
					case EntityID.ItemID.GREEN_CANDY_CANE_BLOCK:
						return "Blocco verde Candy Cane";
					case EntityID.ItemID.GREEN_CANDY_CANE_WALL:
						return "Muro verde Candy Cane";
					case EntityID.ItemID.SNOW_BLOCK:
						return "Blocco di neve";
					case EntityID.ItemID.SNOW_BRICK:
						return "Mattone di neve";
					case EntityID.ItemID.SNOW_BRICK_WALL:
						return "Muro di mattoni di neve";
					case EntityID.ItemID.BLUE_LIGHT:
						return "Luce blu";
					case EntityID.ItemID.RED_LIGHT:
						return "Luce rossa";
					case EntityID.ItemID.GREEN_LIGHT:
						return "Luce verde";
					case EntityID.ItemID.BLUE_PRESENT:
						return "Regalo blu";
					case EntityID.ItemID.GREEN_PRESENT:
						return "Regalo verde";
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Regalo giallo ";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Sfera di neve";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Cavolo";
					case EntityID.ItemID.DRAGON_MASK:
						return "Maschera del Drago";
					case EntityID.ItemID.TITAN_HELMET:
						return "Casco del Titano";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Copricapo spettrale";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Corazza del Drago";
					case EntityID.ItemID.TITAN_MAIL:
						return "Armatura del Titano";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Armatura spettrale";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Schinieri del Drago";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Gambali del Titano";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Subligar spettrale";
					case EntityID.ItemID.TIZONA:
						return "Tizona";
					case EntityID.ItemID.TONBOGIRI:
						return "Tonbogiri";
					case EntityID.ItemID.SHARANGA:
						return "Sharanga";
					case EntityID.ItemID.SPECTRAL_ARROW:
						return "Freccia spettrale";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Balestra vulcanica";
					case EntityID.ItemID.VULCAN_BOLT:
						return "Dardo vulcanico";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Teschio dallo sguardo sospetto";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "Anima della luce";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Capsula di Petri";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Nido d'ape";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Fiala di sangue";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Zanna di lupo";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Cervello";
					case EntityID.ItemID.MUSIC_BOX_DESERT:
						return "Carillon (Deserto)";
					case EntityID.ItemID.MUSIC_BOX_SPACE:
						return "Carillon (Spazio)";
					case EntityID.ItemID.MUSIC_BOX_TUTORIAL:
						return "Carillon (Tutorial)";
					case EntityID.ItemID.MUSIC_BOX_BOSS4:
						return "Carillon (Boss 4)";
					case EntityID.ItemID.MUSIC_BOX_OCEAN:
						return "Carillon (Oceano)";
					case EntityID.ItemID.MUSIC_BOX_SNOW:
						return "Carillon (Neve)";
#if VERSION_101
					case EntityID.ItemID.FABULOUS_RIBBON:
						return "Nastro favoloso";
					case EntityID.ItemID.GEORGES_HAT:
						return "Cappello di George";
					case EntityID.ItemID.FABULOUS_TUTU:
						return "Tutù favoloso";
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
						return "Camicia da smoking di George";
					case EntityID.ItemID.FABULOUS_SLIPPERS:
						return "Pantofole favolose";
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Pantaloni da smoking di George";
					case EntityID.ItemID.SPARKLY_WINGS:
						return "Ali scintillanti";
					case EntityID.ItemID.CAMPFIRE:
						return "Fuoco di bivacco";
					case EntityID.ItemID.WOOD_HELMET:
						return "Casco di legno";
					case EntityID.ItemID.WOOD_BREASTPLATE:
						return "Pettorale di legno";
					case EntityID.ItemID.WOOD_GREAVES:
						return "Schiniere di legno";
					case EntityID.ItemID.CACTUS_SWORD:
						return "Spada di cactus";
					case EntityID.ItemID.CACTUS_PICKAXE:
						return "Piccone di cactus";
					case EntityID.ItemID.CACTUS_HELMET:
						return "Casco di cactus";
					case EntityID.ItemID.CACTUS_BREASTPLATE:
						return "Pettorale di cactus";
					case EntityID.ItemID.CACTUS_LEGGINGS:
						return "Gambali di cactus";
					case EntityID.ItemID.PURPLE_STAINED_GLASS_WALL:
						return "Vetro viola";
					case EntityID.ItemID.YELLOW_STAINED_GLASS_WALL:
						return "Vetro giallo";
					case EntityID.ItemID.BLUE_STAINED_GLASS_WALL:
						return "Vetro blu";
					case EntityID.ItemID.GREEN_STAINED_GLASS_WALL:
						return "Vetro verde";
					case EntityID.ItemID.RED_STAINED_GLASS_WALL:
						return "Vetro rosso";
					case EntityID.ItemID.MULTICOLORED_STAINED_GLASS_WALL:
						return "Vetro variopinto";
#endif
				}
			}
			else if (LangOption == (int)ID.FRENCH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Pioche en or";
					case EntityID.ItemID.GOLD_BROADSWORD:
						return "Épée longue en or";
					case EntityID.ItemID.GOLD_SHORTSWORD:
						return "Épée courte en or";
					case EntityID.ItemID.GOLD_AXE:
						return "Hache en or";
					case EntityID.ItemID.GOLD_HAMMER:
						return "Marteau en or";
					case EntityID.ItemID.GOLD_BOW:
						return "Arc en or";
					case EntityID.ItemID.SILVER_PICKAXE:
						return "Pioche en argent";
					case EntityID.ItemID.SILVER_BROADSWORD:
						return "Épée longue en argent";
					case EntityID.ItemID.SILVER_SHORTSWORD:
						return "Épée courte en argent";
					case EntityID.ItemID.SILVER_AXE:
						return "Hache en argent";
					case EntityID.ItemID.SILVER_HAMMER:
						return "Marteau en argent";
					case EntityID.ItemID.SILVER_BOW:
						return "Arc en argent";
					case EntityID.ItemID.COPPER_PICKAXE:
						return "Pioche en cuivre";
					case EntityID.ItemID.COPPER_BROADSWORD:
						return "Épée longue en cuivre";
					case EntityID.ItemID.COPPER_SHORTSWORD:
						return "Épée courte en cuivre";
					case EntityID.ItemID.COPPER_AXE:
						return "Hache en cuivre";
					case EntityID.ItemID.COPPER_HAMMER:
						return "Marteau en cuivre";
					case EntityID.ItemID.COPPER_BOW:
						return "Arc en cuivre";
					case EntityID.ItemID.BLUE_PHASESABER:
						return "Sabre laser bleu";
					case EntityID.ItemID.RED_PHASESABER:
						return "Sabre laser rouge";
					case EntityID.ItemID.GREEN_PHASESABER:
						return "Sabre laser vert";
					case EntityID.ItemID.PURPLE_PHASESABER:
						return "Sabre laser violet";
					case EntityID.ItemID.WHITE_PHASESABER:
						return "Sabre laser blanc";
					case EntityID.ItemID.YELLOW_PHASESABER:
						return "Sabre laser jaune";
					case EntityID.ItemID.IRON_PICKAXE:
						return "Pioche en fer";
					case EntityID.ItemID.DIRT_BLOCK:
						return "Bloc de terre";
					case EntityID.ItemID.STONE_BLOCK:
						return "Bloc de pierre";
					case EntityID.ItemID.IRON_BROADSWORD:
						return "Épée longue en fer";
					case EntityID.ItemID.MUSHROOM:
						return "Champignon";
					case EntityID.ItemID.IRON_SHORTSWORD:
						return "Épée courte en fer";
					case EntityID.ItemID.IRON_HAMMER:
						return "Marteau en fer";
					case EntityID.ItemID.TORCH:
						return "Torche";
					case EntityID.ItemID.WOOD:
						return "Bois";
					case EntityID.ItemID.IRON_AXE:
						return "Hache en fer";
					case EntityID.ItemID.IRON_ORE:
						return "Minerai de fer";
					case EntityID.ItemID.COPPER_ORE:
						return "Minerai de cuivre";
					case EntityID.ItemID.GOLD_ORE:
						return "Minerai d'or";
					case EntityID.ItemID.SILVER_ORE:
						return "Minerai d'argent";
					case EntityID.ItemID.COPPER_WATCH:
						return "Montre en cuivre";
					case EntityID.ItemID.SILVER_WATCH:
						return "Montre en argent";
					case EntityID.ItemID.GOLD_WATCH:
						return "Montre en or";
					case EntityID.ItemID.DEPTH_METER:
						return "Altimètre";
					case EntityID.ItemID.GOLD_BAR:
						return "Lingot d'or";
					case EntityID.ItemID.COPPER_BAR:
						return "Lingot de cuivre";
					case EntityID.ItemID.SILVER_BAR:
						return "Lingot d'argent";
					case EntityID.ItemID.IRON_BAR:
						return "Lingot de fer";
					case EntityID.ItemID.GEL:
						return "Gel";
					case EntityID.ItemID.WOODEN_SWORD:
						return "Épée en bois";
					case EntityID.ItemID.WOODEN_DOOR:
						return "Porte en bois";
					case EntityID.ItemID.STONE_WALL:
						return "Mur en pierre";
					case EntityID.ItemID.ACORN:
						return "Gland";
					case EntityID.ItemID.LESSER_HEALING_POTION:
						return "Faible potion de soin";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Cristal de vie";
					case EntityID.ItemID.DIRT_WALL:
						return "Mur en terre";
					case EntityID.ItemID.BOTTLE:
						return "Bouteille";
					case EntityID.ItemID.WOODEN_TABLE:
						return "Table en bois";
					case EntityID.ItemID.FURNACE:
						return "Fournaise";
					case EntityID.ItemID.WOODEN_CHAIR:
						return "Chaise en bois";
					case EntityID.ItemID.IRON_ANVIL:
						return "Enclume";
					case EntityID.ItemID.WORK_BENCH:
						return "Établi";
					case EntityID.ItemID.GOGGLES:
						return "Lunettes";
					case EntityID.ItemID.LENS:
						return "Lentille";
					case EntityID.ItemID.WOODEN_BOW:
						return "Arc en bois";
					case EntityID.ItemID.WOODEN_ARROW:
						return "Flèche en bois";
					case EntityID.ItemID.FLAMING_ARROW:
						return "Flèche enflammée";
					case EntityID.ItemID.SHURIKEN:
						return "Shuriken";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Œil observateur suspicieux";
					case EntityID.ItemID.DEMON_BOW:
						return "Arc démoniaque";
					case EntityID.ItemID.WAR_AXE_OF_THE_NIGHT:
						return "Hache de guerre de la nuit";
					case EntityID.ItemID.LIGHTS_BANE:
						return "Fléau de lumière";
					case EntityID.ItemID.UNHOLY_ARROW:
						return "Flèche impie";
					case EntityID.ItemID.CHEST:
						return "Coffre";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Anneau de régénération";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Miroir magique";
					case EntityID.ItemID.JESTERS_ARROW:
						return "Flèche du bouffon";
					case EntityID.ItemID.ANGEL_STATUE:
						return "Statue d'ange";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Nuage en bouteille";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Bottes d'Hermès";
					case EntityID.ItemID.ENCHANTED_BOOMERANG:
						return "Boomerang enchanté";
					case EntityID.ItemID.DEMONITE_ORE:
						return "Barre de démonite";
					case EntityID.ItemID.DEMONITE_BAR:
						return "Lingot de démonite";
					case EntityID.ItemID.HEART:
						return "Pilier";
					case EntityID.ItemID.CORRUPT_SEEDS:
						return "Graines corrompues";
					case EntityID.ItemID.VILE_MUSHROOM:
						return "Champignon infect";
					case EntityID.ItemID.EBONSTONE_BLOCK:
						return "Bloc d'ébonite";
					case EntityID.ItemID.GRASS_SEEDS:
						return "Graines d'herbe";
					case EntityID.ItemID.SUNFLOWER:
						return "Tournesols";
					case EntityID.ItemID.VILETHORN:
						return "Vileronce";
					case EntityID.ItemID.STARFURY:
						return "Furie stellaire";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Poudre de purification";
					case EntityID.ItemID.VILE_POWDER:
						return "Poudre infecte";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "Morceau pourri";
					case EntityID.ItemID.WORM_TOOTH:
						return "Dent de ver";
					case EntityID.ItemID.WORM_FOOD:
						return "Nourriture pour ver";
					case EntityID.ItemID.COPPER_COIN:
						return "Pièce de cuivre";
					case EntityID.ItemID.SILVER_COIN:
						return "Pièce d'argent";
					case EntityID.ItemID.GOLD_COIN:
						return "Pièce d'or";
					case EntityID.ItemID.PLATINUM_COIN:
						return "Pièce de platine";
					case EntityID.ItemID.FALLEN_STAR:
						return "Étoile filante";
					case EntityID.ItemID.COPPER_GREAVES:
						return "Jambières en cuivre";
					case EntityID.ItemID.IRON_GREAVES:
						return "Jambières en fer";
					case EntityID.ItemID.SILVER_GREAVES:
						return "Jambières en argent";
					case EntityID.ItemID.GOLD_GREAVES:
						return "Jambière en or";
					case EntityID.ItemID.COPPER_CHAINMAIL:
						return "Cotte de mailles en cuivre";
					case EntityID.ItemID.IRON_CHAINMAIL:
						return "Cotte de mailles en fer";
					case EntityID.ItemID.SILVER_CHAINMAIL:
						return "Cotte de mailles en argent";
					case EntityID.ItemID.GOLD_CHAINMAIL:
						return "Cotte de mailles en or";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "Grappin";
					case EntityID.ItemID.CHAIN:
						return "Chaîne en fer";
					case EntityID.ItemID.SHADOW_SCALE:
						return "Écaille sombre";
					case EntityID.ItemID.PIGGY_BANK:
						return "Tirelire";
					case EntityID.ItemID.MINING_HELMET:
						return "Casque de mineur";
					case EntityID.ItemID.COPPER_HELMET:
						return "Casque en cuivre";
					case EntityID.ItemID.IRON_HELMET:
						return "Casque en fer";
					case EntityID.ItemID.SILVER_HELMET:
						return "Casque en argent";
					case EntityID.ItemID.GOLD_HELMET:
						return "Casque en or";
					case EntityID.ItemID.WOOD_WALL:
						return "Mur en bois";
					case EntityID.ItemID.WOOD_PLATFORM:
						return "Plateforme en bois";
					case EntityID.ItemID.FLINTLOCK_PISTOL:
						return "Pistolet à silex";
					case EntityID.ItemID.MUSKET:
						return "Mousquet";
					case EntityID.ItemID.MUSKET_BALL:
						return "Balle de mousquet";
					case EntityID.ItemID.MINISHARK:
						return "Minishark";
					case EntityID.ItemID.IRON_BOW:
						return "Arc en fer";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Jambières de l'ombre";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Armure d'écailles de l'ombre";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Casque de l'ombre";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Pioche cauchemardesque";
					case EntityID.ItemID.THE_BREAKER:
						return "Le briseur";
					case EntityID.ItemID.CANDLE:
						return "Bougie";
					case EntityID.ItemID.COPPER_CHANDELIER:
						return "Chandelier en cuivre";
					case EntityID.ItemID.SILVER_CHANDELIER:
						return "Chandelier en argent";
					case EntityID.ItemID.GOLD_CHANDELIER:
						return "Chandelier en or";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Cristal de mana";
					case EntityID.ItemID.LESSER_MANA_POTION:
						return "Faible potion de mana";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Anneau de pouvoir stellaire";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Fleur de feu";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Missile magique";
					case EntityID.ItemID.DIRT_ROD:
						return "Bâtonnet de terre";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Orbe de lumière";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Orbe d'ombre";
#endif
					case EntityID.ItemID.METEORITE:
						return "Météorite";
					case EntityID.ItemID.METEORITE_BAR:
						return "Barre de météorite";
					case EntityID.ItemID.HOOK:
						return "Crochet";
					case EntityID.ItemID.FLAMARANG:
						return "Flamarang";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Furie en fusion";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "Grande épée ardente";
					case EntityID.ItemID.MOLTEN_PICKAXE:
						return "Pioche en fusion";
					case EntityID.ItemID.METEOR_HELMET:
						return "Casque de météore";
					case EntityID.ItemID.METEOR_SUIT:
						return "Costume de météore";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Leggings de météores";
					case EntityID.ItemID.BOTTLED_WATER:
						return "Eau en bouteille";
					case EntityID.ItemID.SPACE_GUN:
						return "Arme d'espace";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Bottes-fusées";
					case EntityID.ItemID.GRAY_BRICK:
						return "Brique grise";
					case EntityID.ItemID.GRAY_BRICK_WALL:
						return "Mur de briques grises";
					case EntityID.ItemID.RED_BRICK:
						return "Brique rouge";
					case EntityID.ItemID.RED_BRICK_WALL:
						return "Mur de briques rouges";
					case EntityID.ItemID.CLAY_BLOCK:
						return "Bloc d'argile";
					case EntityID.ItemID.BLUE_BRICK:
						return "Brique bleue";
					case EntityID.ItemID.BLUE_BRICK_WALL:
						return "Mur de briques bleues";
					case EntityID.ItemID.CHAIN_LANTERN:
						return "Lanterne à chaîne";
					case EntityID.ItemID.GREEN_BRICK:
						return "Brique verte";
					case EntityID.ItemID.GREEN_BRICK_WALL:
						return "Mur de briques vertes";
					case EntityID.ItemID.PINK_BRICK:
						return "Brique rose";
					case EntityID.ItemID.PINK_BRICK_WALL:
						return "Mur de briques roses";
					case EntityID.ItemID.GOLD_BRICK:
						return "Brique dorée";
					case EntityID.ItemID.GOLD_BRICK_WALL:
						return "Mur de briques dorées";
					case EntityID.ItemID.SILVER_BRICK:
						return "Brique argentée";
					case EntityID.ItemID.SILVER_BRICK_WALL:
						return "Mur de briques argentées";
					case EntityID.ItemID.COPPER_BRICK:
						return "Brique cuivrée";
					case EntityID.ItemID.COPPER_BRICK_WALL:
						return "Mur de briques cuivrées";
					case EntityID.ItemID.SPIKE:
						return "Pointe";
					case EntityID.ItemID.WATER_CANDLE:
						return "Bougie d'eau";
					case EntityID.ItemID.BOOK:
						return "Livre";
					case EntityID.ItemID.COBWEB:
						return "Toile d'araignée";
					case EntityID.ItemID.NECRO_HELMET:
						return "Casque nécro";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Plastron nécro";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Jambières nécro";
					case EntityID.ItemID.BONE:
						return "Os";
					case EntityID.ItemID.MURAMASA:
						return "Muramasa";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Bouclier de cobalt";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Sceptre aquatique";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Fer à cheval porte-bonheur";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Ballon rouge brillant";
					case EntityID.ItemID.HARPOON:
						return "Harpon";
					case EntityID.ItemID.SPIKY_BALL:
						return "Balle hérissée";
					case EntityID.ItemID.BALL_O_HURT:
						return "Ball O' Hurt";
					case EntityID.ItemID.BLUE_MOON:
						return "Lune bleue";
					case EntityID.ItemID.HANDGUN:
						return "Pistolet";
					case EntityID.ItemID.WATER_BOLT:
						return "Trait d'eau";
					case EntityID.ItemID.BOMB:
						return "Bombe";
					case EntityID.ItemID.DYNAMITE:
						return "Dynamite";
					case EntityID.ItemID.GRENADE:
						return "Grenade";
					case EntityID.ItemID.SAND_BLOCK:
						return "Bloc de sable";
					case EntityID.ItemID.GLASS:
						return "Verre";
					case EntityID.ItemID.SIGN:
						return "Panneau";
					case EntityID.ItemID.ASH_BLOCK:
						return "Bloc de cendre";
					case EntityID.ItemID.OBSIDIAN:
						return "Obsidienne";
					case EntityID.ItemID.HELLSTONE:
						return "Pierre de l'enfer";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "Barre de pierre de l'enfer";
					case EntityID.ItemID.MUD_BLOCK:
						return "Bloc de boue";
					case EntityID.ItemID.SAPPHIRE:
						return "Saphir";
					case EntityID.ItemID.RUBY:
						return "Rubis";
					case EntityID.ItemID.EMERALD:
						return "Émeraude";
					case EntityID.ItemID.TOPAZ:
						return "Topaze";
					case EntityID.ItemID.AMETHYST:
						return "Améthyste";
					case EntityID.ItemID.DIAMOND:
						return "Diamant";
					case EntityID.ItemID.GLOWING_MUSHROOM:
						return "Champignon lumineux";
					case EntityID.ItemID.STAR:
						return "Étoile";
					case EntityID.ItemID.IVY_WHIP:
						return "Grappin à lianes";
					case EntityID.ItemID.BREATHING_REED:
						return "Tuba";
					case EntityID.ItemID.FLIPPER:
						return "Palmes";
					case EntityID.ItemID.HEALING_POTION:
						return "Potion de soins";
					case EntityID.ItemID.MANA_POTION:
						return "Potion de mana";
					case EntityID.ItemID.BLADE_OF_GRASS:
						return "Lame d'herbe";
					case EntityID.ItemID.THORN_CHAKRAM:
						return "Chakram d'épines";
					case EntityID.ItemID.OBSIDIAN_BRICK:
						return "Brique d'obsidienne";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Crâne d'obsidienne";
					case EntityID.ItemID.MUSHROOM_GRASS_SEEDS:
						return "Graines de champignon";
					case EntityID.ItemID.JUNGLE_GRASS_SEEDS:
						return "Graines de la jungle";
					case EntityID.ItemID.WOODEN_HAMMER:
						return "Marteau en bois";
					case EntityID.ItemID.STAR_CANNON:
						return "Canon à étoiles";
					case EntityID.ItemID.BLUE_PHASEBLADE:
						return "Sabre laser bleu";
					case EntityID.ItemID.RED_PHASEBLADE:
						return "Sabre laser rouge";
					case EntityID.ItemID.GREEN_PHASEBLADE:
						return "Sabre laser vert";
					case EntityID.ItemID.PURPLE_PHASEBLADE:
						return "Sabre laser violet";
					case EntityID.ItemID.WHITE_PHASEBLADE:
						return "Sabre laser blanc";
					case EntityID.ItemID.YELLOW_PHASEBLADE:
						return "Sabre laser jaune";
					case EntityID.ItemID.METEOR_HAMAXE:
						return "Martache en météorite";
					case EntityID.ItemID.EMPTY_BUCKET:
						return "Seau vide";
					case EntityID.ItemID.WATER_BUCKET:
						return "Seau d'eau";
					case EntityID.ItemID.LAVA_BUCKET:
						return "Seau de lave";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "Rose de la jungle";
					case EntityID.ItemID.STINGER:
						return "Dard";
					case EntityID.ItemID.VINE:
						return "Vigne";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Griffes sauvages";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Bracelet du vent";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Crosse de repousse";
					case EntityID.ItemID.HELLSTONE_BRICK:
						return "Brique de pierre de l'enfer";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "Coussin péteur";
					case EntityID.ItemID.SHACKLE:
						return "Manille";
					case EntityID.ItemID.MOLTEN_HAMAXE:
						return "Martache en fusion";
					case EntityID.ItemID.FLAMELASH:
						return "Mèche enflammée";
					case EntityID.ItemID.PHOENIX_BLASTER:
						return "Blaster phénix";
					case EntityID.ItemID.SUNFURY:
						return "Furie solaire";
					case EntityID.ItemID.HELLFORGE:
						return "Forge infernale";
					case EntityID.ItemID.CLAY_POT:
						return "Pot d'argile";
					case EntityID.ItemID.NATURES_GIFT:
						return "Don de la nature";
					case EntityID.ItemID.BED:
						return "Lit";
					case EntityID.ItemID.SILK:
						return "Soie";
					case EntityID.ItemID.LESSER_RESTORATION_POTION:
						return "Faible potion de restauration";
					case EntityID.ItemID.RESTORATION_POTION:
						return "Potion de restauration";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Casque de la jungle";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Plastron de la jungle";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Jambières de la jungle";
					case EntityID.ItemID.MOLTEN_HELMET:
						return "Casque en fusion";
					case EntityID.ItemID.MOLTEN_BREASTPLATE:
						return "Plastron en fusion";
					case EntityID.ItemID.MOLTEN_GREAVES:
						return "Jambières en fusion";
					case EntityID.ItemID.METEOR_SHOT:
						return "Balle météore";
					case EntityID.ItemID.STICKY_BOMB:
						return "Bombe collante";
					case EntityID.ItemID.BLACK_LENS:
						return "Lentille noire";
					case EntityID.ItemID.SUNGLASSES:
						return "Lunettes de soleil";
					case EntityID.ItemID.WIZARD_HAT:
						return "Chapeau de magicien";
					case EntityID.ItemID.TOP_HAT:
						return "Haut de forme";
					case EntityID.ItemID.TUXEDO_SHIRT:
						return "Veste de smoking";
					case EntityID.ItemID.TUXEDO_PANTS:
						return "Pantalon de smoking";
					case EntityID.ItemID.SUMMER_HAT:
						return "Chapeau d'été";
					case EntityID.ItemID.BUNNY_HOOD:
						return "Capuche de lapin";
					case EntityID.ItemID.PLUMBERS_HAT:
						return "Casquette de plombier";
					case EntityID.ItemID.PLUMBERS_SHIRT:
						return "Veste de plombier";
					case EntityID.ItemID.PLUMBERS_PANTS:
						return "Pantalon de plombier";
					case EntityID.ItemID.HEROS_HAT:
						return "Capuche de héros";
					case EntityID.ItemID.HEROS_SHIRT:
						return "Veste de héros";
					case EntityID.ItemID.HEROS_PANTS:
						return "Pantalon de héros";
					case EntityID.ItemID.FISH_BOWL:
						return "Bocal à poissons";
					case EntityID.ItemID.ARCHAEOLOGISTS_HAT:
						return "Chapeau d'archéologue";
					case EntityID.ItemID.ARCHAEOLOGISTS_JACKET:
						return "Veste d'archéologue";
					case EntityID.ItemID.ARCHAEOLOGISTS_PANTS:
						return "Pantalon d'archéologue";
#if VERSION_INITIAL
					case EntityID.ItemID.BLACK_THREAD:
						return "Teinture noire";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Teinture mauve";
#else
					case EntityID.ItemID.BLACK_THREAD:
						return "Fil noir";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Fil violet";
#endif
					case EntityID.ItemID.NINJA_HOOD:
						return "Cagoule de ninja";
					case EntityID.ItemID.NINJA_SHIRT:
						return "Veste de ninja";
					case EntityID.ItemID.NINJA_PANTS:
						return "Pantalon de ninja";
					case EntityID.ItemID.LEATHER:
						return "Cuir";
					case EntityID.ItemID.RED_HAT:
						return "Chapeau rouge";
					case EntityID.ItemID.GOLDFISH:
						return "Poisson rouge";
					case EntityID.ItemID.ROBE:
						return "Robe";
					case EntityID.ItemID.ROBOT_HAT:
						return "Chapeau de robot";
					case EntityID.ItemID.GOLD_CROWN:
						return "Couronne d'or";
					case EntityID.ItemID.HELLFIRE_ARROW:
						return "Flèche du feu de l'enfer";
					case EntityID.ItemID.SANDGUN:
						return "Canon à sable";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "Poupée vaudou du guide";
					case EntityID.ItemID.DIVING_HELMET:
						return "Casque de plongée";
					case EntityID.ItemID.FAMILIAR_SHIRT:
						return "Chemise familière";
					case EntityID.ItemID.FAMILIAR_PANTS:
						return "Pantalon familier";
					case EntityID.ItemID.FAMILIAR_WIG:
						return "Perruque familière";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Faux de démon";
					case EntityID.ItemID.NIGHTS_EDGE:
						return "Fil des Ténèbres";
					case EntityID.ItemID.DARK_LANCE:
						return "Lance sombre";
					case EntityID.ItemID.CORAL:
						return "Corail";
					case EntityID.ItemID.CACTUS:
						return "Cactus";
					case EntityID.ItemID.TRIDENT:
						return "Trident";
					case EntityID.ItemID.SILVER_BULLET:
						return "Balle d'argent";
					case EntityID.ItemID.THROWING_KNIFE:
						return "Couteau de lancer";
					case EntityID.ItemID.SPEAR:
						return "Lance";
					case EntityID.ItemID.BLOWPIPE:
						return "Sarbacane";
					case EntityID.ItemID.GLOWSTICK:
						return "Bâton lumineux";
					case EntityID.ItemID.SEED:
						return "Graine";
					case EntityID.ItemID.WOODEN_BOOMERANG:
						return "Boomerang en bois";
					case EntityID.ItemID.AGLET:
						return "Embout de lacet";
					case EntityID.ItemID.STICKY_GLOWSTICK:
						return "Bâton lumineux collant";
					case EntityID.ItemID.POISONED_KNIFE:
						return "Couteau empoisonné";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Potion de peau d'obsidienne";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Potion de régénération";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Potion de rapidité";
					case EntityID.ItemID.GILLS_POTION:
						return "Potion de branchies";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Potion de peau de fer";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Potion de régénération de mana";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Potion de pouvoir magique";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Potion de poids plume";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Potion de spéléologue";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Potion d'invisibilité";
					case EntityID.ItemID.SHINE_POTION:
						return "Potion de brillance";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Potion de vision nocturne";
					case EntityID.ItemID.BATTLE_POTION:
						return "Potion de bataille";
					case EntityID.ItemID.THORNS_POTION:
						return "Potion d'épines";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Potion de marche sur l'eau";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Potion de tir à l'arc";
					case EntityID.ItemID.HUNTER_POTION:
						return "Potion du chasseur";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Potion de gravité";
					case EntityID.ItemID.GOLD_CHEST:
						return "Coffre d'or";
					case EntityID.ItemID.DAYBLOOM_SEEDS:
						return "Graines de floraison du jour";
					case EntityID.ItemID.MOONGLOW_SEEDS:
						return "Graines de lueur de lune";
					case EntityID.ItemID.BLINKROOT_SEEDS:
						return "Graines de racine clignotante";
					case EntityID.ItemID.DEATHWEED_SEEDS:
						return "Graines de mauvaise herbe morte";
					case EntityID.ItemID.WATERLEAF_SEEDS:
						return "Graines de feuilles de l'eau";
					case EntityID.ItemID.FIREBLOSSOM_SEEDS:
						return "Graines de fleur de feu";
					case EntityID.ItemID.DAYBLOOM:
						return "Floraison du jour";
					case EntityID.ItemID.MOONGLOW:
						return "Lueur de lune";
					case EntityID.ItemID.BLINKROOT:
						return "Racine clignotante";
					case EntityID.ItemID.DEATHWEED:
						return "Mauvaise herbe morte";
					case EntityID.ItemID.WATERLEAF:
						return "Feuille de l'eau";
					case EntityID.ItemID.FIREBLOSSOM:
						return "Fleur de feu";
					case EntityID.ItemID.SHARK_FIN:
						return "Aileron de requin";
					case EntityID.ItemID.FEATHER:
						return "Plume";
					case EntityID.ItemID.TOMBSTONE:
						return "Pierre tombale";
					case EntityID.ItemID.MIME_MASK:
						return "Masque du mime";
					case EntityID.ItemID.ANTLION_MANDIBLE:
						return "Mandibule de fourmilion";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "Pièces détachées";
					case EntityID.ItemID.THE_DOCTORS_SHIRT:
						return "Veste du docteur";
					case EntityID.ItemID.THE_DOCTORS_PANTS:
						return "Pantalon du docteur";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Clé dorée";
					case EntityID.ItemID.SHADOW_CHEST:
						return "Coffre sombre";
					case EntityID.ItemID.SHADOW_KEY:
						return "Clé sombre";
					case EntityID.ItemID.OBSIDIAN_BRICK_WALL:
						return "Mur de briques d'obsidienne";
					case EntityID.ItemID.JUNGLE_SPORES:
						return "Spores de la jungle";
					case EntityID.ItemID.LOOM:
						return "Métier à tisser";
					case EntityID.ItemID.PIANO:
						return "Piano";
					case EntityID.ItemID.DRESSER:
						return "Commode";
					case EntityID.ItemID.BENCH:
						return "Banc";
					case EntityID.ItemID.BATHTUB:
						return "Baignoire";
					case EntityID.ItemID.RED_BANNER:
						return "Bannière rouge";
					case EntityID.ItemID.GREEN_BANNER:
						return "Bannière verte";
					case EntityID.ItemID.BLUE_BANNER:
						return "Bannière bleue";
					case EntityID.ItemID.YELLOW_BANNER:
						return "Bannière jaune";
					case EntityID.ItemID.LAMP_POST:
						return "Lampadaire";
					case EntityID.ItemID.TIKI_TORCH:
						return "Torche de tiki";
					case EntityID.ItemID.BARREL:
						return "Baril";
					case EntityID.ItemID.CHINESE_LANTERN:
						return "Lanterne chinoise";
					case EntityID.ItemID.COOKING_POT:
						return "Marmite";
					case EntityID.ItemID.SAFE:
						return "Coffre-fort";
					case EntityID.ItemID.SKULL_LANTERN:
						return "Lanterne crâne";
					case EntityID.ItemID.TRASH_CAN:
						return "Poubelle";
					case EntityID.ItemID.CANDELABRA:
						return "Candélabre";
					case EntityID.ItemID.PINK_VASE:
						return "Vase rose";
					case EntityID.ItemID.MUG:
						return "Chope";
					case EntityID.ItemID.KEG:
						return "Tonnelet";
					case EntityID.ItemID.ALE:
						return "Bière";
					case EntityID.ItemID.BOOKCASE:
						return "Bibliothèque";
					case EntityID.ItemID.THRONE:
						return "Trône";
					case EntityID.ItemID.BOWL:
						return "Bol";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Bol de soupe";
					case EntityID.ItemID.TOILET:
						return "Toilettes";
					case EntityID.ItemID.GRANDFATHER_CLOCK:
						return "Horloge de grand-père";
					case EntityID.ItemID.STATUE:
						return "Statue d'armure";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Étendard de bataille gobelin";
					case EntityID.ItemID.TATTERED_CLOTH:
						return "Vêtements en lambeaux";
					case EntityID.ItemID.SAWMILL:
						return "Scierie";
					case EntityID.ItemID.COBALT_ORE:
						return "Minerai de cobalt";
					case EntityID.ItemID.MYTHRIL_ORE:
						return "Minerai de mythril";
					case EntityID.ItemID.ADAMANTITE_ORE:
						return "Minerai d'adamantine";
					case EntityID.ItemID.PWNHAMMER:
						return "Pwnhammer";
					case EntityID.ItemID.EXCALIBUR:
						return "Excalibur";
					case EntityID.ItemID.HALLOWED_SEEDS:
						return "Graines sacrées";
					case EntityID.ItemID.EBONSAND_BLOCK:
						return "Bloc de sable d'ébène";
					case EntityID.ItemID.COBALT_HAT:
						return "Chapeau de cobalt";
					case EntityID.ItemID.COBALT_HELMET:
						return "Casque de cobalt";
					case EntityID.ItemID.COBALT_MASK:
						return "Masque de cobalt";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Plastron de cobalt";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Jambières de cobalt";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Capuche de mythril";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Casque de mythril";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Chapeau de mythril";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Cotte de mailles de mythril";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Jambières de mythril";
					case EntityID.ItemID.COBALT_BAR:
						return "Barre de cobalt";
					case EntityID.ItemID.MYTHRIL_BAR:
						return "Barre de mythril";
					case EntityID.ItemID.COBALT_CHAINSAW:
						return "Tronçonneuse de cobalt";
					case EntityID.ItemID.MYTHRIL_CHAINSAW:
						return "Tronçonneuse de mythril";
					case EntityID.ItemID.COBALT_DRILL:
						return "Perceuse de cobalt";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Perceuse de mythril";
					case EntityID.ItemID.ADAMANTITE_CHAINSAW:
						return "Tronçonneuse d'adamantine";
					case EntityID.ItemID.ADAMANTITE_DRILL:
						return "Perceuse d'adamantine";
					case EntityID.ItemID.DAO_OF_POW:
						return "Dao de Pow";
					case EntityID.ItemID.MYTHRIL_HALBERD:
						return "Hallebarde de mythril";
					case EntityID.ItemID.ADAMANTITE_BAR:
						return "Barre d'amantine";
					case EntityID.ItemID.GLASS_WALL:
						return "Mur de verre";
					case EntityID.ItemID.COMPASS:
						return "Boussole";
					case EntityID.ItemID.DIVING_GEAR:
						return "Équipement de plongée";
					case EntityID.ItemID.GPS:
						return "GPS";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Fer à cheval d'obsidienne";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Bouclier d'obsidienne";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Atelier du bricoleur";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Nuage dans un ballon";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Coiffe d'adamantine";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Casque d'adamantine";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Masque d'adamantine";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Plastron d'adamantine";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Jambières en adamantine";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Bottes spectrales";
					case EntityID.ItemID.ADAMANTITE_GLAIVE:
						return "Glaive d'adamantine";
					case EntityID.ItemID.TOOLBELT:
						return "Ceinture à outils";
					case EntityID.ItemID.PEARLSAND_BLOCK:
						return "Bloc de sable de perle";
					case EntityID.ItemID.PEARLSTONE_BLOCK:
						return "Bloc de pierre de perle";
					case EntityID.ItemID.MINING_SHIRT:
						return "Veste de mineur";
					case EntityID.ItemID.MINING_PANTS:
						return "Pantalon de mineur";
					case EntityID.ItemID.PEARLSTONE_BRICK:
						return "Brique de pierre de perle";
					case EntityID.ItemID.IRIDESCENT_BRICK:
						return "Brique iridescente";
					case EntityID.ItemID.MUDSTONE_BRICK:
						return "Brique de pierre de terre";
					case EntityID.ItemID.COBALT_BRICK:
						return "Brique de cobalt";
					case EntityID.ItemID.MYTHRIL_BRICK:
						return "Brique de mythril";
					case EntityID.ItemID.PEARLSTONE_BRICK_WALL:
						return "Mur de briques de pierre de perle";
					case EntityID.ItemID.IRIDESCENT_BRICK_WALL:
						return "Mur de briques iridescentes";
					case EntityID.ItemID.MUDSTONE_BRICK_WALL:
						return "Mur de briques de pierre de terre";
					case EntityID.ItemID.COBALT_BRICK_WALL:
						return "Mur de briques de cobalt";
					case EntityID.ItemID.MYTHRIL_BRICK_WALL:
						return "Mur de briques de mythril";
					case EntityID.ItemID.HOLY_WATER:
						return "Eau bénite";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Eau impie";
					case EntityID.ItemID.SILT_BLOCK:
						return "Bloc de limon";
					case EntityID.ItemID.FAIRY_BELL:
						return "Clochette de fée";
					case EntityID.ItemID.BREAKER_BLADE:
						return "Lame du briseur";
					case EntityID.ItemID.BLUE_TORCH:
						return "Torche bleue";
					case EntityID.ItemID.RED_TORCH:
						return "Torche rouge";
					case EntityID.ItemID.GREEN_TORCH:
						return "Torche verte";
					case EntityID.ItemID.PURPLE_TORCH:
						return "Torche violette";
					case EntityID.ItemID.WHITE_TORCH:
						return "Torche blanche";
					case EntityID.ItemID.YELLOW_TORCH:
						return "Torche jaune";
					case EntityID.ItemID.DEMON_TORCH:
						return "Torche du démon";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Fusil d'assaut mécanique";
					case EntityID.ItemID.COBALT_REPEATER:
						return "Arbalète en cobalt";
					case EntityID.ItemID.MYTHRIL_REPEATER:
						return "Arbalète en mythril";
					case EntityID.ItemID.DUAL_HOOK:
						return "Crochet Double";
					case EntityID.ItemID.STAR_STATUE:
						return "Statue d'étoile";
					case EntityID.ItemID.SWORD_STATUE:
						return "Statue d'épée";
					case EntityID.ItemID.SLIME_STATUE:
						return "Statue de slime";
					case EntityID.ItemID.GOBLIN_STATUE:
						return "Statue de gobelin";
					case EntityID.ItemID.SHIELD_STATUE:
						return "Statue de bouclier";
					case EntityID.ItemID.BAT_STATUE:
						return "Statue de chauve-souris";
					case EntityID.ItemID.FISH_STATUE:
						return "Statue de poisson";
					case EntityID.ItemID.BUNNY_STATUE:
						return "Statue de lapin";
					case EntityID.ItemID.SKELETON_STATUE:
						return "Statue de squelette";
					case EntityID.ItemID.REAPER_STATUE:
						return "Statue de faucheur";
					case EntityID.ItemID.WOMAN_STATUE:
						return "Statue de femme";
					case EntityID.ItemID.IMP_STATUE:
						return "Statue de diablotin";
					case EntityID.ItemID.GARGOYLE_STATUE:
						return "Statue de gargouille";
					case EntityID.ItemID.GLOOM_STATUE:
						return "Statue de morosité";
					case EntityID.ItemID.HORNET_STATUE:
						return "Statue de frelon";
					case EntityID.ItemID.BOMB_STATUE:
						return "Statue de bombe";
					case EntityID.ItemID.CRAB_STATUE:
						return "Statue de crabe";
					case EntityID.ItemID.HAMMER_STATUE:
						return "Statue de marteau";
					case EntityID.ItemID.POTION_STATUE:
						return "Statue de potion";
					case EntityID.ItemID.SPEAR_STATUE:
						return "Statue de lance";
					case EntityID.ItemID.CROSS_STATUE:
						return "Statue de croix";
					case EntityID.ItemID.JELLYFISH_STATUE:
						return "Statue de méduse";
					case EntityID.ItemID.BOW_STATUE:
						return "Statue d'arc";
					case EntityID.ItemID.BOOMERANG_STATUE:
						return "Statue de boomerang";
					case EntityID.ItemID.BOOT_STATUE:
						return "Statue de botte";
					case EntityID.ItemID.CHEST_STATUE:
						return "Statue de coffre";
					case EntityID.ItemID.BIRD_STATUE:
						return "Statue d'oiseau";
					case EntityID.ItemID.AXE_STATUE:
						return "Statue de hache";
					case EntityID.ItemID.CORRUPT_STATUE:
						return "Statue corrompue";
					case EntityID.ItemID.TREE_STATUE:
						return "Statue d'arbre";
					case EntityID.ItemID.ANVIL_STATUE:
						return "Statue d'enclume";
					case EntityID.ItemID.PICKAXE_STATUE:
						return "Statue de pioche";
					case EntityID.ItemID.MUSHROOM_STATUE:
						return "Statue de champignon";
					case EntityID.ItemID.EYEBALL_STATUE:
						return "Statue d'œil";
					case EntityID.ItemID.PILLAR_STATUE:
						return "Statue de pilier";
					case EntityID.ItemID.HEART_STATUE:
						return "Statue de cœur";
					case EntityID.ItemID.POT_STATUE:
						return "Statue de pot";
					case EntityID.ItemID.SUNFLOWER_STATUE:
						return "Statue de tournesol";
					case EntityID.ItemID.KING_STATUE:
						return "Statue de roi";
					case EntityID.ItemID.QUEEN_STATUE:
						return "Statue de reine";
					case EntityID.ItemID.PIRANHA_STATUE:
						return "Statue de piranha";
					case EntityID.ItemID.PLANKED_WALL:
						return "Mur de planches";
					case EntityID.ItemID.WOODEN_BEAM:
						return "Poutre de bois";
					case EntityID.ItemID.ADAMANTITE_REPEATER:
						return "Arbalète d'adamantine";
					case EntityID.ItemID.ADAMANTITE_SWORD:
						return "Épée d'adamantine";
					case EntityID.ItemID.COBALT_SWORD:
						return "Épée de cobalt";
					case EntityID.ItemID.MYTHRIL_SWORD:
						return "Épée de mythril";
					case EntityID.ItemID.MOON_CHARM:
						return "Sortilège lunaire";
					case EntityID.ItemID.RULER:
						return "Règle";
					case EntityID.ItemID.CRYSTAL_BALL:
						return "Boule de cristal";
					case EntityID.ItemID.DISCO_BALL:
						return "Boule à facettes";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Emblème sorcier";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Emblème guerrier";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Emblème ranger";
					case EntityID.ItemID.DEMON_WINGS:
						return "Ailes de démon";
					case EntityID.ItemID.ANGEL_WINGS:
						return "Ailes d'ange";
					case EntityID.ItemID.MAGICAL_HARP:
						return "Harpe magique";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Bâton d'arc-en-ciel";
					case EntityID.ItemID.ICE_ROD:
						return "Bâton de glace";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Coquillage de Neptune";
					case EntityID.ItemID.MANNEQUIN:
						return "Mannequin";
					case EntityID.ItemID.GREATER_HEALING_POTION:
						return "Potion de soins supérieure";
					case EntityID.ItemID.GREATER_MANA_POTION:
						return "Potion de mana supérieure";
					case EntityID.ItemID.PIXIE_DUST:
						return "Poudre de fée";
					case EntityID.ItemID.CRYSTAL_SHARD:
						return "Éclat de cristal";
					case EntityID.ItemID.CLOWN_HAT:
						return "Chapeau de clown";
					case EntityID.ItemID.CLOWN_SHIRT:
						return "Veste de clown";
					case EntityID.ItemID.CLOWN_PANTS:
						return "Pantalon de clown";
					case EntityID.ItemID.FLAMETHROWER:
						return "Lance-flammes";
					case EntityID.ItemID.BELL:
						return "Cloche";
					case EntityID.ItemID.HARP:
						return "Harpe";
					case EntityID.ItemID.WRENCH:
						return "Clé à molette";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Pince coupante";
					case EntityID.ItemID.ACTIVE_STONE_BLOCK:
						return "Bloc de pierre actif";
					case EntityID.ItemID.INACTIVE_STONE_BLOCK:
						return "Bloc de pierre inactif";
					case EntityID.ItemID.LEVER:
						return "Levier";
					case EntityID.ItemID.LASER_RIFLE:
						return "Fusil laser";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Balle de cristal";
					case EntityID.ItemID.HOLY_ARROW:
						return "Flèche bénite";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Dague magique";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Tempête de cristal";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Flammes maudites";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "Âme de lumière";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "Âme de la nuit";
					case EntityID.ItemID.CURSED_FLAME:
						return "Flamme maudite";
					case EntityID.ItemID.CURSED_TORCH:
						return "Torche maudite";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Forge en adamantine";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Enclume en mythril";
					case EntityID.ItemID.UNICORN_HORN:
						return "Corne de licorne";
					case EntityID.ItemID.DARK_SHARD:
						return "Éclat sombre";
					case EntityID.ItemID.LIGHT_SHARD:
						return "Éclat de lumière";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Plaque de pression rouge";
					case EntityID.ItemID.WIRE:
						return "Câble";
					case EntityID.ItemID.SPELL_TOME:
						return "Livre de sorts";
					case EntityID.ItemID.STAR_CLOAK:
						return "Cape stellaire";
					case EntityID.ItemID.MEGASHARK:
						return "Mégashark";
					case EntityID.ItemID.SHOTGUN:
						return "Fusil à pompe";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Pierre du philosophe";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Gant du titan";
					case EntityID.ItemID.COBALT_NAGINATA:
						return "Naginata en cobalt";
					case EntityID.ItemID.SWITCH:
						return "Interrupteur";
					case EntityID.ItemID.DART_TRAP:
						return "Piège à fléchette";
					case EntityID.ItemID.BOULDER:
						return "Rocher";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Plaque de pression verte";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Plaque de pression grise";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Plaque de pression marron";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Œil mécanique";
					case EntityID.ItemID.CURSED_ARROW:
						return "Flèche maudite";
					case EntityID.ItemID.CURSED_BULLET:
						return "Balle maudite";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "Âme d'effroi";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "Âme de pouvoir";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "Âme de vision";
					case EntityID.ItemID.GUNGNIR:
						return "Gungnir";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Armure de plaques sacrée";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Jambières sacrées";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Casque sacré";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Pendentif en croix";
					case EntityID.ItemID.MANA_FLOWER:
						return "Fleur de mana";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Ver mécanique";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Crâne mécanique";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Coiffe sacrée";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Masque sacré";
					case EntityID.ItemID.SLIME_CROWN:
						return "Couronne de slime";
					case EntityID.ItemID.LIGHT_DISC:
						return "Disque de lumière";
					case EntityID.ItemID.MUSIC_BOX_OVERWORLD_DAY:
						return "Boîte à musique (Jour du monde supérieur)";
					case EntityID.ItemID.MUSIC_BOX_EERIE:
						return "Boîte à musique (Surnaturel)";
					case EntityID.ItemID.MUSIC_BOX_NIGHT:
						return "Boîte à musique (Nuit)";
					case EntityID.ItemID.MUSIC_BOX_TITLE:
						return "Boîte à musique (Titre)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND:
						return "Boîte à musique (Souterrain)";
					case EntityID.ItemID.MUSIC_BOX_BOSS1:
						return "Boîte à musique (Boss 1)";
					case EntityID.ItemID.MUSIC_BOX_JUNGLE:
						return "Boîte à musique (Jungle)";
					case EntityID.ItemID.MUSIC_BOX_CORRUPTION:
						return "Boîte à musique(Corruption)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_CORRUPTION:
						return "Boîte à musique (Corruption du souterrain)";
					case EntityID.ItemID.MUSIC_BOX_THE_HALLOW:
						return "Boîte à musique (La Sainteté)";
					case EntityID.ItemID.MUSIC_BOX_BOSS2:
						return "Boîte à musique (Boss 2)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_HALLOW:
						return "Boîte à musique (Sainteté du souterrain)";
					case EntityID.ItemID.MUSIC_BOX_BOSS3:
						return "Boîte à musique (Boss 3)";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "Âme du vol";
					case EntityID.ItemID.MUSIC_BOX:
						return "Boîte à musique";
					case EntityID.ItemID.DEMONITE_BRICK:
						return "Brique de démonite";
					case EntityID.ItemID.HALLOWED_REPEATER:
						return "Arbalète bénie";
					case EntityID.ItemID.HAMDRAX:
						return "Martache-perce";
					case EntityID.ItemID.EXPLOSIVES:
						return "Explosifs";
					case EntityID.ItemID.INLET_PUMP:
						return "Poste de pompage";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Sortie de pompage";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "Minuteur d'une seconde";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "Minuteur de 3 secondes";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "Minuteur de 5 secondes";
					case EntityID.ItemID.CANDY_CANE_BLOCK:
						return "Bloc de sucrerie";
					case EntityID.ItemID.CANDY_CANE_WALL:
						return "Mur de sucrerie";
					case EntityID.ItemID.SANTA_HAT:
						return "Bonnet de père Noël";
					case EntityID.ItemID.SANTA_SHIRT:
						return "Veste de père Noël";
					case EntityID.ItemID.SANTA_PANTS:
						return "Pantalon de père Noël";
					case EntityID.ItemID.GREEN_CANDY_CANE_BLOCK:
						return "Bloc de sucrerie vert";
					case EntityID.ItemID.GREEN_CANDY_CANE_WALL:
						return "Mur de sucrerie vert ";
					case EntityID.ItemID.SNOW_BLOCK:
						return "bloc de neige";
					case EntityID.ItemID.SNOW_BRICK:
						return "brique de neige";
					case EntityID.ItemID.SNOW_BRICK_WALL:
						return "Mur de briques de neige";
					case EntityID.ItemID.BLUE_LIGHT:
						return "Lumière bleue";
					case EntityID.ItemID.RED_LIGHT:
						return "Lumière rouge";
					case EntityID.ItemID.GREEN_LIGHT:
						return "Lumière verte";
					case EntityID.ItemID.BLUE_PRESENT:
						return "Cadeau bleu";
					case EntityID.ItemID.GREEN_PRESENT:
						return "Cadeau vert";
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Cadeau jaune";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Globe de neige";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Chou";
					case EntityID.ItemID.DRAGON_MASK:
						return "Masque de dragon";
					case EntityID.ItemID.TITAN_HELMET:
						return "Casque de titan";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Coiffe spectrale";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Plastron de dragon";
					case EntityID.ItemID.TITAN_MAIL:
						return "Cotte de mailles de titan";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Armure spectrale";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Jambières de dragon";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Jambières de titan";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Subligar spectral";
					case EntityID.ItemID.TIZONA:
						return "Tizona";
					case EntityID.ItemID.TONBOGIRI:
						return "Tonbogiri";
					case EntityID.ItemID.SHARANGA:
						return "Sharanga";
					case EntityID.ItemID.SPECTRAL_ARROW:
						return "Flèche spectrale";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Arbalète de Vulcain";
					case EntityID.ItemID.VULCAN_BOLT:
						return "Éclair de Vulcain";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Crâne à l'air douteux";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "Âme du fléau";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Boîte de Petri";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Nid d'abeille";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Fiole de sang";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Croc de loup";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Cervelle";
					case EntityID.ItemID.MUSIC_BOX_DESERT:
						return "Boîte à musique (Désert)";
					case EntityID.ItemID.MUSIC_BOX_SPACE:
						return "Boîte à musique (Espace)";
					case EntityID.ItemID.MUSIC_BOX_TUTORIAL:
						return "Boîte à musique (Tutoriel)";
					case EntityID.ItemID.MUSIC_BOX_BOSS4:
						return "Boîte à musique (Boss 4)";
					case EntityID.ItemID.MUSIC_BOX_OCEAN:
						return "Boîte à musique (Océan)";
					case EntityID.ItemID.MUSIC_BOX_SNOW:
						return "Boîte à musique (Neige)";
#if VERSION_101
					case EntityID.ItemID.FABULOUS_RIBBON:
						return "Ruban somptueux";
					case EntityID.ItemID.GEORGES_HAT:
						return "Chapeau de George";
					case EntityID.ItemID.FABULOUS_TUTU:
						return "Tutu somptueux";
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
						return "Veste de smoking de George";
					case EntityID.ItemID.FABULOUS_SLIPPERS:
						return "Chaussons somptueux";
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Pantalon de smoking de George";
					case EntityID.ItemID.SPARKLY_WINGS:
						return "Ailes brillantes";
					case EntityID.ItemID.CAMPFIRE:
						return "Feu de camp";
					case EntityID.ItemID.WOOD_HELMET:
						return "Casque en bois";
					case EntityID.ItemID.WOOD_BREASTPLATE:
						return "Plastron en bois";
					case EntityID.ItemID.WOOD_GREAVES:
						return "Jambières en bois";
					case EntityID.ItemID.CACTUS_SWORD:
						return "Épée cactus";
					case EntityID.ItemID.CACTUS_PICKAXE:
						return "Pioche cactus";
					case EntityID.ItemID.CACTUS_HELMET:
						return "Casque cactus";
					case EntityID.ItemID.CACTUS_BREASTPLATE:
						return "Plastron cactus";
					case EntityID.ItemID.CACTUS_LEGGINGS:
						return "Jambières cactus ";
					case EntityID.ItemID.PURPLE_STAINED_GLASS_WALL:
						return "Vitrail violet";
					case EntityID.ItemID.YELLOW_STAINED_GLASS_WALL:
						return "Vitrail jaune";
					case EntityID.ItemID.BLUE_STAINED_GLASS_WALL:
						return "Vitrail bleu";
					case EntityID.ItemID.GREEN_STAINED_GLASS_WALL:
						return "Vitrail vert";
					case EntityID.ItemID.RED_STAINED_GLASS_WALL:
						return "Vitrail rouge";
					case EntityID.ItemID.MULTICOLORED_STAINED_GLASS_WALL:
						return "Vitrail multicolore";
#endif
				}
			}
			else if (LangOption == (int)ID.SPANISH)
			{
				switch ((EntityID.ItemID)l)
				{
					case EntityID.ItemID.GOLD_PICKAXE:
						return "Pico de oro";
					case EntityID.ItemID.GOLD_BROADSWORD:
						return "Espada larga de oro";
					case EntityID.ItemID.GOLD_SHORTSWORD:
						return "Espada corta de oro";
					case EntityID.ItemID.GOLD_AXE:
						return "Hacha de oro";
					case EntityID.ItemID.GOLD_HAMMER:
						return "Martillo de oro";
					case EntityID.ItemID.GOLD_BOW:
						return "Arco de oro";
					case EntityID.ItemID.SILVER_PICKAXE:
						return "Pico de plata";
					case EntityID.ItemID.SILVER_BROADSWORD:
						return "Espada larga de plata";
					case EntityID.ItemID.SILVER_SHORTSWORD:
						return "Espada corta de plata";
					case EntityID.ItemID.SILVER_AXE:
						return "Hacha de plata";
					case EntityID.ItemID.SILVER_HAMMER:
						return "Martillo de plata";
					case EntityID.ItemID.SILVER_BOW:
						return "Arco de plata";
					case EntityID.ItemID.COPPER_PICKAXE:
						return "Pico de cobre";
					case EntityID.ItemID.COPPER_BROADSWORD:
						return "Espada larga de cobre";
					case EntityID.ItemID.COPPER_SHORTSWORD:
						return "Espada corta de cobre";
					case EntityID.ItemID.COPPER_AXE:
						return "Hacha de cobre";
					case EntityID.ItemID.COPPER_HAMMER:
						return "Martillo de cobre";
					case EntityID.ItemID.COPPER_BOW:
						return "Arco de cobre";
					case EntityID.ItemID.BLUE_PHASESABER:
						return "Sable de luz azul";
					case EntityID.ItemID.RED_PHASESABER:
						return "Sable de luz rojo";
					case EntityID.ItemID.GREEN_PHASESABER:
						return "Sable de luz verde";
					case EntityID.ItemID.PURPLE_PHASESABER:
						return "Sable de luz morado";
					case EntityID.ItemID.WHITE_PHASESABER:
						return "Sable de luz blanco";
					case EntityID.ItemID.YELLOW_PHASESABER:
						return "Sable de luz amarillo";
					case EntityID.ItemID.IRON_PICKAXE:
						return "Pico de hierro";
					case EntityID.ItemID.DIRT_BLOCK:
						return "Bloque de tierra";
					case EntityID.ItemID.STONE_BLOCK:
						return "Bloque de piedra";
					case EntityID.ItemID.IRON_BROADSWORD:
						return "Espada larga de hierro";
					case EntityID.ItemID.MUSHROOM:
						return "Champiñón";
					case EntityID.ItemID.IRON_SHORTSWORD:
						return "Espada corta de hierro";
					case EntityID.ItemID.IRON_HAMMER:
						return "Martillo de hierro";
					case EntityID.ItemID.TORCH:
						return "Antorcha";
					case EntityID.ItemID.WOOD:
						return "Madera";
					case EntityID.ItemID.IRON_AXE:
						return "Hacha de hierro";
					case EntityID.ItemID.IRON_ORE:
						return "Mineral de hierro";
					case EntityID.ItemID.COPPER_ORE:
						return "Mineral de cobre";
					case EntityID.ItemID.GOLD_ORE:
						return "Mineral de oro";
					case EntityID.ItemID.SILVER_ORE:
						return "Mineral de plata";
					case EntityID.ItemID.COPPER_WATCH:
						return "Reloj de cobre";
					case EntityID.ItemID.SILVER_WATCH:
						return "Reloj de plata";
					case EntityID.ItemID.GOLD_WATCH:
						return "Reloj de oro";
					case EntityID.ItemID.DEPTH_METER:
						return "Medidor de profundidad";
					case EntityID.ItemID.GOLD_BAR:
						return "Lingote de oro";
					case EntityID.ItemID.COPPER_BAR:
						return "Lingote de cobre";
					case EntityID.ItemID.SILVER_BAR:
						return "Lingote de plata";
					case EntityID.ItemID.IRON_BAR:
						return "Lingote de hierro";
					case EntityID.ItemID.GEL:
						return "Gel";
					case EntityID.ItemID.WOODEN_SWORD:
						return "Espada de madera";
					case EntityID.ItemID.WOODEN_DOOR:
						return "Puerta de madera";
					case EntityID.ItemID.STONE_WALL:
						return "Pared de piedra";
					case EntityID.ItemID.ACORN:
						return "Bellota";
					case EntityID.ItemID.LESSER_HEALING_POTION:
						return "Poción curativa menor";
					case EntityID.ItemID.LIFE_CRYSTAL:
						return "Cristal de vida";
					case EntityID.ItemID.DIRT_WALL:
						return "Pared de tierra";
					case EntityID.ItemID.BOTTLE:
						return "Botella";
					case EntityID.ItemID.WOODEN_TABLE:
						return "Mesa de madera";
					case EntityID.ItemID.FURNACE:
						return "Forja";
					case EntityID.ItemID.WOODEN_CHAIR:
						return "Silla de madera";
					case EntityID.ItemID.IRON_ANVIL:
						return "Yunque de hierro";
					case EntityID.ItemID.WORK_BENCH:
						return "Banco de trabajo";
					case EntityID.ItemID.GOGGLES:
						return "Gafas de protección";
					case EntityID.ItemID.LENS:
						return "Lentes";
					case EntityID.ItemID.WOODEN_BOW:
						return "Arco de madera";
					case EntityID.ItemID.WOODEN_ARROW:
						return "Flecha de madera";
					case EntityID.ItemID.FLAMING_ARROW:
						return "Flecha ardiente";
					case EntityID.ItemID.SHURIKEN:
						return "Estrellas ninja";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_EYE:
						return "Ojo de aspecto sospechoso";
					case EntityID.ItemID.DEMON_BOW:
						return "Arco demoníaco";
					case EntityID.ItemID.WAR_AXE_OF_THE_NIGHT:
						return "Hacha de la noche";
					case EntityID.ItemID.LIGHTS_BANE:
						return "Azote de la luz";
					case EntityID.ItemID.UNHOLY_ARROW:
						return "Flecha infame";
					case EntityID.ItemID.CHEST:
						return "Cofre";
					case EntityID.ItemID.BAND_OF_REGENERATION:
						return "Banda de regeneración";
					case EntityID.ItemID.MAGIC_MIRROR:
						return "Espejo mágico";
					case EntityID.ItemID.JESTERS_ARROW:
						return "Flecha de bufón";
					case EntityID.ItemID.ANGEL_STATUE:
						return "Estatua de ángel";
					case EntityID.ItemID.CLOUD_IN_A_BOTTLE:
						return "Nube en botella";
					case EntityID.ItemID.HERMES_BOOTS:
						return "Botas de Hermes";
					case EntityID.ItemID.ENCHANTED_BOOMERANG:
						return "Bumerán encantado";
					case EntityID.ItemID.DEMONITE_ORE:
						return "Mineral endemoniado";
					case EntityID.ItemID.DEMONITE_BAR:
						return "Lingote endemoniado";
					case EntityID.ItemID.HEART:
						return "Corazón";
					case EntityID.ItemID.CORRUPT_SEEDS:
						return "Semillas corrompidas";
					case EntityID.ItemID.VILE_MUSHROOM:
						return "Champiñón vil";
					case EntityID.ItemID.EBONSTONE_BLOCK:
						return "Bloque de piedra de ébano";
					case EntityID.ItemID.GRASS_SEEDS:
						return "Semillas de césped";
					case EntityID.ItemID.SUNFLOWER:
						return "Girasol";
					case EntityID.ItemID.VILETHORN:
						return "Lanzador de espina vil";
					case EntityID.ItemID.STARFURY:
						return "Furia de estrellas";
					case EntityID.ItemID.PURIFICATION_POWDER:
						return "Polvo de purificación";
					case EntityID.ItemID.VILE_POWDER:
						return "Polvo vil";
					case EntityID.ItemID.ROTTEN_CHUNK:
						return "Trozo podrido";
					case EntityID.ItemID.WORM_TOOTH:
						return "Diente de gusano";
					case EntityID.ItemID.WORM_FOOD:
						return "Cebo de gusanos";
					case EntityID.ItemID.COPPER_COIN:
						return "Moneda de cobre";
					case EntityID.ItemID.SILVER_COIN:
						return "Moneda de plata";
					case EntityID.ItemID.GOLD_COIN:
						return "Moneda de oro";
					case EntityID.ItemID.PLATINUM_COIN:
						return "Moneda de platino";
					case EntityID.ItemID.FALLEN_STAR:
						return "Estrella fugaz";
					case EntityID.ItemID.COPPER_GREAVES:
						return "Grebas de cobre";
					case EntityID.ItemID.IRON_GREAVES:
						return "Grebas de hierro";
					case EntityID.ItemID.SILVER_GREAVES:
						return "Grebas de plata";
					case EntityID.ItemID.GOLD_GREAVES:
						return "Grebas de oro";
					case EntityID.ItemID.COPPER_CHAINMAIL:
						return "Cota de malla de cobre";
					case EntityID.ItemID.IRON_CHAINMAIL:
						return "Cota de malla de hierro";
					case EntityID.ItemID.SILVER_CHAINMAIL:
						return "Cota de malla de plata";
					case EntityID.ItemID.GOLD_CHAINMAIL:
						return "Cota de malla de oro";
					case EntityID.ItemID.GRAPPLING_HOOK:
						return "Garfio de escalada";
					case EntityID.ItemID.CHAIN:
						return "Cadena de hierro";
					case EntityID.ItemID.SHADOW_SCALE:
						return "Escama de las sombras";
					case EntityID.ItemID.PIGGY_BANK:
						return "Hucha";
					case EntityID.ItemID.MINING_HELMET:
						return "Casco de minero";
					case EntityID.ItemID.COPPER_HELMET:
						return "Casco de cobre";
					case EntityID.ItemID.IRON_HELMET:
						return "Casco de hierro";
					case EntityID.ItemID.SILVER_HELMET:
						return "Casco de plata";
					case EntityID.ItemID.GOLD_HELMET:
						return "Casco de oro";
					case EntityID.ItemID.WOOD_WALL:
						return "Pared de madera";
					case EntityID.ItemID.WOOD_PLATFORM:
						return "Plataforma de madera";
					case EntityID.ItemID.FLINTLOCK_PISTOL:
						return "Pistola de pedernal";
					case EntityID.ItemID.MUSKET:
						return "Mosquete";
					case EntityID.ItemID.MUSKET_BALL:
						return "Bala de mosquete";
					case EntityID.ItemID.MINISHARK:
						return "Minitiburón";
					case EntityID.ItemID.IRON_BOW:
						return "Arco de hierro";
					case EntityID.ItemID.SHADOW_GREAVES:
						return "Grebas de las sombras";
					case EntityID.ItemID.SHADOW_SCALEMAIL:
						return "Cota de escamas de las sombras";
					case EntityID.ItemID.SHADOW_HELMET:
						return "Casco de las sombras";
					case EntityID.ItemID.NIGHTMARE_PICKAXE:
						return "Pico de pesadilla";
					case EntityID.ItemID.THE_BREAKER:
						return "La Despedazadora";
					case EntityID.ItemID.CANDLE:
						return "Vela";
					case EntityID.ItemID.COPPER_CHANDELIER:
						return "Lámpara araña de cobre";
					case EntityID.ItemID.SILVER_CHANDELIER:
						return "Lámpara araña de plata";
					case EntityID.ItemID.GOLD_CHANDELIER:
						return "Lámpara araña de oro";
					case EntityID.ItemID.MANA_CRYSTAL:
						return "Cristal de maná";
					case EntityID.ItemID.LESSER_MANA_POTION:
						return "Poción de maná menor";
					case EntityID.ItemID.BAND_OF_STARPOWER:
						return "Banda de polvo de estrellas";
					case EntityID.ItemID.FLOWER_OF_FIRE:
						return "Flor de fuego";
					case EntityID.ItemID.MAGIC_MISSILE:
						return "Proyectil mágico";
					case EntityID.ItemID.DIRT_ROD:
						return "Varita de tierra";
#if VERSION_INITIAL
					case EntityID.ItemID.SHADOW_ORB:
						return "Orbe de luz";
#else
					case EntityID.ItemID.SHADOW_ORB:
						return "Orbe sombrío";
#endif
					case EntityID.ItemID.METEORITE:
						return "Meteorito";
					case EntityID.ItemID.METEORITE_BAR:
						return "Lingote de meteorito";
					case EntityID.ItemID.HOOK:
						return "Gancho";
					case EntityID.ItemID.FLAMARANG:
						return "Bumerán de llamas";
					case EntityID.ItemID.MOLTEN_FURY:
						return "Furia fundida";
					case EntityID.ItemID.FIERY_GREATSWORD:
						return "Espadón ardiente";
					case EntityID.ItemID.MOLTEN_PICKAXE:
						return "Pico fundido";
					case EntityID.ItemID.METEOR_HELMET:
						return "Casco de meteorito";
					case EntityID.ItemID.METEOR_SUIT:
						return "Cota de meteorito";
					case EntityID.ItemID.METEOR_LEGGINGS:
						return "Perneras de meteorito";
					case EntityID.ItemID.BOTTLED_WATER:
						return "Agua embotellada";
					case EntityID.ItemID.SPACE_GUN:
						return "Pistola espacial";
					case EntityID.ItemID.ROCKET_BOOTS:
						return "Botas cohete";
					case EntityID.ItemID.GRAY_BRICK:
						return "Ladrillo gris";
					case EntityID.ItemID.GRAY_BRICK_WALL:
						return "Pared de ladrillo gris";
					case EntityID.ItemID.RED_BRICK:
						return "Ladrillo rojo";
					case EntityID.ItemID.RED_BRICK_WALL:
						return "Pared de ladrillo rojo";
					case EntityID.ItemID.CLAY_BLOCK:
						return "Bloque de arcilla";
					case EntityID.ItemID.BLUE_BRICK:
						return "Ladrillo azul";
					case EntityID.ItemID.BLUE_BRICK_WALL:
						return "Pared de ladrillo azul";
					case EntityID.ItemID.CHAIN_LANTERN:
						return "Farolillo";
					case EntityID.ItemID.GREEN_BRICK:
						return "Ladrillo verde";
					case EntityID.ItemID.GREEN_BRICK_WALL:
						return "Pared de ladrillo verde";
					case EntityID.ItemID.PINK_BRICK:
						return "Ladrillo rosa";
					case EntityID.ItemID.PINK_BRICK_WALL:
						return "Pared de ladrillo rosa";
					case EntityID.ItemID.GOLD_BRICK:
						return "Ladrillo dorado";
					case EntityID.ItemID.GOLD_BRICK_WALL:
						return "Pared de ladrillo dorado";
					case EntityID.ItemID.SILVER_BRICK:
						return "Ladrillo plateado";
					case EntityID.ItemID.SILVER_BRICK_WALL:
						return "Pared de ladrillo plateado";
					case EntityID.ItemID.COPPER_BRICK:
						return "Ladrillo cobrizo";
					case EntityID.ItemID.COPPER_BRICK_WALL:
						return "Pared de ladrillo cobrizo";
					case EntityID.ItemID.SPIKE:
						return "Púa";
					case EntityID.ItemID.WATER_CANDLE:
						return "Vela de agua";
					case EntityID.ItemID.BOOK:
						return "Libro";
					case EntityID.ItemID.COBWEB:
						return "Telaraña";
					case EntityID.ItemID.NECRO_HELMET:
						return "Casco de los muertos";
					case EntityID.ItemID.NECRO_BREASTPLATE:
						return "Peto de los muertos";
					case EntityID.ItemID.NECRO_GREAVES:
						return "Grebas de los muertos";
					case EntityID.ItemID.BONE:
						return "Hueso";
					case EntityID.ItemID.MURAMASA:
						return "Muramasa";
					case EntityID.ItemID.COBALT_SHIELD:
						return "Escudo de cobalto";
					case EntityID.ItemID.AQUA_SCEPTER:
						return "Cetro de agua";
					case EntityID.ItemID.LUCKY_HORSESHOE:
						return "Herradura de la suerte";
					case EntityID.ItemID.SHINY_RED_BALLOON:
						return "Globo rojo brillante";
					case EntityID.ItemID.HARPOON:
						return "Arpón";
					case EntityID.ItemID.SPIKY_BALL:
						return "Bola con pinchos";
					case EntityID.ItemID.BALL_O_HURT:
						return "Flagelo con bola";
					case EntityID.ItemID.BLUE_MOON:
						return "Luna azul";
					case EntityID.ItemID.HANDGUN:
						return "Pistola";
					case EntityID.ItemID.WATER_BOLT:
						return "Proyectil de agua";
					case EntityID.ItemID.BOMB:
						return "Bomba";
					case EntityID.ItemID.DYNAMITE:
						return "Dinamita";
					case EntityID.ItemID.GRENADE:
						return "Granada";
					case EntityID.ItemID.SAND_BLOCK:
						return "Bloque de arena";
					case EntityID.ItemID.GLASS:
						return "Cristal";
					case EntityID.ItemID.SIGN:
						return "Cartel";
					case EntityID.ItemID.ASH_BLOCK:
						return "Bloque de ceniza";
					case EntityID.ItemID.OBSIDIAN:
						return "Obsidiana";
					case EntityID.ItemID.HELLSTONE:
						return "Piedra infernal";
					case EntityID.ItemID.HELLSTONE_BAR:
						return "Lingote de piedra infernal";
					case EntityID.ItemID.MUD_BLOCK:
						return "Bloque de lodo";
					case EntityID.ItemID.SAPPHIRE:
						return "Zafiro";
					case EntityID.ItemID.RUBY:
						return "Rubí";
					case EntityID.ItemID.EMERALD:
						return "Esmeralda";
					case EntityID.ItemID.TOPAZ:
						return "Topacio";
					case EntityID.ItemID.AMETHYST:
						return "Amatista";
					case EntityID.ItemID.DIAMOND:
						return "Diamante";
					case EntityID.ItemID.GLOWING_MUSHROOM:
						return "Champiñón brillante";
					case EntityID.ItemID.STAR:
						return "Estrella";
					case EntityID.ItemID.IVY_WHIP:
						return "Látigo de hiedra";
					case EntityID.ItemID.BREATHING_REED:
						return "Caña para respirar";
					case EntityID.ItemID.FLIPPER:
						return "Aletas";
					case EntityID.ItemID.HEALING_POTION:
						return "Poción curativa";
					case EntityID.ItemID.MANA_POTION:
						return "Poción de maná";
					case EntityID.ItemID.BLADE_OF_GRASS:
						return "Espada de hierba";
					case EntityID.ItemID.THORN_CHAKRAM:
						return "Chakram de espinas";
					case EntityID.ItemID.OBSIDIAN_BRICK:
						return "Ladrillo de obsidiana";
					case EntityID.ItemID.OBSIDIAN_SKULL:
						return "Calavera obsidiana";
					case EntityID.ItemID.MUSHROOM_GRASS_SEEDS:
						return "Semillas de césped-champiñón";
					case EntityID.ItemID.JUNGLE_GRASS_SEEDS:
						return "Semillas de césped selvático";
					case EntityID.ItemID.WOODEN_HAMMER:
						return "Martillo de madera";
					case EntityID.ItemID.STAR_CANNON:
						return "Cañón de estrellas";
					case EntityID.ItemID.BLUE_PHASEBLADE:
						return "Espada de luz azul";
					case EntityID.ItemID.RED_PHASEBLADE:
						return "Espada de luz roja";
					case EntityID.ItemID.GREEN_PHASEBLADE:
						return "Espada de luz verde";
					case EntityID.ItemID.PURPLE_PHASEBLADE:
						return "Espada de luz morada";
					case EntityID.ItemID.WHITE_PHASEBLADE:
						return "Espada de luz blanca";
					case EntityID.ItemID.YELLOW_PHASEBLADE:
						return "Espada de luz amarilla";
					case EntityID.ItemID.METEOR_HAMAXE:
						return "Hacha-martillo de meteorito";
					case EntityID.ItemID.EMPTY_BUCKET:
						return "Cubo vacío";
					case EntityID.ItemID.WATER_BUCKET:
						return "Cubo de agua";
					case EntityID.ItemID.LAVA_BUCKET:
						return "Cubo de lava";
					case EntityID.ItemID.JUNGLE_ROSE:
						return "Rosa de la selva";
					case EntityID.ItemID.STINGER:
						return "Aguijón";
					case EntityID.ItemID.VINE:
						return "Enredadera";
					case EntityID.ItemID.FERAL_CLAWS:
						return "Garras de bestia";
					case EntityID.ItemID.ANKLET_OF_THE_WIND:
						return "Tobillera de viento";
					case EntityID.ItemID.STAFF_OF_REGROWTH:
						return "Báculo de regeneración";
					case EntityID.ItemID.HELLSTONE_BRICK:
						return "Ladrillo de piedra infernal";
					case EntityID.ItemID.WHOOPIE_CUSHION:
						return "Cojín flatulento";
					case EntityID.ItemID.SHACKLE:
						return "Argolla";
					case EntityID.ItemID.MOLTEN_HAMAXE:
						return "Hacha-martillo fundido";
					case EntityID.ItemID.FLAMELASH:
						return "Látigo de llamas";
					case EntityID.ItemID.PHOENIX_BLASTER:
						return "Desintegrador Fénix";
					case EntityID.ItemID.SUNFURY:
						return "Furia solar";
					case EntityID.ItemID.HELLFORGE:
						return "Forja infernal";
					case EntityID.ItemID.CLAY_POT:
						return "Recipiente de barro";
					case EntityID.ItemID.NATURES_GIFT:
						return "Don de la naturaleza";
					case EntityID.ItemID.BED:
						return "Cama";
					case EntityID.ItemID.SILK:
						return "Seda";
					case EntityID.ItemID.LESSER_RESTORATION_POTION:
						return "Poción de recuperación menor";
					case EntityID.ItemID.RESTORATION_POTION:
						return "Poción de recuperación";
					case EntityID.ItemID.JUNGLE_HAT:
						return "Casco para la selva";
					case EntityID.ItemID.JUNGLE_SHIRT:
						return "Camisa para la selva";
					case EntityID.ItemID.JUNGLE_PANTS:
						return "Pantalones para la selva";
					case EntityID.ItemID.MOLTEN_HELMET:
						return "Casco fundido";
					case EntityID.ItemID.MOLTEN_BREASTPLATE:
						return "Peto fundido";
					case EntityID.ItemID.MOLTEN_GREAVES:
						return "Grebas fundidas";
					case EntityID.ItemID.METEOR_SHOT:
						return "Proyectil de meteorito";
					case EntityID.ItemID.STICKY_BOMB:
						return "Bomba lapa";
					case EntityID.ItemID.BLACK_LENS:
						return "Lentes negras";
					case EntityID.ItemID.SUNGLASSES:
						return "Gafas de sol";
					case EntityID.ItemID.WIZARD_HAT:
						return "Sombrero de mago";
					case EntityID.ItemID.TOP_HAT:
						return "Sombrero de copa";
					case EntityID.ItemID.TUXEDO_SHIRT:
						return "Camisa de esmoquin";
					case EntityID.ItemID.TUXEDO_PANTS:
						return "Pantalones de esmoquin";
					case EntityID.ItemID.SUMMER_HAT:
						return "Sombrero veraniego";
					case EntityID.ItemID.BUNNY_HOOD:
						return "Máscara de conejito";
					case EntityID.ItemID.PLUMBERS_HAT:
						return "Gorra de fontanero";
					case EntityID.ItemID.PLUMBERS_SHIRT:
						return "Camisa de fontanero";
					case EntityID.ItemID.PLUMBERS_PANTS:
						return "Pantalones de fontanero";
					case EntityID.ItemID.HEROS_HAT:
						return "Gorro de héroe";
					case EntityID.ItemID.HEROS_SHIRT:
						return "Camisa de héroe";
					case EntityID.ItemID.HEROS_PANTS:
						return "Pantalones de héroe";
					case EntityID.ItemID.FISH_BOWL:
						return "Pecera";
					case EntityID.ItemID.ARCHAEOLOGISTS_HAT:
						return "Sombrero de arqueólogo";
					case EntityID.ItemID.ARCHAEOLOGISTS_JACKET:
						return "Chaqueta de arqueólogo";
					case EntityID.ItemID.ARCHAEOLOGISTS_PANTS:
						return "Pantalones de arqueólogo";
#if VERSION_INITIAL
					case EntityID.ItemID.BLACK_THREAD:
						return "Tinte negro";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Tinte violeta";
#else
					case EntityID.ItemID.BLACK_THREAD:
						return "Hilo negro";
					case EntityID.ItemID.PURPLE_THREAD:
						return "Hilo morado";
#endif
					case EntityID.ItemID.NINJA_HOOD:
						return "Gorro de ninja";
					case EntityID.ItemID.NINJA_SHIRT:
						return "Camisa de ninja";
					case EntityID.ItemID.NINJA_PANTS:
						return "Pantalones de ninja";
					case EntityID.ItemID.LEATHER:
						return "Cuero";
					case EntityID.ItemID.RED_HAT:
						return "Sombrero rojo";
					case EntityID.ItemID.GOLDFISH:
						return "Pececillo";
					case EntityID.ItemID.ROBE:
						return "Vestido";
					case EntityID.ItemID.ROBOT_HAT:
						return "Sombrero de robot";
					case EntityID.ItemID.GOLD_CROWN:
						return "Corona de oro";
					case EntityID.ItemID.HELLFIRE_ARROW:
						return "Flecha de fuego infernal";
					case EntityID.ItemID.SANDGUN:
						return "Pistola de arena";
					case EntityID.ItemID.GUIDE_VOODOO_DOLL:
						return "Muñeco vudú del guía";
					case EntityID.ItemID.DIVING_HELMET:
						return "Casco de buceo";
					case EntityID.ItemID.FAMILIAR_SHIRT:
						return "Camisa informal";
					case EntityID.ItemID.FAMILIAR_PANTS:
						return "Pantalones informales";
					case EntityID.ItemID.FAMILIAR_WIG:
						return "Peluca informal";
					case EntityID.ItemID.DEMON_SCYTHE:
						return "Guadaña demoníaca";
					case EntityID.ItemID.NIGHTS_EDGE:
						return "Espada de la noche";
					case EntityID.ItemID.DARK_LANCE:
						return "Lanza de la oscuridad";
					case EntityID.ItemID.CORAL:
						return "Coral";
					case EntityID.ItemID.CACTUS:
						return "Cactus";
					case EntityID.ItemID.TRIDENT:
						return "Tridente";
					case EntityID.ItemID.SILVER_BULLET:
						return "Bala de plata";
					case EntityID.ItemID.THROWING_KNIFE:
						return "Cuchillo arrojadizo";
					case EntityID.ItemID.SPEAR:
						return "Lanza";
					case EntityID.ItemID.BLOWPIPE:
						return "Cerbatana";
					case EntityID.ItemID.GLOWSTICK:
						return "Varita luminosa";
					case EntityID.ItemID.SEED:
						return "Semilla";
					case EntityID.ItemID.WOODEN_BOOMERANG:
						return "Bumerán de madera";
					case EntityID.ItemID.AGLET:
						return "Herrete";
					case EntityID.ItemID.STICKY_GLOWSTICK:
						return "Varita luminosa adhesiva";
					case EntityID.ItemID.POISONED_KNIFE:
						return "Cuchillo envenenado";
					case EntityID.ItemID.OBSIDIAN_SKIN_POTION:
						return "Poción de piel obsidiana";
					case EntityID.ItemID.REGENERATION_POTION:
						return "Poción de regeneración";
					case EntityID.ItemID.SWIFTNESS_POTION:
						return "Poción de rapidez";
					case EntityID.ItemID.GILLS_POTION:
						return "Poción de agallas";
					case EntityID.ItemID.IRONSKIN_POTION:
						return "Poción de piel de hierro";
					case EntityID.ItemID.MANA_REGENERATION_POTION:
						return "Poción de regeneración de maná";
					case EntityID.ItemID.MAGIC_POWER_POTION:
						return "Poción de poder mágico";
					case EntityID.ItemID.FEATHERFALL_POTION:
						return "Poción de caída de pluma";
					case EntityID.ItemID.SPELUNKER_POTION:
						return "Poción de espeleólogo";
					case EntityID.ItemID.INVISIBILITY_POTION:
						return "Poción de invisibilidad";
					case EntityID.ItemID.SHINE_POTION:
						return "Poción de brillo";
					case EntityID.ItemID.NIGHT_OWL_POTION:
						return "Poción de noctámbulo";
					case EntityID.ItemID.BATTLE_POTION:
						return "Poción de batalla";
					case EntityID.ItemID.THORNS_POTION:
						return "Poción de espinas";
					case EntityID.ItemID.WATER_WALKING_POTION:
						return "Poción de flotación";
					case EntityID.ItemID.ARCHERY_POTION:
						return "Poción de tiro con arco";
					case EntityID.ItemID.HUNTER_POTION:
						return "Poción de cazador";
					case EntityID.ItemID.GRAVITATION_POTION:
						return "Poción de gravedad";
					case EntityID.ItemID.GOLD_CHEST:
						return "Cofre de oro";
					case EntityID.ItemID.DAYBLOOM_SEEDS:
						return "Semillas de resplandor diurno";
					case EntityID.ItemID.MOONGLOW_SEEDS:
						return "Semillas de luz de luna";
					case EntityID.ItemID.BLINKROOT_SEEDS:
						return "Semillas de raíz intermitente";
					case EntityID.ItemID.DEATHWEED_SEEDS:
						return "Semillas de malahierba";
					case EntityID.ItemID.WATERLEAF_SEEDS:
						return "Semillas de hoja de agua";
					case EntityID.ItemID.FIREBLOSSOM_SEEDS:
						return "Semillas de resplandor de fuego";
					case EntityID.ItemID.DAYBLOOM:
						return "Resplandor diurno";
					case EntityID.ItemID.MOONGLOW:
						return "Luz de luna";
					case EntityID.ItemID.BLINKROOT:
						return "Raíz intermitente";
					case EntityID.ItemID.DEATHWEED:
						return "Malahierba";
					case EntityID.ItemID.WATERLEAF:
						return "Hoja de agua";
					case EntityID.ItemID.FIREBLOSSOM:
						return "Resplandor de fuego";
					case EntityID.ItemID.SHARK_FIN:
						return "Aleta de tiburón";
					case EntityID.ItemID.FEATHER:
						return "Pluma";
					case EntityID.ItemID.TOMBSTONE:
						return "Lápida";
					case EntityID.ItemID.MIME_MASK:
						return "Máscara de mimo";
					case EntityID.ItemID.ANTLION_MANDIBLE:
						return "Mandíbula de hormiga león";
					case EntityID.ItemID.ILLEGAL_GUN_PARTS:
						return "Piezas de arma ilegales";
					case EntityID.ItemID.THE_DOCTORS_SHIRT:
						return "Camisa del doctor";
					case EntityID.ItemID.THE_DOCTORS_PANTS:
						return "Pantalones del doctor";
					case EntityID.ItemID.GOLDEN_KEY:
						return "Llave dorada";
					case EntityID.ItemID.SHADOW_CHEST:
						return "Cofre de las sombras";
					case EntityID.ItemID.SHADOW_KEY:
						return "Llave de las sombras";
					case EntityID.ItemID.OBSIDIAN_BRICK_WALL:
						return "Pared de ladrillo de obsidiana";
					case EntityID.ItemID.JUNGLE_SPORES:
						return "Esporas de la selva";
					case EntityID.ItemID.LOOM:
						return "Telar";
					case EntityID.ItemID.PIANO:
						return "Piano";
					case EntityID.ItemID.DRESSER:
						return "Aparador";
					case EntityID.ItemID.BENCH:
						return "Banco";
					case EntityID.ItemID.BATHTUB:
						return "Bañera";
					case EntityID.ItemID.RED_BANNER:
						return "Estandarte rojo";
					case EntityID.ItemID.GREEN_BANNER:
						return "Estandarte verde";
					case EntityID.ItemID.BLUE_BANNER:
						return "Estandarte azul";
					case EntityID.ItemID.YELLOW_BANNER:
						return "Estandarte amarillo";
					case EntityID.ItemID.LAMP_POST:
						return "Farola";
					case EntityID.ItemID.TIKI_TORCH:
						return "Antorcha tiki";
					case EntityID.ItemID.BARREL:
						return "Barril";
					case EntityID.ItemID.CHINESE_LANTERN:
						return "Farolillo de papel";
					case EntityID.ItemID.COOKING_POT:
						return "Perol";
					case EntityID.ItemID.SAFE:
						return "Caja fuerte";
					case EntityID.ItemID.SKULL_LANTERN:
						return "Cráneo con vela";
					case EntityID.ItemID.TRASH_CAN:
						return "Cubo de basura";
					case EntityID.ItemID.CANDELABRA:
						return "Candelabro";
					case EntityID.ItemID.PINK_VASE:
						return "Recipiente rosa";
					case EntityID.ItemID.MUG:
						return "Taza";
					case EntityID.ItemID.KEG:
						return "Barrica";
					case EntityID.ItemID.ALE:
						return "Cerveza";
					case EntityID.ItemID.BOOKCASE:
						return "Librería";
					case EntityID.ItemID.THRONE:
						return "Trono";
					case EntityID.ItemID.BOWL:
						return "Cuenco";
					case EntityID.ItemID.BOWL_OF_SOUP:
						return "Cuenco de sopa";
					case EntityID.ItemID.TOILET:
						return "Retrete";
					case EntityID.ItemID.GRANDFATHER_CLOCK:
						return "Reloj de pie";
					case EntityID.ItemID.STATUE:
						return "Estatua de armadura";
					case EntityID.ItemID.GOBLIN_BATTLE_STANDARD:
						return "Estandarte de batalla duende";
					case EntityID.ItemID.TATTERED_CLOTH:
						return "Harapos";
					case EntityID.ItemID.SAWMILL:
						return "Serrería";
					case EntityID.ItemID.COBALT_ORE:
						return "Mineral de cobalto";
					case EntityID.ItemID.MYTHRIL_ORE:
						return "Mineral de mithril";
					case EntityID.ItemID.ADAMANTITE_ORE:
						return "Mineral de adamantita";
					case EntityID.ItemID.PWNHAMMER:
						return "Gran martillo";
					case EntityID.ItemID.EXCALIBUR:
						return "Excalibur";
					case EntityID.ItemID.HALLOWED_SEEDS:
						return "Semillas sagradas";
					case EntityID.ItemID.EBONSAND_BLOCK:
						return "Bloque de arena de ébano";
					case EntityID.ItemID.COBALT_HAT:
						return "Gorro de cobalto";
					case EntityID.ItemID.COBALT_HELMET:
						return "Casco de cobalto";
					case EntityID.ItemID.COBALT_MASK:
						return "Máscara de cobalto";
					case EntityID.ItemID.COBALT_BREASTPLATE:
						return "Peto de cobalto";
					case EntityID.ItemID.COBALT_LEGGINGS:
						return "Perneras de cobalto";
					case EntityID.ItemID.MYTHRIL_HOOD:
						return "Caperuza de mithril";
					case EntityID.ItemID.MYTHRIL_HELMET:
						return "Casco de mithril";
					case EntityID.ItemID.MYTHRIL_HAT:
						return "Gorro de mithril";
					case EntityID.ItemID.MYTHRIL_CHAINMAIL:
						return "Cota de malla de mithril";
					case EntityID.ItemID.MYTHRIL_GREAVES:
						return "Grebas de mithril";
					case EntityID.ItemID.COBALT_BAR:
						return "Lingote de cobalto";
					case EntityID.ItemID.MYTHRIL_BAR:
						return "Lingote de mithril";
					case EntityID.ItemID.COBALT_CHAINSAW:
						return "Motosierra de cobalto";
					case EntityID.ItemID.MYTHRIL_CHAINSAW:
						return "Motosierra de mithril";
					case EntityID.ItemID.COBALT_DRILL:
						return "Taladro de cobalto";
					case EntityID.ItemID.MYTHRIL_DRILL:
						return "Taladro de mithril";
					case EntityID.ItemID.ADAMANTITE_CHAINSAW:
						return "Motosierra de adamantita";
					case EntityID.ItemID.ADAMANTITE_DRILL:
						return "Taladro de adamantita";
					case EntityID.ItemID.DAO_OF_POW:
						return "Flagelo Taoísta";
					case EntityID.ItemID.MYTHRIL_HALBERD:
						return "Alabarda de mithril";
					case EntityID.ItemID.ADAMANTITE_BAR:
						return "Lingote de adamantita";
					case EntityID.ItemID.GLASS_WALL:
						return "Pared de cristal";
					case EntityID.ItemID.COMPASS:
						return "Brújula";
					case EntityID.ItemID.DIVING_GEAR:
						return "Equipo de buceo";
					case EntityID.ItemID.GPS:
						return "GPS";
					case EntityID.ItemID.OBSIDIAN_HORSESHOE:
						return "Herradura de obsidiana";
					case EntityID.ItemID.OBSIDIAN_SHIELD:
						return "Escudo de obsidiana";
					case EntityID.ItemID.TINKERERS_WORKSHOP:
						return "Taller de chapuzas";
					case EntityID.ItemID.CLOUD_IN_A_BALLOON:
						return "Nube en globo";
					case EntityID.ItemID.ADAMANTITE_HEADGEAR:
						return "Tocado de adamantita";
					case EntityID.ItemID.ADAMANTITE_HELMET:
						return "Casco de adamantita";
					case EntityID.ItemID.ADAMANTITE_MASK:
						return "Máscara de adamantita";
					case EntityID.ItemID.ADAMANTITE_BREASTPLATE:
						return "Peto de adamantita";
					case EntityID.ItemID.ADAMANTITE_LEGGINGS:
						return "Polainas de adamantita";
					case EntityID.ItemID.SPECTRE_BOOTS:
						return "Botas de espectro";
					case EntityID.ItemID.ADAMANTITE_GLAIVE:
						return "Guja de adamantita";
					case EntityID.ItemID.TOOLBELT:
						return "Cinturón de herramientas";
					case EntityID.ItemID.PEARLSAND_BLOCK:
						return "Bloque de arena perlada";
					case EntityID.ItemID.PEARLSTONE_BLOCK:
						return "Bloque de piedra perlada";
					case EntityID.ItemID.MINING_SHIRT:
						return "Camisa de minero";
					case EntityID.ItemID.MINING_PANTS:
						return "Pantalones de minero";
					case EntityID.ItemID.PEARLSTONE_BRICK:
						return "Ladrillo de piedra perlada";
					case EntityID.ItemID.IRIDESCENT_BRICK:
						return "Ladrillo tornasol";
					case EntityID.ItemID.MUDSTONE_BRICK:
						return "Ladrillo de lutita";
					case EntityID.ItemID.COBALT_BRICK:
						return "Ladrillo de cobalto";
					case EntityID.ItemID.MYTHRIL_BRICK:
						return "Ladrillo de mithril";
					case EntityID.ItemID.PEARLSTONE_BRICK_WALL:
						return "Pared de ladrillo de piedra perlada";
					case EntityID.ItemID.IRIDESCENT_BRICK_WALL:
						return "Pared de ladrillo tornasol";
					case EntityID.ItemID.MUDSTONE_BRICK_WALL:
						return "Pared de ladrillo de lutita";
					case EntityID.ItemID.COBALT_BRICK_WALL:
						return "Pared de ladrillo de cobalto";
					case EntityID.ItemID.MYTHRIL_BRICK_WALL:
						return "Pared de ladrillo de mithril";
					case EntityID.ItemID.HOLY_WATER:
						return "Agua sagrada";
					case EntityID.ItemID.UNHOLY_WATER:
						return "Agua impura";
					case EntityID.ItemID.SILT_BLOCK:
						return "Bloque de limo";
					case EntityID.ItemID.FAIRY_BELL:
						return "Campana de hada";
					case EntityID.ItemID.BREAKER_BLADE:
						return "Espada despedazadora";
					case EntityID.ItemID.BLUE_TORCH:
						return "Antorcha azul";
					case EntityID.ItemID.RED_TORCH:
						return "Antorcha roja";
					case EntityID.ItemID.GREEN_TORCH:
						return "Antorcha verde";
					case EntityID.ItemID.PURPLE_TORCH:
						return "Antorcha morada";
					case EntityID.ItemID.WHITE_TORCH:
						return "Antorcha blanca";
					case EntityID.ItemID.YELLOW_TORCH:
						return "Antorcha amarilla";
					case EntityID.ItemID.DEMON_TORCH:
						return "Antorcha demoníaca";
					case EntityID.ItemID.CLOCKWORK_ASSAULT_RIFLE:
						return "Fusil de asalto de precisión";
					case EntityID.ItemID.COBALT_REPEATER:
						return "Repetidor de cobalto";
					case EntityID.ItemID.MYTHRIL_REPEATER:
						return "Repetidor de mithril";
					case EntityID.ItemID.DUAL_HOOK:
						return "Gancho doble";
					case EntityID.ItemID.STAR_STATUE:
						return "Estatua de estrella";
					case EntityID.ItemID.SWORD_STATUE:
						return "Estatua de espada";
					case EntityID.ItemID.SLIME_STATUE:
						return "Estatua de slime";
					case EntityID.ItemID.GOBLIN_STATUE:
						return "Estatua de duende";
					case EntityID.ItemID.SHIELD_STATUE:
						return "Estatua de escudo";
					case EntityID.ItemID.BAT_STATUE:
						return "Estatua de murciélago";
					case EntityID.ItemID.FISH_STATUE:
						return "Estatua de pez";
					case EntityID.ItemID.BUNNY_STATUE:
						return "Estatua de conejito";
					case EntityID.ItemID.SKELETON_STATUE:
						return "Estatua de esqueleto";
					case EntityID.ItemID.REAPER_STATUE:
						return "Estatua de la Muerte";
					case EntityID.ItemID.WOMAN_STATUE:
						return "Estatua de mujer";
					case EntityID.ItemID.IMP_STATUE:
						return "Estatua de diablillo";
					case EntityID.ItemID.GARGOYLE_STATUE:
						return "Estatua de gárgola";
					case EntityID.ItemID.GLOOM_STATUE:
						return "Estatua melancólica";
					case EntityID.ItemID.HORNET_STATUE:
						return "Estatua de avispón";
					case EntityID.ItemID.BOMB_STATUE:
						return "Estatua de bomba";
					case EntityID.ItemID.CRAB_STATUE:
						return "Estatua de cangrejo";
					case EntityID.ItemID.HAMMER_STATUE:
						return "Estatua de martilla";
					case EntityID.ItemID.POTION_STATUE:
						return "Estatua de poción";
					case EntityID.ItemID.SPEAR_STATUE:
						return "Estatua de lanza";
					case EntityID.ItemID.CROSS_STATUE:
						return "Estatua de cruz";
					case EntityID.ItemID.JELLYFISH_STATUE:
						return "Estatua de medusa";
					case EntityID.ItemID.BOW_STATUE:
						return "Estatua de arco";
					case EntityID.ItemID.BOOMERANG_STATUE:
						return "Estatua de bumerán";
					case EntityID.ItemID.BOOT_STATUE:
						return "Estatua de bota";
					case EntityID.ItemID.CHEST_STATUE:
						return "Estatua de cofre";
					case EntityID.ItemID.BIRD_STATUE:
						return "Estatua de pájaro";
					case EntityID.ItemID.AXE_STATUE:
						return "Estatua de hacha";
					case EntityID.ItemID.CORRUPT_STATUE:
						return "Estatua de corrupción";
					case EntityID.ItemID.TREE_STATUE:
						return "Estatua de árbol";
					case EntityID.ItemID.ANVIL_STATUE:
						return "Estatua de yunque";
					case EntityID.ItemID.PICKAXE_STATUE:
						return "Estatua de pico";
					case EntityID.ItemID.MUSHROOM_STATUE:
						return "Estatua de champiñón";
					case EntityID.ItemID.EYEBALL_STATUE:
						return "Estatua de ojo";
					case EntityID.ItemID.PILLAR_STATUE:
						return "Estatua de columna";
					case EntityID.ItemID.HEART_STATUE:
						return "Estatua de corazón";
					case EntityID.ItemID.POT_STATUE:
						return "Estatua de marmita";
					case EntityID.ItemID.SUNFLOWER_STATUE:
						return "Estatua de girasol";
					case EntityID.ItemID.KING_STATUE:
						return "Estatua de rey";
					case EntityID.ItemID.QUEEN_STATUE:
						return "Estatua de reina";
					case EntityID.ItemID.PIRANHA_STATUE:
						return "Estatua de piraña";
					case EntityID.ItemID.PLANKED_WALL:
						return "Pared de tablones";
					case EntityID.ItemID.WOODEN_BEAM:
						return "Viga de madera";
					case EntityID.ItemID.ADAMANTITE_REPEATER:
						return "Repetidor de adamantita";
					case EntityID.ItemID.ADAMANTITE_SWORD:
						return "Espada de adamantita";
					case EntityID.ItemID.COBALT_SWORD:
						return "Espada de cobalto";
					case EntityID.ItemID.MYTHRIL_SWORD:
						return "Espada de mithril";
					case EntityID.ItemID.MOON_CHARM:
						return "Hechizo de luna";
					case EntityID.ItemID.RULER:
						return "Regla";
					case EntityID.ItemID.CRYSTAL_BALL:
						return "Bola de cristal";
					case EntityID.ItemID.DISCO_BALL:
						return "Bola de discoteca";
					case EntityID.ItemID.SORCERER_EMBLEM:
						return "Emblema de hechicero";
					case EntityID.ItemID.WARRIOR_EMBLEM:
						return "Emblema de guerrero";
					case EntityID.ItemID.RANGER_EMBLEM:
						return "Emblema de guardián";
					case EntityID.ItemID.DEMON_WINGS:
						return "Alas demoníacas";
					case EntityID.ItemID.ANGEL_WINGS:
						return "Alas de ángel";
					case EntityID.ItemID.MAGICAL_HARP:
						return "Arpa mágica";
					case EntityID.ItemID.RAINBOW_ROD:
						return "Varita multicolor";
					case EntityID.ItemID.ICE_ROD:
						return "Varita helada";
					case EntityID.ItemID.NEPTUNES_SHELL:
						return "Concha de Neptuno";
					case EntityID.ItemID.MANNEQUIN:
						return "Maniquí";
					case EntityID.ItemID.GREATER_HEALING_POTION:
						return "Poción curativa mayor";
					case EntityID.ItemID.GREATER_MANA_POTION:
						return "Poción de maná mayor";
					case EntityID.ItemID.PIXIE_DUST:
						return "Polvo de hada";
					case EntityID.ItemID.CRYSTAL_SHARD:
						return "Fragmento de cristal";
					case EntityID.ItemID.CLOWN_HAT:
						return "Sombrero de payaso";
					case EntityID.ItemID.CLOWN_SHIRT:
						return "Camisa de payaso";
					case EntityID.ItemID.CLOWN_PANTS:
						return "Pantalones de payaso";
					case EntityID.ItemID.FLAMETHROWER:
						return "Lanzallamas";
					case EntityID.ItemID.BELL:
						return "Campana";
					case EntityID.ItemID.HARP:
						return "Arpa";
					case EntityID.ItemID.WRENCH:
						return "Llave inglesa";
					case EntityID.ItemID.WIRE_CUTTER:
						return "Alicates";
					case EntityID.ItemID.ACTIVE_STONE_BLOCK:
						return "Bloque de piedra activo";
					case EntityID.ItemID.INACTIVE_STONE_BLOCK:
						return "Bloque de piedra inactivo";
					case EntityID.ItemID.LEVER:
						return "Palanca";
					case EntityID.ItemID.LASER_RIFLE:
						return "Fusil láser";
					case EntityID.ItemID.CRYSTAL_BULLET:
						return "Bala de cristal";
					case EntityID.ItemID.HOLY_ARROW:
						return "Flecha sagrada";
					case EntityID.ItemID.MAGIC_DAGGER:
						return "Daga mágica";
					case EntityID.ItemID.CRYSTAL_STORM:
						return "Tormenta de cristal";
					case EntityID.ItemID.CURSED_FLAMES:
						return "Llamas malditas";
					case EntityID.ItemID.SOUL_OF_LIGHT:
						return "Alma de luz";
					case EntityID.ItemID.SOUL_OF_NIGHT:
						return "Alma de noche";
					case EntityID.ItemID.CURSED_FLAME:
						return "Llama maldita";
					case EntityID.ItemID.CURSED_TORCH:
						return "Antorcha maldita";
					case EntityID.ItemID.ADAMANTITE_FORGE:
						return "Forja de adamantita";
					case EntityID.ItemID.MYTHRIL_ANVIL:
						return "Yunque de mithril";
					case EntityID.ItemID.UNICORN_HORN:
						return "Cuerno de unicornio";
					case EntityID.ItemID.DARK_SHARD:
						return "Fragmento de oscuridad";
					case EntityID.ItemID.LIGHT_SHARD:
						return "Fragmento de luz";
					case EntityID.ItemID.RED_PRESSURE_PLATE:
						return "Placa de presión roja";
					case EntityID.ItemID.WIRE:
						return "Alambre";
					case EntityID.ItemID.SPELL_TOME:
						return "Tomo encantado";
					case EntityID.ItemID.STAR_CLOAK:
						return "Manto de estrellas";
					case EntityID.ItemID.MEGASHARK:
						return "Megatiburón";
					case EntityID.ItemID.SHOTGUN:
						return "Escopeta";
					case EntityID.ItemID.PHILOSOPHERS_STONE:
						return "Piedra filosofal";
					case EntityID.ItemID.TITAN_GLOVE:
						return "Guante de titán";
					case EntityID.ItemID.COBALT_NAGINATA:
						return "Naginata de cobalto";
					case EntityID.ItemID.SWITCH:
						return "Interruptor";
					case EntityID.ItemID.DART_TRAP:
						return "Trampa de dardos";
					case EntityID.ItemID.BOULDER:
						return "Roca";
					case EntityID.ItemID.GREEN_PRESSURE_PLATE:
						return "Placa de presión verde";
					case EntityID.ItemID.GRAY_PRESSURE_PLATE:
						return "Placa de presión gris";
					case EntityID.ItemID.BROWN_PRESSURE_PLATE:
						return "Placa de presión marrón";
					case EntityID.ItemID.MECHANICAL_EYE:
						return "Ojo mecánico";
					case EntityID.ItemID.CURSED_ARROW:
						return "Flecha maldita";
					case EntityID.ItemID.CURSED_BULLET:
						return "Bala maldita";
					case EntityID.ItemID.SOUL_OF_FRIGHT:
						return "Alma de terror";
					case EntityID.ItemID.SOUL_OF_MIGHT:
						return "Alma de poder";
					case EntityID.ItemID.SOUL_OF_SIGHT:
						return "Alma de visión";
					case EntityID.ItemID.GUNGNIR:
						return "Gungnir";
					case EntityID.ItemID.HALLOWED_PLATE_MAIL:
						return "Cota de placas sagrada";
					case EntityID.ItemID.HALLOWED_GREAVES:
						return "Grebas sagradas";
					case EntityID.ItemID.HALLOWED_HELMET:
						return "Casco sagrado";
					case EntityID.ItemID.CROSS_NECKLACE:
						return "Collar con cruz";
					case EntityID.ItemID.MANA_FLOWER:
						return "Flor de maná";
					case EntityID.ItemID.MECHANICAL_WORM:
						return "Gusano mecánico";
					case EntityID.ItemID.MECHANICAL_SKULL:
						return "Cráneo mecánico";
					case EntityID.ItemID.HALLOWED_HEADGEAR:
						return "Tocado sagrado";
					case EntityID.ItemID.HALLOWED_MASK:
						return "Máscara sagrada";
					case EntityID.ItemID.SLIME_CROWN:
						return "Corona de slime";
					case EntityID.ItemID.LIGHT_DISC:
						return "Disco de luz";
					case EntityID.ItemID.MUSIC_BOX_OVERWORLD_DAY:
						return "Caja de música (Superficie de día)";
					case EntityID.ItemID.MUSIC_BOX_EERIE:
						return "Caja de música (Sobrecogedor)";
					case EntityID.ItemID.MUSIC_BOX_NIGHT:
						return "Caja de música (Noche)";
					case EntityID.ItemID.MUSIC_BOX_TITLE:
						return "Caja de música (Título)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND:
						return "Caja de música (Subsuelo)";
					case EntityID.ItemID.MUSIC_BOX_BOSS1:
						return "Caja de música (Jefe 1)";
					case EntityID.ItemID.MUSIC_BOX_JUNGLE:
						return "Caja de música (Selva)";
					case EntityID.ItemID.MUSIC_BOX_CORRUPTION:
						return "Caja de música (Corrupción)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_CORRUPTION:
						return "Caja de música (Corrupción en el subsuelo)";
					case EntityID.ItemID.MUSIC_BOX_THE_HALLOW:
						return "Caja de música (Terreno sagrado)";
					case EntityID.ItemID.MUSIC_BOX_BOSS2:
						return "Caja de música (Jefe 2)";
					case EntityID.ItemID.MUSIC_BOX_UNDERGROUND_HALLOW:
						return "Caja de música (Subsuelo sagrado)";
					case EntityID.ItemID.MUSIC_BOX_BOSS3:
						return "Caja de música (Jefe 3)";
					case EntityID.ItemID.SOUL_OF_FLIGHT:
						return "Alma de vuelo";
					case EntityID.ItemID.MUSIC_BOX:
						return "Caja de música";
					case EntityID.ItemID.DEMONITE_BRICK:
						return "Ladrillo endemoniado";
					case EntityID.ItemID.HALLOWED_REPEATER:
						return "Repetidor sagrado";
					case EntityID.ItemID.HAMDRAX:
						return "Martitaladrahacha";
					case EntityID.ItemID.EXPLOSIVES:
						return "Explosivos";
					case EntityID.ItemID.INLET_PUMP:
						return "Colector de entrada";
					case EntityID.ItemID.OUTLET_PUMP:
						return "Colector de salida";
					case EntityID.ItemID.ONE_SECOND_TIMER:
						return "Temporizador de 1 segundo";
					case EntityID.ItemID.THREE_SECOND_TIMER:
						return "Temporizador de 3 segundos";
					case EntityID.ItemID.FIVE_SECOND_TIMER:
						return "Temporizador de 5 segundos";
					case EntityID.ItemID.CANDY_CANE_BLOCK:
						return "Bloque de caramelo";
					case EntityID.ItemID.CANDY_CANE_WALL:
						return "Pared de caramelo";
					case EntityID.ItemID.SANTA_HAT:
						return "Gorro de Papá Noel";
					case EntityID.ItemID.SANTA_SHIRT:
						return "Camisa de Papá Noel";
					case EntityID.ItemID.SANTA_PANTS:
						return "Pantalones Papá Noel";
					case EntityID.ItemID.GREEN_CANDY_CANE_BLOCK:
						return "Bloque de caramelo verde";
					case EntityID.ItemID.GREEN_CANDY_CANE_WALL:
						return "Pared de caramelo verde";
					case EntityID.ItemID.SNOW_BLOCK:
						return "Bloque de nieve";
					case EntityID.ItemID.SNOW_BRICK:
						return "Ladrillo de nieve";
					case EntityID.ItemID.SNOW_BRICK_WALL:
						return "Pared de ladrillos de nieve";
					case EntityID.ItemID.BLUE_LIGHT:
						return "Luz azul";
					case EntityID.ItemID.RED_LIGHT:
						return "Luz roja";
					case EntityID.ItemID.GREEN_LIGHT:
						return "Luz verde";
					case EntityID.ItemID.BLUE_PRESENT:
						return "Regalo azul";
					case EntityID.ItemID.GREEN_PRESENT:
						return "Regalo verde";
					case EntityID.ItemID.YELLOW_PRESENT:
						return "Regalo amarillo";
					case EntityID.ItemID.SNOW_GLOBE:
						return "Globo de nieve";
					case EntityID.ItemID.PET_SPAWN_1:
						return "Repollo";
					case EntityID.ItemID.DRAGON_MASK:
						return "Máscara de dragón";
					case EntityID.ItemID.TITAN_HELMET:
						return "Casco de titán";
					case EntityID.ItemID.SPECTRAL_HEADGEAR:
						return "Tocado espectral";
					case EntityID.ItemID.DRAGON_BREASTPLATE:
						return "Peto de dragón";
					case EntityID.ItemID.TITAN_MAIL:
						return "Malla de titán";
					case EntityID.ItemID.SPECTRAL_ARMOR:
						return "Armadura espectral";
					case EntityID.ItemID.DRAGON_GREAVES:
						return "Grebas de dragón";
					case EntityID.ItemID.TITAN_LEGGINGS:
						return "Perneras de titán";
					case EntityID.ItemID.SPECTRAL_SUBLIGAR:
						return "Liguero espectral";
					case EntityID.ItemID.TIZONA:
						return "Tizona";
					case EntityID.ItemID.TONBOGIRI:
						return "Tonbogiri";
					case EntityID.ItemID.SHARANGA:
						return "Sharanga";
					case EntityID.ItemID.SPECTRAL_ARROW:
						return "Flecha espectral";
					case EntityID.ItemID.VULCAN_REPEATER:
						return "Repetidor volcánico";
					case EntityID.ItemID.VULCAN_BOLT:
						return "Relámpago volcánico";
					case EntityID.ItemID.SUSPICIOUS_LOOKING_SKULL:
						return "Calavera de aspecto sospechoso";
					case EntityID.ItemID.SOUL_OF_BLIGHT:
						return "Alma enfermiza";
					case EntityID.ItemID.PET_SPAWN_2:
						return "Placa de Petri";
					case EntityID.ItemID.PET_SPAWN_3:
						return "Panal";
					case EntityID.ItemID.PET_SPAWN_4:
						return "Vial de sangre";
					case EntityID.ItemID.PET_SPAWN_5:
						return "Colmillo de lobo";
					case EntityID.ItemID.PET_SPAWN_6:
						return "Cerebro";
					case EntityID.ItemID.MUSIC_BOX_DESERT:
						return "Caja de música (Desierto)";
					case EntityID.ItemID.MUSIC_BOX_SPACE:
						return "Caja de música (Espacio)";
					case EntityID.ItemID.MUSIC_BOX_TUTORIAL:
						return "Caja de música (Tutorial)";
					case EntityID.ItemID.MUSIC_BOX_BOSS4:
						return "Caja de música (Enemigo final 4)";
					case EntityID.ItemID.MUSIC_BOX_OCEAN:
						return "Caja de música (Océano)";
					case EntityID.ItemID.MUSIC_BOX_SNOW:
						return "Caja de música (Nieve)";
#if VERSION_101
					case EntityID.ItemID.FABULOUS_RIBBON:
						return "Pajarita fabulosa";
					case EntityID.ItemID.GEORGES_HAT:
						return "Sombrero de George";
					case EntityID.ItemID.FABULOUS_TUTU:
						return "Tutú fabuloso";
					case EntityID.ItemID.GEORGES_TUXEDO_SHIRT:
						return "Camisa de esmoquin de George";
					case EntityID.ItemID.FABULOUS_SLIPPERS:
						return "Zapatillas fabulosas";
					case EntityID.ItemID.GEORGES_TUXEDO_PANTS:
						return "Pantalones de esmoquin de George";
					case EntityID.ItemID.SPARKLY_WINGS:
						return "Alas brillantes";
					case EntityID.ItemID.CAMPFIRE:
						return "Hoguera";
					case EntityID.ItemID.WOOD_HELMET:
						return "Casco de madera";
					case EntityID.ItemID.WOOD_BREASTPLATE:
						return "Peto de madera";
					case EntityID.ItemID.WOOD_GREAVES:
						return "Grebas de madera";
					case EntityID.ItemID.CACTUS_SWORD:
						return "Espada de cactus"; // This wasn't in the spanish strings file, so I don't know how it managed the name for the Cactus sword, if it did at all.
					case EntityID.ItemID.CACTUS_PICKAXE:
						return "Pico de cactus";
					case EntityID.ItemID.CACTUS_HELMET:
						return "Casco de cactus";
					case EntityID.ItemID.CACTUS_BREASTPLATE:
						return "Peto de cactus";
					case EntityID.ItemID.CACTUS_LEGGINGS:
						return "Perneras de cactus";
					case EntityID.ItemID.PURPLE_STAINED_GLASS_WALL:
						return "Vidriera morada";
					case EntityID.ItemID.YELLOW_STAINED_GLASS_WALL:
						return "Vidriera amarilla";
					case EntityID.ItemID.BLUE_STAINED_GLASS_WALL:
						return "Vidriera azul";
					case EntityID.ItemID.GREEN_STAINED_GLASS_WALL:
						return "Vidriera verde";
					case EntityID.ItemID.RED_STAINED_GLASS_WALL:
						return "Vidriera roja";
					case EntityID.ItemID.MULTICOLORED_STAINED_GLASS_WALL:
						return "Vidriera de colores";
#endif
				}
			}
			return null;
		}

		public static string ItemAffixName(int PrefixID, int NetID)
		{
			string ItemName = Lang.ItemName(NetID);
			if (PrefixID != 0)
			{
				if (LangOption <= (int)ID.ENGLISH)
				{
					if (!ItemName.StartsWith("The "))
					{
						ItemName = ItemPrefix(PrefixID) + " " + ItemName;
					}
					else
					{	// This is a lesser known Old-Gen console addition; Any item with 'The' at the start of its name will have the prefix added after 'The' for gramatical correctness.
						ItemName = "The " + ItemPrefix(PrefixID) + ItemName.Remove(0, 3); // Since in versions below 1.02, it only happens with 'The Breaker', this is more notable in 1.02 and above.
					}

				}
				else
				{
					ItemName += " (";
					ItemName += ItemPrefix(PrefixID);
					ItemName += ")";
				}
			}
			return ItemName;
		}

		public static string DryadEvilGood()
		{
			string Result = null;
			if (LangOption <= (int)ID.ENGLISH)
			{
				Result = ((WorldGen.GoodCoverage == 0) ? (Main.WorldName + " is " + WorldGen.EvilCoverage + "% corrupt.") : ((WorldGen.EvilCoverage != 0) ? (Main.WorldName + " is " + WorldGen.GoodCoverage + "% hallow, and " + WorldGen.EvilCoverage + "% corrupt.") : (Main.WorldName + " is " + WorldGen.GoodCoverage + "% hallow.")));
				if (WorldGen.GoodCoverage > WorldGen.EvilCoverage)
				{
					return Result + " Keep up the good work!";
				}
				if (WorldGen.EvilCoverage > WorldGen.GoodCoverage && WorldGen.EvilCoverage > 20)
				{
					return Result + " Things are grim indeed.";
				}
				return Result + " You should try harder.";
			}
			if (LangOption == (int)ID.GERMAN)
			{
				Result = ((WorldGen.GoodCoverage == 0) ? (Main.WorldName + " ist zu " + WorldGen.EvilCoverage + "% verderbt.") : ((WorldGen.EvilCoverage != 0) ? (Main.WorldName + " ist zu " + WorldGen.GoodCoverage + "% geheiligt und zu " + WorldGen.EvilCoverage + "% verderbt.") : (Main.WorldName + " ist zu " + WorldGen.GoodCoverage + "% geheiligt.")));
				Result = ((WorldGen.GoodCoverage > WorldGen.EvilCoverage) ? (Result + " Gute Arbeit, weiter so!") : ((WorldGen.EvilCoverage <= WorldGen.GoodCoverage || WorldGen.EvilCoverage <= 20) ? (Result + " Streng dich mehr an!") : (Result + " Es sieht in der Tat nicht gut aus.")));
			}
			else if (LangOption == (int)ID.ITALIAN)
			{
				Result = ((WorldGen.GoodCoverage == 0) ? (Main.WorldName + " è corrotto " + WorldGen.EvilCoverage + "%.") : ((WorldGen.EvilCoverage != 0) ? (Main.WorldName + " è consacrato " + WorldGen.GoodCoverage + "% e corrotto " + WorldGen.EvilCoverage + "%.") : (Main.WorldName + " è consacrato " + WorldGen.GoodCoverage + "%.")));
				Result = ((WorldGen.GoodCoverage > WorldGen.EvilCoverage) ? (Result + " Continua così!") : ((WorldGen.EvilCoverage <= WorldGen.GoodCoverage || WorldGen.EvilCoverage <= 20) ? (Result + " Dovresti impegnarti di più.") : (Result + " Le cose vanno male.")));
			}
			else if (LangOption == (int)ID.FRENCH)
			{
				Result = ((WorldGen.GoodCoverage == 0) ? (Main.WorldName + " est corrompu à " + WorldGen.EvilCoverage + "\u00a0%.") : ((WorldGen.EvilCoverage != 0) ? (Main.WorldName + " est purifié à " + WorldGen.GoodCoverage + "% et corrompu à " + WorldGen.EvilCoverage + "\u00a0%.") : (Main.WorldName + " est purifié à " + WorldGen.GoodCoverage + "\u00a0%.")));
				Result = ((WorldGen.GoodCoverage > WorldGen.EvilCoverage) ? (Result + " Continuez comme ça.") : ((WorldGen.EvilCoverage <= WorldGen.GoodCoverage || WorldGen.EvilCoverage <= 20) ? (Result + " Essayez encore.") : (Result + " En effet, c'est pas la joie.")));
			}
			else if (LangOption == (int)ID.SPANISH)
			{
				Result = ((WorldGen.GoodCoverage == 0) ? (Main.WorldName + " ha sido corrompido por " + WorldGen.EvilCoverage + "%.") : ((WorldGen.EvilCoverage != 0) ? (Main.WorldName + " ha sido bendecido por " + WorldGen.GoodCoverage + "% y corrompido por " + WorldGen.EvilCoverage + "%.") : (Main.WorldName + " ha sido bendecido por " + WorldGen.GoodCoverage + "%.")));
				Result = ((WorldGen.GoodCoverage > WorldGen.EvilCoverage) ? (Result + " ¡Sigue haciéndolo bien!") : ((WorldGen.EvilCoverage <= WorldGen.GoodCoverage || WorldGen.EvilCoverage <= 20) ? (Result + " Deberías esforzarte más.") : (Result + " Es bastante desalentador.")));
			}
			return Result;
		}

		public static void SetLang(int LangSetting)
		{
			if (LangOption != LangSetting)
			{
				LangOption = LangSetting;
				if (LangOption <= (int)ID.ENGLISH)
				{
					MiscText[0] = "A goblin army has been defeated!";
					MiscText[1] = "A goblin army is approaching from the west!";
					MiscText[2] = "A goblin army is approaching from the east!";
					MiscText[3] = "A goblin army has arrived!";
					MiscText[4] = "The Frost Legion has been defeated!";
					MiscText[5] = "The Frost Legion is approaching from the west!";
					MiscText[6] = "The Frost Legion is approaching from the east!";
					MiscText[7] = "The Frost Legion has arrived!";
					MiscText[8] = "The Blood Moon is rising...";
					MiscText[9] = "You feel an evil presence watching you...";
					MiscText[10] = "A horrible chill goes down your spine...";
					MiscText[11] = "Screams echo around you...";
					MiscText[12] = "Your world has been blessed with Cobalt!";
					MiscText[13] = "Your world has been blessed with Mythril!";
					MiscText[14] = "Your world has been blessed with Adamantite!";
					MiscText[15] = "The ancient spirits of light and dark have been released.";
					MiscText[16] = " has awoken!";
					MiscText[17] = " has been defeated!";
					MiscText[18] = " has arrived!";
					MiscText[19] = " was slain...";
					MiscText[20] = "The Twins";
					MiscText[21] = "Invalid operation at this state.";
					MiscText[22] = "You are not using the same version as this server.";
					MiscText[23] = "Current players: ";
					MiscText[24] = " has enabled PvP!";
					MiscText[25] = " has disabled PvP!";
					MiscText[26] = " is no longer on a party.";
					MiscText[27] = " has joined the red party.";
					MiscText[28] = " has joined the green party.";
					MiscText[29] = " has joined the blue party.";
					MiscText[30] = " has joined the yellow party.";
					MiscText[31] = "Welcome, ";
					MiscText[32] = " has joined.";
					MiscText[33] = " has left.";
					MiscText[34] = "The Twins have awoken!";
					MiscText[35] = "The Twins have been defeated!";
					MiscText[36] = "A meteorite has landed!";
					MenuText[0] = "Ingredients";
					MenuText[1] = " in your inventory)";
					MenuText[2] = "Disconnect";
					MenuText[3] = "Attention!";
					MenuText[4] = "<c>When this icon is visible\n\n\nthe game is <i>saving</i> data.";
					MenuText[5] = "Error!";
					MenuText[6] = "Play Online";
					MenuText[7] = "Invite Only";
					MenuText[8] = "Found server...";
					MenuText[9] = "Load failed!";
					MenuText[10] = "Start Game";
					MenuText[11] = "Create World";
					MenuText[12] = "Corrupted character data was found and has been deleted.";
					MenuText[13] = "Play Game";
					MenuText[14] = "Settings";
					MenuText[15] = "Exit Game";
					MenuText[16] = "Create Character";
					MenuText[17] = XButton + "Delete";
					MenuText[18] = "Hair";
					MenuText[19] = "Eyes";
					MenuText[20] = "Skin";
					MenuText[21] = "Clothes";
					MenuText[22] = "Male";
					MenuText[23] = "Female";
					MenuText[24] = "Hardcore";
					MenuText[25] = "Difficult";
					MenuText[26] = "Normal";
					MenuText[27] = "Random";
					MenuText[28] = "Create";
					MenuText[29] = "Death is permanent";
					MenuText[30] = "Drop all items on death";
					MenuText[31] = "Drop money on death";
					MenuText[32] = "Select difficulty";
					MenuText[33] = "Shirt";
					MenuText[34] = "Undershirt";
					MenuText[35] = "Pants";
					MenuText[36] = "Shoes";
					MenuText[37] = "Hair";
					MenuText[38] = "Hair Color";
					MenuText[39] = "Eye Color";
					MenuText[40] = "Skin Color";
					MenuText[41] = "Shirt Color";
					MenuText[42] = "Undershirt Color";
					MenuText[43] = "Pants Color";
					MenuText[44] = "Shoe Color";
					MenuText[45] = "Enter Character Name:";
					MenuText[46] = "Delete ";
					MenuText[47] = "Credits";
					MenuText[48] = "Enter World Name:";
					MenuText[49] = "Leave without creating a character?";
					MenuText[50] = "Select Character";
					MenuText[51] = "Waiting for game to start...";
					MenuText[52] = "Press START";
					MenuText[53] = "Character name";
					MenuText[54] = "Saving Character...";
					MenuText[55] = "World name";
					MenuText[56] = "World";
					MenuText[57] = "Spawn point set!";
					MenuText[58] = "Distance traveled";
					MenuText[59] = "Resources mined and gathered";
					MenuText[60] = "Items crafted";
					MenuText[61] = "Items used";
					MenuText[62] = "Normal bosses defeated";
					MenuText[63] = "Hard Mode bosses defeated";
					MenuText[64] = "Times died";
					MenuText[65] = "Volume";
					MenuText[66] = "No Storage Device has been selected. Saving has been disabled.";
					MenuText[67] = "Autosave On";
					MenuText[68] = "Autosave Off";
					MenuText[69] = "No Storage Device";
					MenuText[70] = "The Storage Device has been removed. Saving has been disabled.";
					MenuText[71] = "Pickup Text On";
					MenuText[72] = "Pickup Text Off";
					MenuText[73] = "Requesting world information...";
					MenuText[74] = "Requesting tile data...";
					MenuText[75] = "Accepting invitation...";
					MenuText[76] = "Searching...";
					MenuText[77] = "No games found";
					MenuText[78] = "Players: ";
					MenuText[79] = "~ EMPTY ~";
					MenuText[80] = "Joining game...";
					MenuText[81] = "PvP";
					MenuText[82] = "Team";
					MenuText[83] = "Your Worlds";
					MenuText[84] = "Join Game";
					MenuText[85] = "Depth: ";
					MenuText[86] = "m below";
					MenuText[87] = "m above";
					MenuText[88] = "level";
					MenuText[89] = "Tutorial";
					MenuText[90] = "Ok";
					MenuText[91] = "Choose world size:";
					MenuText[92] = "Small";
					MenuText[93] = "Medium";
					MenuText[94] = "Large";
					MenuText[95] = "Position: ";
					MenuText[96] = "m east";
					MenuText[97] = "m west";
					MenuText[98] = "center";
					MenuText[99] = "Save Game";
					MenuText[100] = "Exit to Main Menu";
					MenuText[101] = "Main Menu";
					MenuText[102] = "Settings data was corrupted and has been deleted.";
					MenuText[103] = "Corrupted world data was found and has been deleted.";
					MenuText[104] = "Yes";
					MenuText[105] = "No";
					MenuText[106] = "Leaderboards";
					MenuText[107] = "Achievements";
					MenuText[108] = "Help & Options";
					MenuText[109] = "Unlock Full Game";
					MenuText[110] = "How to Play";
					MenuText[111] = "Controls";
					MenuText[112] = "Resume Game";
					WorldGenText[0] = "Generating world terrain...";
					WorldGenText[1] = "Adding sand...";
					WorldGenText[2] = "Generating hills...";
					WorldGenText[3] = "Puttin dirt behind dirt...";
					WorldGenText[4] = "Placing rocks in the dirt...";
					WorldGenText[5] = "Placing dirt in the rocks...";
					WorldGenText[6] = "Adding clay...";
					WorldGenText[7] = "Making random holes...";
					WorldGenText[8] = "Generating small caves...";
					WorldGenText[9] = "Generating large caves...";
					WorldGenText[10] = "Generating surface caves...";
					WorldGenText[11] = "Generating jungle...";
					WorldGenText[12] = "Generating floating islands...";
					WorldGenText[13] = "Adding mushroom patches...";
					WorldGenText[14] = "Placing mud in the dirt...";
					WorldGenText[15] = "Adding silt...";
					WorldGenText[16] = "Adding shinies...";
					WorldGenText[17] = "Adding webs...";
					WorldGenText[18] = "Creating underworld...";
					WorldGenText[19] = "Adding water bodies...";
					WorldGenText[20] = "Making the world evil...";
					WorldGenText[21] = "Generating mountain caves...";
					WorldGenText[22] = "Creating beaches...";
					WorldGenText[23] = "Adding gems...";
					WorldGenText[24] = "Gravitating sand...";
					WorldGenText[25] = "Cleaning up dirt backgrounds...";
					WorldGenText[26] = "Placing altars...";
					WorldGenText[27] = "Settling liquids...";
					WorldGenText[28] = "Placing life crystals...";
					WorldGenText[29] = "Placing statues...";
					WorldGenText[30] = "Hiding treasure...";
					WorldGenText[31] = "Hiding more treasure...";
					WorldGenText[32] = "Hiding jungle treasure...";
					WorldGenText[33] = "Hiding water treasure...";
					WorldGenText[34] = "Placing traps...";
					WorldGenText[35] = "Placing breakables...";
					WorldGenText[36] = "Placing hellforges...";
					WorldGenText[37] = "Spreading grass...";
					WorldGenText[38] = "Growing cacti...";
					WorldGenText[39] = "Planting sunflowers...";
					WorldGenText[40] = "Planting trees...";
					WorldGenText[41] = "Planting herbs...";
					WorldGenText[42] = "Planting weeds...";
					WorldGenText[43] = "Growing vines...";
					WorldGenText[44] = "Planting flowers...";
					WorldGenText[45] = "Planting mushrooms...";
					WorldGenText[46] = "The connection to the host has been lost.";
					WorldGenText[47] = "Resetting game objects...";
					WorldGenText[48] = "Setting hard mode...";
					WorldGenText[49] = "Saving world data...";
					WorldGenText[50] = "Backing up world file...";
					WorldGenText[51] = "Loading world data...";
					WorldGenText[52] = "Checking tile alignment...";
					WorldGenText[53] = "An error occurred while reading from the Storage Device.";
					WorldGenText[54] = "An error occurred while writing to the Storage Device.";
					WorldGenText[55] = "Finding tile frames...";
					WorldGenText[56] = "Adding snow...";
					WorldGenText[57] = "Waiting for a player to leave...";
					WorldGenText[58] = "Creating dungeon...";
					InterfaceText[0] = "Cancel";
					InterfaceText[1] = "Exit without saving";
					InterfaceText[2] = "Save and Exit";
					InterfaceText[3] = "Trash Can";
					InterfaceText[4] = "Inventory";
					InterfaceText[5] = "Do you want to return to the Main Menu?";
					InterfaceText[6] = "Buffs";
					InterfaceText[7] = "Housing";
					InterfaceText[8] = "This housing is not suitable.";
					InterfaceText[9] = "Accessories";
					InterfaceText[10] = " Defense";
					InterfaceText[11] = "Vanity";
					InterfaceText[12] = "Helmet";
					InterfaceText[13] = "Shirt";
					InterfaceText[14] = "Pants";
					InterfaceText[15] = " platinum ";
					InterfaceText[16] = " gold ";
					InterfaceText[17] = " silver ";
					InterfaceText[18] = " copper";
					InterfaceText[19] = "Reforge";
					InterfaceText[20] = "Failed to create a network session.";
					InterfaceText[21] = "Failed to join the session. The session either is full or cannot be found.";
					InterfaceText[22] = "Required objects:";
					InterfaceText[23] = "None";
					InterfaceText[24] = "Alternate grappling mode";
					InterfaceText[25] = "Crafting";
					InterfaceText[26] = "Coins";
					InterfaceText[27] = "Ammo";
					InterfaceText[28] = "Shop";
					InterfaceText[29] = InvSelectAction + "Loot All";
					InterfaceText[30] = InvSelectAction + "Deposit All";
					InterfaceText[31] = InvSelectAction + "Quick Stack";
					InterfaceText[32] = "Piggy Bank";
					InterfaceText[33] = "Safe";
					InterfaceText[34] = "Time: ";
					InterfaceText[35] = "Are you sure you want to quit?";
					InterfaceText[36] = "The connection to Xbox LIVE has been lost.";
					InterfaceText[37] = "Number of entries: ";
					InterfaceText[38] = "You were slain...";
					InterfaceText[39] = "This housing is suitable.";
					InterfaceText[40] = "This is not valid housing.";
					InterfaceText[41] = "This housing is already occupied.";
					InterfaceText[42] = "This housing is corrupted.";
					InterfaceText[43] = "This gamer profile does not have suitable privileges to join. You may require a LIVE Gold account, or need to change your parental control settings.";
					InterfaceText[44] = "Receiving tile data";
					InterfaceText[45] = "Equip";
					InterfaceText[46] = "Cost: ";
					InterfaceText[47] = "Save";
					InterfaceText[48] = "Edit";
					InterfaceText[49] = "Status";
					InterfaceText[50] = "Curse";
					InterfaceText[51] = "Help";
					InterfaceText[52] = "Close";
					InterfaceText[53] = "Water";
					InterfaceText[54] = "Heal";
					InterfaceText[55] = "Provides tips and crafting advice.";
					InterfaceText[56] = "Sells basic goods.";
					InterfaceText[57] = "Heals wounds and debuffs.";
					InterfaceText[58] = "Sells explosives.";
					InterfaceText[59] = "Sells natural goods and tells you the state of the World.";
					InterfaceText[60] = "Sells guns and ammo.";
					InterfaceText[61] = "Sells vanity clothes.";
					InterfaceText[62] = "Sells tools and wires.";
					InterfaceText[63] = "Sells handy gadgets and reforges items.";
					InterfaceText[64] = "Sells magic items and accessories.";
					InterfaceText[65] = "A jolly old fellow.";
					InterfaceText[66] = "Game Ended";
					InterfaceText[67] = "The game was ended by the host.";
					InterfaceText[68] = "Unable to join due to privileges blocked on one of the signed in profiles.";
					InterfaceText[69] = "You are currently playing the trial version. Please buy the full version to play online.";
					InterfaceText[70] = "There is insufficient space available on the selected storage device.";
					InterfaceText[71] = "Playing split-screen in a Standard Definition video mode will result in game text that is difficult to read. High Definition (HD) is strongly recommended for an optimal gameplay experience.";
					InterfaceText[72] = "Ban World";
					InterfaceText[73] = "Add this world to your Banned Worlds list?";
					InterfaceText[74] = "This world is in your Banned Worlds list.";
					InterfaceText[75] = "Continue (remove from list)";
					InterfaceText[76] = "(Awaiting approval)";
					InterfaceText[77] = "(Censored)";
					InterfaceText[78] = "The Saved Game \"{0}\" was transferred from another profile and will be deleted.";
					// 1.01 onwards adds an entry in this position for the text "Are you sure?"; its usage is unknown to me.
					InterfaceText[79] = "The game will end due to the Member Content settings of one of the signed in profiles.";
					TipText[0] = "Equipped in vanity slot";
					TipText[1] = "No stats will be gained";
					TipText[2] = " melee damage";
					TipText[3] = " ranged damage";
					TipText[4] = " magic damage";
					TipText[5] = "% critical strike chance";
					TipText[6] = "Insanely fast speed";
					TipText[7] = "Very fast speed";
					TipText[8] = "Fast speed";
					TipText[9] = "Average speed";
					TipText[10] = "Slow speed";
					TipText[11] = "Very slow speed";
					TipText[12] = "Extremely slow speed";
					TipText[13] = "Snail speed";
					TipText[14] = "No knockback";
					TipText[15] = "Extremely weak knockback";
					TipText[16] = "Very weak knockback";
					TipText[17] = "Weak knockback";
					TipText[18] = "Average knockback";
					TipText[19] = "Strong knockback";
					TipText[20] = "Very strong knockback";
					TipText[21] = "Extremely strong knockback";
					TipText[22] = "Insane knockback";
					TipText[23] = "Equipable";
					TipText[24] = "Vanity Item";
					TipText[25] = " defense";
					TipText[26] = "% pickaxe power";
					TipText[27] = "% axe power";
					TipText[28] = "% hammer power";
					TipText[29] = "Restores ";
					TipText[30] = " life";
					TipText[31] = " mana";
					TipText[32] = "Uses ";
					TipText[33] = "Can be placed";
					TipText[34] = "Ammo";
					TipText[35] = "Consumable";
					TipText[36] = "Material";
					TipText[37] = " minute duration";
					TipText[38] = " second duration";
					TipText[39] = "% damage";
					TipText[40] = "% speed";
					TipText[41] = "% critical strike chance";
					TipText[42] = "% mana cost";
					TipText[43] = "% size";
					TipText[44] = "% velocity";
					TipText[45] = "% knockback";
					TipText[46] = "% movement speed";
					TipText[47] = "% melee speed";
					TipText[48] = "Set bonus: ";
					TipText[49] = "Sell price: ";
					TipText[50] = "Buy price: ";
					TipText[51] = "No value";
					DeathText[0] = " couldn't find the antidote.";
					DeathText[1] = " couldn't put the fire out.";
					DeathText[2] = " tried to escape.";
					DeathText[3] = " was licked.";
					Buff.BuffName[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Obsidian Skin";
					Buff.BuffTip[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Immune to lava";
					Buff.BuffName[(byte)EntityID.BuffID.LIFE_REGEN] = "Regeneration";
					Buff.BuffTip[(byte)EntityID.BuffID.LIFE_REGEN] = "Provides life regeneration";
					Buff.BuffName[(byte)EntityID.BuffID.HASTE] = "Swiftness";
					Buff.BuffTip[(byte)EntityID.BuffID.HASTE] = "25% increased movement speed";
					Buff.BuffName[(byte)EntityID.BuffID.GILLS] = "Gills";
					Buff.BuffTip[(byte)EntityID.BuffID.GILLS] = "Breathe water instead of air";
					Buff.BuffName[(byte)EntityID.BuffID.IRONSKIN] = "Ironskin";
					Buff.BuffTip[(byte)EntityID.BuffID.IRONSKIN] = "Increase defense by 8";
					Buff.BuffName[(byte)EntityID.BuffID.MANA_REGEN] = "Mana Regeneration";
					Buff.BuffTip[(byte)EntityID.BuffID.MANA_REGEN] = "Increased mana regeneration";
					Buff.BuffName[(byte)EntityID.BuffID.MAGIC_POWER] = "Magic Power";
					Buff.BuffTip[(byte)EntityID.BuffID.MAGIC_POWER] = "20% increased magic damage";
					Buff.BuffName[(byte)EntityID.BuffID.SLOWFALL] = "Featherfall";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOWFALL] = "Press UP or DOWN to control speed of descent";
					Buff.BuffName[(byte)EntityID.BuffID.FIND_TREASURE] = "Spelunker";
					Buff.BuffTip[(byte)EntityID.BuffID.FIND_TREASURE] = "Shows the location of treasure and ore";
					Buff.BuffName[(byte)EntityID.BuffID.INVISIBLE] = "Invisibility";
					Buff.BuffTip[(byte)EntityID.BuffID.INVISIBLE] = "Grants invisibility";
					Buff.BuffName[(byte)EntityID.BuffID.SHINE] = "Shine";
					Buff.BuffTip[(byte)EntityID.BuffID.SHINE] = "Emitting light";
					Buff.BuffName[(byte)EntityID.BuffID.NIGHTVISION] = "Night Owl";
					Buff.BuffTip[(byte)EntityID.BuffID.NIGHTVISION] = "Increased night vision";
					Buff.BuffName[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Battle";
					Buff.BuffTip[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Increased enemy spawn rate";
					Buff.BuffName[(byte)EntityID.BuffID.THORNS] = "Thorns";
					Buff.BuffTip[(byte)EntityID.BuffID.THORNS] = "Attackers also take damage";
					Buff.BuffName[(byte)EntityID.BuffID.WATER_WALK] = "Water Walking";
					Buff.BuffTip[(byte)EntityID.BuffID.WATER_WALK] = "Press DOWN to enter water";
					Buff.BuffName[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Archery";
					Buff.BuffTip[(byte)EntityID.BuffID.RANGED_DAMAGE] = "20% increased arrow damage and speed";
					Buff.BuffName[(byte)EntityID.BuffID.DETECT_CREATURE] = "Hunter";
					Buff.BuffTip[(byte)EntityID.BuffID.DETECT_CREATURE] = "Shows the location of enemies";
					Buff.BuffName[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Gravitation";
					Buff.BuffTip[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Press UP or DOWN to reverse gravity";
					Buff.BuffName[(byte)EntityID.BuffID.LIGHT_ORB] = "Orb of Light";
					Buff.BuffTip[(byte)EntityID.BuffID.LIGHT_ORB] = "A magical orb that provides light";
					Buff.BuffName[(byte)EntityID.BuffID.POISONED] = "Poisoned";
					Buff.BuffTip[(byte)EntityID.BuffID.POISONED] = "Slowly losing life";
					Buff.BuffName[(byte)EntityID.BuffID.POTION_DELAY] = "Potion Sickness";
					Buff.BuffTip[(byte)EntityID.BuffID.POTION_DELAY] = "Cannot consume anymore healing items";
					Buff.BuffName[(byte)EntityID.BuffID.BLIND] = "Darkness";
					Buff.BuffTip[(byte)EntityID.BuffID.BLIND] = "Decreased light vision";
					Buff.BuffName[(byte)EntityID.BuffID.NO_ITEMS] = "Cursed";
					Buff.BuffTip[(byte)EntityID.BuffID.NO_ITEMS] = "Cannot use any items";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE] = "On Fire!";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE] = "Slowly losing life";
					Buff.BuffName[(byte)EntityID.BuffID.DRUNK] = "Tipsy";
					Buff.BuffTip[(byte)EntityID.BuffID.DRUNK] = "Increased melee abilities, lowered defense";
					Buff.BuffName[(byte)EntityID.BuffID.WELL_FED] = "Well Fed";
					Buff.BuffTip[(byte)EntityID.BuffID.WELL_FED] = "Minor improvements to all stats";
					Buff.BuffName[(byte)EntityID.BuffID.FAIRY] = "Fairy";
					Buff.BuffTip[(byte)EntityID.BuffID.FAIRY] = "A fairy is following you";
					Buff.BuffName[(byte)EntityID.BuffID.WEREWOLF] = "Werewolf";
					Buff.BuffTip[(byte)EntityID.BuffID.WEREWOLF] = "Physical abilities are increased";
					Buff.BuffName[(byte)EntityID.BuffID.CLARAVOYANCE] = "Clairvoyance";
					Buff.BuffTip[(byte)EntityID.BuffID.CLARAVOYANCE] = "Magic powers are increased";
					Buff.BuffName[(byte)EntityID.BuffID.BLEED] = "Bleeding";
					Buff.BuffTip[(byte)EntityID.BuffID.BLEED] = "Cannot regenerate life";
					Buff.BuffName[(byte)EntityID.BuffID.CONFUSED] = "Confused";
					Buff.BuffTip[(byte)EntityID.BuffID.CONFUSED] = "Movement is reversed";
					Buff.BuffName[(byte)EntityID.BuffID.SLOW] = "Slow";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOW] = "Movement speed is reduced";
					Buff.BuffName[(byte)EntityID.BuffID.WEAK] = "Weak";
					Buff.BuffTip[(byte)EntityID.BuffID.WEAK] = "Physical abilities are decreased";
					Buff.BuffName[(byte)EntityID.BuffID.MERFOLK] = "Merfolk";
					Buff.BuffTip[(byte)EntityID.BuffID.MERFOLK] = "Can breathe and move easily underwater";
					Buff.BuffName[(byte)EntityID.BuffID.SILENCE] = "Silenced";
					Buff.BuffTip[(byte)EntityID.BuffID.SILENCE] = "Cannot use items that require mana";
					Buff.BuffName[(byte)EntityID.BuffID.BROKEN_ARMOR] = "Broken Armor";
					Buff.BuffTip[(byte)EntityID.BuffID.BROKEN_ARMOR] = "Defense is cut in half";
					Buff.BuffName[(byte)EntityID.BuffID.HORRIFIED] = "Horrified";
					Buff.BuffTip[(byte)EntityID.BuffID.HORRIFIED] = "You have seen something nasty, there is no escape.";
					Buff.BuffName[(byte)EntityID.BuffID.TONGUED] = "The Tongue";
					Buff.BuffTip[(byte)EntityID.BuffID.TONGUED] = "You are being sucked into the mouth";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE_2] = "Cursed Inferno";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE_2] = "Losing life";
					Buff.BuffName[(byte)EntityID.BuffID.PET] = "Pet Guinea Pig";
					Buff.BuffTip[(byte)EntityID.BuffID.PET] = "Simply adorable";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 1] = "Pet Slime";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 1] = "A real slime ball";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 2] = "Pet Tiphia";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 2] = "Wants all the honeys";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 3] = "Pet Bat";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 3] = "Out for blood";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 4] = "Pet Werewolf";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 4] = "Man's best friend";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 5] = "Pet Zombie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 5] = "Eats brains";
					Main.TileNames[(int)EntityID.TileID.BOTTLE] = "Bottle";
					Main.TileNames[(int)EntityID.TileID.TABLE] = "Table";
					Main.TileNames[(int)EntityID.TileID.CHAIR] = "Chair";
					Main.TileNames[(int)EntityID.TileID.ANVIL] = "Anvil";
					Main.TileNames[(int)EntityID.TileID.FURNACE] = "Furnace";
					Main.TileNames[(int)EntityID.TileID.WORK_BENCH] = "Work Bench";
					Main.TileNames[(int)EntityID.TileID.DEMON_ALTAR] = "Demon Altar";
					Main.TileNames[(int)EntityID.TileID.HELLFORGE] = "Hellforge";
					Main.TileNames[(int)EntityID.TileID.LOOM] = "Loom";
					Main.TileNames[(int)EntityID.TileID.KEG] = "Keg";
					Main.TileNames[(int)EntityID.TileID.COOKING_POT] = "Cooking Pot";
					Main.TileNames[(int)EntityID.TileID.BOOKCASE] = "Bookcase";
					Main.TileNames[(int)EntityID.TileID.SAWMILL] = "Sawmill";
					Main.TileNames[(int)EntityID.TileID.TINKERERS_WORKSHOP] = "Tinkerer's Workshop";
					Main.TileNames[(int)EntityID.TileID.ADAMANTITE_FORGE] = "Adamantite Forge";
					Main.TileNames[(int)EntityID.TileID.MYTHRIL_ANVIL] = "Mythril Anvil";
				}
				else if (LangOption == (int)ID.GERMAN)
				{
					MiscText[0] = "Die Goblin-Armee wurde besiegt!";
					MiscText[1] = "Eine Goblin-Armee nähert sich von Westen!";
					MiscText[2] = "Eine Goblin-Armee nähert sich von Osten!";
					MiscText[3] = "Ein Goblin-Armee ist da!";
					MiscText[4] = "Die Frost-Legion wurde besiegt!";
					MiscText[5] = "Die Frost-Legion nähert sich aus dem Westen!";
					MiscText[6] = "Die Frost-Legion nähert sich aus dem Osten!";
					MiscText[7] = "Die Frost-Legion ist da!";
					MiscText[8] = "Der Blutmond steigt auf ...";
					MiscText[9] = "Du fühlst dich von einer bösen Kraft beobachtet ...";
					MiscText[10] = "Eine Eiseskälte steigt in dir hoch ...";
					MiscText[11] = "Du hoerst das Echo von Schreien um dich herum ...";
					MiscText[12] = "Deine Welt wurde mit Kobalt gesegnet!";
					MiscText[13] = "Deine Welt wurde mit Mithril gesegnet!";
					MiscText[14] = "Deine Welt wurde mit Adamantit gesegnet!";
					MiscText[15] = "Die uralten Geister des Lichts und der Finsternis wurden freigelassen.";
					MiscText[16] = " ist aufgewacht!";
					MiscText[17] = " wurde besiegt!";
					MiscText[18] = " ist eingetroffen!";
					MiscText[19] = " wurde getötet von ...";
					MiscText[20] = "Die Zwillinge";
					MiscText[21] = "Ungültige Operation in diesem Zustand.";
					MiscText[22] = "Du verwendest nicht die gleiche Version wie der Server.";
					MiscText[23] = "Aktuelle Spieler: ";
					MiscText[24] = " hat PvP aktiviert!";
					MiscText[25] = " hat PvP deaktiviert!";
					MiscText[26] = " ist in keiner Gruppe mehr.";
					MiscText[27] = " ist der roten Gruppe beigetreten.";
					MiscText[28] = " ist der gruenen Gruppe beigetreten.";
					MiscText[29] = " ist der blauen Gruppe beigetreten.";
					MiscText[30] = " ist der gelben Gruppe beigetreten.";
					MiscText[31] = "Willkommen, ";
					MiscText[32] = " ist dazugekommen.";
					MiscText[33] = " hat das Spiel verlassen.";
					MiscText[34] = "Die Zwillinge sind erwacht!";
					MiscText[35] = "Die Zwillinge wurden besiegt!";
					MiscText[36] = "Ein Meteorit ist gelandet!";
					MenuText[0] = "Bestandteile";
					MenuText[1] = " deines Inventars)";
					MenuText[2] = "Trennen";
					MenuText[3] = "Achtung!";
					MenuText[4] = "<c>Wenn dieses Symbol erscheint,\n\n\n<i>speichert</i> das Spiel Daten.";
					MenuText[5] = "Fehler!";
					MenuText[6] = "Online spielen";
					MenuText[7] = "Nur mit Einladung";
					MenuText[8] = "Server gefunden ...";
					MenuText[9] = "Laden fehlgeschlagen!";
					MenuText[10] = "Spiel beginnen";
					MenuText[11] = "Welt erstellen";
					MenuText[12] = "Beschädigte Zeichendaten wurden gefunden und gelöscht.";
					MenuText[13] = "Spiel spielen";
					MenuText[14] = "Einstellungen";
					MenuText[15] = "Spiel verlassen";
					MenuText[16] = "Charakter erstellen";
					MenuText[17] = XButton + "Löschen";
					MenuText[18] = "Haar";
					MenuText[19] = "Augen";
					MenuText[20] = "Haut";
					MenuText[21] = "Kleidung";
					MenuText[22] = "Männlich";
					MenuText[23] = "Weiblich";
					MenuText[24] = "Hardcore";
					MenuText[25] = "Schwierig";
					MenuText[26] = "Normal";
					MenuText[27] = "Zufällig";
					MenuText[28] = "Erstellen";
					MenuText[29] = "Der Tod ist für immer";
					MenuText[30] = "Lass alle Items auf den Tod fallen";
					MenuText[31] = "Lass Geld auf den Tod fallen";
					MenuText[32] = "Schwierigkeitsgrad wählen";
					MenuText[33] = "Hemd";
					MenuText[34] = "Unterhemd";
					MenuText[35] = "Hose";
					MenuText[36] = "Schuhe";
					MenuText[37] = "Haar";
					MenuText[38] = "Haarfarbe";
					MenuText[39] = "Augenfarbe";
					MenuText[40] = "Hautfarbe";
					MenuText[41] = "Hemdfarbe";
					MenuText[42] = "Unterhemdfarbe";
					MenuText[43] = "Hosenfarbe";
					MenuText[44] = "Schuhfarbe";
					MenuText[45] = "Charaktername eingeben:";
					MenuText[46] = "Löschen ";
					MenuText[47] = "Mitwirkende";
					MenuText[48] = "Weltnamen eingeben:";
					MenuText[49] = "Verlassen, ohne einen Charakter zu erstellen?";
					MenuText[50] = "Wähle einen Charakter aus";
					MenuText[51] = "Das Spiel wird gestartet ...";
					MenuText[52] = "Drücke auf START";
					MenuText[53] = "Charaktername";
					MenuText[54] = "Charakter speichern ...";
					MenuText[55] = "Name der Welt";
					MenuText[56] = "Welt";
					MenuText[57] = "Spawnpoint gesetzt!";
					MenuText[58] = "Zurückgelegte Strecke";
					MenuText[59] = "Ressourcen abgebaut und gesammelt";
					MenuText[60] = "Hergestellte Items";
					MenuText[61] = "Genutzte Items";
					MenuText[62] = "Normale Bosse wurden besiegt";
					MenuText[63] = "Hardmode-Bosse wurden besiegt";
					MenuText[64] = "Zeiten erloschen";
					MenuText[65] = "Lautstärke";
					MenuText[66] = "Es wurde kein Speichermedium ausgewählt. Die Speicherung wurde deaktiviert.";
					MenuText[67] = "Automat. sichern an";
					MenuText[68] = "Automat. sichern aus";
					MenuText[69] = "Keine Speichermedium";
					MenuText[70] = "Das Speichermedium wurde entfernt. Die Speicherung wurde deaktiviert.";
					MenuText[71] = "Pickup-Text an";
					MenuText[72] = "Pickup-Text aus";
					MenuText[73] = "Informationen über die Welt werden angefordert ...";
					MenuText[74] = "Tile-Daten werden angefordert ...";
					MenuText[75] = "Einladung annehmen ...";
					MenuText[76] = "Suchen ...";
					MenuText[77] = "Keine Spiele gefunden";
					MenuText[78] = "Spieler:";
					MenuText[79] = "~ LEER ~";
					MenuText[80] = "Spiel beitreten ...";
					MenuText[81] = "PvP";
					MenuText[82] = "Team";
					MenuText[83] = "Deine Welten";
					MenuText[84] = "Spiel beitreten";
					MenuText[85] = "Tiefe: ";
					MenuText[86] = "m unterhalb";
					MenuText[87] = "m oberhalb";
					MenuText[88] = "Level";
					MenuText[89] = "Tutorial";
					MenuText[90] = "OK";
					MenuText[91] = "Weltgröße wählen:";
					MenuText[92] = "Klein";
					MenuText[93] = "Mittel";
					MenuText[94] = "Groß";
					MenuText[95] = "Position: ";
					MenuText[96] = "m östlich";
					MenuText[97] = "m westlich";
					MenuText[98] = "zentral";
					MenuText[99] = "Spiel speichern";
					MenuText[100] = "Zum Hauptmenü zurückkehren";
					MenuText[101] = "Hauptmenü";
					MenuText[102] = "Die Einstellungsdaten waren beschädigt und wurden gelöscht.";
					MenuText[103] = "Beschädigte Weltdaten wurden gefunden und gelöscht.";
					MenuText[104] = "Ja";
					MenuText[105] = "Nein";
					MenuText[106] = "Bestenlisten";
					MenuText[107] = "Erfolge";
					MenuText[108] = "Hilfe und Optionen";
					MenuText[109] = "Vollständiges Spiel freischalten";
					MenuText[110] = "So wird gespielt";
					MenuText[111] = "Steuerung";
					MenuText[112] = "Spiel fortsetzen";
					WorldGenText[0] = "Generieren des Weltgeländes ...";
					WorldGenText[1] = "Sand wird hinzugefügt ...";
					WorldGenText[2] = "Hügel werden generiert ...";
					WorldGenText[3] = "Dreck wird hinter Dreck geschoben ...";
					WorldGenText[4] = "Felsen werden in den Dreck gesetzt ...";
					WorldGenText[5] = "Dreck wird in Felsen platziert ...";
					WorldGenText[6] = "Lehm wird hinzugefügt ...";
					WorldGenText[7] = "Zufällig platzierte Löcher werden geschaffen:";
					WorldGenText[8] = "Generieren kleiner Höhlen ...";
					WorldGenText[9] = "Generieren großer Höhlen ...";
					WorldGenText[10] = "Höhlenoberflächen werden generiert ...";
					WorldGenText[11] = "Generieren des Dschungels:";
					WorldGenText[12] = "Schwimmende Inseln werden generiert ...";
					WorldGenText[13] = "Pilzflecken werden generiert ...";
					WorldGenText[14] = "Schlamm wird in Dreck gefügt ...";
					WorldGenText[15] = "Schlick wird hinzugefügt ...";
					WorldGenText[16] = "Glitzer wird hinzugefügt ...";
					WorldGenText[17] = "Spinnweben werden hinzugefügt ...";
					WorldGenText[18] = "Erstellen der Unterwelt ...";
					WorldGenText[19] = "Gewässer wird hinzugefügt ...";
					WorldGenText[20] = "Macht die Welt böse ...";
					WorldGenText[21] = "Berghöhlen werden generiert ...";
					WorldGenText[22] = "Strände werden erstellt ...";
					WorldGenText[23] = "Edelsteine werden hinzugefügt ...";
					WorldGenText[24] = "Gravitieren von Sand ...";
					WorldGenText[25] = "Reinigung von Dreckhintergrund ...";
					WorldGenText[26] = "Platzieren von Altären ...";
					WorldGenText[27] = "Gewässer verteilen ...";
					WorldGenText[28] = "Lebenskristalle platzieren ...";
					WorldGenText[29] = "Platzieren von Statuen ...";
					WorldGenText[30] = "Verstecken von Schätzen ...";
					WorldGenText[31] = "Verstecken von mehr Schätzen ...";
					WorldGenText[32] = "Verstecken von Dschungelschätzen ...";
					WorldGenText[33] = "Verstecken von Wasserschätzen ...";
					WorldGenText[34] = "Platzieren von Fallen ...";
					WorldGenText[35] = "Platzieren von Zerbrechlichem ...";
					WorldGenText[36] = "Platzieren von Höllenschmieden ...";
					WorldGenText[37] = "Gras wird verteilt ...";
					WorldGenText[38] = "Kakteen wachsen ...";
					WorldGenText[39] = "Sonnenblumen werden gepflanzt ...";
					WorldGenText[40] = "Bäume werden gepflanzt ...";
					WorldGenText[41] = "Kräuter werden gepflanzt ...";
					WorldGenText[42] = "Unkraut wird gepflanzt ...";
					WorldGenText[43] = "Wein wird angebaut ...";
					WorldGenText[44] = "Blumen werden gepflanzt ...";
					WorldGenText[45] = "Pilze werden gesät ...";
					WorldGenText[46] = "Die Verbindung zum Host wurde unterbrochen";
					WorldGenText[47] = "Spielobjekte werden zurückgesetzt ...";
					WorldGenText[48] = "Schwerer Modus wird eingestellt ...";
					WorldGenText[49] = "Weltdaten werden gesichert ...";
					WorldGenText[50] = "Backup von Weltdatei wird erstellt ...";
					WorldGenText[51] = "Weltdaten werden geladen ...";
					WorldGenText[52] = "Überprüfen der Feld-Ausrichtung ...";
					WorldGenText[53] = "Fehler beim Lesen vom Datenträger";
					WorldGenText[54] = "Fehler beim Schreiben auf den Datenträger";
					WorldGenText[55] = "Suchen von Feld-Frames ...";
					WorldGenText[56] = "Schnee hinzufügen ...";
					WorldGenText[57] = "Welt";
					WorldGenText[58] = "Verlies erstellen ...";
					InterfaceText[0] = "Abbrechen";
					InterfaceText[1] = "Vorgang ohne Speichern beenden";
					InterfaceText[2] = "Speichern und beenden";
					InterfaceText[3] = "Mülleimer";
					InterfaceText[4] = "Inventar";
					InterfaceText[5] = "Möchtest du zum Hauptmenü zurückkehren?";
					InterfaceText[6] = "Buffs";
					InterfaceText[7] = "Behausung";
					InterfaceText[8] = "Diese Behausung ist ungeeignet.";
					InterfaceText[9] = "Zusaetze";
					InterfaceText[10] = " Abwehr";
					InterfaceText[11] = "Vanity";
					InterfaceText[12] = "Helm";
					InterfaceText[13] = "Hemd";
					InterfaceText[14] = "Hose";
					InterfaceText[15] = " platin ";
					InterfaceText[16] = " gold ";
					InterfaceText[17] = " silber ";
					InterfaceText[18] = " kupfer";
					InterfaceText[19] = "Nachschmieden";
					InterfaceText[20] = "Das Erstellen einer Netzwerksitzung ist fehlgeschlagen.";
					InterfaceText[21] = "Der Versuch, der Sitzung beizutreten, ist fehlgeschlagen. Die Sitzung ist entweder voll oder kann nicht gefunden werden.";
					InterfaceText[22] = "Erforderliche Objekte:";
					InterfaceText[23] = "Keine";
					InterfaceText[24] = "Greifhaken-Modus ändern";
					InterfaceText[25] = "Herstellen";
					InterfaceText[26] = "Münzen";
					InterfaceText[27] = "Munition";
					InterfaceText[28] = "Geschäft";
					InterfaceText[29] = InvSelectAction + "Alle ausräumen";
					InterfaceText[30] = InvSelectAction + "Alle ablegen";
					InterfaceText[31] = InvSelectAction + "Schnellstapeln";
					InterfaceText[32] = "Sparschwein";
					InterfaceText[33] = "Tresor";
					InterfaceText[34] = "Zeit: ";
					InterfaceText[35] = "Bist du dir sicher, dass du aufhören möchtest?";
					InterfaceText[36] = "Die Verbindung zu Xbox LIVE wurde unterbrochen.";
					InterfaceText[37] = "Anzahl von Eintragungen: ";
					InterfaceText[38] = "Du wurdest getötet ...";
					InterfaceText[39] = "Diese Behausung ist geeignet.";
					InterfaceText[40] = "Das ist keine zulässige Behausung";
					InterfaceText[41] = "Diese Behausung ist bereits belegt.";
					InterfaceText[42] = "Diese Behausung ist beschädigt.";
					InterfaceText[43] = "Dieses Spielerprofil hat nicht die passenden Zugangsberechtigungen für eine Teilnahme. Um teilnehmen zu können, benötigst du entweder einen LIVE Gold Account oder du musst deine Jugendschutzeinstellungen ändern.";
					InterfaceText[44] = "Felddaten werden empfangen";
					InterfaceText[45] = "Ausrüsten";
					InterfaceText[46] = "Kosten: ";
					InterfaceText[47] = "Sparen";
					InterfaceText[48] = "Bearbeiten";
					InterfaceText[49] = "Status";
					InterfaceText[50] = "Fluch";
					InterfaceText[51] = "Hilfe";
					InterfaceText[52] = "Schließen";
					InterfaceText[53] = "Wasser";
					InterfaceText[54] = "Heilen";
					InterfaceText[55] = "Stellt Tipps und Handwerksvorschläge bereit.";
					InterfaceText[56] = "Verkauft reguläre Waren.";
					InterfaceText[57] = "Heilt Wunden und Debuffs.";
					InterfaceText[58] = "Verkauft Sprengstoff.";
					InterfaceText[59] = "Verkauft Naturwaren und informiert dich über den Zustand der Welt.";
					InterfaceText[60] = "Verkauft Pistolen und Munition.";
					InterfaceText[61] = "Verkauft Vanity-Kleidung.";
					InterfaceText[62] = "Verkauft Werkzeuge und Kabel.";
					InterfaceText[63] = "Verkauft praktisches Zubehör und schmiedet Items zusammen.";
					InterfaceText[64] = "Verkauft magische Items und Zubehör.";
					InterfaceText[65] = "Ein lustiger alter Kerl.";
					InterfaceText[66] = "Spiel beendet";
					InterfaceText[67] = "Das Spiel wurde vom Host beendet.";
					InterfaceText[68] = "Es kann nicht beitreten werden, da die Rechte auf einem der Profile geblockt sind.";
					InterfaceText[69] = "Du spielst zur Zeit auf der Testversion. Bitte kaufe die Vollversion, um online zu spielen.";
					InterfaceText[70] = "Die Speicherkapazität des ausgewählten Speichermediums reicht nicht aus.";
					InterfaceText[71] = "Das Spiel auf einem geteilten Bildschirm in einem Videomodus mit Standardauflösung führt zu einer schlechten Lesbarkeit des Spieltexts. Für eine optimale Spielerfahrung wird High Definition (HD) dringend empfohlen.";
					InterfaceText[72] = "Verbanne Welt";
					InterfaceText[73] = "Bist du dir sicher, dass du diese Welt deiner \"Verbannte Welten\" Liste hinzufügen möchtest?\n\nWenn du OK auswählst, beendest du gleichzeitig dieses Spiel.";
					InterfaceText[74] = "WARNUNG! Die Welt, die du gerade betrittst, befindet sich auf deiner \"Verbannte Welten\" Liste.\n\nWenn du dich dafür entscheidest, diese Welt zu besuchen, wird sie von deiner \"Verbannte Welten\" Liste gestrichen.";
					InterfaceText[75] = "Fortfahren";
					InterfaceText[76] = "(In Erwartung der Bestaetigung)";
					InterfaceText[77] = "(Zensiert)";
					InterfaceText[78] = "Das gespeicherte Spiel \"{0}\" wurde von einem anderen Profil übertragen und wird nun gelöscht.";
					InterfaceText[79] = "Durch die Nutzerinhalt-Einstellungen von einem der Profile wird das Spiel nun beendet.";
					TipText[0] = "Ausgerüstet im Vanity-Slot";
					TipText[1] = "Keine Werte werden gewonnen";
					TipText[2] = " Nahkampfschaden";
					TipText[3] = " Fernkampfschaden";
					TipText[4] = " Magischer Schaden";
					TipText[5] = "% kritische Trefferchance";
					TipText[6] = "Wahnsinnig schnell";
					TipText[7] = "Sehr schnell";
					TipText[8] = "Schnell";
					TipText[9] = "Durchschnittlich";
					TipText[10] = "Langsam";
					TipText[11] = "Sehr langsam";
					TipText[12] = "Extrem langsam";
					TipText[13] = "Schneckentempo";
					TipText[14] = "Kein Rückstoß";
					TipText[15] = "Extrem schwacher Rückstoß";
					TipText[16] = "Sehr schwacher Rückstoß";
					TipText[17] = "Schwacher Rückstoß";
					TipText[18] = "Mittlerer Rückstoß";
					TipText[19] = "Starker Rückstoß";
					TipText[20] = "Sehr starker Rückstoß";
					TipText[21] = "Extrem starker Rückstoß";
					TipText[22] = "Wahnsinniger Rückstoß";
					TipText[23] = "Ausrüstbar";
					TipText[24] = "Mode-Items";
					TipText[25] = " Abwehr";
					TipText[26] = "% Spitzhackenkraft";
					TipText[27] = "% Axtkraft";
					TipText[28] = "% Hammerkraft";
					TipText[29] = "Stellt ";
					TipText[30] = " Leben wieder her";
					TipText[31] = " Mana wieder her";
					TipText[32] = "Verwendet ";
					TipText[33] = "Kann platziert werden";
					TipText[34] = "Munition";
					TipText[35] = "Verbrauchbar";
					TipText[36] = "Material";
					TipText[37] = " Minuten Dauer";
					TipText[38] = " Sekunden Dauer";
					TipText[39] = "% Schaden";
					TipText[40] = "% Tempo";
					TipText[41] = "% kritische Trefferchance";
					TipText[42] = "% Manakosten";
					TipText[43] = "% Größe";
					TipText[44] = "% Projektiltempo";
					TipText[45] = "% Rückstoß";
					TipText[46] = "% Bewegungstempo";
					TipText[47] = "% Nahkampftempo";
					TipText[48] = "Bonus-Set: ";
					TipText[49] = "Verkaufspreis: ";
					TipText[50] = "Kaufpreis: ";
					TipText[51] = "Kein Wert";
					DeathText[0] = " konnte das Antidot nicht finden.";
					DeathText[1] = " konnte das Feuer nicht löschen.";
					DeathText[2] = " hat versucht, zu fliehen";
					DeathText[3] = " wurde abgeleckt";
					Buff.BuffName[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Obsidianhaut";
					Buff.BuffTip[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Immun gegen Lava";
					Buff.BuffName[(byte)EntityID.BuffID.LIFE_REGEN] = "Wiederbelebung";
					Buff.BuffTip[(byte)EntityID.BuffID.LIFE_REGEN] = "Belebt wieder";
					Buff.BuffName[(byte)EntityID.BuffID.HASTE] = "Wendigkeit";
					Buff.BuffTip[(byte)EntityID.BuffID.HASTE] = "Erhöht Bewegungstempo um 25%";
					Buff.BuffName[(byte)EntityID.BuffID.GILLS] = "Kiemen";
					Buff.BuffTip[(byte)EntityID.BuffID.GILLS] = "Wasser statt Luft atmen";
					Buff.BuffName[(byte)EntityID.BuffID.IRONSKIN] = "Eisenhaut";
					Buff.BuffTip[(byte)EntityID.BuffID.IRONSKIN] = "Erhöht die Abwehr um 8";
					Buff.BuffName[(byte)EntityID.BuffID.MANA_REGEN] = "Mana-Wiederherstellung";
					Buff.BuffTip[(byte)EntityID.BuffID.MANA_REGEN] = "Erhöhte Mana-Wiederherstellung";
					Buff.BuffName[(byte)EntityID.BuffID.MAGIC_POWER] = "Magiekraft";
					Buff.BuffTip[(byte)EntityID.BuffID.MAGIC_POWER] = "Erhöht magischen Schaden um 20%";
					Buff.BuffName[(byte)EntityID.BuffID.SLOWFALL] = "Federsturz";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOWFALL] = "Zur Kontrolle der Sinkgeschwindigkeit Hoch oder Hinunter drücken";
					Buff.BuffName[(byte)EntityID.BuffID.FIND_TREASURE] = "Höhlenforscher";
					Buff.BuffTip[(byte)EntityID.BuffID.FIND_TREASURE] = "Zeigt den Fundort von Schatz und Erz";
					Buff.BuffName[(byte)EntityID.BuffID.INVISIBLE] = "Unsichtbarkeit";
					Buff.BuffTip[(byte)EntityID.BuffID.INVISIBLE] = "Macht unsichtbar";
					Buff.BuffName[(byte)EntityID.BuffID.SHINE] = "Glanz";
					Buff.BuffTip[(byte)EntityID.BuffID.SHINE] = "Strahlt Licht aus";
					Buff.BuffName[(byte)EntityID.BuffID.NIGHTVISION] = "Nachteule";
					Buff.BuffTip[(byte)EntityID.BuffID.NIGHTVISION] = "Erhöhte Nachtsicht";
					Buff.BuffName[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Kampf";
					Buff.BuffTip[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Erhöhte Feind-Spawnrate";
					Buff.BuffName[(byte)EntityID.BuffID.THORNS] = "Dornen";
					Buff.BuffTip[(byte)EntityID.BuffID.THORNS] = "Auch die Angreifer erleiden Schaden";
					Buff.BuffName[(byte)EntityID.BuffID.WATER_WALK] = "Wasserlaufen";
					Buff.BuffTip[(byte)EntityID.BuffID.WATER_WALK] = "HINUNTER drücken, um aufs Wasser zu gehen";
					Buff.BuffName[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Bogenschießen";
					Buff.BuffTip[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Um 20% erhöhter Pfeilschaden und -tempo";
					Buff.BuffName[(byte)EntityID.BuffID.DETECT_CREATURE] = "Jäger";
					Buff.BuffTip[(byte)EntityID.BuffID.DETECT_CREATURE] = "Zeigt die Position von Feinden";
					Buff.BuffName[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Gravitation";
					Buff.BuffTip[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Zum Umkehren der Schwerkraft HOCH oder HINUNTER drücken";
					Buff.BuffName[(byte)EntityID.BuffID.LIGHT_ORB] = "Lichtkugel";
					Buff.BuffTip[(byte)EntityID.BuffID.LIGHT_ORB] = "Eine magische Kugel, die Licht verströmt";
					Buff.BuffName[(byte)EntityID.BuffID.POISONED] = "Vergiftet";
					Buff.BuffTip[(byte)EntityID.BuffID.POISONED] = "Langsam entweicht das Leben";
					Buff.BuffName[(byte)EntityID.BuffID.POTION_DELAY] = "Krankheitstrank";
					Buff.BuffTip[(byte)EntityID.BuffID.POTION_DELAY] = "Kann keine Heil-Items mehr verbrauchen";
					Buff.BuffName[(byte)EntityID.BuffID.BLIND] = "Dunkelheit";
					Buff.BuffTip[(byte)EntityID.BuffID.BLIND] = "Schlechtere Sicht durch weniger Licht";
					Buff.BuffName[(byte)EntityID.BuffID.NO_ITEMS] = "Verflucht";
					Buff.BuffTip[(byte)EntityID.BuffID.NO_ITEMS] = "Kann keine Items verwenden";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE] = "Flammenmeer!";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE] = "Langsam entweicht das Leben";
					Buff.BuffName[(byte)EntityID.BuffID.DRUNK] = "Beschwipst";
					Buff.BuffTip[(byte)EntityID.BuffID.DRUNK] = "Erhöhte Nahkampffähigkeiten, verminderte Abwehr";
					Buff.BuffName[(byte)EntityID.BuffID.WELL_FED] = "Kleine Stärkung";
					Buff.BuffTip[(byte)EntityID.BuffID.WELL_FED] = "Geringe Anhebung aller Werte";
					Buff.BuffName[(byte)EntityID.BuffID.FAIRY] = "Fee";
					Buff.BuffTip[(byte)EntityID.BuffID.FAIRY] = "Eine Fee folgt dir";
					Buff.BuffName[(byte)EntityID.BuffID.WEREWOLF] = "Werwolf";
					Buff.BuffTip[(byte)EntityID.BuffID.WEREWOLF] = "Körperliche Fähigkeiten sind gestiegen";
					Buff.BuffName[(byte)EntityID.BuffID.CLARAVOYANCE] = "Hellsehen";
					Buff.BuffTip[(byte)EntityID.BuffID.CLARAVOYANCE] = "Magiekräfte werden erhöht";
					Buff.BuffName[(byte)EntityID.BuffID.BLEED] = "Bluted";
					Buff.BuffTip[(byte)EntityID.BuffID.BLEED] = "Kann sich nicht mehr erholen";
					Buff.BuffName[(byte)EntityID.BuffID.CONFUSED] = "Verwirrt";
					Buff.BuffTip[(byte)EntityID.BuffID.CONFUSED] = "Bewegt sich in die falsche Richtung";
					Buff.BuffName[(byte)EntityID.BuffID.SLOW] = "Langsam";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOW] = "Bewegungstempo ist herabgesetzt";
					Buff.BuffName[(byte)EntityID.BuffID.WEAK] = "Schwach";
					Buff.BuffTip[(byte)EntityID.BuffID.WEAK] = "Körperliche Leistungsfähigkeit ist reduziert";
					Buff.BuffName[(byte)EntityID.BuffID.MERFOLK] = "Meermenschen";
					Buff.BuffTip[(byte)EntityID.BuffID.MERFOLK] = "Können unter Wasser leicht atmen und sich bewegen ";
					Buff.BuffName[(byte)EntityID.BuffID.SILENCE] = "Zum Schweigen gebracht";
					Buff.BuffTip[(byte)EntityID.BuffID.SILENCE] = "Kann keine Items nutzen, die Mana erfordern";
					Buff.BuffName[(byte)EntityID.BuffID.BROKEN_ARMOR] = "Beschädigte Rüstung";
					Buff.BuffTip[(byte)EntityID.BuffID.BROKEN_ARMOR] = "Die Abwehr ist um die Hälfte reduziert";
					Buff.BuffName[(byte)EntityID.BuffID.HORRIFIED] = "Entsetzt";
					Buff.BuffTip[(byte)EntityID.BuffID.HORRIFIED] = "Du hast etwas Schlimmes gesehen. Da gibt es keinen Weg dran vorbei.";
					Buff.BuffName[(byte)EntityID.BuffID.TONGUED] = "Die Zunge";
					Buff.BuffTip[(byte)EntityID.BuffID.TONGUED] = "Du wirst in den Mund gesogen";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE_2] = "Verfluchtes Inferno";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE_2] = "Leben geht verloren";
					Buff.BuffName[(byte)EntityID.BuffID.PET] = "Haustier-Meerschweinchen";
					Buff.BuffTip[(byte)EntityID.BuffID.PET] = "Zum Verlieben";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 1] = "Haustier-Schleim";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 1] = "Ein echter Schleimball";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 2] = "Haustier-Tiphia";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 2] = "Will alles, was süß ist";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 3] = "Haustier-Fledermaus";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 3] = "Auf der Jagd nach Blut";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 4] = "Haustier-Werwolf";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 4] = "Der beste Freund des Menschen";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 5] = "Haustier-Zombie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 5] = "Verspeist Gehirne";
					Main.TileNames[(int)EntityID.TileID.BOTTLE] = "Flasche";
					Main.TileNames[(int)EntityID.TileID.TABLE] = "Tabelle";
					Main.TileNames[(int)EntityID.TileID.CHAIR] = "Stuhl";
					Main.TileNames[(int)EntityID.TileID.ANVIL] = "Amboss";
					Main.TileNames[(int)EntityID.TileID.FURNACE] = "Schmelzofen";
					Main.TileNames[(int)EntityID.TileID.WORK_BENCH] = "Werkbank";
					Main.TileNames[(int)EntityID.TileID.DEMON_ALTAR] = "Dämon-Altar";
					Main.TileNames[(int)EntityID.TileID.HELLFORGE] = "Höllenschmiede";
					Main.TileNames[(int)EntityID.TileID.LOOM] = "Webstuhl";
					Main.TileNames[(int)EntityID.TileID.KEG] = "Gärbottich";
					Main.TileNames[(int)EntityID.TileID.COOKING_POT] = "Kochtopf";
					Main.TileNames[(int)EntityID.TileID.BOOKCASE] = "Bücherregal";
					Main.TileNames[(int)EntityID.TileID.SAWMILL] = "Sägewerk";
					Main.TileNames[(int)EntityID.TileID.TINKERERS_WORKSHOP] = "Tüftler-Werkstatt";
					Main.TileNames[(int)EntityID.TileID.ADAMANTITE_FORGE] = "Adamantitschmiede";
					Main.TileNames[(int)EntityID.TileID.MYTHRIL_ANVIL] = "Mithrilamboss";
				}
				else if (LangOption == (int)ID.ITALIAN)
				{
					MiscText[0] = "L'esercito dei goblin è stato sconfitto!";
					MiscText[1] = "L'esercito dei goblin si sta avvicinando da ovest!";
					MiscText[2] = "L'esercito dei goblin si sta avvicinando da est!";
					MiscText[3] = "L'esercito dei goblin è arrivato!";
					MiscText[4] = "La Legione gelo è stata sconfitta!";
					MiscText[5] = "La Legione gelo si sta avvicinando da ovest!";
					MiscText[6] = "La Legione gelo si sta avvicinando da est!";
					MiscText[7] = "La Legione gelo è arrivata!";
					MiscText[8] = "La Luna di Sangue sta sorgendo...";
					MiscText[9] = "Senti una presenza malvagia che ti sta guardando...";
					MiscText[10] = "Un freddo terribile ti attraversa la spina dorsale...";
					MiscText[11] = "Intorno a te echeggiano urla... ";
					MiscText[12] = "Il tuo mondo è stato benedetto con cobalto! ";
					MiscText[13] = "Il tuo mondo è stato benedetto con mitrilio! ";
					MiscText[14] = "Il tuo mondo è stato benedetto con adamantio!";
					MiscText[15] = "I vecchi spiriti di luce e tenebre sono stati liberati.  ";
					MiscText[16] = " si è svegliato!";
					MiscText[17] = " è stato sconfitto!";
					MiscText[18] = " è arrivato!";
					MiscText[19] = " è stato ucciso...";
					MiscText[20] = "I gemelli";
					MiscText[21] = "Operazione non valida in questo stato.";
					MiscText[22] = "Non stai utilizzando la stessa versione del server.";
					MiscText[23] = "Giocatori correnti: ";
					MiscText[24] = " ha attivato il PvP!";
					MiscText[25] = " ha disattivato il PvP!";
					MiscText[26] = " non è più in un gruppo.";
					MiscText[27] = " si è unito al gruppo rosso.";
					MiscText[28] = " si è unito al gruppo verde.";
					MiscText[29] = " si è unito al gruppo blu.";
					MiscText[30] = " si è unito al gruppo giallo.";
					MiscText[31] = "Benevenuto, ";
					MiscText[32] = " ha aderito.";
					MiscText[33] = " ha smesso di.";
					MiscText[34] = "I Gemelli si sono svegliati!";
					MiscText[35] = "I Gemelli sono stati sconfitti!";
					MiscText[36] = "Un meteorite è atterrato!";
					MenuText[0] = "Ingredienti";
					MenuText[1] = " nel tuo inventario)";
					MenuText[2] = "Disconnetti";
					MenuText[3] = "Attenzione!";
					MenuText[4] = "<c>Quando questa icona è visibile\n\n\nla partita sta <i>salvando</i> i dati.";
					MenuText[5] = "Errore!";
					MenuText[6] = "Gioca online";
					MenuText[7] = "Solo su invito";
					MenuText[8] = "Server trovato...";
					MenuText[9] = "Caricamento non riuscito!";
					MenuText[10] = "Inizia partita";
					MenuText[11] = "Crea Mondo";
					MenuText[12] = "Sono stati trovati ed eliminati dati del personaggio danneggiati.";
					MenuText[13] = "Gioca";
					MenuText[14] = "Impostazioni";
					MenuText[15] = "Esci dal gioco";
					MenuText[16] = "Crea personaggio";
					MenuText[17] = XButton + "Elimina";
					MenuText[18] = "Capelli";
					MenuText[19] = "Occhi";
					MenuText[20] = "Pelle";
					MenuText[21] = "Abiti";
					MenuText[22] = "Maschio";
					MenuText[23] = "Femmina";
					MenuText[24] = "Hardcore";
					MenuText[25] = "Difficile";
					MenuText[26] = "Normale";
					MenuText[27] = "Casuale";
					MenuText[28] = "Crea";
					MenuText[29] = "Si muore per sempre";
					MenuText[30] = "Alla morte tutti gli oggetti vengono lasciati";
					MenuText[31] = "Alla morte tutte le monete vengono lasciate";
					MenuText[32] = "Livello di difficoltà";
					MenuText[33] = "Camicia";
					MenuText[34] = "Maglietta";
					MenuText[35] = "Pantaloni";
					MenuText[36] = "Scarpe";
					MenuText[37] = "Capelli";
					MenuText[38] = "Colore capelli";
					MenuText[39] = "Colore occhi";
					MenuText[40] = "Colore pelle";
					MenuText[41] = "Colore camicia";
					MenuText[42] = "Colore maglietta";
					MenuText[43] = "Colore pantaloni";
					MenuText[44] = "Colore scarpe";
					MenuText[45] = "Inserisci nome personaggio:";
					MenuText[46] = "Elimina ";
					MenuText[47] = "Riconoscimenti";
					MenuText[48] = "Inserisci nome mondo:";
					MenuText[49] = "Te ne vai senza aver creato un personaggio?";
					MenuText[50] = "Seleziona personaggio";
					MenuText[51] = "Caricamento partita";
					MenuText[52] = "Premi START";
					MenuText[53] = "Nome personaggio";
					MenuText[54] = "Salvataggio personaggio";
					MenuText[55] = "Nome Mondo";
					MenuText[56] = "Mondo";
					MenuText[57] = "Punto di rigenerazione impostato!";
					MenuText[58] = "Distanza percorsa";
					MenuText[59] = "Risorse estratte e raccolte";
					MenuText[60] = "Oggetti creati";
					MenuText[61] = "Oggetti utilizzati";
					MenuText[62] = "Boss sconfitti in modalità normale";
					MenuText[63] = "Boss sconfitti in modalità hardmode";
					MenuText[64] = "Volte in cui sei morto";
					MenuText[65] = "Volume";
					MenuText[66] = "Non è stato selezionato nessun supporto di memoria. Il salvataggio è stato disabilitato.";
					MenuText[67] = "Salvataggio automatico On";
					MenuText[68] = "Salvataggio automatico Off";
					MenuText[69] = "Nessun supporto di memoria";
					MenuText[70] = "Il supporto di memoria è stato rimosso. Il salvataggio è stato disabilitato.";
					MenuText[71] = "Testo di collegamento On";
					MenuText[72] = "Testo di collegamento Off";
					MenuText[73] = "Richiesta informazioni mondo...";
					MenuText[74] = "Richiesta dati in cascata...";
					MenuText[75] = "Accettazione invito...";
					MenuText[76] = "Ricerca...";
					MenuText[77] = "Nessuna partita trovata";
					MenuText[78] = "Giocatori:";
					MenuText[79] = "~ VUOTO ~";
					MenuText[80] = "Entrando...";
					MenuText[81] = "PvP";
					MenuText[82] = "Squadra";
					MenuText[83] = "I tuoi Mondi";
					MenuText[84] = "Entra nella partita";
					MenuText[85] = "Profondità: ";
					MenuText[86] = "m sotto";
					MenuText[87] = "m sopra";
					MenuText[88] = "livello";
					MenuText[89] = "Tutorial";
					MenuText[90] = "Ok";
					MenuText[91] = "Scegli grandezza del mondo:";
					MenuText[92] = "Piccolo";
					MenuText[93] = "Medio";
					MenuText[94] = "Grande";
					MenuText[95] = "Posizione: ";
					MenuText[96] = "m ad est";
					MenuText[97] = "m ad ovest";
					MenuText[98] = "centro ";
					MenuText[99] = "Salva gioco";
					MenuText[100] = "Esci dal menu principale";
					MenuText[101] = "Menu principale";
					MenuText[102] = "Sono stati trovati ed eliminati dati di impostazione danneggiati.";
					MenuText[103] = "Sono stati trovati ed eliminati dati del mondo danneggiati.";
					MenuText[104] = "Sì";
					MenuText[105] = "No";
					MenuText[106] = "Classifiche";
					MenuText[107] = "Obiettivi";
					MenuText[108] = "Guida e opzioni";
					MenuText[109] = "Sblocca gioco completo";
					MenuText[110] = "Come giocare";
					MenuText[111] = "Comandi";
					MenuText[112] = "Riprendi gioco";
					WorldGenText[0] = "Crea terreno del mondo...";
					WorldGenText[1] = "Aggiungi sabbia...";
					WorldGenText[2] = "Crea colline...";
					WorldGenText[3] = "Aggiungi terra dietro la terra...";
					WorldGenText[4] = "Posiziona rocce nella terra...";
					WorldGenText[5] = "Posiziona terra nelle rocce...";
					WorldGenText[6] = "Aggiungi argilla...";
					WorldGenText[7] = "Crea fori casuali...";
					WorldGenText[8] = "Crea piccole grotte: ";
					WorldGenText[9] = "Crea grandi grotte...";
					WorldGenText[10] = "Crea grotte superficiali...";
					WorldGenText[11] = "Crea giungla...";
					WorldGenText[12] = "Crea isole fluttuanti...";
					WorldGenText[13] = "Aggiungi campi di funghi...";
					WorldGenText[14] = "Posiziona fango nella terra...";
					WorldGenText[15] = "Aggiungi fango...";
					WorldGenText[16] = "Aggiungi elementi luminosi...";
					WorldGenText[17] = "Aggiungi ragnatele...";
					WorldGenText[18] = "Crea sotterraneo...";
					WorldGenText[19] = "Aggiungi creature acquatiche...";
					WorldGenText[20] = "Rendi il mondo malvagio...";
					WorldGenText[21] = "Crea grotte montuose...";
					WorldGenText[22] = "Crea spiagge...";
					WorldGenText[23] = "Aggiungi gemme";
					WorldGenText[24] = "Ruota sabbia...";
					WorldGenText[25] = "Pulisci sfondi terra...";
					WorldGenText[26] = "Posiziona altari...";
					WorldGenText[27] = "Versa liquidi...";
					WorldGenText[28] = "Posiziona cristalli di vita...";
					WorldGenText[29] = "Posiziona statue...";
					WorldGenText[30] = "Nascondi tesori...";
					WorldGenText[31] = "Nascondi più tesori...";
					WorldGenText[32] = "Nascondi tesori nella giungla...";
					WorldGenText[33] = "Nascondi tesori in acqua...";
					WorldGenText[34] = "Disponi trappole...";
					WorldGenText[35] = "Disponi oggetti fragili...";
					WorldGenText[36] = "Disponi creazioni degli inferi...";
					WorldGenText[37] = "Estensione erba...";
					WorldGenText[38] = "Crescita cactus...";
					WorldGenText[39] = "Pianta girasoli...";
					WorldGenText[40] = "Pianta alberi...";
					WorldGenText[41] = "Pianta erbe...";
					WorldGenText[42] = "Pianta erbacce...";
					WorldGenText[43] = "Coltiva viti...";
					WorldGenText[44] = "Pianta fiori...";
					WorldGenText[45] = "Pianta funghi...";
					WorldGenText[46] = "Connessione all'host perduta.";
					WorldGenText[47] = "Resetta oggetti di gioco...";
					WorldGenText[48] = "Imposta modalità difficile...";
					WorldGenText[49] = "Salva dati del mondo...";
					WorldGenText[50] = "Backup file mondo...";
					WorldGenText[51] = "Carica dati del mondo...";
					WorldGenText[52] = "Controlla l'allineamento delle mattonelle...";
					WorldGenText[53] = "Si è verificato un errore durante la lettura del supporto di memoria.";
					WorldGenText[54] = "Si è verificato un errore durante la scrittura sul supporto di memoria.";
					WorldGenText[55] = "Trova cornici delle mattonelle...";
					WorldGenText[56] = "Aggiungi neve ...";
					WorldGenText[57] = "Mondo";
					WorldGenText[58] = "Crea la dungeon...";
					InterfaceText[0] = "Cancella";
					InterfaceText[1] = "Esci senza salvare";
					InterfaceText[2] = "Salva ed esci";
					InterfaceText[3] = "Cestino";
					InterfaceText[4] = "Inventario";
					InterfaceText[5] = "Vuoi tornare al menu principale?";
					InterfaceText[6] = "Bonus";
					InterfaceText[7] = "Alloggio";
					InterfaceText[8] = "Questo alloggio non è adatto.";
					InterfaceText[9] = "Accessori";
					InterfaceText[10] = " Difesa";
					InterfaceText[11] = "Estetica";
					InterfaceText[12] = "Casco";
					InterfaceText[13] = "Camicia";
					InterfaceText[14] = "Pantaloni";
					InterfaceText[15] = " platino ";
					InterfaceText[16] = " oro ";
					InterfaceText[17] = " argento ";
					InterfaceText[18] = " rame";
					InterfaceText[19] = "Riforgiare";
					InterfaceText[20] = "Creazione sessione di rete non riuscita.";
					InterfaceText[21] = "Partecipazione alla sessione non riuscita. La sessione è completa o non è stata trovata.";
					InterfaceText[22] = "Oggetti richiesti:";
					InterfaceText[23] = "Nessuno";
					InterfaceText[24] = "Alterna la modalità di lotta";
					InterfaceText[25] = "Creazione Oggetti";
					InterfaceText[26] = "Monete";
					InterfaceText[27] = "Munizioni";
					InterfaceText[28] = "Negozio";
					InterfaceText[29] = InvSelectAction + "Saccheggia tutto";
					InterfaceText[30] = InvSelectAction + "Deposita tutto";
					InterfaceText[31] = InvSelectAction + "Raggruppamento rapido";
					InterfaceText[32] = "Salvadanaio";
					InterfaceText[33] = "Caveau";
					InterfaceText[34] = "Tempo: ";
					InterfaceText[35] = "Sei sicuro di voler uscire?";
					InterfaceText[36] = "Connessione a Xbox LIVE perduta";
					InterfaceText[37] = "Numero di entrate: ";
					InterfaceText[38] = "Sei morto...";
					InterfaceText[39] = "Questo alloggio è adatto.";
					InterfaceText[40] = "Questo alloggio non è valido.";
					InterfaceText[41] = "Questo alloggio è già occupato.";
					InterfaceText[42] = "Questo alloggio è corrotto.";
					InterfaceText[43] = "Questo profilo non possiede i privilegi adatti per entrare. È necessario avere un account LIVE Gold o cambiare le impostazioni per il controllo genitori. ";
					InterfaceText[44] = "Ricezione dati in cascata";
					InterfaceText[45] = "Equipaggiamento";
					InterfaceText[46] = "Costo: ";
					InterfaceText[47] = "Salva";
					InterfaceText[48] = "Modifica";
					InterfaceText[49] = "Stato";
					InterfaceText[50] = "Maledizione";
					InterfaceText[51] = "Aiuto";
					InterfaceText[52] = "Chiudi";
					InterfaceText[53] = "Acqua";
					InterfaceText[54] = "Guarire";
					InterfaceText[55] = "Offre consigli e suggerimenti sulla creazione.";
					InterfaceText[56] = "Vende merce base.";
					InterfaceText[57] = "Guarisce ferite e malus.";
					InterfaceText[58] = "Vende esplosivi.";
					InterfaceText[59] = "Vende merce naturale e indica lo stato del Mondo.";
					InterfaceText[60] = "Vende pistole e munizioni.";
					InterfaceText[61] = "Vende abiti.";
					InterfaceText[62] = "Vende cavi e attrezzi.";
					InterfaceText[63] = "Vende merce utile e riforgia oggetti.";
					InterfaceText[64] = "Vende oggetti e accessori magici.";
					InterfaceText[65] = "Un vecchio simpaticone.";
					InterfaceText[66] = "Partita terminata";
					InterfaceText[67] = "La partita è stata terminata dall'host.";
					InterfaceText[68] = "Impossibile connettersi a causa delle impostazioni di privacy di uno dei profili connessi.";
					InterfaceText[69] = "Stai giocando in versione prova. Acquista la versione completa per giocare online.";
					InterfaceText[70] = "Spazio insufficiente sul supporto di memoria selezionato.";
					InterfaceText[71] = "Con la condivisione dello schermo in definizione standard è difficile leggere il testo durante la partita. Raccomandiamo quindi, di utilizzare l'alta definizione (HD) per un'esperienza di gioco migliore.";
					InterfaceText[72] = "Blocca Mondo";
					InterfaceText[73] = "Sei sicuro di voler aggiungere questo Mondo alla tua lista dei Mondi bloccati?\n\nUscirai inoltre dalla partita, selezionando OK.";
					InterfaceText[74] = "ATTENZIONE! Il Mondo in cui stai entrando, è presente nella tua lista dei Mondi bloccati.\n\nSe decidi di partecipare a questa partita, il Mondo verrà rimosso dalla tua lista dei Mondi bloccati.";
					InterfaceText[75] = "Continua";
					InterfaceText[76] = "(In attesa di approvazione)";
					InterfaceText[77] = "(Censurato)";
					InterfaceText[78] = "Il Gioco Salvato \"{0}\" è stato trasferito da un altro profilo e sarà cancellato.";
					InterfaceText[79] = "La partita finirà a causa delle impostazioni familiari di uno dei profili connessi.";
					TipText[0] = "Equipaggiato nella sezione di estetica";
					TipText[1] = "Nessun parametro incrementato";
					TipText[2] = " Danno da mischia";
					TipText[3] = " Danno boomerang";
					TipText[4] = " Danno magico";
					TipText[5] = "% Possibilità colpo critico";
					TipText[6] = "Velocità matta";
					TipText[7] = "Extra velocità";
					TipText[8] = "Alta velocità";
					TipText[9] = "Media velocità";
					TipText[10] = "Bassa velocità";
					TipText[11] = "Velocità molto bassa";
					TipText[12] = "Velocità extra bassa";
					TipText[13] = "Velocità lumaca";
					TipText[14] = "Nessuno spintone";
					TipText[15] = "Spintone extra debole";
					TipText[16] = "Spintone molto debole";
					TipText[17] = "Spintone debole";
					TipText[18] = "Spintone medio";
					TipText[19] = "Spintone forte";
					TipText[20] = "Spintone molto forte";
					TipText[21] = "Spintone extra forte";
					TipText[22] = "Spintone matto";
					TipText[23] = "Equipaggiabili";
					TipText[24] = "Oggetti di estetica";
					TipText[25] = " Difesa";
					TipText[26] = "% Potenza piccone";
					TipText[27] = "% Potenza ascia";
					TipText[28] = "% Potenza martello";
					TipText[29] = "Risana ";
					TipText[30] = " vita";
					TipText[31] = " mana";
					TipText[32] = "Utilizza ";
					TipText[33] = "Può essere posizionato";
					TipText[34] = "Munizioni";
					TipText[35] = "Consumabile";
					TipText[36] = "Materiale";
					TipText[37] = " Durata minuto";
					TipText[38] = " Durata secondo";
					TipText[39] = "% Danno";
					TipText[40] = "% Velocità";
					TipText[41] = "% Possibilità colpo critico";
					TipText[42] = "% Costo mana";
					TipText[43] = "% Dimensione";
					TipText[44] = "% Velocità del proiettile";
					TipText[45] = "% Spintone";
					TipText[46] = "% Velocità movimento";
					TipText[47] = "% Velocità corpo a corpo";
					TipText[48] = "Imposta bonus: ";
					TipText[49] = "Prezzo di vendita: ";
					TipText[50] = "Prezzo di acquisto: ";
					TipText[51] = "Nessun valore";
					DeathText[0] = " non ha trovato l'antidoto.";
					DeathText[1] = " non ha spento il fuoco.";
					DeathText[2] = " ha tentato di scappare.";
					DeathText[3] = "è stato battuto. ";
					Buff.BuffName[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Pelle ossidiana";
					Buff.BuffTip[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Immune alla lava";
					Buff.BuffName[(byte)EntityID.BuffID.LIFE_REGEN] = "Rigenerazione";
					Buff.BuffTip[(byte)EntityID.BuffID.LIFE_REGEN] = "Rigenera la vita";
					Buff.BuffName[(byte)EntityID.BuffID.HASTE] = "Velocità";
					Buff.BuffTip[(byte)EntityID.BuffID.HASTE] = "Velocità di movimento aumentata del 25%";
					Buff.BuffName[(byte)EntityID.BuffID.GILLS] = "Branchie";
					Buff.BuffTip[(byte)EntityID.BuffID.GILLS] = "Respira acqua invece di aria";
					Buff.BuffName[(byte)EntityID.BuffID.IRONSKIN] = "Pelle di ferro";
					Buff.BuffTip[(byte)EntityID.BuffID.IRONSKIN] = "Aumenta la difesa di 8";
					Buff.BuffName[(byte)EntityID.BuffID.MANA_REGEN] = "Rigenerazione mana";
					Buff.BuffTip[(byte)EntityID.BuffID.MANA_REGEN] = "Aumenta la rigenerazione del mana";
					Buff.BuffName[(byte)EntityID.BuffID.MAGIC_POWER] = "Potere magico";
					Buff.BuffTip[(byte)EntityID.BuffID.MAGIC_POWER] = "Danno magico aumentato del 20%";
					Buff.BuffName[(byte)EntityID.BuffID.SLOWFALL] = "Cascata di piume";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOWFALL] = "Premi UP o DOWN per controllare la velocità di discesa";
					Buff.BuffName[(byte)EntityID.BuffID.FIND_TREASURE] = "Speleologo";
					Buff.BuffTip[(byte)EntityID.BuffID.FIND_TREASURE] = "Mostra l'ubicazione di tesori e minerali";
					Buff.BuffName[(byte)EntityID.BuffID.INVISIBLE] = "Invisibilità";
					Buff.BuffTip[(byte)EntityID.BuffID.INVISIBLE] = "Rende invisibili";
					Buff.BuffName[(byte)EntityID.BuffID.SHINE] = "Brillantezza";
					Buff.BuffTip[(byte)EntityID.BuffID.SHINE] = "Emette luce";
					Buff.BuffName[(byte)EntityID.BuffID.NIGHTVISION] = "Civetta notturna";
					Buff.BuffTip[(byte)EntityID.BuffID.NIGHTVISION] = "Visione notturna aumentata";
					Buff.BuffName[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Battaglia";
					Buff.BuffTip[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Ritmo generazione nemici aumentato";
					Buff.BuffName[(byte)EntityID.BuffID.THORNS] = "Spine";
					Buff.BuffTip[(byte)EntityID.BuffID.THORNS] = "Anche gli aggressori subiscono danni";
					Buff.BuffName[(byte)EntityID.BuffID.WATER_WALK] = "Camminata nell'acqua";
					Buff.BuffTip[(byte)EntityID.BuffID.WATER_WALK] = "Premi DOWN per entrare nell'acqua";
					Buff.BuffName[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Arco";
					Buff.BuffTip[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Danno e velocià freccia aumentati del 20%";
					Buff.BuffName[(byte)EntityID.BuffID.DETECT_CREATURE] = "Cacciatore";
					Buff.BuffTip[(byte)EntityID.BuffID.DETECT_CREATURE] = "Mostra la posizione dei nemici";
					Buff.BuffName[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Gravità";
					Buff.BuffTip[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Premi UP o DOWN per invertire la gravità";
					Buff.BuffName[(byte)EntityID.BuffID.LIGHT_ORB] = "Orbita di luce";
					Buff.BuffTip[(byte)EntityID.BuffID.LIGHT_ORB] = "Sfera magica che fornisce luce";
					Buff.BuffName[(byte)EntityID.BuffID.POISONED] = "Avvelenato";
					Buff.BuffTip[(byte)EntityID.BuffID.POISONED] = "Perdi lentamente la vita";
					Buff.BuffName[(byte)EntityID.BuffID.POTION_DELAY] = "Malattia pozione";
					Buff.BuffTip[(byte)EntityID.BuffID.POTION_DELAY] = "Non si possono più consumare oggetti curativi";
					Buff.BuffName[(byte)EntityID.BuffID.BLIND] = "Oscurità";
					Buff.BuffTip[(byte)EntityID.BuffID.BLIND] = "Visione della luce diminuita";
					Buff.BuffName[(byte)EntityID.BuffID.NO_ITEMS] = "Maledetto";
					Buff.BuffTip[(byte)EntityID.BuffID.NO_ITEMS] = "Non si possono più utilizzare oggetti";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE] = "A fuoco!";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE] = "Perdi lentamente la vita";
					Buff.BuffName[(byte)EntityID.BuffID.DRUNK] = "Brillo";
					Buff.BuffTip[(byte)EntityID.BuffID.DRUNK] = "Abilità corpo a corpo aumentata, difesa abbassata";
					Buff.BuffName[(byte)EntityID.BuffID.WELL_FED] = "Ben nutrito";
					Buff.BuffTip[(byte)EntityID.BuffID.WELL_FED] = "Migliorie minori a tutti i parametri";
					Buff.BuffName[(byte)EntityID.BuffID.FAIRY] = "Fata";
					Buff.BuffTip[(byte)EntityID.BuffID.FAIRY] = "Una fata ti sta seguendo";
					Buff.BuffName[(byte)EntityID.BuffID.WEREWOLF] = "Lupo mannaro";
					Buff.BuffTip[(byte)EntityID.BuffID.WEREWOLF] = "Abilità fisiche aumentate";
					Buff.BuffName[(byte)EntityID.BuffID.CLARAVOYANCE] = "Chiaroveggenza";
					Buff.BuffTip[(byte)EntityID.BuffID.CLARAVOYANCE] = "Poteri magici aumentati";
					Buff.BuffName[(byte)EntityID.BuffID.BLEED] = "Sanguinamento";
					Buff.BuffTip[(byte)EntityID.BuffID.BLEED] = "Impossibile rigenerare vita";
					Buff.BuffName[(byte)EntityID.BuffID.CONFUSED] = "Confuso";
					Buff.BuffTip[(byte)EntityID.BuffID.CONFUSED] = "Movimento invertito";
					Buff.BuffName[(byte)EntityID.BuffID.SLOW] = "Lento";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOW] = "Velocità movimento ridotta";
					Buff.BuffName[(byte)EntityID.BuffID.WEAK] = "Debole";
					Buff.BuffTip[(byte)EntityID.BuffID.WEAK] = "Abilità fisiche diminuite";
					Buff.BuffName[(byte)EntityID.BuffID.MERFOLK] = "Tritone";
					Buff.BuffTip[(byte)EntityID.BuffID.MERFOLK] = "Può respirare e muoversi facilmente sott'acqua";
					Buff.BuffName[(byte)EntityID.BuffID.SILENCE] = "Tacere";
					Buff.BuffTip[(byte)EntityID.BuffID.SILENCE] = "Non possono utilizzare gli elementi che richiedono mana";
					Buff.BuffName[(byte)EntityID.BuffID.BROKEN_ARMOR] = "Armatura rotta";
					Buff.BuffTip[(byte)EntityID.BuffID.BROKEN_ARMOR] = "La difesa è dimezzata";
					Buff.BuffName[(byte)EntityID.BuffID.HORRIFIED] = "Inorridito";
					Buff.BuffTip[(byte)EntityID.BuffID.HORRIFIED] = "Hai visto qualcosa di orribile, non c'è via di scampo.";
					Buff.BuffName[(byte)EntityID.BuffID.TONGUED] = "La Lingua";
					Buff.BuffTip[(byte)EntityID.BuffID.TONGUED] = "Sei stato succhiato nella bocca";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE_2] = "Inferno maledetto";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE_2] = "Perdi la vita";
					Buff.BuffName[(byte)EntityID.BuffID.PET] = "Porcellino d'India";
					Buff.BuffTip[(byte)EntityID.BuffID.PET] = "Semplicemente adorabile";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 1] = "Slime";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 1] = "Una vera palla di slime";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 2] = "Vespa";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 2] = "Vuole tutto il miele";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 3] = "Pipistrello";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 3] = "A caccia di sangue";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 4] = "Lupo mannaro";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 4] = "Il migliore amico dell'uomo";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 5] = "Zombie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 5] = "Mangia cervelli";
					Main.TileNames[(int)EntityID.TileID.BOTTLE] = "Bottiglia";
					Main.TileNames[(int)EntityID.TileID.TABLE] = "Tavolo";
					Main.TileNames[(int)EntityID.TileID.CHAIR] = "Sedia";
					Main.TileNames[(int)EntityID.TileID.ANVIL] = "Incudine";
					Main.TileNames[(int)EntityID.TileID.FURNACE] = "Fornace";
					Main.TileNames[(int)EntityID.TileID.WORK_BENCH] = "Banco da lavoro";
					Main.TileNames[(int)EntityID.TileID.DEMON_ALTAR] = "Altare dei demoni";
					Main.TileNames[(int)EntityID.TileID.HELLFORGE] = "Creazione degli inferi";
					Main.TileNames[(int)EntityID.TileID.LOOM] = "Telaio";
					Main.TileNames[(int)EntityID.TileID.KEG] = "Barilotto";
					Main.TileNames[(int)EntityID.TileID.COOKING_POT] = "Pentola";
					Main.TileNames[(int)EntityID.TileID.BOOKCASE] = "Scaffale";
					Main.TileNames[(int)EntityID.TileID.SAWMILL] = "Segheria";
					Main.TileNames[(int)EntityID.TileID.TINKERERS_WORKSHOP] = "Laboratorio dell'inventore";
					Main.TileNames[(int)EntityID.TileID.ADAMANTITE_FORGE] = "Forgia di adamantio";
					Main.TileNames[(int)EntityID.TileID.MYTHRIL_ANVIL] = "Incudine di mitrilio";
				}
				else if (LangOption == (int)ID.FRENCH)
				{
					MiscText[0] = "L'armée des gobelins a été vaincue.";
					MiscText[1] = "Une armée de gobelins approche par l'ouest.";
					MiscText[2] = "Une armée de gobelins approche par l'est.";
					MiscText[3] = "Une armée de gobelins est arrivée\u00a0!";
					MiscText[4] = "La Légion gel a été vaincue\u00a0!";
					MiscText[5] = "La Légion gel approche l'ouest\u00a0!";
					MiscText[6] = "La Légion gel approche par l'est\u00a0!";
					MiscText[7] = "La Légion gel est arrivée\u00a0!";
					MiscText[8] = "La lune sanglante se lève...";
					MiscText[9] = "Vous sentez une présence maléfique vous observer...";
					MiscText[10] = "Un frisson vous parcourt le dos...";
					MiscText[11] = "Des cris retentissent autour de vous...";
					MiscText[12] = "Votre monde a la chance de profiter de ressources de cobalt.";
					MiscText[13] = "Votre monde a la chance de profiter de ressources de mythril.";
					MiscText[14] = "Votre monde a la chance de profiter de ressources d'adamantine.";
					MiscText[15] = "Les anciens esprits de l'ombre et de la lumière ont été relâchés.";
					MiscText[16] = " est réveillé.";
					MiscText[17] = " a été vaincue.";
					MiscText[18] = " est arrivée.";
					MiscText[19] = " s'est fait éliminer...";
					MiscText[20] = "Les jumeaux";
					MiscText[21] = "Opération non valable en l'état.";
					MiscText[22] = "Vous n'utilisez pas la même version que ce serveur.";
					MiscText[23] = "Joueurs actuels : ";
					MiscText[24] = " a activé le PvP.";
					MiscText[25] = " a désactivé le PvP.";
					MiscText[26] = " n'est plus dans une équipe.";
					MiscText[27] = " a rejoint l'équipe rouge.";
					MiscText[28] = " a rejoint l'équipe verte.";
					MiscText[29] = " a rejoint l'équipe bleue.";
					MiscText[30] = " a rejoint l'équipe jaune.";
					MiscText[31] = "Bienvenue, ";
					MiscText[32] = " a rejoint.";
					MiscText[33] = " a quitté.";
					MiscText[34] = "Les Jumeaux se sont réveillés\u00a0!";
					MiscText[35] = "Les Jumeaux ont été vaincus\u00a0!";
					MiscText[36] = "Une météorite a atterri !";
					MenuText[0] = "Ingrédients";
					MenuText[1] = "dans votre inventaire)";
					MenuText[2] = "Déconnexion";
					MenuText[3] = "Attention\u00a0!";
					MenuText[4] = "<c>Lorsque cette icône apparaît,\n\n\nle jeu est en cours de <i>sauvegarde</i> de données.";
					MenuText[5] = "Erreur\u00a0!";
					MenuText[6] = "Jouer en ligne";
					MenuText[7] = "Sur invitation seulement";
					MenuText[8] = "Serveur trouvé...";
					MenuText[9] = "Le chargement a échoué.";
					MenuText[10] = "Démarrer jeu";
					MenuText[11] = "Créer un monde";
					MenuText[12] = "Des données avec des caractères corrompus ont été détectées et supprimées.";
					MenuText[13] = "Jouer";
					MenuText[14] = "Paramètres";
					MenuText[15] = "Quitter le jeu";
					MenuText[16] = "Créer un personnage";
					MenuText[17] = XButton + "Supprimer";
					MenuText[18] = "Cheveux";
					MenuText[19] = "Yeux";
					MenuText[20] = "Peau";
					MenuText[21] = "Vêtements";
					MenuText[22] = "Homme";
					MenuText[23] = "Femme";
					MenuText[24] = "Hardcore";
					MenuText[25] = "Difficile";
					MenuText[26] = "Normal";
					MenuText[27] = "Aléatoire";
					MenuText[28] = "Créer";
					MenuText[29] = "La mort est définitive";
					MenuText[30] = "Perdre tous ses objets à la mort";
					MenuText[31] = "Perdre son argent à la mort";
					MenuText[32] = "Choisir la difficulté";
					MenuText[33] = "Chemise";
					MenuText[34] = "Maillot de corps";
					MenuText[35] = "Pantalon";
					MenuText[36] = "Chaussures";
					MenuText[37] = "Cheveux";
					MenuText[38] = "Couleur des cheveux";
					MenuText[39] = "Couleur des yeux";
					MenuText[40] = "Couleur de peau";
					MenuText[41] = "Couleur de chemise";
					MenuText[42] = "Couleur de maillot de corps";
					MenuText[43] = "Couleur de pantalon";
					MenuText[44] = "Couleur des chaussures";
					MenuText[45] = "Saisir le nom du personnage :";
					MenuText[46] = "Supprimer ";
					MenuText[47] = "Crédits";
					MenuText[48] = "Saisir un nom de monde :";
					MenuText[49] = "Quitter sans créer de personnage\u00a0?";
					MenuText[50] = "Sélectionner un personnage";
					MenuText[51] = "En attente du démarrage du jeu...";
					MenuText[52] = "Appuyez sur START";
					MenuText[53] = "Nom du personnage";
					MenuText[54] = "Sauvegarde du personnage...";
					MenuText[55] = "Nom du monde";
					MenuText[56] = "Monde";
					MenuText[57] = "Point d'apparition défini\u00a0!";
					MenuText[58] = "Distance parcourue";
					MenuText[59] = "Ressources extraites et collectées";
					MenuText[60] = "Objets fabriqués";
					MenuText[61] = "Objets utilisés";
					MenuText[62] = "Boss normaux vaincus";
					MenuText[63] = "Boss difficiles vaincus";
					MenuText[64] = "Nombre de fois mort(e)";
					MenuText[65] = "Volume";
					MenuText[66] = "La sauvegarde a été désactivée, car aucun périphérique de stockage n'a été sélectionné. ";
					MenuText[67] = "Sauvegarde auto activée";
					MenuText[68] = "Sauvegarde auto désactivée";
					MenuText[69] = "Aucun périphérique de stockage";
					MenuText[70] = "La sauvegarde a été désactivée, car le périphérique de stockage a été retiré.";
					MenuText[71] = "Affichage du texte activé";
					MenuText[72] = "Affichage du texte désactivé";
					MenuText[73] = "Demande d'informations du monde...";
					MenuText[74] = "Demande des données de tuiles...";
					MenuText[75] = "Acceptation de l'invitation...";
					MenuText[76] = "Recherche...";
					MenuText[77] = "Aucune partie trouvée";
					MenuText[78] = "Joueurs\u00a0: ";
					MenuText[79] = "~ VIDE ~";
					MenuText[80] = "Connexion à la partie...";
					MenuText[81] = "PvP";
					MenuText[82] = "Équipe";
					MenuText[83] = "Vos mondes";
					MenuText[84] = "Rejoindre la partie";
					MenuText[85] = "Profondeur\u00a0: ";
					MenuText[86] = "m en-dessous";
					MenuText[87] = "m au-dessus";
					MenuText[88] = "niveau";
					MenuText[89] = "Tutoriel";
					MenuText[90] = "OK";
					MenuText[91] = "Choisir la taille du monde :";
					MenuText[92] = "Petit";
					MenuText[93] = "Moyen";
					MenuText[94] = "Grand";
					MenuText[95] = "Position\u00a0: ";
					MenuText[96] = "m est";
					MenuText[97] = "m ouest";
					MenuText[98] = "centre";
					MenuText[99] = "Sauvegarder la partie";
					MenuText[100] = "Retour au menu principal";
					MenuText[101] = "Menu principal";
					MenuText[102] = "Les données des paramètres étaient corrompues et ont été supprimées.";
					MenuText[103] = "Des données corrompues du monde ont été trouvées et supprimées.";
					MenuText[104] = "Oui";
					MenuText[105] = "Pas";
					MenuText[106] = "Classements";
					MenuText[107] = "Succès";
					MenuText[108] = "Aide et options";
					MenuText[109] = "Déverrouiller le jeu complet";
					MenuText[110] = "Comment jouer";
					MenuText[111] = "Commandes";
					MenuText[112] = "Reprendre le jeu";
					WorldGenText[0] = "Création du terrain...";
					WorldGenText[1] = "Ajout de sable...";
					WorldGenText[2] = "Création des collines...";
					WorldGenText[3] = "Placement de la boue derrière la boue...";
					WorldGenText[4] = "Placement des rochers dans la boue...";
					WorldGenText[5] = "Placement de boue dans les rochers...";
					WorldGenText[6] = "Ajout d'argile...";
					WorldGenText[7] = "Création de trous aléatoires...";
					WorldGenText[8] = "Création de petites cavernes...";
					WorldGenText[9] = "Création de grandes cavernes...";
					WorldGenText[10] = "Création des cavernes en surface...";
					WorldGenText[11] = "Création de jungle...";
					WorldGenText[12] = "Création d'îles flottantes...";
					WorldGenText[13] = "Ajout des parcelles de champignons...";
					WorldGenText[14] = "Placement de la terre dans la boue...";
					WorldGenText[15] = "Ajout de limon...";
					WorldGenText[16] = "Ajout des brillances...";
					WorldGenText[17] = "Ajout de toiles d'araignées...";
					WorldGenText[18] = "Création du monde inférieur...";
					WorldGenText[19] = "Ajout d'étendues d'eau...";
					WorldGenText[20] = "Corruption du monde...";
					WorldGenText[21] = "Création de cavernes montagneuses...";
					WorldGenText[22] = "Création de plages...";
					WorldGenText[23] = "Ajout de gemmes...";
					WorldGenText[24] = "Gravitation du sable...";
					WorldGenText[25] = "Nettoyage d'arrière-plans de boue...";
					WorldGenText[26] = "Placement d'autels...";
					WorldGenText[27] = "Mise en place des points d'eau...";
					WorldGenText[28] = "Placement de cristaux de vie...";
					WorldGenText[29] = "Placement de statues...";
					WorldGenText[30] = "Dissimulation de trésors...";
					WorldGenText[31] = "Dissimulation de trésors supplémentaires...";
					WorldGenText[32] = "Dissimulation de trésors de jungle...";
					WorldGenText[33] = "Dissimulation de trésors d'eau...";
					WorldGenText[34] = "Placement de pièges...";
					WorldGenText[35] = "Placement d'objets cassables...";
					WorldGenText[36] = "Placement de forges infernales...";
					WorldGenText[37] = "Création de zone d'herbe...";
					WorldGenText[38] = "Faire pousser des cactus...";
					WorldGenText[39] = "Plantation de tournesols...";
					WorldGenText[40] = "Plantation d'arbres...";
					WorldGenText[41] = "Plantation d'herbe...";
					WorldGenText[42] = "Plantation de mauvaises herbes...";
					WorldGenText[43] = "Faire pousser des vignes...";
					WorldGenText[44] = "Plantation de fleurs...";
					WorldGenText[45] = "Plantation de champignons...";
					WorldGenText[46] = "La connexion à l'hôte a été perdue.";
					WorldGenText[47] = "Réinitialisation des objets du jeu...";
					WorldGenText[48] = "Installation du mode difficile...";
					WorldGenText[49] = "Sauvegarde des données du monde...";
					WorldGenText[50] = "Sauvegarde du fichier du monde...";
					WorldGenText[51] = "Chargement des données du monde...";
					WorldGenText[52] = "Vérification de l'alignement des blocs...";
					WorldGenText[53] = "Une erreur est survenue lors de la lecture du périphérique de stockage.";
					WorldGenText[54] = "Une erreur est survenue lors de l'écriture sur le périphérique de stockage.";
					WorldGenText[55] = "Trouver les images de blocs...";
					WorldGenText[56] = "Ajout de neige...";
					MenuText[56] = "Monde";
					WorldGenText[58] = "Création de donjon...";
					InterfaceText[0] = "Annuler";
					InterfaceText[1] = "Quitter sans sauvegarder";
					InterfaceText[2] = "Sauvegarder et quitter";
					InterfaceText[3] = "Poubelle";
					InterfaceText[4] = "Inventaire";
					InterfaceText[5] = "Voulez-vous retourner au menu principal\u00a0?";
					InterfaceText[6] = "Buffs";
					InterfaceText[7] = "Logement";
					InterfaceText[8] = "Ce logement n'est pas approprié.";
					InterfaceText[9] = "Accessoires";
					InterfaceText[10] = " Défense";
					InterfaceText[11] = "Vanité";
					InterfaceText[12] = "Casque";
					InterfaceText[13] = "Chemise";
					InterfaceText[14] = "Pantalon";
					InterfaceText[15] = " Platine ";
					InterfaceText[16] = " Or ";
					InterfaceText[17] = " Argent ";
					InterfaceText[18] = " Cuivre";
					InterfaceText[19] = "Reforger";
					InterfaceText[20] = "La création d'une session en réseau a échoué.";
					InterfaceText[21] = "Impossible de rejoindre la session, car elle est pleine ou introuvable.";
					InterfaceText[22] = "Objets requis :";
					InterfaceText[23] = "Aucun";
					InterfaceText[24] = "Alterner le mode grappin";
					InterfaceText[25] = "Artisanat";
					InterfaceText[26] = "Pièces";
					InterfaceText[27] = "Munitions";
					InterfaceText[28] = "Magasin";
					InterfaceText[29] = InvSelectAction + "Tout récupérer";
					InterfaceText[30] = InvSelectAction + "Tout déposer";
					InterfaceText[31] = InvSelectAction + "Pile rapide";
					InterfaceText[32] = "Tirelire";
					InterfaceText[33] = "Coffre-fort";
					InterfaceText[34] = "Temps : ";
					InterfaceText[35] = "Voulez-vous vraiment quitter\u00a0?";
					InterfaceText[36] = "La connexion à la Xbox LIVE a été perdue";
					InterfaceText[37] = "Nombre d'entrées\u00a0: ";
					InterfaceText[38] = "Vous vous êtes fait exterminer...";
					InterfaceText[39] = "Ce logement convient.";
					InterfaceText[40] = "Ce logement ne convient pas.";
					InterfaceText[41] = "Ce logement est déjà occupé.";
					InterfaceText[42] = "Ce logement est corrompu.";
					InterfaceText[43] = "Ce profil du joueur ne dispose pas des privilèges pour se connecter. Il est possible qu'un compte LIVE Gold soit requis, ou que vous deviez changer les paramètres de contrôle parental.";
					InterfaceText[44] = "Réception de données de blocs";
					InterfaceText[45] = "équiper";
					InterfaceText[46] = "Coût: ";
					InterfaceText[47] = "Enregistrer";
					InterfaceText[48] = "Modifier";
					InterfaceText[49] = "État";
					InterfaceText[50] = "Malédiction";
					InterfaceText[51] = "Aide";
					InterfaceText[52] = "Proches";
					InterfaceText[53] = "De l'eau";
					InterfaceText[54] = "Guérir";
					InterfaceText[55] = "Fournit des astuces et des conseils d'artisanat.";
					InterfaceText[56] = "Vend des marchandises de base.";
					InterfaceText[57] = "Guérit les blessures et les debuffs.";
					InterfaceText[58] = "Vend des explosifs.";
					InterfaceText[59] = "Vend des produits naturels et renseigne sur l'état du monde.";
					InterfaceText[60] = "Vend des armes à feu et des munitions.";
					InterfaceText[61] = "Vend des vêtements de vanité.";
					InterfaceText[62] = "Vend des outils et des câbles.";
					InterfaceText[63] = "Vend des gadgets utiles et reforge des objets.";
					InterfaceText[64] = "Vend des objets et accessoires magiques.";
					InterfaceText[65] = "Un vieu bonhomme joyeux.";
					InterfaceText[66] = "Partie terminée";
					InterfaceText[67] = "L'hôte a mis fin à la partie.";
					InterfaceText[68] = "Impossible de rejoindre la partie, car les privilèges sont bloqués pour l'un des profils connectés.";
					InterfaceText[69] = "Vous jouez actuellement à la version d'essai. Veuillez acheter le jeu complet pour pouvoir jouer en ligne.";
					InterfaceText[70] = "Il n'y a pas assez d'espace libre sur le périphérique de stockage sélectionné.";
					InterfaceText[71] = "Jouer sur un écran divisé en mode vidéo définition standard rendra le texte du jeu difficile à lire. Pour une expérience de jeu optimale, la haute définition (HD) est fortement conseillée.";
					InterfaceText[72] = "Bannir un monde";
					InterfaceText[73] = "Voulez-vous vraiment ajouter ce monde à votre liste de mondes bannis?\n\nSi vous sélectionnez OK, vous quitterez cette partie.";
					InterfaceText[74] = "AVERTISSEMENT\u00a0! Le monde auquel vous vous joignez est sur votre liste de mondes bannis.\n\nSi vous décidez de rejoindre cette partie, le monde sera supprimé de votre liste.";
					InterfaceText[75] = "Continuer";
					InterfaceText[76] = "(En attente d'approbation)";
					InterfaceText[77] = "(Censuré)";
					InterfaceText[78] = "La partie enregistrée \"{0}\" a été transféré d'un autre profil et sera supprimée.";
					InterfaceText[79] = "La partie va se terminer en raison des paramètres de contenu des membres de l'un des profils connectés.";
					TipText[0] = "Équipé dans un emplacement Vanité";
					TipText[1] = "Ne procure pas de stats";
					TipText[2] = " de dégâts de mêlée";
					TipText[3] = " de dégâts à distance";
					TipText[4] = " de dégâts magiques";
					TipText[5] = "% de chance de coup critique";
					TipText[6] = "Vitesse insensée";
					TipText[7] = "Vitesse très rapide";
					TipText[8] = "Vitesse rapide";
					TipText[9] = "Vitesse moyenne";
					TipText[10] = "Vitesse lente";
					TipText[11] = "Vitesse très lente";
					TipText[12] = "Vitesse extrêmement lente";
					TipText[13] = "Vitesse d'escargot";
					TipText[14] = "Pas de recul";
					TipText[15] = "Recul extrêmement faible";
					TipText[16] = "Recul très faible";
					TipText[17] = "Recul faible";
					TipText[18] = "Recul moyen";
					TipText[19] = "Fort recul";
					TipText[20] = "Très fort recul";
					TipText[21] = "Recul extrêmement fort";
					TipText[22] = "Recul ahurissant";
					TipText[23] = "Équipable";
					TipText[24] = "Objets de vanité";
					TipText[25] = " de défense";
					TipText[26] = "% de puissance de pioche";
					TipText[27] = "% de puissance de hache";
					TipText[28] = "% de puissance de marteau";
					TipText[29] = "Redonne ";
					TipText[30] = " de vie";
					TipText[31] = " de mana";
					TipText[32] = "Consomme ";
					TipText[33] = "Peut être placé";
					TipText[34] = "Munitions";
					TipText[35] = "Consommable";
					TipText[36] = "Matériau";
					TipText[37] = " Durée minute";
					TipText[38] = " Durée seconde";
					TipText[39] = "% de dégâts";
					TipText[40] = "% de vélocité";
					TipText[41] = "% de chance de coup critique";
					TipText[42] = "% de coût de mana";
					TipText[43] = "% de taille";
					TipText[44] = "% de vitesse de projectile";
					TipText[45] = "% de recul";
					TipText[46] = "% de vitesse de déplacement";
					TipText[47] = "% de vitesse de mêlée";
					TipText[48] = "Bonus de collection : ";
					TipText[49] = "Prix de vente : ";
					TipText[50] = "Prix d'achat : ";
					TipText[51] = "Aucune valeur";
					DeathText[0] = " n'a pas trouvé l'antidote.";
					DeathText[1] = " n'a pas réussi à éteindre l'incendie.";
					DeathText[2] = " a essayé de s'échapper.";
					DeathText[3] = " s'est fait lécher.";
					Buff.BuffName[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Peau d'obsidienne";
					Buff.BuffTip[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Immunise contre la lave";
					Buff.BuffName[(byte)EntityID.BuffID.LIFE_REGEN] = "Régénération";
					Buff.BuffTip[(byte)EntityID.BuffID.LIFE_REGEN] = "Régénère la vie";
					Buff.BuffName[(byte)EntityID.BuffID.HASTE] = "Rapidité";
					Buff.BuffTip[(byte)EntityID.BuffID.HASTE] = "Vitesse de déplacement augmentée de 25\u00a0%";
					Buff.BuffName[(byte)EntityID.BuffID.GILLS] = "Branchies";
					Buff.BuffTip[(byte)EntityID.BuffID.GILLS] = "Permet de respirer sous l'eau comme dans l'air";
					Buff.BuffName[(byte)EntityID.BuffID.IRONSKIN] = "Peau de fer";
					Buff.BuffTip[(byte)EntityID.BuffID.IRONSKIN] = "Augmente la défense de 8";
					Buff.BuffName[(byte)EntityID.BuffID.MANA_REGEN] = "Régénération de mana";
					Buff.BuffTip[(byte)EntityID.BuffID.MANA_REGEN] = "Régénération de mana augmentée";
					Buff.BuffName[(byte)EntityID.BuffID.MAGIC_POWER] = "Pouvoir magique";
					Buff.BuffTip[(byte)EntityID.BuffID.MAGIC_POWER] = "Dégâts magiques augmentés de 20\u00a0%";
					Buff.BuffName[(byte)EntityID.BuffID.SLOWFALL] = "Poids plume";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOWFALL] = "Appuyer sur Bas ou Haut pour contrôler la vitesse de descente";
					Buff.BuffName[(byte)EntityID.BuffID.FIND_TREASURE] = "Spéléologue";
					Buff.BuffTip[(byte)EntityID.BuffID.FIND_TREASURE] = "Indique l'emplacement des trésors et du minerai";
					Buff.BuffName[(byte)EntityID.BuffID.INVISIBLE] = "Invisibilité";
					Buff.BuffTip[(byte)EntityID.BuffID.INVISIBLE] = "Procure l'invisibilité";
					Buff.BuffName[(byte)EntityID.BuffID.SHINE] = "Brillance";
					Buff.BuffTip[(byte)EntityID.BuffID.SHINE] = "Émet une aura de lumière";
					Buff.BuffName[(byte)EntityID.BuffID.NIGHTVISION] = "Vision nocturne";
					Buff.BuffTip[(byte)EntityID.BuffID.NIGHTVISION] = "Améliore la vision de nuit";
					Buff.BuffName[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Bataille";
					Buff.BuffTip[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Augmente la vitesse d'apparition des ennemis";
					Buff.BuffName[(byte)EntityID.BuffID.THORNS] = "Épines";
					Buff.BuffTip[(byte)EntityID.BuffID.THORNS] = "Les attaquants subissent aussi des dégâts";
					Buff.BuffName[(byte)EntityID.BuffID.WATER_WALK] = "Marche sur l'eau";
					Buff.BuffTip[(byte)EntityID.BuffID.WATER_WALK] = "Appuyer sur Bas pour entrer dans l'eau";
					Buff.BuffName[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Tir à l'arc";
					Buff.BuffTip[(byte)EntityID.BuffID.RANGED_DAMAGE] = "La vitesse et les dégâts des flèches augmentent de 20 %";
					Buff.BuffName[(byte)EntityID.BuffID.DETECT_CREATURE] = "Chasseur";
					Buff.BuffTip[(byte)EntityID.BuffID.DETECT_CREATURE] = "Indique l'emplacement des ennemis";
					Buff.BuffName[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Gravitation";
					Buff.BuffTip[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Appuyer sur Haut ou Bas pour inverser la gravité";
					Buff.BuffName[(byte)EntityID.BuffID.LIGHT_ORB] = "Orbe de lumière";
					Buff.BuffTip[(byte)EntityID.BuffID.LIGHT_ORB] = "Un orbe magique qui émet de la lumière";
					Buff.BuffName[(byte)EntityID.BuffID.POISONED] = "Empoisonnement";
					Buff.BuffTip[(byte)EntityID.BuffID.POISONED] = "Perte lente de vie";
					Buff.BuffName[(byte)EntityID.BuffID.POTION_DELAY] = "Maladie des potions";
					Buff.BuffTip[(byte)EntityID.BuffID.POTION_DELAY] = "Ne peut plus consommer de potions de soin";
					Buff.BuffName[(byte)EntityID.BuffID.BLIND] = "Obscurité";
					Buff.BuffTip[(byte)EntityID.BuffID.BLIND] = "Diminue la vision de nuit";
					Buff.BuffName[(byte)EntityID.BuffID.NO_ITEMS] = "Malédiction";
					Buff.BuffTip[(byte)EntityID.BuffID.NO_ITEMS] = "Ne peut utiliser aucun objet";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE] = "En feu !";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE] = "Perte lente de vie";
					Buff.BuffName[(byte)EntityID.BuffID.DRUNK] = "Ivresse";
					Buff.BuffTip[(byte)EntityID.BuffID.DRUNK] = "Aptitudes de mêlée augmentées, défense réduite";
					Buff.BuffName[(byte)EntityID.BuffID.WELL_FED] = "Bien nourri";
					Buff.BuffTip[(byte)EntityID.BuffID.WELL_FED] = "Amélioration mineure de toutes les stats.";
					Buff.BuffName[(byte)EntityID.BuffID.FAIRY] = "Fée";
					Buff.BuffTip[(byte)EntityID.BuffID.FAIRY] = "Une fée vous suit";
					Buff.BuffName[(byte)EntityID.BuffID.WEREWOLF] = "Loup-garou";
					Buff.BuffTip[(byte)EntityID.BuffID.WEREWOLF] = "Les aptitudes physiques sont augmentées";
					Buff.BuffName[(byte)EntityID.BuffID.CLARAVOYANCE] = "Clairvoyance";
					Buff.BuffTip[(byte)EntityID.BuffID.CLARAVOYANCE] = "Les pouvoirs magiques sont augmentés";
					Buff.BuffName[(byte)EntityID.BuffID.BLEED] = "Saignement";
					Buff.BuffTip[(byte)EntityID.BuffID.BLEED] = "Ne peut régénérer la vie";
					Buff.BuffName[(byte)EntityID.BuffID.CONFUSED] = "Confusion";
					Buff.BuffTip[(byte)EntityID.BuffID.CONFUSED] = "Les mouvements sont inversés";
					Buff.BuffName[(byte)EntityID.BuffID.SLOW] = "Ralentissement";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOW] = "La vitesse de déplacement est réduite";
					Buff.BuffName[(byte)EntityID.BuffID.WEAK] = "Faiblesse";
					Buff.BuffTip[(byte)EntityID.BuffID.WEAK] = "Les aptitudes physiques sont diminuées";
					Buff.BuffName[(byte)EntityID.BuffID.MERFOLK] = "Peuple des mers";
					Buff.BuffTip[(byte)EntityID.BuffID.MERFOLK] = "Peut respirer et se déplacer sous l'eau facilement";
					Buff.BuffName[(byte)EntityID.BuffID.SILENCE] = "Silencieux";
					Buff.BuffTip[(byte)EntityID.BuffID.SILENCE] = "Ne peut pas utiliser des éléments qui nécessitent de mana";
					Buff.BuffName[(byte)EntityID.BuffID.BROKEN_ARMOR] = "Armure brisée";
					Buff.BuffTip[(byte)EntityID.BuffID.BROKEN_ARMOR] = "La défense est réduite de moitié";
					Buff.BuffName[(byte)EntityID.BuffID.HORRIFIED] = "Peur panique";
					Buff.BuffTip[(byte)EntityID.BuffID.HORRIFIED] = "Vous avez vu quelque chose de terrible et vous ne pouvez vous échapper.";
					Buff.BuffName[(byte)EntityID.BuffID.TONGUED] = "La langue";
					Buff.BuffTip[(byte)EntityID.BuffID.TONGUED] = "Vous vous êtes fait aspirer dans la bouche";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE_2] = "Brasier maudit";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE_2] = "Perte de vie";
					Buff.BuffName[(byte)EntityID.BuffID.PET] = "Cochon d'Inde de compagnie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET] = "Simplement adorable";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 1] = "Slime de compagnie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 1] = "Un vrai pot de colle";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 2] = "Tiphia de compagnie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 2] = "Veut récupérer tout le miel";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 3] = "Chauve-souris de compagnie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 3] = "Veut du sang";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 4] = "Loup-garou de compagnie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 4] = "Le meilleur ami de l'homme";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 5] = "Zombie de compagnie";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 5] = "Mange de la cervelle";
					Main.TileNames[(int)EntityID.TileID.BOTTLE] = "Bouteille";
					Main.TileNames[(int)EntityID.TileID.TABLE] = "Table";
					Main.TileNames[(int)EntityID.TileID.CHAIR] = "Chaise";
					Main.TileNames[(int)EntityID.TileID.ANVIL] = "Enclume";
					Main.TileNames[(int)EntityID.TileID.FURNACE] = "Fournaise";
					Main.TileNames[(int)EntityID.TileID.WORK_BENCH] = "Établi";
					Main.TileNames[(int)EntityID.TileID.DEMON_ALTAR] = "Autel de démon";
					Main.TileNames[(int)EntityID.TileID.HELLFORGE] = "Forge infernale";
					Main.TileNames[(int)EntityID.TileID.LOOM] = "Métier à tisser";
					Main.TileNames[(int)EntityID.TileID.KEG] = "Tonnelet";
					Main.TileNames[(int)EntityID.TileID.COOKING_POT] = "Marmite";
					Main.TileNames[(int)EntityID.TileID.BOOKCASE] = "Bibliothèque";
					Main.TileNames[(int)EntityID.TileID.SAWMILL] = "Scierie";
					Main.TileNames[(int)EntityID.TileID.TINKERERS_WORKSHOP] = "Atelier du bricoleur";
					Main.TileNames[(int)EntityID.TileID.ADAMANTITE_FORGE] = "Forge en adamantine";
					Main.TileNames[(int)EntityID.TileID.MYTHRIL_ANVIL] = "Enclume en mythril";
				}
				else if (LangOption == (int)ID.SPANISH)
				{
					MiscText[0] = "¡El ejército de duendes ha sido derrotado!";
					MiscText[1] = "¡Un ejército de duendes se aproxima por el oeste!";
					MiscText[2] = "¡Un ejército de duendes se aproxima por el este!";
					MiscText[3] = "¡Un ejército duende ha llegado!";
					MiscText[4] = "¡La Legión de hielo ha sido derrotada!";
					MiscText[5] = "¡La Legión de hielo se aproxima desde el oeste!";
					MiscText[6] = "¡La Legión de hielo se aproxima desde el este!";
					MiscText[7] = "¡La Legión de hielo ha llegado!";
					MiscText[8] = "La luna de sangre está saliendo...";
					MiscText[9] = "Sientes que una presencia maligna te observa...";
					MiscText[10] = "Sientes un horrible escalofrío por la espalda...";
					MiscText[11] = "El eco de los alaridos suena por todas partes...";
					MiscText[12] = "¡Tu mundo ha sido bendecido con cobalto!";
					MiscText[13] = "¡Tu mundo ha sido bendecido con mithril!";
					MiscText[14] = "¡Tu mundo ha sido bendecido con adamantita!";
					MiscText[15] = "Los ancestrales espíritus de la luz y la oscuridad han sido liberados.";
					MiscText[16] = " se despertó.";
					MiscText[17] = " ha caído en combate.";
					MiscText[18] = " llegó.";
					MiscText[19] = " fue asesinado...";
					MiscText[20] = "Los Gemelos";
					MiscText[21] = "Operación no válida en este estado.";
					MiscText[22] = "No tienes la misma versión que este servidor.";
					MiscText[23] = "Jugadores conectados: ";
					MiscText[24] = " ha activado PvP!";
					MiscText[25] = " ha desactivado PvP!";
					MiscText[26] = " ya no pertenece a ningún bando.";
					MiscText[27] = " se ha unido al bando rojo.";
					MiscText[28] = " se ha unido al bando verde.";
					MiscText[29] = " se ha unido al bando azul.";
					MiscText[30] = " se ha unido al bando amarillo.";
					MiscText[31] = "Bienvenido, ";
					MiscText[32] = " se ha unido.";
					MiscText[33] = " se ha marchado.";
					MiscText[34] = "¡Los gemelos se han despertado!";
					MiscText[35] = "¡Los gemelos han sido derrotados!";
					MiscText[36] = "¡Ha caído un meteorito!";
					MenuText[0] = "Ingredientes";
					MenuText[1] = " en el inventario)";
					MenuText[2] = "Desconectar";
					MenuText[3] = "¡Atención!";
					MenuText[4] = "<c>Cuando veas este icono\n\n\nel juego está <i>guardando</i> datos.";
					MenuText[5] = "¡Error!";
					MenuText[6] = "Jugar en línea";
					MenuText[7] = "Solo por invitación";
					MenuText[8] = "Se ha encontrado un servidor...";
					MenuText[9] = "¡Error al cargar!";
					MenuText[10] = "Iniciar juego";
					MenuText[11] = "Crear mundo";
					MenuText[12] = "Se ha encontrado un personaje dañado y se ha eliminado.";
					MenuText[13] = "Jugar";
					MenuText[14] = "Configuración";
					MenuText[15] = "Salir del juego";
					MenuText[16] = "Crear personaje";
					MenuText[17] = XButton + "Eliminar";
					MenuText[18] = "Pelo";
					MenuText[19] = "Ojos";
					MenuText[20] = "Piel";
					MenuText[21] = "Ropa";
					MenuText[22] = "Hombre";
					MenuText[23] = "Mujer";
					MenuText[24] = "Hardcore";
					MenuText[25] = "Dificultad";
					MenuText[26] = "Normal";
					MenuText[27] = "Al azar";
					MenuText[28] = "Crear";
					MenuText[29] = "La muerte es para siempre";
					MenuText[30] = "Suelta todos los objetos al morir";
					MenuText[31] = "Suelta el dinero al morir";
					MenuText[32] = "Seleccionar dificultad";
					MenuText[33] = "Camisa";
					MenuText[34] = "Camiseta";
					MenuText[35] = "Pantalones";
					MenuText[36] = "Zapatos";
					MenuText[37] = "Pelo";
					MenuText[38] = "Color de pelo";
					MenuText[39] = "Color de ojos";
					MenuText[40] = "Color de piel";
					MenuText[41] = "Color de la camisa";
					MenuText[42] = "Color de la camiseta";
					MenuText[43] = "Color de los pantalones";
					MenuText[44] = "Color de los zapatos";
					MenuText[45] = "Escribir nombre del personaje:";
					MenuText[46] = "Eliminar ";
					MenuText[47] = "Créditos";
					MenuText[48] = "Escribir nombre del mundo:";
					MenuText[49] = "¿Quieres salir sin crear un personaje?";
					MenuText[50] = "Elige un personaje";
					MenuText[51] = "Esperando que empiece el juego...";
					MenuText[52] = "Pulsa START";
					MenuText[53] = "Nombre del personaje";
					MenuText[54] = "Guardando personaje...";
					MenuText[55] = "Nombre del mundo";
					MenuText[56] = "Mundo";
					MenuText[57] = "¡Punto de resurreción establecido!";
					MenuText[58] = "Distancia recorrida";
#if VERSION_INITIAL
					MenuText[59] = "Recursos extraídos de la mina y almacenados";
					MenuText[60] = "Objetos creados";
					MenuText[61] = "Objetos usados";
					MenuText[62] = "Enemigos finales normales derrotados";
					MenuText[63] = "Enemigos finales del modo difícil derrotados";
#else
					MenuText[59] = "Recursos extraídos de la mina";
					MenuText[60] = "Objetos creados";
					MenuText[61] = "Objetos usados";
					MenuText[62] = "Enemigos finales normales";
					MenuText[63] = "Enemigos finales del modo difícil";
#endif
					MenuText[64] = "Número de muertes";
					MenuText[65] = "Volumen";
					MenuText[66] = "No se ha seleccionado ningún dispositivo de almacenamiento.";
					MenuText[67] = "Autoguardado activado";
					MenuText[68] = "Autoguardado desactivado";
					MenuText[69] = "No hay dispositivo de almacenamiento";
					MenuText[70] = "Se ha extraído el dispositivo de almacenamiento. Se ha desactivado la función de guardado.";
					MenuText[71] = "Sugerencias activadas";
					MenuText[72] = "Sugerencias desactivadas";
					MenuText[73] = "Obteniendo información del mundo...";
					MenuText[74] = "Obteniendo datos del título...";
					MenuText[75] = "Aceptando invitación...";
					MenuText[76] = "Buscando...";
					MenuText[77] = "No se han encontrado juegos";
					MenuText[78] = "Jugadores: ";
					MenuText[79] = "~ VACÍO ~";
					MenuText[80] = "Uniéndose al juego...";
					MenuText[81] = "PvP";
					MenuText[82] = "Equipo";
					MenuText[83] = "Tus mundos";
					MenuText[84] = "Unirse al juego";
					MenuText[85] = "Profundidad: ";
					MenuText[86] = "m. hacia abajo";
					MenuText[87] = "m. hacia arriba";
					MenuText[88] = "nivel";
					MenuText[89] = "Tutorial";
					MenuText[90] = "Aceptar";
					MenuText[91] = "Elegir tamaño del mundo:";
					MenuText[92] = "Pequeño";
					MenuText[93] = "Mediano";
					MenuText[94] = "Grande";
					MenuText[95] = "Posición: ";
					MenuText[96] = "m este";
					MenuText[97] = "m oeste";
					MenuText[98] = "centro";
					MenuText[99] = "Guardar juego";
					MenuText[100] = "Salir al menú principal";
					MenuText[101] = "Menú principal";
					MenuText[102] = "Los datos de configuración estaban dañados y se han eliminado.";
					MenuText[103] = "Se han encontrado datos de mundo dañados y se han eliminado.";
					MenuText[104] = "Sí";
					MenuText[105] = "No";
					MenuText[106] = "Marcadores";
					MenuText[107] = "Logros";
					MenuText[108] = "Ayuda y opciones";
					MenuText[109] = "Desbloquear juego completo";
					MenuText[110] = "Cómo se juega";
					MenuText[111] = "Controles";
					MenuText[112] = "Reanudar juego";
					WorldGenText[0] = "Generando terreno del mundo...";
					WorldGenText[1] = "Añadiendo arena...";
					WorldGenText[2] = "Generando colinas...";
					WorldGenText[3] = "Amontonando tierra...";
					WorldGenText[4] = "Añadiendo rocas a la tierra...";
					WorldGenText[5] = "Añadiendo tierra a las rocas...";
					WorldGenText[6] = "Añadiendo arcilla...";
					WorldGenText[7] = "Generando agujeros aleatorios...";
					WorldGenText[8] = "Generando cuevas pequeñas...";
					WorldGenText[9] = "Generando cuevas grandes...";
					WorldGenText[10] = "Generando cuevas en la superficie...";
					WorldGenText[11] = "Generando selva...";
					WorldGenText[12] = "Generando islas flotantes...";
					WorldGenText[13] = "Añadiendo parcelas de champiñones...";
					WorldGenText[14] = "Añadiendo lodo a la tierra...";
					WorldGenText[15] = "Añadiendo cieno...";
					WorldGenText[16] = "Añadiendo tesoros...";
					WorldGenText[17] = "Añadiendo telas de araña...";
					WorldGenText[18] = "Creando Inframundo...";
					WorldGenText[19] = "Añadiendo cursos de agua...";
					WorldGenText[20] = "Corrompiendo el mundo...";
					WorldGenText[21] = "Generando cuevas en montañas...";
					WorldGenText[22] = "Creando playas...";
					WorldGenText[23] = "Añadiendo gemas...";
					WorldGenText[24] = "Gravitando arena...";
					WorldGenText[25] = "Limpiando de tierra los entornos...";
					WorldGenText[26] = "Colocando altares...";
					WorldGenText[27] = "Distribuyendo líquidos...";
					WorldGenText[28] = "Colocando cristales de vida...";
					WorldGenText[29] = "Colocando estatuas...";
					WorldGenText[30] = "Ocultando tesoro...";
					WorldGenText[31] = "Ocultando más tesoros...";
					WorldGenText[32] = "Ocultando tesoro en la selva...";
					WorldGenText[33] = "Ocultando tesoro en el agua...";
					WorldGenText[34] = "Colocando trampas...";
					WorldGenText[35] = "Colocando objetos quebradizos...";
					WorldGenText[36] = "Colocando forjas infernales...";
					WorldGenText[37] = "Plantando césped...";
					WorldGenText[38] = "Plantando cactus...";
					WorldGenText[39] = "Plantando girasoles...";
					WorldGenText[40] = "Plantando árboles...";
					WorldGenText[41] = "Plantando hierbas...";
					WorldGenText[42] = "Plantando hierbajos...";
					WorldGenText[43] = "Plantando enredaderas...";
					WorldGenText[44] = "Plantando flores...";
					WorldGenText[45] = "Cultivando champiñones...";
					WorldGenText[46] = "Se ha perdido la conexión con el anfitrión.";
					WorldGenText[47] = "Reiniciando objetos del juego...";
					WorldGenText[48] = "Estableciendo modo Difícil...";
					WorldGenText[49] = "Guardando datos del mundo...";
					WorldGenText[50] = "Copia de seguridad del archivo del mundo...";
					WorldGenText[51] = "Cargando datos del mundo...";
					WorldGenText[52] = "Comprobando alineación de la cuadrícula...";
					WorldGenText[53] = "Se ha producido un error al leer del dispositivo de almacenamiento.";
					WorldGenText[54] = "Se ha producido un error al escribir en el dispositivo de almacenamiento.";
					WorldGenText[55] = "Encontrando bordes de la cuadrícula...";
					WorldGenText[56] = "Adición de nieve ...";
					WorldGenText[57] = "Mundo";
					WorldGenText[58] = "Creando mazmorra...";
					InterfaceText[0] = "Cancelar";
					InterfaceText[1] = "Salir sin guardar";
					InterfaceText[2] = "Guardar y salir";
					InterfaceText[3] = "Papelera";
					InterfaceText[4] = "Inventario";
					InterfaceText[5] = "¿Quieres volver al menú principal?";
					InterfaceText[6] = "Potenciadores";
					InterfaceText[7] = "Vivienda";
					InterfaceText[8] = "Esta casa no cumple los requisitos.";
					InterfaceText[9] = "Accesorios";
					InterfaceText[10] = " Defensa";
					InterfaceText[11] = "Vanidad";
					InterfaceText[12] = "Casco";
					InterfaceText[13] = "Camisa";
					InterfaceText[14] = "Pantalones";
					InterfaceText[15] = " platino ";
					InterfaceText[16] = " oro ";
					InterfaceText[17] = " plata ";
					InterfaceText[18] = " cobre";
					InterfaceText[19] = "Reciclar";
					InterfaceText[20] = "No ha sido posible crear una sesión de red.";
					InterfaceText[21] = "No ha sido posible unirse a la sesión. La sesión está completa o no se puede encontrar.";
					InterfaceText[22] = "Objetos necesarios:";
					InterfaceText[23] = "Ninguno";
					InterfaceText[24] = "Alternar el modo de agarre";
					InterfaceText[25] = "Creación";
					InterfaceText[26] = "Monedas";
					InterfaceText[27] = "Munición";
					InterfaceText[28] = "Tienda";
					InterfaceText[29] = InvSelectAction + "Saquearlo todo";
					InterfaceText[30] = InvSelectAction + "Depositarlo todo";
					InterfaceText[31] = InvSelectAction + "Apilamiento rápido";
					InterfaceText[32] = "Hucha";
					InterfaceText[33] = "Caja fuerte";
					InterfaceText[34] = "Hora: ";
					InterfaceText[35] = "¿Seguro que quieres abandonar?";
					InterfaceText[36] = "Se ha perdido la conexión con Xbox LIVE.";
					InterfaceText[37] = "Número de entradas: ";
					InterfaceText[38] = "Te han matado...";
					InterfaceText[39] = "Esta vivienda es válida.";
					InterfaceText[40] = "Esta vivienda no es válida.";
					InterfaceText[41] = "Esta vivienda ya está ocupada.";
					InterfaceText[42] = "Esta vivienda está corrompida.";
					InterfaceText[43] = "Este perfil de jugador no posee los privilegios necesarios para unirse. Puede que necesites una suscripción LIVE Gold o tengas que cambiar los ajustes parentales.";
					InterfaceText[44] = "Recibiendo datos de casillas";
					InterfaceText[45] = "Equipar";
					InterfaceText[46] = "Coste: ";
					InterfaceText[47] = "Guardar";
					InterfaceText[48] = "Editar";
					InterfaceText[49] = "Estado";
					InterfaceText[50] = "Maldición";
					InterfaceText[51] = "Ayuda";
					InterfaceText[52] = "Cerrar";
					InterfaceText[53] = "Agua";
					InterfaceText[54] = "Sanar";
					InterfaceText[55] = "Proporciona consejos y notas sobre cómo crear objetos.";
					InterfaceText[56] = "Vende objetos básicos.";
					InterfaceText[57] = "Cura las heridas y los suavizadores.";
					InterfaceText[58] = "Vende explosivos.";
					InterfaceText[59] = "Vende objetos naturales y te informa del estado del mundo.";
					InterfaceText[60] = "Vende armas y munición.";
					InterfaceText[61] = "Vende ropa de moda.";
					InterfaceText[62] = "Vende herramientas y cables.";
					InterfaceText[63] = "Vende artilugios útiles y vuelve a forjar objetos.";
					InterfaceText[64] = "Vende objetos y accesorios mágicos.";
					InterfaceText[65] = "Un viejo amigo muy simpático.";
					InterfaceText[66] = "La partida ha terminado";
					InterfaceText[67] = "La partida ha sido finalizada por el anfitrión.";
					InterfaceText[68] = "No es posible unirse debido a los privilegios de uno de los jugadores.";
					InterfaceText[69] = "Actualmente estás jugando a la versión de prueba. Compra la versión completa del juego para jugar en línea.";
					InterfaceText[70] = "No hay espacio suficiente en el dispositivo de almacenamiento seleccionado.";
					InterfaceText[71] = "Jugar en el modo pantalla dividida con el ajuste de vídeo de definición estándar provocará que el texto de la pantalla de juego sea difícil de leer. Recomendamos usar el ajuste de alta definición para disfrutar al máximo de la experiencia de juego.";
					InterfaceText[72] = "Prohibir Mundo";
					InterfaceText[73] = "¿Seguro que quieres añadir este mundo a tu lista de Mundos Prohibidos?\n\nSi seleccionas Aceptar también saldrás de esta partida.";
					InterfaceText[74] = "¡ATENCIÓN! El mundo al que te intentas unir está en tu lista de Mundos Prohibidos.\n\nSi decides unirte a esta partida este mundo será eliminado de tu lista de Mundos Prohibidos.";
					InterfaceText[75] = "Continuar";
					InterfaceText[76] = "(En espera de aprobación)";
					InterfaceText[77] = "(Censurado)";
					InterfaceText[78] = "La partida guardada \"{0}\" fue trasladada desde otro perfil y será eliminado.";
					InterfaceText[79] = "El juego finalizará debido a los ajustes de contenido creado por los miembros de uno de los perfiles que ha iniciado sesión.";
					TipText[0] = "Equipado en la ranura de vanidad";
					TipText[1] = "No aumentará ninguna estadística";
					TipText[2] = " daño en el cuerpo a cuerpo";
					TipText[3] = " daño a distancia";
					TipText[4] = " daño por magia";
					TipText[5] = "% probabilidad de ataque crítico";
					TipText[6] = "Velocidad de vértigo";
					TipText[7] = "Gran velocidad";
					TipText[8] = "Veloz";
					TipText[9] = "Velocidad normal";
					TipText[10] = "Lento";
					TipText[11] = "Muy lento";
					TipText[12] = "Exageradamente lento";
					TipText[13] = "Velocidad de tortuga";
					TipText[14] = "Sin retroceso";
					TipText[15] = "Retroceso sumamente débil";
					TipText[16] = "Retroceso muy débil";
					TipText[17] = "Retroceso débil";
					TipText[18] = "Retroceso normal";
					TipText[19] = "Retroceso fuerte";
					TipText[20] = "Retroceso muy fuerte";
					TipText[21] = "Retroceso tremendamente fuerte";
					TipText[22] = "Retroceso descomunal";
					TipText[23] = "Equipable";
					TipText[24] = "Objeto decorativo";
					TipText[25] = " defensa";
					TipText[26] = "% potencia de pico";
					TipText[27] = "% potencia de hacha";
					TipText[28] = "% potencia de martillo";
					TipText[29] = "Restablece ";
					TipText[30] = " vida";
					TipText[31] = " maná";
					TipText[32] = "Consume ";
					TipText[33] = "Se puede colocar";
					TipText[34] = "Munición";
					TipText[35] = "Consumible";
					TipText[36] = "Material";
					TipText[37] = " minuto/s de duración";
					TipText[38] = " segundo/s de duración";
					TipText[39] = "% daño";
					TipText[40] = "% velocidad";
					TipText[41] = "% probabilidad de ataque crítico";
					TipText[42] = "% coste de maná";
					TipText[43] = "% tamaño";
					TipText[44] = "% velocidad de proyectil";
					TipText[45] = "% retroceso";
					TipText[46] = "% velocidad de movimiento";
					TipText[47] = "% velocidad en el cuerpo a cuerpo";
					TipText[48] = "Bonus conjunto: ";
					TipText[49] = "Precio de venta: ";
					TipText[50] = "Precio de compra: ";
					TipText[51] = "Sin valor";
					DeathText[0] = " no logró encontrar el antídoto.";
					DeathText[1] = " no pudo extinguir el fuego.";
					DeathText[2] = " intentó escapar.";
					DeathText[3] = " recibió una paliza.";
					Buff.BuffName[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Piel obsidiana";
					Buff.BuffTip[(byte)EntityID.BuffID.LAVA_IMMUNE] = "Inmune a la lava";
					Buff.BuffName[(byte)EntityID.BuffID.LIFE_REGEN] = "Regeneración";
					Buff.BuffTip[(byte)EntityID.BuffID.LIFE_REGEN] = "Regenera la vida";
					Buff.BuffName[(byte)EntityID.BuffID.HASTE] = "Rapidez";
					Buff.BuffTip[(byte)EntityID.BuffID.HASTE] = "Aumenta en un 25% la velocidad de movimiento";
					Buff.BuffName[(byte)EntityID.BuffID.GILLS] = "Agallas";
					Buff.BuffTip[(byte)EntityID.BuffID.GILLS] = "Permite respirar agua en lugar de aire";
					Buff.BuffName[(byte)EntityID.BuffID.IRONSKIN] = "Piel de hierro";
					Buff.BuffTip[(byte)EntityID.BuffID.IRONSKIN] = "Aumenta la defensa en 8";
					Buff.BuffName[(byte)EntityID.BuffID.MANA_REGEN] = "Regeneración de maná";
					Buff.BuffTip[(byte)EntityID.BuffID.MANA_REGEN] = "Aumenta la regeneración de maná";
					Buff.BuffName[(byte)EntityID.BuffID.MAGIC_POWER] = "Poder mágico";
					Buff.BuffTip[(byte)EntityID.BuffID.MAGIC_POWER] = "Aumenta el daño mágico en un 20%";
					Buff.BuffName[(byte)EntityID.BuffID.SLOWFALL] = "Caída de pluma";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOWFALL] = "Pulsa ARRIBA o ABAJO para controlar la velocidad de descenso";
					Buff.BuffName[(byte)EntityID.BuffID.FIND_TREASURE] = "Espeleólogo";
					Buff.BuffTip[(byte)EntityID.BuffID.FIND_TREASURE] = "Muestra la ubicación de tesoros y minerales";
					Buff.BuffName[(byte)EntityID.BuffID.INVISIBLE] = "Invisibilidad";
					Buff.BuffTip[(byte)EntityID.BuffID.INVISIBLE] = "Proporciona invisibilidad";
					Buff.BuffName[(byte)EntityID.BuffID.SHINE] = "Brillo";
					Buff.BuffTip[(byte)EntityID.BuffID.SHINE] = "Emite luz";
					Buff.BuffName[(byte)EntityID.BuffID.NIGHTVISION] = "Noctámbulo";
					Buff.BuffTip[(byte)EntityID.BuffID.NIGHTVISION] = "Mejora la visión nocturna";
					Buff.BuffName[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Batalla";
					Buff.BuffTip[(byte)EntityID.BuffID.ENEMY_SPAWNS] = "Aumenta la velocidad de regeneración del enemigo";
					Buff.BuffName[(byte)EntityID.BuffID.THORNS] = "Espinas";
					Buff.BuffTip[(byte)EntityID.BuffID.THORNS] = "Los atacantes también sufren daños";
					Buff.BuffName[(byte)EntityID.BuffID.WATER_WALK] = "Flotación";
					Buff.BuffTip[(byte)EntityID.BuffID.WATER_WALK] = "Pulsa ABAJO para sumergirte";
					Buff.BuffName[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Tiro con arco";
					Buff.BuffTip[(byte)EntityID.BuffID.RANGED_DAMAGE] = "Aumenta en un 20% la velocidad y el daño de las flechas";
					Buff.BuffName[(byte)EntityID.BuffID.DETECT_CREATURE] = "Cazador";
					Buff.BuffTip[(byte)EntityID.BuffID.DETECT_CREATURE] = "Muestra la ubicación de los enemigos";
					Buff.BuffName[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Gravedad";
					Buff.BuffTip[(byte)EntityID.BuffID.GRAVITY_CONTROL] = "Pulsa ARRIBA o ABAJO para invertir la gravedad";
					Buff.BuffName[(byte)EntityID.BuffID.LIGHT_ORB] = "Orbe de luz";
					Buff.BuffTip[(byte)EntityID.BuffID.LIGHT_ORB] = "Orbe mágico que proporciona luz";
					Buff.BuffName[(byte)EntityID.BuffID.POISONED] = "Veneno";
					Buff.BuffTip[(byte)EntityID.BuffID.POISONED] = "Reduce el nivel de vida lentamente";
					Buff.BuffName[(byte)EntityID.BuffID.POTION_DELAY] = "Enfermedad de poción";
					Buff.BuffTip[(byte)EntityID.BuffID.POTION_DELAY] = "Impide seguir consumiendo remedios curativos";
					Buff.BuffName[(byte)EntityID.BuffID.BLIND] = "Oscuridad";
					Buff.BuffTip[(byte)EntityID.BuffID.BLIND] = "Disminuye la claridad";
					Buff.BuffName[(byte)EntityID.BuffID.NO_ITEMS] = "Maldición";
					Buff.BuffTip[(byte)EntityID.BuffID.NO_ITEMS] = "No se puede usar ningún objeto";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE] = "Llamas";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE] = "Reduce el nivel de vida lentamente";
					Buff.BuffName[(byte)EntityID.BuffID.DRUNK] = "Beodo";
					Buff.BuffTip[(byte)EntityID.BuffID.DRUNK] = "Mejora el ataque cuerpo a cuerpo pero reduce la defensa";
					Buff.BuffName[(byte)EntityID.BuffID.WELL_FED] = "Bien alimentado";
					Buff.BuffTip[(byte)EntityID.BuffID.WELL_FED] = "Pequeñas mejoras a todas las estadísticas";
					Buff.BuffName[(byte)EntityID.BuffID.FAIRY] = "Hada";
					Buff.BuffTip[(byte)EntityID.BuffID.FAIRY] = "Un hada te acompaña";
					Buff.BuffName[(byte)EntityID.BuffID.WEREWOLF] = "Hombre lobo";
					Buff.BuffTip[(byte)EntityID.BuffID.WEREWOLF] = "Aumenta la capacidad física";
					Buff.BuffName[(byte)EntityID.BuffID.CLARAVOYANCE] = "Clarividencia";
					Buff.BuffTip[(byte)EntityID.BuffID.CLARAVOYANCE] = "Aumenta los poderes mágicos";
					Buff.BuffName[(byte)EntityID.BuffID.BLEED] = "Hemorragia";
					Buff.BuffTip[(byte)EntityID.BuffID.BLEED] = "No se puede recuperar vida";
					Buff.BuffName[(byte)EntityID.BuffID.CONFUSED] = "Confusión";
					Buff.BuffTip[(byte)EntityID.BuffID.CONFUSED] = "Invierte los movimientos";
					Buff.BuffName[(byte)EntityID.BuffID.SLOW] = "Lentitud";
					Buff.BuffTip[(byte)EntityID.BuffID.SLOW] = "Disminuye la velocidad de movimiento";
					Buff.BuffName[(byte)EntityID.BuffID.WEAK] = "Debilidad";
					Buff.BuffTip[(byte)EntityID.BuffID.WEAK] = "Disminuye la capacidad física";
					Buff.BuffName[(byte)EntityID.BuffID.MERFOLK] = "Tritón";
					Buff.BuffTip[(byte)EntityID.BuffID.MERFOLK] = "Respira y se mueve bajo el agua con facilidad";
					Buff.BuffName[(byte)EntityID.BuffID.SILENCE] = "Silencio";
					Buff.BuffTip[(byte)EntityID.BuffID.SILENCE] = "No puede utilizar los artículos que requieren maná";
					Buff.BuffName[(byte)EntityID.BuffID.BROKEN_ARMOR] = "Armadura rota";
					Buff.BuffTip[(byte)EntityID.BuffID.BROKEN_ARMOR] = "La defensa disminuye hasta la mitad";
					Buff.BuffName[(byte)EntityID.BuffID.HORRIFIED] = "Terror";
					Buff.BuffTip[(byte)EntityID.BuffID.HORRIFIED] = "Has visto algo horrible... ¡No hay escapatoria!";
					Buff.BuffName[(byte)EntityID.BuffID.TONGUED] = "La Lengua";
					Buff.BuffTip[(byte)EntityID.BuffID.TONGUED] = "Te succiona hacia la Boca";
					Buff.BuffName[(byte)EntityID.BuffID.ON_FIRE_2] = "El Averno";
					Buff.BuffTip[(byte)EntityID.BuffID.ON_FIRE_2] = "Reduce el nivel de vida progresivamente";
					Buff.BuffName[(byte)EntityID.BuffID.PET] = "Conejilla de Indias mascota";
					Buff.BuffTip[(byte)EntityID.BuffID.PET] = "Simplementa entrañable";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 1] = "Slime mascota";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 1] = "Una verdadera pelotita slime";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 2] = "Avispa mascota";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 2] = "Quiere toda la miel";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 3] = "Murciélago mascota";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 3] = "En busca de sangre";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 4] = "Hombre lobo mascota";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 4] = "El mejor amigo del hombre";
					Buff.BuffName[(byte)EntityID.BuffID.PET + 5] = "Zombi mascota";
					Buff.BuffTip[(byte)EntityID.BuffID.PET + 5] = "Come cerebros";
					Main.TileNames[(int)EntityID.TileID.BOTTLE] = "Botella";
					Main.TileNames[(int)EntityID.TileID.TABLE] = "Mesa";
					Main.TileNames[(int)EntityID.TileID.CHAIR] = "Silla";
					Main.TileNames[(int)EntityID.TileID.ANVIL] = "Yunque";
					Main.TileNames[(int)EntityID.TileID.FURNACE] = "Forja";
					Main.TileNames[(int)EntityID.TileID.WORK_BENCH] = "Banco de trabajo";
					Main.TileNames[(int)EntityID.TileID.DEMON_ALTAR] = "Altar demoníaco";
					Main.TileNames[(int)EntityID.TileID.HELLFORGE] = "Forja infernal";
					Main.TileNames[(int)EntityID.TileID.LOOM] = "Telar";
					Main.TileNames[(int)EntityID.TileID.KEG] = "Barrica";
					Main.TileNames[(int)EntityID.TileID.COOKING_POT] = "Perol";
					Main.TileNames[(int)EntityID.TileID.BOOKCASE] = "Librería";
					Main.TileNames[(int)EntityID.TileID.SAWMILL] = "Serrería";
					Main.TileNames[(int)EntityID.TileID.TINKERERS_WORKSHOP] = "Taller de chapuzas";
					Main.TileNames[(int)EntityID.TileID.ADAMANTITE_FORGE] = "Forja de adamantita";
					Main.TileNames[(int)EntityID.TileID.MYTHRIL_ANVIL] = "Yunque de mithril";
				}
			}
		}

		public static uint DeathMsgPtr(int PlayerID = -1, int NpcID = 0, int ProjID = 0, int OtherID = -1)
		{
			return ((uint)PlayerID & 0xFF) | (uint)((NpcID & 0x3FF) << 8) | (uint)((ProjID & 0xFF) << 18) | (uint)((OtherID & 0x3F) << 26);
		}

		public static string DeathMsgString(uint Pointer)
		{
			uint MethodID = (Pointer >> 26) & 0x3Fu;
			if (MethodID >= 3 && MethodID < 63)
			{
				return DeathText[MethodID - 3];
			}
			uint PlayerID = Pointer & 0xFFu;
			int NpcID = (int)(Pointer << 14) >> 22;
			uint ProjID = (Pointer >> 18) & 0xFFu;
			string Result = null;
			if (LangOption <= (int)ID.ENGLISH)
			{
				string Message;
				switch (Main.Rand.Next(26))
				{
					case 0:
						Message = " was slain";
						break;
					case 1:
						Message = " was eviscerated";
						break;
					case 2:
						Message = " was murdered";
						break;
					case 3:
						Message = "'s face was torn off";
						break;
					case 4:
						Message = "'s entrails were ripped out";
						break;
					case 5:
						Message = " was destroyed";
						break;
					case 6:
						Message = "'s skull was crushed";
						break;
					case 7:
						Message = " got massacred";
						break;
					case 8:
						Message = " got impaled";
						break;
					case 9:
						Message = " was torn in half";
						break;
					case 10:
						Message = " was decapitated";
						break;
					case 11:
						Message = " let their arms get torn off";
						break;
					case 12:
						Message = " watched their innards become outards";
						break;
					case 13:
						Message = " was brutally dissected";
						break;
					case 14:
						Message = "'s extremities were detached";
						break;
					case 15:
						Message = "'s body was mangled";
						break;
					case 16:
						Message = "'s vital organs were ruptured";
						break;
					case 17:
						Message = " was turned into a pile of flesh";
						break;
					case 18:
						Message = " was removed from " + Main.WorldName;
						break;
					case 19:
						Message = " got snapped in half";
						break;
					case 20:
						Message = " was cut down the middle";
						break;
					case 21:
						Message = " was chopped up";
						break;
					case 22:
						Message = "'s plead for death was answered";
						break;
					case 23:
						Message = "'s meat was ripped off the bone";
						break;
					case 24:
						Message = "'s flailing about was finally stopped";
						break;
					default:
						Message = "'s head was removed";
						break;
				}
				if (PlayerID < 8)
				{
#if VERSION_INITIAL
					Result = ((ProjID == 0) ? (Message + " by " + Main.PlayerSet[PlayerID].Name + "'s " + ItemName(Main.PlayerSet[PlayerID].Inventory[Main.PlayerSet[PlayerID].SelectedItem].NetID) + ".") : (Message + " by " + Main.PlayerSet[PlayerID].Name + "'s " + ProjectileNames[ProjID] + "."));
#else
					Result = ((ProjID == 0) ? (Message + " by " + Main.PlayerSet[PlayerID].CharacterName + "'s " + ItemName(Main.PlayerSet[PlayerID].Inventory[Main.PlayerSet[PlayerID].SelectedItem].NetID) + ".") : (Message + " by " + Main.PlayerSet[PlayerID].CharacterName + "'s " + ProjectileNames[ProjID] + "."));
#endif
				}
				else if (NpcID != 0)
				{
					Result = Message + " by " + NpcName(NpcID) + ".";
				}
				else if (ProjID != 0)
				{
					Result = Message + " by " + ProjectileNames[ProjID] + ".";
				}
				else
				{
					switch (MethodID)
					{
						case 0u:
							Result = ((Main.Rand.Next(2) != 0) ? " didn't bounce." : " fell to their death.");
							break;
						case 1u:
							switch (Main.Rand.Next(4))
							{
								case 0:
									Result = " forgot to breathe.";
									break;
								case 1:
									Result = " is sleeping with the fish.";
									break;
								case 2:
									Result = " drowned.";
									break;
								case 3:
									Result = " is shark food.";
									break;
							}
							break;
						case 2u:
							switch (Main.Rand.Next(4))
							{
								case 0:
									Result = " got melted.";
									break;
								case 1:
									Result = " was incinerated.";
									break;
								case 2:
									Result = " tried to swim in lava.";
									break;
								case 3:
									Result = " likes to play in magma.";
									break;
							}
							break;
						default:
							Result = Message + ".";
							break;
					}
				}
			}
			else if (LangOption == (int)ID.GERMAN)
			{
				string Message;
				switch (Main.Rand.Next(15))
				{
					case 0:
						Message = " wurde getötet von";
						break;
					case 1:
						Message = " wurde vernichtet";
						break;
					case 2:
						Message = " wurde ermordet";
						break;
					case 3:
						Message = " wurde das Gesicht heruntergerissen";
						break;
					case 4:
						Message = " wurden die Eingeweide herausgerissen";
						break;
					case 5:
						Message = " wurde zerstört";
						break;
					case 6:
						Message = " wurde der Schädel eingeschlagen";
						break;
					case 7:
						Message = " wurde massakriert";
						break;
					case 8:
						Message = " wurde gepfählt";
						break;
					case 9:
						Message = " wurde in zwei Hälften gerissen";
						break;
					case 10:
						Message = " wurde geköpft";
						break;
					case 11:
						Message = "wurden die Arme ausgerissen";
						break;
					case 12:
						Message = " sah dabei zu, wie die eigenen Eingeweide herausquollen";
						break;
					case 13:
						Message = " wurde brutal seziert";
						break;
					default:
						Message = " liess sich den Kopf wegreissen";
						break;
				}
				switch (MethodID)
				{
					case 0u:
						Result = ((Main.Rand.Next(2) != 0) ? " ist nicht gesprungen." : " stürzte in den Tod.");
						break;
					case 1u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " hat vergessen zu atmen.";
								break;
							case 1:
								Result = " hat jetzt ein feuchtes Grab bei den Fischen.";
								break;
							case 2:
								Result = " ist ertrunken.";
								break;
							case 3:
								Result = " ist jetzt Fischfutter.";
								break;
						}
						break;
					case 2u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " ist geschmolzen.";
								break;
							case 1:
								Result = " wurde eingeäschert.";
								break;
							case 2:
								Result = " versuchte, in Lava zu baden.";
								break;
							case 3:
								Result = " spielt gern mit Magma.";
								break;
						}
						break;
					default:
						Result = Message + ".";
						break;
				}
			}
			else if (LangOption == (int)ID.ITALIAN)
			{
				string Message;
				switch (Main.Rand.Next(13))
				{
					case 0:
						Message = " è stato ucciso";
						break;
					case 1:
						Message = " è stato sventrato";
						break;
					case 2:
						Message = " è stato assassinato";
						break;
					case 3:
						Message = " è stato distrutto";
						break;
					case 4:
						Message = " è stato massacrato";
						break;
					case 5:
						Message = " è stato distrutto";
						break;
					case 6:
						Message = " il cranio è stato spappolato";
						break;
					case 7:
						Message = " è stato massacrato";
						break;
					case 8:
						Message = " ha visto uscire le sue interiora ";
						break;
					case 9:
						Message = " è stato spezzato a metà";
						break;
					case 10:
						Message = " è stato decapitato";
						break;
					case 11:
						Message = " le braccia sono state spezzate";
						break;
					default:
						Message = " è stato tagliato a metà";
						break;
				}
				switch (MethodID)
				{
					case 0u:
						Result = ((Main.Rand.Next(2) != 0) ? " non poteva rimbalzare." : " sente la sua morte.");
						break;
					case 1u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " ha dimenticato di respirare.";
								break;
							case 1:
								Result = " sta dormendo con i pesci.";
								break;
							case 2:
								Result = " è affogato.";
								break;
							case 3:
								Result = " è un pasto dello squalo.";
								break;
						}
						break;
					case 2u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " si è sciolto.";
								break;
							case 1:
								Result = " si è incenerito.";
								break;
							case 2:
								Result = " ha provato a nuotare nella lava.";
								break;
							case 3:
								Result = " piace giocare nel magma.";
								break;
						}
						break;
					default:
						Result = Message + ".";
						break;
				}
			}
			else if (LangOption == (int)ID.FRENCH)
			{
				string Message;
				switch (Main.Rand.Next(14))
				{
					case 0:
						Message = " s'est fait massacrer";
						break;
					case 1:
						Message = " s'est fait éviscérer";
						break;
					case 2:
						Message = " s'est fait assassiner";
						break;
					case 3:
						Message = " s'est fait défigurer";
						break;
					case 4:
						Message = " a vu ses entrailles tomber à ses pieds";
						break;
					case 5:
						Message = " s'est fait détruire";
						break;
					case 6:
						Message = " s'est fait arracher la tête";
						break;
					case 7:
						Message = " s'est fait tuer";
						break;
					case 8:
						Message = " s'est fait empaler";
						break;
					case 9:
						Message = " s'est fait brutalement découper";
						break;
					case 10:
						Message = " a été décapité";
						break;
					case 11:
						Message = " s'est fait déchiqueter les bras";
						break;
					case 12:
						Message = " s'est fait couper en tranches";
						break;
					default:
						Message = " a perdu la tête";
						break;
				}
				switch (MethodID)
				{
					case 0u:
						Result = ((Main.Rand.Next(2) != 0) ? " ne bouge plus." : " a cassé sa pipe.");
						break;
					case 1u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " a cessé de respirer.";
								break;
							case 1:
								Result = " mange les pissenlits par la racine.";
								break;
							case 2:
								Result = " a coulé à pic.";
								break;
							case 3:
								Result = " nourrit les requins.";
								break;
						}
						break;
					case 2u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " a fondu.";
								break;
							case 1:
								Result = " s'est fait incinérer.";
								break;
							case 2:
								Result = " a tenté de nager dans la lave.";
								break;
							case 3:
								Result = " aime barboter dans le magma.";
								break;
						}
						break;
					default:
						Result = Message + ".";
						break;
				}
			}
			else if (LangOption == (int)ID.SPANISH)
			{
				string Message = " fue asesinado";
				switch (MethodID)
				{
					case 0u:
						Result = ((Main.Rand.Next(2) != 0) ? " no saltó a tiempo." : " ha caído al vacío.");
						break;
					case 1u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " se olvidó de respirar.";
								break;
							case 1:
								Result = " duerme con los peces.";
								break;
							case 2:
								Result = " se ha ahogado.";
								break;
							case 3:
								Result = " es pasto de los tiburones.";
								break;
						}
						break;
					case 2u:
						switch (Main.Rand.Next(4))
						{
							case 0:
								Result = " se ha calcinado.";
								break;
							case 1:
								Result = " se ha chamuscado.";
								break;
							case 2:
								Result = " ha intentado nadar en lava.";
								break;
							case 3:
								Result = " le gusta jugar con el magma.";
								break;
						}
						break;
					default:
						Result = Message + ".";
						break;
				}
			}
			return Result;
		}

		public static string SetSystemLang()
		{
			LanguageId = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
			int LangSetting;
			switch (LanguageId)
			{
				case "de":
					LangSetting = (int)ID.GERMAN;
					break;

				case "fr":
					LangSetting = (int)ID.FRENCH;
					break;

				case "es":
					LangSetting = (int)ID.SPANISH;
					break;

				case "it":
					LangSetting = (int)ID.ITALIAN;
					break;

				default:
					LangSetting = (int)ID.ENGLISH;
					break;
			}
			;

			SetLang(LangSetting);
#if USE_ORIGINAL_CODE
			if (GuideExtensions.ConsoleRegion == ConsoleRegion.NorthAmerica)
			{
				return "ESRB";
			}
			return null;
#else
			string Region = RegionInfo.CurrentRegion.Name; // As you can see in the original segment, only the ESRB check was decompiled, and even in the files I have for the other updates, the only rating image is for the ESRB.

			switch (Region) // For the base version however, files exist for both PEGI and USK, but a check is not there. This makes me wonder if there were different versions of the game for those regions.
			{
				case "US":
				case "CA":
				case "MX":
					return "ESRB";

				case "AT":
				case "BE":
				case "BG":
				case "CY":
				case "CZ":
				case "DK":
				case "EE":
				case "ES":
				case "FI":
				case "FR":
				case "GR":
				case "IS":
				case "IE":
				case "IL":
				case "IT":
				case "LV":
				case "LT":
				case "LU":
				case "NL":
				case "NO":
				case "PL":
				case "PT":
				case "RO":
				case "SI":
				case "SE":
				case "UK":
					return "PEGI";

				case "DE":
					return "USK";

				case "AU": // Little addition by yours truly.
					return "ACB";

				default:
					return null;
			}
			;
#endif
		}

		public static string TutorialLocale(Tutorial Stage)
		{
			switch (LangOption)
			{
				case (int)ID.GERMAN:
					return TutorialDE[(int)Stage];
				case (int)ID.FRENCH:
					return TutorialFR[(int)Stage];
				case (int)ID.ITALIAN:
					return TutorialIT[(int)Stage];
				case (int)ID.SPANISH:
					return TutorialES[(int)Stage];
				default:
					return TutorialEN[(int)Stage];
			}
		}
	}
}
