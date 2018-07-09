using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestItem : Interactable {
	
	private enum QuestItems{Breaker,Ordi,Lumiere,Safe};

	[SerializeField]
	private QuestItems _quiJeSuis;

	[SerializeField]
	private List<Sprite> _StateSprite;

	[SerializeField]
	private List<QuestItem> _lesObjets;
	private bool _isSelected = false;

	private GameObject _instanceMenu;

	private SpriteRenderer _monAffichage;
	///ETAT DE LOBJET COMMENCE A 0 ET FINI A DIFFERENT CHIFFRE CHANGE A CHAQUE MODIFIQUATION DE LOBJET;
	public int _state=0;
	private Object _blinker;
	private const string c0Inspect ="Hey, let’s not waste any more time on that, I just wanna get out of here.";
	private const string c1Inspect ="I don’t think we can use it anymore…";
	private const string c2Inspect ="Seems like we did everything we could with this.";
	private const string c3Inspect ="Let’s not waddledy waddle here. What? What do you mean it’s not a real word?";
	private const string c0Interact ="Darling, snap out of it. We can’t use it, let’s just go back to the other stuff.";
	private const string c1Interact ="I’m sorry… I don’t see how this can useful…";
	private const string c2Interact ="I said it isn’t useful. Knock it off, punk.";
	private const string c3Interact ="Oh mate, I can’t do anything with this beside use it as an air guitar.";
	private const string _cant = "I can't reach this room.";

	protected List<AudioSource> _monSon;
	private void Start()
	{
		_monAffichage=GetComponent<SpriteRenderer>();
		_monSon=new List<AudioSource>();
		GetComponents<AudioSource>(_monSon);
	}
	private void Update()
	{
		if(_isOvered){
			if(Input.GetMouseButtonDown(0)){
				Interact();
			}
			if(Input.GetMouseButtonDown(1)){
				Inspect();
			}
		}

	}

	private void Interact(){
		string parole="";
		switch(_quiJeSuis){
			case QuestItems.Breaker:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="It’s stuck I said. I can’t open that.";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole="Sorry, electricity scares me…";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole="Hum… *grunt* and there. It’s opened.";
								_state+=1;
								_monAffichage.sprite=_StateSprite[_state];
								_monSon[0].Play();
								break;
							case PersoManager.Char.Chips: 
								parole="Aaaand I can’t open it! Go figures!";
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					case 1 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="And what exactly do you want me to do? Electrocute myself to death?";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole="I SAID NO!.. Ahem, sorry… please, let’s just try something else…";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=": I’m a goon, not an electrician.";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole="I’ll just shut down some of that sweet sweet juice! And here, it’s diddly done!";
								_monSon[0].Play();
								_state+=1;
								_lesObjets[1]._state+=1;
								_lesObjets[1].GetComponent<SpriteRenderer>().sprite=_lesObjets[1]._StateSprite[_lesObjets[1]._state];
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					default:
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								_monSon[1].Play();
								parole=c3Interact;
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
				}
				break;
			case QuestItems.Safe:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Darling, I can’t just open it like that, I’m not a magician";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole="Hum… I’m sorry, I don’t think I can do anything.";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole="I may be strong, but I can’t just open that up";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole="Sorry! No explosives, no help from Chips, mate.";
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					case 1 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Give me a moment, darling… here, all done!";
								_monSon[0].Play();
								_state+=1;
								_monAffichage.sprite=_StateSprite[_state-1];
								break;
							case PersoManager.Char.Amelia: 
								parole="Hum… I’m sorry, I don’t think I can do anything.";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole="I may be strong, but I can’t just open that up.";
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole="Sorry! No explosives, no help from Chips, mate.";
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					case 2 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole="I could just… oh wait, I broke it. My bad. Wait, is there something inside?";
								_monSon[0].Play();
								_state+=1;
								_monAffichage.sprite=_StateSprite[_state-1];						
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;

					case 3 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole="It’s a french number! “Quatre-mille-quatre-vingt-quinze”. Where could we input this though?";
								_monSon[0].Play();
								_lesObjets[2]._state+=1;
								_state+=1;
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					default :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
				}
				break;
			case QuestItems.Lumiere:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					case 1:
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole="Let me unscrew that bad boy… hey, I can rewire that! Let’s check if that did anything!";
								_lesObjets[2]._state+=1;
								_lesObjets[2].GetComponent<SpriteRenderer>().sprite=_lesObjets[2]._StateSprite[_lesObjets[2]._state];
								_monSon[0].Play();
								_state+=1;
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					default:
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
				}
				break;
			case QuestItems.Ordi:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					case 1 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								_monSon[1].Play();
								parole="Darling. I’m not gonna mash buttons at random.";
								break;
							case PersoManager.Char.Amelia: 
								parole="I’ll just try the dispense option for now… oh, a little drawer just opened! It contains… bobby pins..?";
								_monSon[0].Play();
								_state+=1;
								break;
							case PersoManager.Char.Bernard:
								_monSon[1].Play(); 
								parole="I can kill a man in more ways than you can imagine, but operating a french computer isn’t";
								break;
							case PersoManager.Char.Chips: 
								_monSon[1].Play();
								parole="Oh yeah, let me just engage my universal translator implant! You douchenoggin.";
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					case 2 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="I’ll just hold onto these, Sugar.";
								_monSon[0].Play();
								_state+=1;
								_lesObjets[3]._state+=1;
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;

					case 3 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;

					case 4:
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole="And… done! It now says… follow final directive? What final directive?";
								_monSon[0].Play();
								_state+=1;
								GameManager.instance.Ending();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
					default :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Interact;
								_monSon[1].Play();
								break;
							case PersoManager.Char.Chips: 
								parole=c3Interact;
								_monSon[1].Play();
								break;
							default:
								parole=_cant;
								_monSon[1].Play();
								break;
						}
						break;
				}
				break;
			default: Debug.Log("Error");break;
		}
		Parler.Parleureur.Parle(PersoManager.getCurrentChar,parole);
	}
	private void Inspect(){
		_monSon[2].Play();
		string parole="";
		switch(_quiJeSuis){
			case QuestItems.Breaker:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="This is used to redirect electricity, no? Uh? It’s… stuck. I can’t open that.";
								break;
							case PersoManager.Char.Amelia: 
								parole="Dad never let me near those things… they’re dangerous… ";
								break;
							case PersoManager.Char.Bernard: 
								parole="A breaker box.  Hum… it’s stuck hard";
								break;
							case PersoManager.Char.Chips: 
								parole="Look at this! I’m sure there’s some juicy wires to play with behind that door.";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					case 1 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="It’s a big jumbling mess. I’m definitely not touching that!";
								break;
							case PersoManager.Char.Amelia: 
								parole="I remember the wires… I don’t want to touch these, please…";
								break;
							case PersoManager.Char.Bernard: 
								parole="It’s opened now, but I can’t make any sense of the wiring.";
								break;
							case PersoManager.Char.Chips: 
								parole="WOW! This is lizardfolk-grade quality wiring! Damn bastards are good at science stuff!";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					default :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Inspect;
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Inspect;
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Inspect;
								break;
							case PersoManager.Char.Chips: 
								parole=c3Inspect;
								break;
							default:
								parole=_cant;
								break;
						}
						break;
				}
				break;
			case QuestItems.Safe:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Hum… I could open that for you, with the rights tools. ";
								break;
							case PersoManager.Char.Amelia: 
								parole="It’s a safe! Oh… it’s locked…";
								break;
							case PersoManager.Char.Bernard: 
								parole="A safe. High quality too. Won’t be easy to open without a key.";
								break;
							case PersoManager.Char.Chips: 
								parole="Yo dude, that looks lock up tight! Wish I could blow it up…";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					case 1 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Thoses bobby pins I picked up could very well do the job ";
								break;
							case PersoManager.Char.Amelia: 
								parole="It’s a safe! Oh… it’s locked…";
								break;
							case PersoManager.Char.Bernard: 
								parole="A safe. High quality too. Won’t be easy to open without a key.";
								break;
							case PersoManager.Char.Chips: 
								parole="Yo dude, that looks lock up tight! Wish I could blow it up…";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					case 2 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="There’s a cute box inside! But it can’t be opened? How troublesome. ";
								break;
							case PersoManager.Char.Amelia: 
								parole="A wood cube? I don’t understand what it could be used for.";
								break;
							case PersoManager.Char.Bernard: 
								parole="It’s just a cube. Solid, but in wood. I could probably crush it with my bare hands.";
								break;
							case PersoManager.Char.Chips: 
								parole="Sick colorless rubik cube. No clue what it could be used for though.";
								break;
							default:
								parole=_cant;
								break;
						}
						break;

					case 3 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Oh, a scrap of paper! It’s… oh god, it’s some more gibberish. ";
								break;
							case PersoManager.Char.Amelia: 
								parole="There’s a piece of paper there...";
								break;
							case PersoManager.Char.Bernard: 
								parole="Look’s like there was some paper in there. Can’t read it though";
								break;
							case PersoManager.Char.Chips: 
								parole="I’m not touching that. Looks like a lizardfolk trap thing or… maybe it was an egg??";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					default :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Inspect;
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Inspect;
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Inspect;
								break;
							case PersoManager.Char.Chips: 
								parole=c3Inspect;
								break;
							default:
								parole=_cant;
								break;
						}
						break;
				}
				break;
			case QuestItems.Lumiere:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="I’ll just try not to step on that lightbulb.";
								break;
							case PersoManager.Char.Amelia: 
								parole="They should have made a safer light, if they expected us to walk on the ceiling.";
								break;
							case PersoManager.Char.Bernard: 
								parole="Walking on the ceiling… this whole experiment feels like a badly scripted dream. They better not be experimenting on my boy too.";
								break;
							case PersoManager.Char.Chips: 
								parole="Man I feel like in a James Bond movie!";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					default:
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Chips only shut down that light bulb? What a waste of time.";
								break;
							case PersoManager.Char.Amelia: 
								parole="Oh! The light is closed now!";
								break;
							case PersoManager.Char.Bernard: 
								parole="That was a big mess of wire to shut down a single lightbulb.";
								break;
							case PersoManager.Char.Chips: 
								parole="Man, it only shut down that puny… wait a minute. That’s an awfully big socket for a bulb as big as Bonnie’s dignity.";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
				}
				break;
			case QuestItems.Ordi:
				switch(_state){
					case 0 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Seems like a computer, but it’s not working.";
								break;
							case PersoManager.Char.Amelia: 
								parole="Look, an azerty keyboard! I remember using those back in France.";
								break;
							case PersoManager.Char.Bernard: 
								parole="A computer… can’t use them without my son’s help I’m afraid.";
								break;
							case PersoManager.Char.Chips: 
								parole="It’s so hi-tech and yet, they decided to use an Azerty keyboard. Only lizardfolks are that insane.";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					case 1 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Oh, it’s working now! Kinda. I can’t understand a single word displayed there.";
								break;
							case PersoManager.Char.Amelia: 
								parole="Oh, it’s in french! There’s an option to “dispense” and a password field…";
								break;
							case PersoManager.Char.Bernard: 
								parole="Oh, this is french. I sadly can’t read that, sorry.";
								break;
							case PersoManager.Char.Chips: 
								parole="Yo dude, I can’t read croissant.";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					case 2 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole="Oh, bobby pins? I definitely can use them as lockpicks.";
								break;
							case PersoManager.Char.Amelia: 
								parole="Why would it be so complicated to get bobby pins?";
								break;
							case PersoManager.Char.Bernard: 
								parole="My wife leaves these everywhere around the house. I can’t stand it.";
								break;
							case PersoManager.Char.Chips: 
								parole="Yoooo I see where this is going bro!";
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					
					case 3 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Inspect;
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Inspect;
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Inspect;
								break;
							case PersoManager.Char.Chips: 
								parole=c3Inspect;
								break;
							default:
								parole=_cant;
								break;
						}
						break;

					case 4 :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Inspect;
								break;
							case PersoManager.Char.Amelia: 
								parole="Maybe I can input that French word in the password field?";
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Inspect;
								break;
							case PersoManager.Char.Chips: 
								parole=c3Inspect;
								break;
							default:
								parole=_cant;
								break;
						}
						break;
					default :
						switch(PersoManager.getCurrentChar){
							case PersoManager.Char.Bonnie: 
								parole=c0Inspect;
								break;
							case PersoManager.Char.Amelia: 
								parole=c1Inspect;
								break;
							case PersoManager.Char.Bernard: 
								parole=c2Inspect;
								break;
							case PersoManager.Char.Chips: 
								parole=c3Inspect;
								break;
							default:
								parole=_cant;
								break;
						}
						break;
				}
				break;
			default: Debug.Log("Error");break;
		}
		Parler.Parleureur.Parle(PersoManager.getCurrentChar,parole);
	}
	private void OnMouseExit()
	{
		//Destroy(_instanceMenu,0f);
		CursorManager.instance.ToggleCursor();
		_isSelected=false;
		_isOvered=false;
		Destroy(_blinker,0f);
	}
	protected override void OnMouseEnter()
	{
		_blinker=Instantiate(Resources.Load("Blinker"),new Vector3(0,gameObject.GetComponent<BoxCollider2D>().bounds.size.y/2+0.5f,0),Quaternion.identity,transform);
		_isOvered=true;
		CursorManager.instance.ToggleCursor();
	}
}
