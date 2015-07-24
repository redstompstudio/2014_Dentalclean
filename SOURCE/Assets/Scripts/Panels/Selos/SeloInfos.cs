using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum LABEL_CATEGORY
{
	TEXTURA,
	ATRIBUTO,
	CABECA,
	VALORIZACAO,
	CLASSIFICACAO_ETARIA,
	OUTROS,
	USO_PRODUTOS,
	PUBLICO,
}

public class SeloInfos : MonoBehaviour 
{
	[HideInInspector]
	public LABEL_CATEGORY category;	
	[HideInInspector]
	public TIPO_CERDA textura;
	[HideInInspector]
	public ATRIBUTOS atributo;
	[HideInInspector]
	public CABECAS cabeca;
	[HideInInspector]
	public VALORIZACAO valorizacao;
	[HideInInspector]
	public CLASSIFICAO_ETARIA classificacaoEtaria;
	[HideInInspector]
	public OUTROS outros;
	[HideInInspector]
	public USO_PRODUTOS usoProdutos;
	[HideInInspector]
	public PUBLICO publico;

	private Button button;

	public Sprite labelIcon;
	public string labelTitle;
	public string labelDescription;

	public GameObject seloMaior;

	void Awake()
	{
		if(button == null)
			button = GetComponent<Button>();

		button.onClick.AddListener(OnClick);

		LabelsDataBase.Instance.RegisterLabel(this);
	}

	public void Enable()
	{
		gameObject.SetActive(true);
	}

	public void Disable()
	{
		gameObject.SetActive(false);
	}

	void OnClick()
	{
		//SelosPanel.instance.OnOpen(this);
		ItemDetailsPanel.instance.OnClickedOnSelo(this);
		seloMaior.SetActive(true);
	}
}
