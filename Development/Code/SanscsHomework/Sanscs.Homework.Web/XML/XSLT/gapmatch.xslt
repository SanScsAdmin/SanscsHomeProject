<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="/">
    <div class="question">
    <div id="wrapper">
          <xsl:value-of select="assessmentItem/itemBody/choiceInteraction/prompt"/>
    <div id="dropables">
      <xsl:for-each select="assessmentItem/itemBody/gapMatchInteraction/gapText">
        <div class="draggable-objects"><xsl:value-of select="."/></div> 
      </xsl:for-each>
    <div class="clear"></div>
    </div>
      <div id="ccss_stage">
    <xsl:for-each select="assessmentItem/itemBody/gapMatchInteraction/blockquote/p/node()">
        <xsl:value-of select="."/>
        <xsl:if test="name()='gap'">
          <span class="dropable-container"></span>
          <input type="text"/>
        </xsl:if>
    </xsl:for-each>
      </div>
    <input type="button" onclick="getanswer(this)" value="提交答案">
            <xsl:attribute name="id">
              <xsl:value-of select="/assessmentItem/@questionId"/>
            </xsl:attribute>
          </input>
      </div>
    </div>
  </xsl:template>
</xsl:stylesheet>
