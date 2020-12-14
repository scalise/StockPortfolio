<template>
    <v-row>
        <v-col lg="12" md="12">
            <v-card>               
                <v-list>
                    <template v-for="(item, index) in items">

                        <v-list-item :key="item.title"
                                     @click="">

                            <v-list-item-content>
                                <v-list-item-title v-html="item.title"></v-list-item-title>
                            </v-list-item-content>

                            <v-list-item-action>
                                <v-list-item-title v-html="`<span>$</span>${item.amount}`"></v-list-item-title>
                            </v-list-item-action>

                        </v-list-item>
                    </template>
                </v-list>
            </v-card>
        </v-col>
</v-row>
</template>
<script>
    export default {
        name: 'PortfolioSummary',        
        data() {
            return {
                items: [                    
                    {
                        title: 'Total Cash',                        
                        amount: 6465.73
                    },                    
                    {
                        title: 'Total Positions',                        
                        amount: 123.45
                    }
                ]
            }
        }
    }
</script>