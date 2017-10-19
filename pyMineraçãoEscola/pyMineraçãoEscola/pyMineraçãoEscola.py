import urllib.request
import json
import matplotlib.pyplot as plt
import re

with open('csFiltro.txt') as file_object:
    filtroAPI = file_object.read()
    filtroAPI = filtroAPI.rstrip()
    filtroAPI = filtroAPI.split("#")
   

estInfo = []
i = 0

while i<5:
    estInfo.append(re.search('[[A-Z]{2}|[Brasil]{6}', filtroAPI[i]).group(0))
    i += 1

print(estInfo)
    
url = 'http://educacao.dadosabertosbr.com/api/escolas/buscaavancada?situacaoFuncionamento=1'

try:

    dadosTotais = urllib.request.urlopen(url).read()
    dadosTotais = json.loads(dadosTotais.decode('utf-8'))

    dadosEstado0 = urllib.request.urlopen(url+filtroAPI[0]).read()
    dadosEstado0 = json.loads(dadosEstado0.decode('utf-8'))
    
    dadosEstado1 = urllib.request.urlopen(url+filtroAPI[1]).read()
    dadosEstado1 = json.loads(dadosEstado1.decode('utf-8'))

    dadosEstado2 = urllib.request.urlopen(url+filtroAPI[2]).read()
    dadosEstado2 = json.loads(dadosEstado2.decode('utf-8'))

    dadosEstado3 = urllib.request.urlopen(url+filtroAPI[3]).read()
    dadosEstado3 = json.loads(dadosEstado3.decode('utf-8'))

    dadosEstado4 = urllib.request.urlopen(url+filtroAPI[4]).read()
    dadosEstado4 = json.loads(dadosEstado4.decode('utf-8'))
    
    
    print(estInfo[0] +': \t' + str(dadosEstado0[0]))
    print(estInfo[1] +': \t' + str(dadosEstado1[0]))
    print(estInfo[2] +': \t' + str(dadosEstado2[0]))
    print(estInfo[3] +': \t' + str(dadosEstado3[0]))
    print(estInfo[4] +': \t' + str(dadosEstado4[0]))


except Exception as e:
    print(e)


labels = estInfo
sizes = [dadosEstado0[0], dadosEstado1[0], dadosEstado2[0], dadosEstado3[0], dadosEstado4[0]]


explode = (0.1, 0.5, 0.1, 0.1, 0.1) 

fig1, ax1 = plt.subplots()
ax1.pie(sizes, explode=explode, labels=labels, autopct='%1.1f%%', shadow=False, startangle=90)
ax1.axis('equal')  

plt.show()
